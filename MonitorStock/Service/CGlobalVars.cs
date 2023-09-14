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
    /// <summary>
    /// Trouble Shoot  
    /// C# MariaDB연동 시 DBNull 에러 피하기 : https://www.zemna.net/blog/%EB%8D%B0%EC%9D%B4%ED%84%B0%EB%B2%A0%EC%9D%B4%EC%8A%A4-%EC%97%B0%EB%8F%99%EC%8B%9C-dbnull-%EC%97%90%EB%9F%AC-%ED%94%BC%ED%95%98%EA%B8%B0/
    ///     > 버전 문제 10.5 괜추~
    /// </summary>
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
