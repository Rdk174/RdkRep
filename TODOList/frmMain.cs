using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.IO;
using Newtonsoft.Json;
using log4net;
using log4net.Config;
using System.Drawing.Printing;
namespace TODOList

{
    public partial class frmMain : Form
    {
        private static readonly log4net.ILog log =
        LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public frmMain()
        {
            InitializeComponent();
        }

        public class DataSheet
        {
            public int id { get; set; }
            public string task { get; set; }
            public DateTime deadline { get; set; }
            public bool isFinished { get; set; }
        }
        public List<DataSheet> GridToArray()
        {
            var result = new List<DataSheet>();
            for (var i = 0; i < gridTaskList.Rows.Count; i++)
            {
                result.Add(new DataSheet() { id = int.Parse(gridTaskList.Rows[i].Cells[0].Value.ToString()),
                task = gridTaskList.Rows[i].Cells[1].Value.ToString(),
                deadline = DateTime.Parse(gridTaskList.Rows[i].Cells[2].Value.ToString()),
                isFinished = bool.Parse(gridTaskList.Rows[i].Cells[3].Value.ToString()) });
            }
            return result;
        }

        public void SaveJson()
        {
            try
            {
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
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
                        MessageBox.Show("Сохранено", "Успех", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception e)
            {
                log.Error(e);
            }
        }
        public void LoadJson()
        {
            
            try
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    gridTaskList.Rows.Clear();
                    using (StreamReader sr = new StreamReader(openFileDialog.FileName))
                    using (JsonReader jr = new JsonTextReader(sr))
                    {
                        JsonSerializer js = new JsonSerializer();
                        js.Formatting = Formatting.Indented;
                        var data = js.Deserialize<List<DataSheet>>(jr);
                        foreach (var item in data)
                        {
                            gridTaskList.Rows.Add(item.id, item.task, item.deadline.ToShortDateString(), item.isFinished);
                        }
                        Recolor();
                    }
                }
            }
            catch (Exception e)
            {
                MessageBox.Show("Ошибка","Ошибка", MessageBoxButtons.OK,MessageBoxIcon.Error);
                log.Error(e);
            }

        }

        public void Recolor()
        {
            gridTaskList.Font = Properties.Settings.Default.myFont;
            for (var index = 0; index < gridTaskList.Rows.Count; index++)
            {
                if (DateTime.Parse(gridTaskList.Rows[index].Cells[2].EditedFormattedValue.ToString()) < DateTime.Today.Date &&
                     gridTaskList.Rows[index].Cells[3].EditedFormattedValue.ToString() == "False")
                {
                    gridTaskList.Rows[index].DefaultCellStyle.BackColor = Properties.Settings.Default.ExpiredTask;
                }
                else if (index % 2 != 0 &&
                    gridTaskList.Rows[index].Cells[3].EditedFormattedValue.ToString() == "False")
                {
                    gridTaskList.Rows[index].DefaultCellStyle.BackColor = Properties.Settings.Default.RowColor2;
                }
                else if (gridTaskList.Rows[index].Cells[3].EditedFormattedValue.ToString() == "True")
                {
                    gridTaskList.Rows[index].DefaultCellStyle.BackColor = Properties.Settings.Default.ClosedTask;
                }
                else
                {
                    gridTaskList.Rows[index].DefaultCellStyle.BackColor = Properties.Settings.Default.RowColor1;
                }
            }
            gridTaskList.CommitEdit(DataGridViewDataErrorContexts.Commit);
        }

        public void Recolor(int index)
        {
            if (DateTime.Parse(gridTaskList.Rows[index].Cells[2].EditedFormattedValue.ToString()) < DateTime.Today.Date &&
                gridTaskList.Rows[index].Cells[3].EditedFormattedValue.ToString() == "False")
            {
                gridTaskList.Rows[index].DefaultCellStyle.BackColor = Color.Red;
            }
            else if (index % 2 != 0 &&
                gridTaskList.Rows[index].Cells[3].EditedFormattedValue.ToString() == "False")
            {
                gridTaskList.Rows[index].DefaultCellStyle.BackColor = Color.LightGray;
            }
            else if (gridTaskList.Rows[index].Cells[3].EditedFormattedValue.ToString() == "True")
            {
                gridTaskList.Rows[index].DefaultCellStyle.BackColor = Color.LightGreen;
            }
            else
            {
                gridTaskList.Rows[index].DefaultCellStyle.BackColor = Color.White;
            }
            gridTaskList.CommitEdit(DataGridViewDataErrorContexts.Commit);
            gridTaskList.ClearSelection();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            int i;
            if (gridTaskList.Rows.Count==0)
            {
                i = 0;
            }
            else
            {
                i = int.Parse(gridTaskList.Rows[gridTaskList.Rows.Count-1].Cells[0].Value.ToString());
            }
            if (txtTask.Text == "")
            {
                MessageBox.Show("Введите текст", "Ошибка",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            else if (dateDeadline.Value<DateTime.Parse(DateTime.Today.ToShortDateString()))
            {
                MessageBox.Show("Дэдлайн меньше текущей даты", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                gridTaskList.Rows.Add(i + 1, txtTask.Text, dateDeadline.Value.ToShortDateString(), false);
                Recolor(i);
                gridTaskList.ClearSelection();
            }
        }

        private void сохранитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveJson();   
        }
       private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadJson();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show(gridTaskList.Rows.Count.ToString());
            }
            catch(Exception error)
            {
                MessageBox.Show(error.Message);
            }
        }

