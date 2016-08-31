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
using System.Net;
using System.Management;
using Microsoft.Win32;
using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Linq;

namespace Pinger
{
    public partial class frmMain : Form
    {
        private static readonly log4net.ILog log =
        LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        const uint WM_SETTEXT = 0x000C;
        public frmMain()
        {
            InitializeComponent();
        }
        public bool isDocChanged { get; set; }
        public Bitmap SetPicture(string IPAdress, int timer)
        {
            Bitmap pic;
            Ping ping = new Ping();
            PingReply pingReply = ping.Send(IPAdress, timer);
            return pingReply.Status == IPStatus.Success
                ? Properties.Resources.green
                : Properties.Resources.red;
        }
        List<Addresses> GridToArray()
        {
            var result = new List<Addresses>();
            for (var i = 0; i < gridAddresses.Rows.Count; i++)
            {
                result.Add(new Addresses()
                {
                    Id= int.Parse(gridAddresses.Rows[i].Cells[0].Value.ToString()),
                    Name = gridAddresses.Rows[i].Cells[1].Value.ToString(),
                    Address = gridAddresses.Rows[i].Cells[2].Value.ToString(),
                    IP = gridAddresses.Rows[i].Cells[3].Value.ToString()
                });
            }
            return result;
        }
        public void SaveDoc()
        {
            if (Properties.Settings.Default.filePath =="")
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    Properties.Settings.Default.filePath = saveFileDialog.FileName;
                    if (File.Exists(saveFileDialog.FileName))
                    {
                        File.Delete(saveFileDialog.FileName);
                    }
                    var result = GridToArray();
                    using (StreamWriter sw = new StreamWriter(saveFileDialog.FileName))
                    {
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
            }
            else
            {
                if (File.Exists(Properties.Settings.Default.filePath))
                {
                    File.Delete(Properties.Settings.Default.filePath);
                }
                var result = GridToArray();
                using (StreamWriter sw = new StreamWriter(Properties.Settings.Default.filePath))
                {
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
        }
        public void LoadDoc()
        {
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                Properties.Settings.Default.filePath = openFileDialog.FileName;
                gridAddresses.Rows.Clear();
                timerRefresh.Enabled = true;
                using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                {
                    using (JsonReader jr = new JsonTextReader(sr))
                    {
                        JsonSerializer js = new JsonSerializer();
                        js.Formatting = Formatting.Indented;
                        var data = js.Deserialize<List<Addresses>>(jr);
                        foreach (var item in data)
                        {
                            var picture = SetPicture(item.IP, 10);
                            gridAddresses.Rows.Add(item.Id, item.Name, item.Address, item.IP, picture);
                        }
                        timerRLabel.Enabled = true;
                        toolStripStatusLabel.Text = "Документ загружен";
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
            if (gridAddresses.Rows.Count == 0)
            {
                i = 0;
            }
            else
            {
                i = int.Parse(gridAddresses.Rows[gridAddresses.Rows.Count - 1].Cells[0].Value.ToString());
            }
            if (ipAddressControl1.Text == "..." || ipAddressControl1.Text == "0.0.0.0")
            {
                MessageBox.Show("Введите IP адрес","Внимание",MessageBoxButtons.OK,MessageBoxIcon.Information);
            }
            else
            {
                var picture = SetPicture(ipAddressControl1.Text, 10);
                gridAddresses.Rows.Add(i+1, 
                    txtName.Text,
                    txtAdress.Text, 
                    ipAddressControl1.Text, 
                    picture);
                isDocChanged = true;
                txtName.Text = "";
                txtAdress.Text = "";
                timerRefresh.Enabled = true;
                ipAddressControl1.Text = "0.0.0.0";
            }
        }

        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Идет обновление данных, пожалуйста подождите";
            Refresh();
            toolStripProgressBar.Visible = true;
            if (gridAddresses.Rows.Count != 0)
            {
                toolStripProgressBar.Step = toolStripProgressBar.Maximum/gridAddresses.Rows.Count;
                foreach (DataGridViewRow item in gridAddresses.Rows)
                {
                    var picture = SetPicture(gridAddresses.Rows[item.Index].Cells[3].Value.ToString(), 3000);
                    gridAddresses.Rows[item.Index].Cells[4].Value = picture;
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
            }
        }

        private void новыйСписокToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Создать новый список?", "Новый", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (gridAddresses.Rows.Count != 0 && isDocChanged)
                {
                    if (MessageBox.Show("Сохранить список перед закрытием?", "Сохранить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        SaveDoc();
                        gridAddresses.Rows.Clear();
                    }
                    else
                    {
                        gridAddresses.Rows.Clear();
                    }
                }
                else
                {
                    gridAddresses.Rows.Clear();
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
            Properties.Settings.Default.filePath = "";
        }

        private void timerRLabel_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Готово";
            timerRLabel.Enabled=false;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            txtSearch.Text = "Введите наименование ресурса или его IP адресс";
            txtSearch.Font = new Font(txtSearch.Font, FontStyle.Italic);
        }

        private void contextMenuStrip1_Opening(object sender, System.ComponentModel.CancelEventArgs e)
        {

        }

        private void toolStripMenuItemPing_Click(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
            frmPing f = new frmPing();
            f.Owner = this;
            f.ShowDialog();
        }

        private void uTMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
            frmUTM f = new frmUTM();
            f.Owner = this;
            f.ShowDialog();
            //string IP = gridAdresses.Rows[gridAdresses.CurrentRow.Index].Cells[3].Value.ToString();
            //WebRequest request = WebRequest.Create("http://" + IP+ ":8080/");
            //try
            //{
            //    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
            //    if (response == null || response.StatusCode != HttpStatusCode.OK)
            //    {
            //        MessageBox.Show("УТМ по адресу: " + IP + " не запущен", "УТМ " + IP, MessageBoxButtons.OK, MessageBoxIcon.Information);
            //    }
            //    else
            //    {
            //        MessageBox.Show("УТМ по адресу: "+IP+" запущен","УТМ "+IP,MessageBoxButtons.OK,MessageBoxIcon.Information);
            //    }
            //    response.Close();
            //}
            //catch (Exception error)
            //{
            //    MessageBox.Show("Не удалось соедениться с указанным узлом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //    log.Error(error);
            //}
        }
        private void ultraVNCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var ip = gridAddresses.Rows[gridAddresses.CurrentRow.Index].Cells[3].Value.ToString();
            Process.Start("C:\\Program Files\\uvnc bvba\\UltraVNC\\vncviewer.exe",ip);
            //var mainHandle = WinAPI.FindWindow(null, "UltraVNC Viewer - 1.2.1.1");
            //var comboboxHandle = WinAPI.FindWindowEx((IntPtr)mainHandle, (IntPtr)0, "ComboBox",null);
            //var editHandle = WinAPI.FindWindowEx((IntPtr)comboboxHandle, (IntPtr)0, "Edit",null);
            //var ip = gridAdresses.Rows[gridAdresses.CurrentRow.Index].Cells[3].Value.ToString();
            //WinAPI.SendMessage(editHandle, WM_SETTEXT, 1, ip);
        }
    }
}
