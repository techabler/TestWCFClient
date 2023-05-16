using MonitorStock.Model;
using MonitorStock.Service;
using MySql.Data.MySqlClient;
using Org.BouncyCastle.Asn1.X509;
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
    public partial class UCStockList : UserControl
    {
        public List<CStockInfo> fullList = new List<CStockInfo>();
        public List<CStockInfo> displayList = new List<CStockInfo>();
        private int selectStock = -1;
        private BindingList<object> _cbBokmark = new BindingList<object>();
        private string _connectionString = string.Empty;

        public UCStockList()
        {
            InitializeComponent();
        }

        private void UCStockList_Load(object sender, EventArgs e)
        {
            //Screen screen = Screen.FromPoint(Cursor.Position);
            //this.Location = screen.Bounds.Location;
            this.AutoScaleMode = AutoScaleMode.Inherit;
            this.Dock = DockStyle.Fill;

            initCombo();
            LoadData();
        }

        private void initBookmarkType()
        {
            if(CGlobalVars.bookmarkType.Count > 0)
            {
                foreach(var item in CGlobalVars.bookmarkType)
                {
                    _cbBokmark.Add(new { Display = item.description, Value = item.code });
                }

                cbBookMark.Items.Clear();
                cbBookMark.DataSource = _cbBokmark;
                cbBookMark.DisplayMember = "Display";
                cbBookMark.ValueMember = "Value";
            }
        }

        private void initCombo() 
        {
            cbMarket.Items.Clear();
            cbMarket.Items.Add(EMMarket.ALL.ToString());
            cbMarket.Items.Add(EMMarket.KOSPI.ToString());
            cbMarket.Items.Add(EMMarket.KOSDAQ.ToString());
            cbMarket.SelectedIndex = 0;
            
            initBookmarkType();
            
        }

        private void LoadData()
        {

            _connectionString = ConfigurationManager.AppSettings["STOCKDB_ConnectionString"];

            using (var conn = new MySqlConnection(_connectionString))
            {
                conn.Open();

                DBController controller = new DBController();
                // MonitorStock.Model.CStockInfo stock = controller.get_stockinfo(conn, "005930");

                //DataTable dt = controller.get_stockinfoTable(conn, "005930");
                DataTable dt = controller.get_stockListTable(conn, EMMarket.ALL);

                displayList = fullList = BaseTable.ConvertDataTable<CStockInfo>(dt);

                dgsStockList.DataSource = dt;

                //Console.WriteLine(stock.name);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<CStockInfo> tmpStockList = new List<CStockInfo>();
            var searchCode = txtStockCode.Text.Trim();
            var searchName = txtStockName.Text.Trim();

            if(string.IsNullOrEmpty(searchCode) && string.IsNullOrEmpty(searchName))
            {
                MessageBox.Show("검색어를 입력해 주세요!");
                return;
            }

            if (displayList.Count > 0)
            {
                foreach (var stock in displayList)
                {
                    if(searchCode.Length > 0 && stock.code.Contains(searchCode))
                    {
                        tmpStockList.Add(stock);
                        continue;
                    }

                    if(searchName.Length > 0 && stock.name.Contains(searchName))
                    {
                        tmpStockList.Add(stock);
                        continue;
                    }
                }
                dgsStockList.DataSource = tmpStockList;
            }
        }

        private void cbMarket_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (fullList.Count > 0)
            {
                var selectedMarket = cbMarket.Items[cbMarket.SelectedIndex].ToString();

                if (selectedMarket.Equals(EMMarket.ALL.ToString()))
                {
                    dgsStockList.DataSource = displayList = fullList;
                }
                else
                {
                    List<CStockInfo> tmpStockList = new List<CStockInfo>();

                    foreach (var stock in fullList)
                    {
                        if (selectedMarket.Equals(stock.market))
                        {
                            tmpStockList.Add(stock);
                        }
                    }

                    dgsStockList.DataSource = displayList = tmpStockList;
                }

                
            }
        }

        private void btnBookMark_Click(object sender, EventArgs e)
        {
            if (displayList.Count > 0 && selectStock > -1)
            {
                string selectedBookmarkCode = cbBookMark.SelectedValue as String;

                CStockInfo stock = displayList[selectStock];
                DateTime now = DateTime.Now;
                CModelBookmark bookmark = new CModelBookmark() { code = stock.code, market = stock.market, type = selectedBookmarkCode, date = now.ToString("yyyy-MM-dd") };

                Console.WriteLine(bookmark.ToString());
                string SQL = $"INSERT INTO bookmark_list(date, scode, market, type) VALUES('{bookmark.date}', '{bookmark.code}', '{bookmark.market}', '{bookmark.type}')";

                using (var conn = new MySqlConnection(_connectionString))
                {
                    conn.Open();

                    DBController controller = new DBController();

                    bool result = controller.Insert(conn, SQL);

                    MessageBox.Show($"Insert Result : {result}");
                }


            }
        }

        private void dgsStockList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            selectStock = e.RowIndex;
        }

        private void txtStockName_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }

        private void txtStockCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(null, null);
            }
        }
    }
}