        private void очиститьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Очистить", "", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                gridTaskList.Rows.Clear();
            }
        }

        private void удалитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (gridTaskList.Rows.Count == 0)
            {
                MessageBox.Show("Таблица пуста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else if ((MessageBox.Show("Delete?", "Delete",
                      MessageBoxButtons.YesNo,
                      MessageBoxIcon.Question)) == DialogResult.Yes)
            {
                try
                {
                    foreach (DataGridViewRow item in gridTaskList.SelectedRows)
                    {
                        gridTaskList.Rows.RemoveAt(item.Index);
                    }
                }
                catch
                {
                    MessageBox.Show("Строка не выделена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                foreach (DataGridViewRow item in gridTaskList.Rows)
                {
                    Recolor(item.Index);
                }
            }
        }

        private void gridTaskList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DateTime.Parse(gridTaskList.Rows[gridTaskList.CurrentRow.Index].Cells[2].EditedFormattedValue.ToString()) < DateTime.Parse(DateTime.Today.ToShortDateString()))
            {
                gridTaskList.Rows[gridTaskList.CurrentRow.Index].ReadOnly = true;
                if (gridTaskList.Rows[gridTaskList.CurrentRow.Index].Cells[3].EditedFormattedValue.ToString() == "True")
                {
                    gridTaskList.Rows[gridTaskList.CurrentRow.Index].Cells[3].Value = true;
                }
                else
                {
                    gridTaskList.Rows[gridTaskList.CurrentRow.Index].Cells[3].Value = false;
                }
            }
        }

        private void gridTaskList_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            Point po = ((DataGridView)sender).CurrentCellAddress;
            Recolor(po.Y);
        }

        private void toolStripMenuItem3_Click_1(object sender, EventArgs e)
        {
            MessageBox.Show(gridTaskList.Rows[0].Cells[2].EditedFormattedValue.ToString()+";;;"+DateTime.Today+";;;"+dateDeadline.Value.ToShortDateString());
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            dateDeadline.Value = DateTime.Parse(DateTime.Today.ToShortDateString());
            gridTaskList.Font = Properties.Settings.Default.myFont;
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void удалитьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            удалитьToolStripMenuItem_Click(sender,e);
        }

        private void очиститьToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            очиститьToolStripMenuItem_Click(sender, e);
        }

        private void завершитьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Boolean.Parse(gridTaskList.Rows[gridTaskList.CurrentRow.Index].Cells[3].EditedFormattedValue.ToString()) == false)
            {
                gridTaskList.Rows[gridTaskList.CurrentRow.Index].Cells[3].Value = "True";
                Recolor(gridTaskList.CurrentRow.Index);
            }
            else
            {
                gridTaskList.Rows[gridTaskList.CurrentRow.Index].Cells[3].Value = "False";
                Recolor(gridTaskList.CurrentRow.Index);
            }
        }

        private void txtTask_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) dateDeadline.Focus();
        }

        private void dateDeadline_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) btnAdd.Focus();
        }

        private void btnAdd_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter) txtTask.Focus();
        }

        private void gridTaskList_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Delete)
            {
                if (gridTaskList.Rows.Count == 0)
                {
                    MessageBox.Show("Таблица пуста", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else if ((MessageBox.Show("Delete?", "Delete",
                          MessageBoxButtons.YesNo,
                          MessageBoxIcon.Question)) == DialogResult.Yes)
                {
                    try
                    {
                        foreach (DataGridViewRow item in gridTaskList.SelectedRows)
                        {
                            gridTaskList.Rows.RemoveAt(item.Index);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Строка не выделена", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    foreach (DataGridViewRow item in gridTaskList.Rows)
                    {
                        Recolor(item.Index);
                    }
                }
            }  
        }
        private void jsonToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveJson();
        }
        private void jsonLoadToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LoadJson();
        }
        private void параметрыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmSettings f = new frmSettings();
            f.Owner = this;
            f.ShowDialog();
        }
        private void печатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (printDialog1.ShowDialog() == DialogResult.OK)
            {
                printDocument1.PrinterSettings = printDialog1.PrinterSettings;               
                printDocument1.Print();
            }
        }

        private void printDocument1_PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp = new Bitmap(gridTaskList.Size.Width + 10, gridTaskList.Size.Height + 10);
            gridTaskList.DrawToBitmap(bmp, gridTaskList.Bounds);
            e.Graphics.DrawImage(bmp, 0, 0);
        }
    }
}


