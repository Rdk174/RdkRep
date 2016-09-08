using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using log4net;
using System.Net.NetworkInformation;
using System.Net;
using System.Diagnostics;
using System.Linq;
using System.Data;
using System.Text;
using HtmlAgilityPack;
using System.Text.RegularExpressions;
using Microsoft.Office.Interop.Excel;
using System.Threading;

using Excell = Microsoft.Office.Interop.Excel.Application;
using System.Runtime.InteropServices;

namespace Pinger
{
    public partial class frmMain : Form
    {
        private static readonly log4net.ILog log =
        LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        const uint WM_SETTEXT = 0x000C;
        private Excell application;
        private Workbook workBook;
        private Worksheet worksheet;
        public Thread refreshThread;
        public Thread loadThread;
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
                    OOO = gridAddresses.Rows[i].Cells[2].Value.ToString(),
                    Address = gridAddresses.Rows[i].Cells[3].Value.ToString(),
                    IP = gridAddresses.Rows[i].Cells[4].Value.ToString(),
                    UTMVer = gridAddresses.Rows[i].Cells[6].Value.ToString(),
                    PKI = gridAddresses.Rows[i].Cells[7].Value.ToString(),
                    Gost = gridAddresses.Rows[i].Cells[8].Value.ToString()
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

        public void LoadDoc(object filePath)
        {
            //Properties.Settings.Default.filePath = openFileDialog.FileName;
            Invoke(new System.Action(() =>
            {
                gridAddresses.Rows.Clear();
                timerRefresh.Enabled = true;
                toolStripStatusLabel.Text = "Идет загрузка файла, пожалуйста подождите";
                toolStripProgressBar.Visible = true;
            }));
            using (StreamReader sr = new StreamReader(filePath.ToString()))
            {
                    using (JsonReader jr = new JsonTextReader(sr))
                    {
                        JsonSerializer js = new JsonSerializer();
                        js.Formatting = Formatting.Indented;
                        var data = js.Deserialize<List<Addresses>>(jr);
                        Invoke(new System.Action(() =>
                        {
                            toolStripProgressBar.Maximum = data.Count;
                            toolStripProgressBar.Step = toolStripProgressBar.Maximum / data.Count;
                        }));
                        foreach (var item in data)
                        {
                        var picture = SetPicture(item.IP, 10);
                        Invoke(new System.Action(() =>
                        {
                            gridAddresses.Rows.Add(item.Id, item.Name, item.OOO, item.Address, item.IP, picture, item.UTMVer, item.PKI, item.Gost);
                            //gridAddresses.Rows.Add(item.Id, item.Name, item.OOO, item.Address, item.IP, picture, " ", " ", " ");
                            toolStripProgressBar.PerformStep();
                            statusStrip1.Refresh();
                        }));
                        }
                        Invoke(new System.Action(() =>
                        {
                            timerRLabel.Enabled = true;
                            toolStripProgressBar.Visible = false;
                            toolStripStatusLabel.Text = "Файл загружен";
                        }));
                    }
                Recolor();
              }
        }
        public int Search(string str)
        {
            System.Data.DataTable dt = new System.Data.DataTable();
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
        public void Recolor()
        {
            foreach (DataGridViewRow item in gridAddresses.Rows)
            {
                if (item.Index % 2 != 0)
                {
                    gridAddresses.Rows[item.Index].DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    gridAddresses.Rows[item.Index].DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
        public string getRequest(string url)
        {
            try
            {
                var httpWebRequest = (HttpWebRequest)WebRequest.Create(url);
                httpWebRequest.AllowAutoRedirect = false;//Запрещаем автоматический редирект
                httpWebRequest.Method = "GET"; //Можно не указывать, по умолчанию используется GET.
                httpWebRequest.Referer = "http://google.com"; // Реферер. Тут можно указать любой URL
                using (var httpWebResponse = (HttpWebResponse)httpWebRequest.GetResponse())
                {
                    using (var stream = httpWebResponse.GetResponseStream())
                    {
                        using (var reader = new StreamReader(stream, Encoding.GetEncoding(httpWebResponse.CharacterSet)))
                        {
                            return reader.ReadToEnd();
                        }
                    }
                }
            }
            catch
            {
                return String.Empty;
            }
        }
        public string[] Parser(string url)
        {
            HtmlAgilityPack.HtmlDocument doc = new HtmlAgilityPack.HtmlDocument();
            doc.LoadHtml(getRequest(url));
            string[] result = new string[3];
            try
            {
                HtmlNodeCollection c = doc.DocumentNode.SelectNodes("//div[@class='tab-pane fade in active']/pre");
                var st = c[0].InnerText.Normalize();
                string version_template = "[0-9]+.[0-9]+.[0-9]+";
                string date_template = "[0-9]+-[0-9]+-[0-9]+";
                var re = new Regex(@version_template);
                MatchCollection mc = re.Matches(st);
                result[0] = mc[0].ToString();
                st = c[c.Count - 2].InnerText.Normalize();
                re = new Regex(@date_template);
                mc = re.Matches(st);
                result[1] = mc[1].ToString();
                st = c[c.Count - 1].InnerText.Normalize();
                re = new Regex(@date_template);
                mc = re.Matches(st);
                result[2] = mc[1].ToString();
                return result;
            }
            catch(Exception err)
            {
                //MessageBox.Show("Не удалось получить данные", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                log.Error(err);
                result[0] = result[1] = result[2] = "";
                return result;
            }
        }
        private void txtSearch_Click(object sender, EventArgs e)
        {


        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i;
            bool valid=true;
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
                foreach (DataGridViewRow item in gridAddresses.Rows)
                {
                    if (ipAddressControl1.Text == gridAddresses.Rows[item.Index].Cells[4].Value.ToString())
                    {
                        MessageBox.Show("Ресурс с таким IP адрессом уже существует", "Внимание", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        valid = false;
                    }
                }
                if(valid)
                {
                    var picture = SetPicture(ipAddressControl1.Text, 10);
                    gridAddresses.Rows.Add(i + 1,
                        txtName.Text,
                        txtOOO.Text,
                        txtAdress.Text,
                        ipAddressControl1.Text,
                        picture," ", " "," ");
                    isDocChanged = true;
                    txtName.Text = "";
                    txtOOO.Text = "";
                    txtAdress.Text = "";
                    timerRefresh.Enabled = true;
                    ipAddressControl1.Text = "0.0.0.0";
                    Recolor();
                }
            }
        }
        public void RefreshTable()
        {
            if (gridAddresses.Rows.Count != 0)
            {
                Invoke(new System.Action(() =>
                {
                    toolStripStatusLabel.Text = "Идет обновление данных, пожалуйста подождите";
                    Refresh();
                    toolStripProgressBar.Visible = true;
                    toolStripProgressBar.Value = 0;
                    toolStripProgressBar.Step = toolStripProgressBar.Maximum / gridAddresses.Rows.Count;
                }));
                foreach (DataGridViewRow item in gridAddresses.Rows)
                {
                    Invoke(new System.Action(() =>
                    {
                        toolStripProgressBar.PerformStep();
                        statusStrip1.Refresh();
                    }));
                    var picture = SetPicture(gridAddresses.Rows[item.Index].Cells[4].Value.ToString(), 3000);
                    Invoke(new System.Action(() =>
                    {
                        gridAddresses.Rows[item.Index].Cells[5].Value = picture;
                    }));
                }
                Invoke(new System.Action(() =>
                {
                    toolStripStatusLabel.Text = "Готово";
                    toolStripProgressBar.Visible = false;
                    toolStripProgressBar.Value = 0;
                }));
            }
        }
        private void timerRefresh_Tick(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AllowAutoUpdate)
            {
                refreshThread = new Thread(new ThreadStart(RefreshTable));
                refreshThread.Start();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    SaveDoc(saveFileDialog.FileName);
                    isDocChanged = false;
                }
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
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    loadThread = new Thread(new ParameterizedThreadStart(LoadDoc));
                    loadThread.Start(openFileDialog.FileName);
                }
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
            System.Windows.Forms.Application.Exit();
        }
        private void CloseExcel()
        {
            if (application != null)
            {
                int excelProcessId = -1;
                WinAPI.GetWindowThreadProcessId(application.Hwnd, ref excelProcessId);

                //Marshal.ReleaseComObject(worksheet);
                //workBook.Close();
                //Marshal.ReleaseComObject(workBook);
                //application.Quit();
                //Marshal.ReleaseComObject(application);

                application = null;
                // Прибиваем висящий процесс
                try
                {
                    Process process = Process.GetProcessById(excelProcessId);
                    process.Kill();
                }
                finally { }
            }
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
            CloseExcel();
            Environment.Exit(0);
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            isDocChanged = false;
            timerRefresh.Interval = Properties.Settings.Default.TimerAutoUpdate;
            if (File.Exists(Environment.CurrentDirectory + "\\Планшеты мавт.json"))
            {
                loadThread = new Thread(new ParameterizedThreadStart(LoadDoc));
                loadThread.Start(Environment.CurrentDirectory + "\\Планшеты мавт.json");
                Recolor();
            }
            ultraVNCToolStripMenuItem.Visible = Properties.Settings.Default.AllowUltraVNC;
            ultraVNCToolStripMenuItem.Enabled = Properties.Settings.Default.AllowUltraVNC;
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
        public void OneUTM(object IP)
        {
            var url = "http://" + IP.ToString() + ":" + Properties.Settings.Default.UTMPort + "/";
            var result = Parser(url);
            Invoke(new System.Action(() =>
            {
                gridAddresses[6, gridAddresses.CurrentRow.Index].Value = result[0];
                gridAddresses[7, gridAddresses.CurrentRow.Index].Value = result[1];
                gridAddresses[8, gridAddresses.CurrentRow.Index].Value = result[2];
            }));
        }

        private void uTMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridAddresses[6, gridAddresses.CurrentRow.Index].Value.ToString() != " ")
            {
                Thread oneutmThread = new Thread(new ParameterizedThreadStart(OneUTM));
                oneutmThread.Start(gridAddresses[4, gridAddresses.CurrentRow.Index].Value.ToString());
            }
            if (Properties.Settings.Default.AllowPagesiteUTM)
            {
                timerRefresh.Enabled = false;
                frmUTM f = new frmUTM();
                f.Owner = this;
                f.ShowDialog();
            }
            else
            {
                string IP = gridAddresses.Rows[gridAddresses.CurrentRow.Index].Cells[4].Value.ToString();
                WebRequest request = WebRequest.Create("http://" + IP+":" + Properties.Settings.Default.UTMPort+"/");
                try
                {
                    HttpWebResponse response = (HttpWebResponse)request.GetResponse();
                    if (response == null || response.StatusCode != HttpStatusCode.OK)
                    {
                        MessageBox.Show("УТМ по адресу: " + IP+": " + Properties.Settings.Default.UTMPort+" не запущен", "УТМ " + IP, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else
                    {
                        MessageBox.Show("УТМ по адресу: " + IP + ": " + Properties.Settings.Default.UTMPort + " запущен", "УТМ " + IP, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    response.Close();
                }
                catch (Exception error)
                {
                    MessageBox.Show("Не удалось соедениться с указанным узлом", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error(error);
                }
            }
        }
        private void ultraVNCToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Properties.Settings.Default.AllowUltraVNC)
            {
                timerRefresh.Enabled = false;
                string path = Properties.Settings.Default.PathUltraVNC;
                var ip = gridAddresses.Rows[gridAddresses.CurrentRow.Index].Cells[4].Value.ToString();
                try
                {
                    Process.Start(path, ip);
                }
                catch (Exception err)
                {
                    MessageBox.Show("Не удалось запусть UltraVNC, проверьте правильность пути: " + path + " и повторите попытку",
                        "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    log.Error(err);
                }

            }
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
            txtSearch.Font = new System.Drawing.Font(txtSearch.Font, FontStyle.Regular);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            gridAddresses.ClearSelection();
            gridAddresses.Rows[Search(txtSearch.Text)].Selected = true;
            txtSearch.Text = "Введите наименование или адрес";
            txtSearch.Font = new System.Drawing.Font(txtSearch.Font, FontStyle.Italic);

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
            {
                gridAddresses.CurrentCell = gridAddresses[0, e.RowIndex];
                gridAddresses.Rows[e.RowIndex].Selected = true;
            }
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
                Recolor();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) button1.PerformClick();
        }

        private void settingsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
            frmSettings f = new frmSettings();
            f.Owner = this;
            f.ShowDialog();
        }

        private void gridAddresses_UserAddedRow(object sender, DataGridViewRowEventArgs e)
        {
          
        }

        private void gridAddresses_UserDeletedRow(object sender, DataGridViewRowEventArgs e)
        {
      
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            Form2 f = new Form2();
            f.Owner = this;
            f.ShowDialog();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            var url="http://10.8.0.110:8080/";
            var result = Parser(url);
            MessageBox.Show("Версия: " +result[0] + Environment.NewLine + 
                "PKI: "+ result[1] + Environment.NewLine + 
                "ГОСТ: "+result[2]);
        }
        public void LoadUTM()
        {
            if (gridAddresses.Rows.Count != 0)
            {
                isDocChanged = true;
                Invoke(new System.Action(() =>
                {
                    timerRefresh.Enabled = false;
                    toolStripStatusLabel.Text = "Идет получение сведений об UTM, пожалуйста подождите";
                    toolStripProgressBar.Value = 0;
                    toolStripProgressBar.Visible = true;
                    toolStripProgressBar.Step = toolStripProgressBar.Maximum / gridAddresses.Rows.Count;
                }));
                foreach (DataGridViewRow item in gridAddresses.Rows)
                {
                    Invoke(new System.Action(() =>
                    {
                        toolStripProgressBar.PerformStep();
                    }));
                    var url = "http://" + gridAddresses[4, item.Index].Value.ToString() + ":" + Properties.Settings.Default.UTMPort + "/";
                    var result = Parser(url);
                    Invoke(new System.Action(() =>
                    {
                        gridAddresses[6, item.Index].Value = result[0];
                        gridAddresses[7, item.Index].Value = result[1];
                        gridAddresses[8, item.Index].Value = result[2];
                    }));
                }
                Invoke(new System.Action(() =>
                {
                    timerRefresh.Enabled = true;
                    toolStripStatusLabel.Text = "Готово";
                    toolStripProgressBar.Visible = false;
                    toolStripProgressBar.Value = 0;
                }));
            }
        }
        private void получитьСведенияОбUTMToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Thread loadUtmThread = new Thread(new ThreadStart(LoadUTM));
            loadUtmThread.Start();
        }

        private void обновитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            refreshThread = new Thread(new ThreadStart(RefreshTable));
            refreshThread.Start();
        }

        private void toExcellToolStripMenuItem_Click(object sender, EventArgs e)
        {
            

            application = new Excell
            {
                DisplayAlerts = false
            };
           application.Visible = false;

            // Файл шаблона
            const string template = "template.xltm";

            // Открываем книгу
            workBook = application.Workbooks.Open(Path.Combine(Environment.CurrentDirectory, template));

            // Получаем активную таблицу
            worksheet = workBook.ActiveSheet as Worksheet;

            // Записываем данные
            int rowExcel = 2;

            for (int i = 0; i < gridAddresses.Rows.Count; i++)
            {
                worksheet.Cells[rowExcel, "A"] = gridAddresses.Rows[i].Cells[0].Value;
                worksheet.Cells[rowExcel, "B"] = gridAddresses.Rows[i].Cells[1].Value;
                worksheet.Cells[rowExcel, "C"] = gridAddresses.Rows[i].Cells[2].Value;
                worksheet.Cells[rowExcel, "D"] = gridAddresses.Rows[i].Cells[3].Value;
                worksheet.Cells[rowExcel, "E"] = gridAddresses.Rows[i].Cells[6].Value;
                worksheet.Cells[rowExcel, "F"] = gridAddresses.Rows[i].Cells[8].Value;
                ++rowExcel;
            }
            application.Run("Format");
            var range= worksheet.get_Range("A1", "F"+rowExcel);
            range.EntireColumn.AutoFit();
            range.EntireRow.AutoFit();
            // Показываем приложение
            application.Visible = true;
            application.UserControl = true;
            TopMost = false;
        }

        private void toolStripMenuItemPing_Click_1(object sender, EventArgs e)
        {
            timerRefresh.Enabled = false;
            frmPing f = new frmPing();
            f.Owner = this;
            f.ShowDialog();
        }

        private void frmMain_Deactivate(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.ShowInTaskbar = false;
                notifyIcon1.Visible = true;
            }
        }

        private void notifyIcon1_MouseDoubleClick(object sender, MouseEventArgs e)
        {

        }

        private void notifyIcon1_Click(object sender, EventArgs e)
        {
            if (this.WindowState == FormWindowState.Minimized)
            {
                this.WindowState = FormWindowState.Normal;
                this.ShowInTaskbar = true;
                notifyIcon1.Visible = false;
            }
        }
    }
}
