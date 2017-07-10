using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class StatisticRep
    {
        public string Rep { get; set; }
    }
    public class TOTAL: StatisticRep
    {
        public int I { get; set; }
        public int P { get; set; }
        public int C { get; set; }
        public int CS { get; set; }
        public int Total { get; set; }
    }
    public class STPR:StatisticRep
    {
        public int ST { get; set; }
        public int PR { get; set; }
        public int Liquor { get; set; }
        public int UO { get; set; }
    }
}
