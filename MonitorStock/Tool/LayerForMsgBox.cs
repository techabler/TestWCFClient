using System;
using System.Drawing;
using System.Windows.Forms;

namespace AtemFMSOpStationUI.Stations
{
    public partial class LayerForMsgBox : Form
    {
        public LayerForMsgBox()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Screen screen = Screen.FromPoint(Cursor.Position);
            this.Location = screen.Bounds.Location;
            this.CenterToScreen();
            this.WindowState = FormWindowState.Maximized;
        }
    }
}
