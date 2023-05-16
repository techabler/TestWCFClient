using MonitorStock.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorStock.Service
{
    public static class CGlobalVars
    {
        public static List<CBookmarkType> bookmarkType = new List<CBookmarkType>();


        public static void init()
        {
            string connString = ConfigurationManager.AppSettings["STOCKDB_ConnectionString"];

            using (var conn = new MySqlConnection(connString))
            {
                conn.Open();

                DBController controller = new DBController();

                RESTCallQueryParam body = new RESTCallQueryParam();
                body.Table = STOCKTableName.bookmark_type.ToString();
                body.useLimit = false;

                DataTable dt = controller.getTableRow(conn, body);

                bookmarkType = BaseTable.ConvertDataTable<CBookmarkType>(dt);

                conn.Clone();
            }
        }

    }
}
