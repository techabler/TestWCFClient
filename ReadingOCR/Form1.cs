using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ReadingOCR
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnCapture_Click(object sender, EventArgs e)
        {
            string filePath = "test.png";

            ImgCapture imgCapture = new ImgCapture(1600, 100, 600, 600);
            imgCapture.SetPath(filePath);
            imgCapture.DoCaptureImage();

            return;
        }
    }
}
