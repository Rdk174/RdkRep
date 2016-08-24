using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TODOList
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();
            
        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void frmSettings_Load(object sender, EventArgs e)
        {
            lblRow1Color.BackColor = Properties.Settings.Default.RowColor1;
            lblRow2Color.BackColor = Properties.Settings.Default.RowColor2;
            lblClosedColor.BackColor = Properties.Settings.Default.ClosedTask;
            lblExpiredColor.BackColor = Properties.Settings.Default.ExpiredTask;
            listExample.DrawMode = DrawMode.OwnerDrawFixed;
            listExample.Font = Properties.Settings.Default.myFont;
            lblFont.Text = Properties.Settings.Default.myFont.Name + ";" + Properties.Settings.Default.myFont.SizeInPoints;
        }

        private void comboBoxRow1_DrawItem(object sender, DrawItemEventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void listExample_DrawItem(object sender, DrawItemEventArgs e)
        {
            e.DrawBackground();
            string text = listExample.Items[e.Index].ToString();
            Font myFont = Properties.Settings.Default.myFont;
            Color myColor = Color.White;
            SolidBrush myBrush = new SolidBrush(Properties.Settings.Default.RowColor1);
            switch (e.Index)
            {
                case 0:
                    myBrush = new SolidBrush(Properties.Settings.Default.RowColor1);
                    text=listExample.Items[e.Index].ToString();
                    break;
                case 1:
                    myBrush = new SolidBrush(Properties.Settings.Default.RowColor2);
                    text = listExample.Items[e.Index].ToString();
                    break;
                case 2:
                    myBrush = myBrush = new SolidBrush(Properties.Settings.Default.ClosedTask);
                    text = listExample.Items[e.Index].ToString();
                    break;
               case 3:
                    myBrush = myBrush = new SolidBrush(Properties.Settings.Default.ExpiredTask);
                    text = listExample.Items[e.Index].ToString();
                    break;
            }
            e.Graphics.FillRectangle(myBrush, e.Bounds);
            e.Graphics.DrawString(text, myFont, Brushes.Black, e.Bounds, StringFormat.GenericDefault);
            e.DrawFocusRectangle();
        }

        private void listExample_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnRow1_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lblRow1Color.BackColor = colorDialog.Color;
                Properties.Settings.Default.RowColor1 = colorDialog.Color;
                listExample.DrawItem += new DrawItemEventHandler(listExample_DrawItem);
                Refresh();
            }
        }

        private void btnRow2_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lblRow2Color.BackColor = colorDialog.Color;
                Properties.Settings.Default.RowColor2 = colorDialog.Color;
                listExample.DrawItem += new DrawItemEventHandler(listExample_DrawItem);
                Refresh();
            }
        }

        private void btnClosed_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lblClosedColor.BackColor = colorDialog.Color;
                Properties.Settings.Default.ClosedTask = colorDialog.Color;
                listExample.DrawItem += new DrawItemEventHandler(listExample_DrawItem);
                Refresh();
            }
        }

        private void btnExpired_Click(object sender, EventArgs e)
        {
            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                lblExpiredColor.BackColor = colorDialog.Color;
                Properties.Settings.Default.ExpiredTask = colorDialog.Color;
                listExample.DrawItem += new DrawItemEventHandler(listExample_DrawItem);
                Refresh();
            }
        }

        private void btnFont_Click(object sender, EventArgs e)
        {
            if (fontDialog.ShowDialog() == DialogResult.OK) {
                lblFont.Text = fontDialog.Font.Name + ";" + fontDialog.Font.SizeInPoints;
                Properties.Settings.Default.myFont = fontDialog.Font;
                listExample.Font = Properties.Settings.Default.myFont;
                Refresh();
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Save();
            frmMain main = this.Owner as frmMain;
            main.Recolor();
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void btnToDefault_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите установить настройки по умолчанию?", "Сброс", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Properties.Settings.Default.Reset();
                lblRow1Color.BackColor = Properties.Settings.Default.RowColor1;
                lblRow2Color.BackColor = Properties.Settings.Default.RowColor2;
                lblClosedColor.BackColor = Properties.Settings.Default.ClosedTask;
                lblExpiredColor.BackColor = Properties.Settings.Default.ExpiredTask;
                listExample.DrawMode = DrawMode.OwnerDrawFixed;
                listExample.Font = Properties.Settings.Default.myFont;
                lblFont.Text = Properties.Settings.Default.myFont.Name + ";" + Properties.Settings.Default.myFont.SizeInPoints;
            }
        }

        private void lblFont_Click(object sender, EventArgs e)
        {

        }
    }
}

