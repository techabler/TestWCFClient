using MonitorStock.Model;
using MonitorStock.Service;
using MySql.Data.MySqlClient;
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
    public partial class UCBookmarkList : UserControl
    {
        public List<CBookmarkInfo> fullList = new List<CBookmarkInfo>();
        public List<CBookmarkInfo> displayList = new List<CBookmarkInfo>();
        private BindingList<object> _cbBokmark = new BindingList<object>();
        private string _connectionString = string.Empty;

        public UCBookmarkList()
        {
            InitializeComponent();
        }

        private void BookmarkList_Load(object sender, EventArgs e)
        {
            this.AutoScaleMode = AutoScaleMode.Inherit;
            this.Dock = DockStyle.Fill;

            initCombo();
            LoadData();
            initDatePicker();
        }

        private void initBookmarkType()
        {
            if (CGlobalVars.bookmarkType.Count > 0)
            {
                _cbBokmark.Add(new { Display = "ALL", Value = "ALL" });

                foreach (var item in CGlobalVars.bookmarkType)
                {
                    _cbBokmark.Add(new { Display = item.description, Value = item.code });
                }

                cbBookmark.Items.Clear();
                cbBookmark.DataSource = _cbBokmark;
                cbBookmark.DisplayMember = "Display";
                cbBookmark.ValueMember = "Value";
            }
        }

        /// <summary>
        /// 등록일 선택 Combo init
        /// </summary>
        private void initDatePicker()
        {
            DateTime dateTime = DateTime.Now;

            dtPicker.Value = dateTime.AddDays(-1);
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
                DataTable dt = controller.get_bookmarkTable(conn);

                dt.Columns.Add("선택", System.Type.GetType("System.Boolean"));

                displayList = fullList = BaseTable.ConvertDataTable<CBookmarkInfo>(dt);

                dgvBookmarkList.DataSource = dt;

                //Console.WriteLine(stock.name);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            List<CBookmarkInfo> tmpStockList = new List<CBookmarkInfo>();
            var selMarket = cbMarket.Items[cbMarket.SelectedIndex].ToString();
            var selType = cbBookmark.SelectedValue.ToString();

            if (displayList.Count > 0)
            {
                var selDateTime = dtPicker.Value.ToShortDateString();

                foreach (var bookmark in displayList)
                {
                    var condition = false;

                    if(selMarket != EMMarket.ALL.ToString())
                    {
                        if(bookmark.market.Contains(selMarket))
                        {
                            condition = true;
                        }
                    }
                    else
                    {
                        condition = true;
                    }

                    if(selType != EMMarket.ALL.ToString())
                    {
                        if(bookmark.type.Contains(selType))
                        {
                            condition = true;
                        }
                        else
                        {
                            condition = false;
                        }
                    }

                    if (condition && bookmark.DATE.ToString().Contains(selDateTime))
                    {
                        tmpStockList.Add(bookmark);
                    }

                }

                dgvBookmarkList.DataSource = tmpStockList;
            }
        }
    }
}
