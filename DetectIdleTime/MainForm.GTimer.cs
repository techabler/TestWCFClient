using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DetectIdleTime
{
    public partial class MainForm
    {
        private InactiveDetector _detector;
        private void StartSessionTimer()
        {
            SessionTimer.Interval = 1000;
            SessionTimer.Tick += SessionTimer_Tick;
            SessionTimer.Enabled = true;

            _detector = new InactiveDetector();
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
            TimeSpan? inactiveTimeSpan = _detector.GetInactiveIdleTime();

            if (inactiveTimeSpan != null && inactiveTimeSpan.Value.TotalSeconds > 10)
            {
                // Call Logout/Sing Out
                lbIdleTickCount.Text = $"{inactiveTimeSpan.Value.TotalSeconds}Sec Idle - Timeout";
            }
            else
            {
                lbIdleTickCount.Text = $"{inactiveTimeSpan.Value.TotalSeconds}Sec Idle";
            }
        }
    }
}
