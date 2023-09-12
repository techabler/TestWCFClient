using MonitorStock.Model;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorStock.Service
{
    public enum EMMarket
    {
        KOSPI,
        KOSDAQ,
        ALL
    }

    public class DBController
    {
        /// <summary>
        /// String 쿼리 실행 
        /// </summary>
        /// <param name="conn">DB Connection Context</param>
        /// <param name="row">tb_base_row instance</param>
        /// <returns></returns>
        private long _sql_insert(MySqlConnection conn, string SQL)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = SQL;

                if (cmd.ExecuteNonQuery() > 0)
                {
                    return cmd.LastInsertedId;
                }
                else
                {
                    // error check...
                    return -1;
                }
            }
        }

        public bool Insert(MySqlConnection conn, string SQL)
        {
            return _sql_insert(conn, SQL) != -1 ;
        }


        /// <summary>
        /// String 쿼리 업데이트 
        /// 이걸로 하면 AGING 업데이트 못함. (cmd.CommandText) 찍어 보쇼...
        /// 이유는 tb_aging_row 클래스에서 힌트를 찾고...
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="row"></param>
        /// <returns></returns>
        private bool _sql_update(MySqlConnection conn, string SQL)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = SQL;
                return cmd.ExecuteNonQuery() > 0;
            }
        }



        /// <summary>
        /// RestParam 타입의 Query를 이용하여 Select 구문 실행 
        /// </summary>
        /// <param name="conn">Connection Context</param>
        /// <param name="body">RESTCallQueryBody Instance</param>
        /// <returns>DataTable Type</returns>
        private DataTable _sql_select(MySqlConnection conn, RESTCallQueryParam body)
        {
            //
            body.Limit = body.Limit == 0 || body.Limit > UInt16.MaxValue ? UInt16.MaxValue : body.Limit;

            //
            if (string.IsNullOrWhiteSpace(body.Select)) body.Select = "*";

            //
            StringBuilder sql = new StringBuilder();
            sql.AppendLine($"SELECT {body.Select}");
            sql.AppendLine($"  FROM `{body.Table}`");
            if (!string.IsNullOrWhiteSpace(body.Where))
            {
                sql.AppendLine($" WHERE {body.Where}");
            }

            if (!string.IsNullOrWhiteSpace(body.Groupby))
            {
                sql.AppendLine($" WHERE {body.Groupby}");
            }

            if (!string.IsNullOrWhiteSpace(body.Orderby))
            {
                sql.AppendLine($" ORDER BY {body.Orderby}");
            }

            if (body.useLimit)
            {
                sql.AppendLine($" LIMIT {body.Limit}");
            }

            DataTable table = new DataTable();

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql.ToString();
                var reader = cmd.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }

            return table;
        }

        private DataTable _sql_query(MySqlConnection conn, string query)
        {
            if(string.IsNullOrWhiteSpace(query)) return null;

            DataTable table = new DataTable();
            using(var cmd = conn.CreateCommand())
            {
                cmd.CommandText= query;
                var reader = cmd.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }

            return table;
        }

        /// <summary>
        /// String 쿼리 반환 결과 카운팅 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="sql"></param>
        /// <returns></returns>
        private long _sql_count(MySqlConnection conn, string sql)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                return Convert.ToInt64(cmd.ExecuteScalar().ToString());
            }
        }

        public DataTable getTableRow(MySqlConnection conn, RESTCallQueryParam param)
        {
            return _sql_select(conn, param);
        }

        /// <summary>
        /// TODO : Stock 정보 가져오기로 변경 by Stock Code
        /// </summary>
        /// <param name="conn">Connection Context</param>
        /// <param name="tray_id">Tray Id</param>
        /// <returns></returns>
        public CStockInfo get_stockinfo(MySqlConnection conn, string stock_code)
        {
            RESTCallQueryParam body = new RESTCallQueryParam();
            body.Table = STOCKTableName.stock_list.ToString();
            body.Where = $"code = '{stock_code}'";

            return BaseTable.ConvertDataTable<CStockInfo>(_sql_select(conn, body)).First();
        }

        public DataTable get_stockinfoTable(MySqlConnection conn, string stock_code)
        {
            RESTCallQueryParam body = new RESTCallQueryParam();
            body.Table = STOCKTableName.stock_list.ToString();
            body.Where = $"code = '{stock_code}'";

            return _sql_select(conn, body);
        }

        public DataTable get_stockListTable(MySqlConnection conn, EMMarket market)
        {
            RESTCallQueryParam body = new RESTCallQueryParam();
            body.Table = STOCKTableName.stock_list.ToString();
            body.useLimit = false;

            if(market != EMMarket.ALL)
            {
                body.Where = $"market = '{market.ToString()}'";
            }

            return _sql_select(conn, body);
        }

        public DataTable get_bookmarkTable(MySqlConnection conn)
        {
            string query = @"SELECT DATE, scode,  (SELECT name FROM stock_list A WHERE A.CODE = scode) AS sname, market, A.`type`, B.description FROM bookmark_list A
                            INNER JOIN bookmark_type B ON A.`type`=B.code
                            ORDER BY DATE ASC";

            return _sql_query(conn, query);
        }

        /*
        

        /// <summary>
        /// TODO : Stock 정보 가져오기로 변경 by Stock ID
        /// </summary>
        /// <param name="conn">Connection Context</param>
        /// <param name="id">id of tb_tray</param>
        /// <returns></returns>
        private tb_tray_row _get_tray(MySqlConnection conn, Int64 id)
        {
            RESTCallQueryParam body = new RESTCallQueryParam();
            body.Table = FMSTableNames.tb_tray.ToString();
            body.Where = $"id = {id}";
            return tb_base.ConvertDataTable<tb_tray_row>(_sql_select(conn, body)).First();
        }


        /// <summary>
        /// TODO : Stock Price List 반환하기로 변경 
        /// </summary>
        /// <param name="conn">Connection Context</param>
        /// <param name="cell_id">id of the cell</param>
        /// <returns></returns>
        private tb_cell_process_row _get_cell_process(MySqlConnection conn, string cell_id)
        {
            RESTCallQueryParam body = new RESTCallQueryParam();
            body.Table = FMSTableNames.tb_cell_process.ToString();
            body.Where = $"cell_id = '{cell_id}'";

            try
            {
                return tb_base.ConvertDataTable<tb_cell_process_row>(_sql_select(conn, body)).First();
            }
            catch
            {
                return null;
            }
        }

        /// <summary>
        /// TODO : 특정 쿼리 실행 후 DataTable 타입으로 Deserialize 하여 반환으로 변경 
        /// </summary>
        /// <param name="conn"></param>
        /// <param name="eqp_id"></param>
        /// <returns></returns>
        private tb_eqp_row _get_eqp(MySqlConnection conn, string eqp_id)
        {
            string table_name = AtemFMSDBTablesMaria.GlobalObject.IsAgingEqp(eqp_id) ? "tb_aging" : "tb_eqp";
            string sql = $"SELECT * FROM {table_name} WHERE eqp_id = '{eqp_id}' LIMIT 1";

            DataTable table = new DataTable();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                var reader = cmd.ExecuteReader();
                table.Load(reader);
                reader.Close();
            }

            return tb_base.ConvertDataTable<tb_eqp_row>(table).First();
        }

        */


        /*
         
        // TODO : 특정 처리에 대한 사용자 함수로 사용 

        private bool _insert_or_update_tray(MySqlConnection conn, tb_tray_row tray)
        {
            try
            {
                var existing_tray = _get_tray(conn, tray.tray_id);

                // existing tray, update it
                tray.id = existing_tray.id;
                return _sql_update(conn, tray);
            }
            catch
            {
                // new tray, insert it
                return _sql_insert(conn, tray) >= 0;
            }
        }

        private bool _update_eqp_or_aging(MySqlConnection conn, tb_eqp_row eqp)
        {
            if (AtemFMSDBTablesMaria.GlobalObject.IsAgingEqp(eqp.eqp_id))
            {
                tb_aging_row aging = JsonConvert.DeserializeObject<tb_aging_row>(JsonConvert.SerializeObject(eqp));
                return _sql_update(conn, aging);
            }
            else
            {
                return _sql_update(conn, eqp);
            }
        }

        private long _tb_tray_process_insert_on_job_start(MySqlConnection conn, tb_tray_row tray)
        {
            tb_tray_process_row process = JsonConvert.DeserializeObject<tb_tray_process_row>(JsonConvert.SerializeObject(tray));
            return _sql_insert(conn, process);
        }

        */



    }
}
