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
using System.Data;

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
                    Id = int.Parse(gridAddresses.Rows[i].Cells[0].Value.ToString()),
                    Name = gridAddresses.Rows[i].Cells[1].Value.ToString(),
                    Address = gridAddresses.Rows[i].Cells[2].Value.ToString(),
                    IP = gridAddresses.Rows[i].Cells[3].Value.ToString()
                });
            }
            return result;
        }
        public void SaveDoc(string filePath)
        {
            //Properties.Settings.Default.filePath = saveFileDialog.FileName;
            if (File.Exists(filePath)) File.Delete(filePath);
            var result = GridToArray();
            using (StreamWriter sw = new StreamWriter(filePath))
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

        public void LoadDoc(string filePath)
        {
            //Properties.Settings.Default.filePath = openFileDialog.FileName;
            gridAddresses.Rows.Clear();
            timerRefresh.Enabled = true;
            using (StreamReader sr = new StreamReader(filePath))
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
        public int Search(string str)
        {
            DataTable dt = new DataTable();
            BindingSource bns = new BindingSource();
            foreach (DataGridViewColumn col in gridAddresses.Columns)
            {
                dt.Columns.Add(col.Name);
            }

            foreach (DataGridViewRow row in gridAddresses.Rows)
            {
                DataRow dRow = dt.NewRow();
                foreach (DataGridViewCell cell in row.Cells)
                {
                    dRow[cell.ColumnIndex] = cell.Value;
                }
                dt.Rows.Add(dRow);
            }
            bns.DataSource = dt;
            //dt.DefaultView.RowFilter = "like '%" + str.Trim() + "%' ";
            int position = 0;
            foreach (DataGridViewColumn col in gridAddresses.Columns)
            {
                if (bns.Find(col.Name, str) > 0)
                {
                    position = bns.Find(col.Name, str);
                }
            }
            return position;
        }
       
        private void txtSearch_Click(object sender, EventArgs e)
        {


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
                toolStripProgressBar.Step = toolStripProgressBar.Maximum / gridAddresses.Rows.Count;
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
                if (saveFileDialog.ShowDialog() == DialogResult.OK) SaveDoc(saveFileDialog.FileName);
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
                if (openFileDialog.ShowDialog()==DialogResult.OK) LoadDoc(openFileDialog.FileName);
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
                        if (saveFileDialog.ShowDialog() == DialogResult.OK) SaveDoc(saveFileDialog.FileName);
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
            if (gridAddresses.Rows.Count != 0 && isDocChanged)
            {
                if (MessageBox.Show("Сохранить список перед закрытием?", "Сохранить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (saveFileDialog.ShowDialog() == DialogResult.OK) SaveDoc(saveFileDialog.FileName);
                    gridAddresses.Rows.Clear();
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            isDocChanged = false;
            LoadDoc(Environment.CurrentDirectory+"\\Планшеты мавт.json");
        }

        private void timerRLabel_Tick(object sender, EventArgs e)
        {
            toolStripStatusLabel.Text = "Готово";
            timerRLabel.Enabled=false;
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            timerRefresh.Start();
            //txtSearch.Text = "Введите наименование, адрес или IP адрес";
            //txtSearch.Font = new Font(txtSearch.Font, FontStyle.Italic);
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
            timerRefresh.Enabled = false;
            var ip = gridAddresses.Rows[gridAddresses.CurrentRow.Index].Cells[3].Value.ToString();
            Process.Start("C:\\Program Files\\uvnc bvba\\UltraVNC\\vncviewer.exe",ip);
            //var mainHandle = WinAPI.FindWindow(null, "UltraVNC Viewer - 1.2.1.1");
            //var comboboxHandle = WinAPI.FindWindowEx((IntPtr)mainHandle, (IntPtr)0, "ComboBox",null);
            //var editHandle = WinAPI.FindWindowEx((IntPtr)comboboxHandle, (IntPtr)0, "Edit",null);
            //var ip = gridAdresses.Rows[gridAdresses.CurrentRow.Index].Cells[3].Value.ToString();
            //WinAPI.SendMessage(editHandle, WM_SETTEXT, 1, ip);
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            
        }

        private void txtSearch_Enter(object sender, EventArgs e)
        {
            timerRefresh.Stop();
            txtSearch.Text = "";
            txtSearch.Font = new Font(txtSearch.Font, FontStyle.Regular);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gridAddresses.ClearSelection();
            gridAddresses.Rows[Search(txtSearch.Text)].Selected = true;
            txtSearch.Text = "Введите наименование или адрес";
            txtSearch.Font = new Font(txtSearch.Font, FontStyle.Italic);

        }

        private void txtName_Enter(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
        }

        private void txtName_Leave(object sender, EventArgs e)
        {
            timerRefresh.Enabled = true;
        }

        private void ipAddressControl1_Enter(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
        }

        private void ipAddressControl1_Leave(object sender, EventArgs e)
        {
            timerRefresh.Enabled = true;
        }

        private void txtAdress_Enter(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
        }

        private void txtAdress_Leave(object sender, EventArgs e)
        {
            timerRefresh.Enabled = true;
        }

        private void gridAddresses_CellClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void gridAddresses_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
                gridAddresses.Rows[e.RowIndex].Selected = true;
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Удалить строку?", "Удалить", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                gridAddresses.Rows.RemoveAt(gridAddresses.CurrentRow.Index);
                isDocChanged = true;
                foreach (DataGridViewRow row in gridAddresses.Rows)
                {
                    gridAddresses.Rows[row.Index].Cells[0].Value = row.Index + 1;
                }
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) button1.PerformClick();
        }
    }
}
