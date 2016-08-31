using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.NetworkInformation;

namespace Pinger
{
    public partial class frmPing : Form
    {
        public frmPing()
        {
            InitializeComponent();
        }
        public void StartPing(string IP)
        {
                Ping ping = new Ping();
                PingReply pingReply = ping.Send(IP,1000);
                string text = txtPing.Text;
                txtPing.Text = text+pingReply.Status.ToString() + " | " + pingReply.RoundtripTime.ToString() + "мс | с адресом " + pingReply.Address + Environment.NewLine;
                txtPing.SelectionLength = 0;
        }
        private void frmPing_Load(object sender, EventArgs e)
        {
            timer1.Enabled = true;
            frmMain main = Owner as frmMain;
            this.Text ="Пинг" + main.gridAddresses.Rows[main.gridAddresses.CurrentRow.Index].Cells[3].Value.ToString();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            frmMain main = Owner as frmMain;
            StartPing(main.gridAddresses.Rows[main.gridAddresses.CurrentRow.Index].Cells[3].Value.ToString());
        }

        private void frmPing_FormClosing(object sender, FormClosingEventArgs e)
        {
            timer1.Enabled = false;
            frmMain main = Owner as frmMain;
            main.timerRefresh.Enabled = true;
        }

        private void txtPing_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
