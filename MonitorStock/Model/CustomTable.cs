using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorStock.Model
{
    internal class CustomTable
    {
    }

    public class CBookmarkType
    {
        public int idx { get; set; }
        public string code { get; set; }
        public string description { get; set; }
    }

    public class CBookmark
    {
        public string name { get; set; }
        public string code { get; set; }
    }

    public class CBookmarkInfo
    {
        public string date { get; set; }
        public string scode { get; set; }
        public string sname { get; set; }

        public string market { get; set; }
        public string type { get; set; }
        public string description { get; set; }

    }

    public class CStockInfo
    {
        public int idx { get; set; }
        public String code { get; set; }
        public String isu_cd { get; set; }
        public String name { get; set; }
        public String market { get; set; }
        public String dept { get; set; }
        public long close { get; set; }
        public int changecode { get; set; }
        public long changes { get; set; }
        public String chagesratio { get; set; }
        public long open { get; set; }
        public long high { get; set; }
        public long low { get; set; }
        public long volume { get; set; }
        public long amount { get; set; }
        public long marcap { get; set; }
        public long stocks { get; set; }
        public String marketid { get; set; }
    }

    public class CModelBookmark
    {
        public int idx { get; set; }
        public String date { get; set; }
        public String code { get; set; }
        public String market { get; set; }
        public String type { get; set; }
    }


}
