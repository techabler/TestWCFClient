using AtemFMSOpStationUI.Stations;
using MonitorStock.Service;
using MonitorStock.Tool;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MonitorStock
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }


        private void stockListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UCStockList uCStockList = new UCStockList();

            pnlBody.Controls.Add(uCStockList);

            return;

            //var conString = ConfigurationManager.AppSettings["STOCKDB_ConnectionString"];

            //using(var conn = new MySqlConnection(conString))
            //{
            //    conn.Open();

            //    DBController controller = new DBController();
            //    // MonitorStock.Model.CStockInfo stock = controller.get_stockinfo(conn, "005930");

            //    DataTable dt = controller.get_stockinfoTable(conn, "005930");

            //    //dgDataResult.DataSource = dt;

            //    //Console.WriteLine(stock.name);
            //}
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            CGlobalVars.init();
        }
    }
}
