using System;
using System.Windows.Forms;

namespace AtemFMSOpStationUI.Stations
{
    public class HMIMessageBox
    {
        public static DialogResult Show(UserControl parent, string message, string title = "Error", MessageBoxButtons buttons = MessageBoxButtons.OK)
        {
            LayerForMsgBox layer_form = new LayerForMsgBox
            {
                TopMost = true
            };


            if (parent.InvokeRequired)
            {
                parent.Invoke(new Action(() =>
                {
                    layer_form.Show();
                }));
            }
            else
            {
                layer_form.Show();
            }




            AtemFMSMessageBox box = new AtemFMSMessageBox(message, title, buttons)
            {
                TopMost = true,
                StartPosition = FormStartPosition.CenterScreen
            };

            DialogResult r = DialogResult.OK;
            if (parent.InvokeRequired)
            {
                parent.Invoke(new Action(() =>
                {
                    r = box.ShowDialog();
                    layer_form.Close();
                }));
            }
            else
            {
                r = box.ShowDialog();
                layer_form.Close();
            }
            return r;
        }
    }
}
