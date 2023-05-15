using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorStock
{
    public class RESTCallQueryParam
    {
        /// <summary>
        /// Specify SQL Query
        /// </summary>
        public string Query { get; set; } = string.Empty;

        /// <summary>
        /// Define SELECT list : Comma-Separated Column Names or * or empty (same as *)
        /// </summary>
        public string Select { get; set; } = string.Empty;

        /// <summary>
        /// Use to specify table name in case the REST url has no table_name parameters
        /// </summary>
        public string Table { get; set; } = string.Empty;

        /// <summary>
        /// Specify WHERE condition in string
        /// </summary>
        public string Where { get; set; } = string.Empty;

        /// <summary>
        /// Specify GROUP BY condition in string
        /// </summary>
        public string Groupby { get; set; } = string.Empty;

        /// <summary>
        /// Specify ORDER BY condition in string
        /// </summary>
        public string Orderby { get; set; } = string.Empty;

        /// <summary>
        /// Specify LIMIT parameter, default is 1
        /// </summary>
        public UInt64 Limit { get; set; } = 1;

        public bool useLimit { get; set; } = true;
    }
}
