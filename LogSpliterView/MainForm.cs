using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LogSpliterView
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            double a = 0.123456789;
            double b = a * 1000 * 1000 * 10;

            double p = b;

            Console.WriteLine(p.ToString());
            Console.WriteLine(p.ToString("000000"));
            Console.WriteLine(string.Format("{0:000000}", p));

            if (a < 0.0)
            {
                Console.WriteLine("Minus");
            }
        }
    }
}
