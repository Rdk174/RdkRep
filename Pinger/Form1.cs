using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using log4net;
using log4net.Config;
using System.Drawing.Printing;
using IPAddressControlLib;
using System.Net.NetworkInformation;

namespace Pinger
{
    public partial class frmMain : Form
    {
        private static readonly log4net.ILog log =
        LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public frmMain()
        {
            InitializeComponent();
        }
        public class AdressesList
        {
            public int index { get; set; }
            public string name { get; set; }
            public string adress { get; set; }
            public string ipAdress { get; set; }
        }
        public bool isDocChanged { get; set; }
        public string FilePath { get; set; }
        public Bitmap SetPicture(string IPAdress, int timer)
        {
            Bitmap pic;
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(IPAdress, timer);
            if (pingReply.Status==IPStatus.Success) pic = Properties.Resources.green;
            else pic = Properties.Resources.red;
            return pic;
        }
        public List<AdressesList> GridToArray()
        {
            var result = new List<AdressesList>();
            for (var i = 0; i < gridAdresses.Rows.Count; i++)
            {
                result.Add(new AdressesList()
                {
                    index= int.Parse(gridAdresses.Rows[i].Cells[0].Value.ToString()),
                    name = gridAdresses.Rows[i].Cells[1].Value.ToString(),
                    adress = gridAdresses.Rows[i].Cells[2].Value.ToString(),
                    ipAdress = gridAdresses.Rows[i].Cells[3].Value.ToString()
                });
            }
            return result;
        }
        public void SaveDoc()
        {
            if (FilePath =="")
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    FilePath = saveFileDialog.FileName;
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        File.Delete(saveFileDialog.FileName);
                    }
                    var result = GridToArray();
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    using (JsonWriter jw = new JsonTextWriter(sw))
                    {
                        JsonSerializer js = new JsonSerializer();
                        js.Formatting = Formatting.Indented;
                        js.Serialize(jw, result);
                        timerRLabel.Enabled = true;
                        toolStripStatusLabel.Text = "Сохранение прошло успешно";
                    }
                }
            }
            else
            {
                if (File.Exists(FilePath))
                {
                    File.Delete(FilePath);
                }
                var result = GridToArray();
                using (StreamWriter sw = new StreamWriter(FilePath))
                using (JsonWriter jw = new JsonTextWriter(sw))
                {
                    JsonSerializer js = new JsonSerializer();
                    js.Formatting = Formatting.Indented;
                    js.Serialize(jw, result);
                    timerRLabel.Enabled = true;
                    toolStripStatusLabel.Text="Сохранение прошло успешно";
                }
            }
        }
        public void LoadDoc()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                FilePath = openFileDialog.FileName;
                gridAdresses.Rows.Clear();
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                using (JsonReader jr = new JsonTextReader(sr))
                {
                    JsonSerializer js = new JsonSerializer();
                    js.Formatting = Formatting.Indented;
                    var data = js.Deserialize<List<AdressesList>>(jr);
                    foreach (var item in data)
                    {
                        var picture = SetPicture(item.ipAdress, 10);
                        gridAdresses.Rows.Add(item.index,item.name ,item.adress, item.ipAdress, picture);
                    }
                }
            }
        }
       
        private void txtSearch_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            txtSearch.Font = new Font(txtSearch.Font, FontStyle.Regular);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i;
            if (gridAdresses.Rows.Count == 0)
            {
                i = 0;
            }
            else
            {
                i = int.Parse(gridAdresses.Rows[gridAdresses.Rows.Count - 1].Cells[0].Value.ToString());
            }
            if (ipAddressControl1.Text == "..." || ipAddressControl1.Text == "0.0.0.0")
            {
                MessageBox.Show("Введите IP адрес","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                var picture = SetPicture(ipAddressControl1.Text, 10);
                gridAdresses.Rows.Add(i+1, 
                    txtName.Text,
                    txtAdress.Text, 
                    ipAddressControl1.Text, 
                    picture);
                isDocChanged = true;
                txtName.Text = "";
                txtAdress.Text = "";
                ipAddressControl1.Text = "0.0.0.0";
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Идет обновление данных, пожалуйста подождите";
            Refresh();
            toolStripProgressBar.Visible = true;
            if (gridAdresses.Rows.Count != 0)
            {
                toolStripProgressBar.Step = toolStripProgressBar.Maximum/gridAdresses.Rows.Count;
                foreach (DataGridViewRow item in gridAdresses.Rows)
                {
                    var picture = SetPicture(gridAdresses.Rows[item.Index].Cells[3].Value.ToString(), 3000);
                    gridAdresses.Rows[item.Index].Cells[4].Value = picture;
                    toolStripProgressBar.PerformStep();
                }
                toolStripStatusLabel.Text = "Готово";
                toolStripProgressBar.Visible = false;
                toolStripProgressBar.Value = 0;
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                SaveDoc();
            }
            catch (Exception error)
            {
                MessageBox.Show("Не удалось сохранить файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error(error);
                Dispose();
            }
        }

        private void открытьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                LoadDoc();
            }
            catch (Exception error)
            {
                MessageBox.Show("Не удалось открыть файл", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error(error);
                Dispose();
            }
        }

        private void новыйСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Создать новый файл?", "Новый", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (gridAdresses.Rows.Count != 0 && isDocChanged)
                {
                    if (MessageBox.Show("Сохранить файл перед закрытием?", "Сохранить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SaveDoc();
                        gridAdresses.Rows.Clear();
                    }
                    else
                    {
                        gridAdresses.Rows.Clear();
                    }
                }
                else
                {
                    gridAdresses.Rows.Clear();
                }
            }
        }
        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            isDocChanged = false;
            FilePath = ""; 
        }

        private void timerRLabel_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Готово";
            timerRLabel.Enabled=false;
        }
    }
}
