using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace MonitorStock
{
    public enum STOCKTableName
    {
        stock_list,
        stock_price_kosdaq,
        stock_price_kospi,
        bookmark_stock,
        bookmark_increase_top20,
        bookmark_foreigner_buy
    }

    public enum BOOKMARKType
    {
        FP,
        FQ,
        PU,
        QU
    }

    public class BaseTable
    {
        public int count { get; set; }

        public static List<T> ConvertDataTable<T>(DataTable dt)
        {
            List<T> data = new List<T>();
            foreach (DataRow row in dt.Rows)
            {
                T item = GetItem<T>(row);
                data.Add(item);
            }
            return data;
        }

        public static T GetItem<T>(DataRow row)
        {
            Type temp = typeof(T);
            T obj = Activator.CreateInstance<T>();

            foreach(DataColumn column in row.Table.Columns)
            {
                foreach(PropertyInfo pro in temp.GetProperties())
                {
                    if (pro.Name == column.ColumnName)
                        pro.SetValue(obj, ConvertFromDBVal(row[column.ColumnName]), null);
                    else
                        continue;
                }
            }

            return obj;
        }

        private static object ConvertFromDBVal(object obj)
        {
            if (obj == null || obj == DBNull.Value)
            {
                return null;
            }
            else
            {
                return obj;
            }
        }

    }

    internal class CommonTable
    {
    }
}
