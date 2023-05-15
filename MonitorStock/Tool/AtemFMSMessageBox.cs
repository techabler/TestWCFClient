using System;
using System.Drawing;
using System.Windows.Forms;

namespace AtemFMSOpStationUI.Stations
{
    public partial class AtemFMSMessageBox : Form
    {
        public AtemFMSMessageBox()
        {
            InitializeComponent();
        }

        public AtemFMSMessageBox(string message, string title, MessageBoxButtons buttons)
        {
            InitializeComponent();

            tbMessage.Text = message.Replace("\n","\r\n");
            tbTitle.Text = title;

            if(title.ToLower().Contains("error"))
            {
                tbTitle.BackColor = Color.Red;
                tbTitle.ForeColor = Color.White;
                tbMessage.BackColor = Color.Orange;
            }

            if(buttons == MessageBoxButtons.YesNo)
            {
                BTNOK.Text = "YES";
                BTN_CANCEL.Text = "NO";

                BTNOK.Tag = DialogResult.Yes;
                BTN_CANCEL.Tag = DialogResult.No;
            }
            else if(buttons == MessageBoxButtons.OKCancel)
            {
                BTNOK.Text = "OK";
                BTN_CANCEL.Text = "CANCEL";

                BTNOK.Tag = DialogResult.OK;
                BTN_CANCEL.Tag = DialogResult.Cancel;
            }
            else if(buttons == MessageBoxButtons.OK)
            {
                BTN_CANCEL.Visible = false;
                BTNOK.Text = "OK";
                BTNOK.Dock = DockStyle.Fill;

                BTNOK.Tag = DialogResult.OK;
                BTN_CANCEL.Tag = null;
                this.CancelButton = null;
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            BTNOK.Focus();
        }

        private void BTNOK_Click(object sender, EventArgs e)
        {
            if (BTNOK.Text == "OK")
            {
                DialogResult = DialogResult.OK;
            }
            else
            {
                DialogResult = DialogResult.Yes;
            }
        }

        private void BTN_CANCEL_Click(object sender, EventArgs e)
        {
            if (BTNOK.Text == "Cancel")
            {
                DialogResult = DialogResult.Cancel;
            }
            else
            {
                DialogResult = DialogResult.No;
            }
        }
    }
}
