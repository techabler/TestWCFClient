using AtemFMSOpStationUI.Stations;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorStock.Tool
{
    public partial class UCForm : UserControl
    {
        public UCForm()
        {
            InitializeComponent();
        }

        //protected override void OnLoad(EventArgs e)
        //{
        //    base.OnLoad(e);
        //    HMIMessageBox.Show(this, "Test");
        //}

        private void UCForm_Load(object sender, EventArgs e)
        {
            HMIMessageBox.Show(this, "Test");
        }
    }
}
