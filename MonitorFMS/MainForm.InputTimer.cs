using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorFMS
{
    public partial class MainForm
    {
        private InactiveDetector detector;

        private void StartSessionTimer()
        {
            SessionTimer.Interval = 1000;
            SessionTimer.Tick += SessionTimer_Tick;
            SessionTimer.Enabled = true;

            this.detector = new InactiveDetector();
        }

        private void SessionTimer_Tick(object sender, EventArgs e)
        {
            tsStatus.Text = System.DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");

            checkInactiveIdleTime();
        }

        private void StopSessionTimer()
        {
            SessionTimer.Tick -= SessionTimer_Tick;
            SessionTimer.Enabled = false;
        }

        private void checkInactiveIdleTime()
        {
            TimeSpan? inactiveTimeSpan = detector.GetInactiveIdleTime();

            if (inactiveTimeSpan != null && inactiveTimeSpan.Value.TotalSeconds > 10)
            {
                oPUIToolStripMenuItem_Click(null, null);
                //tsStatus.Text = $"{inactiveTimeSpan.Value.TotalSeconds}초 동안 비활성화됨";
            }
        }

    }
}
