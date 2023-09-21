using Serilog;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DetectIdleTime
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            StartSessionTimer();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            Log.Logger = new LoggerConfiguration()
                .MinimumLevel.Debug()
                .WriteTo.Console()
                .WriteTo.File("C:/GLog/Detect_Idle_Time.log", rollingInterval:RollingInterval.Day)
                .CreateLogger();
        }

        private void MainForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            StopSessionTimer();
        }
    }
}
