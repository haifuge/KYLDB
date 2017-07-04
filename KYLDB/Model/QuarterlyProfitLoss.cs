using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class QuarterlyProfitLoss: BaseRepModel
    {
        public string PL_WK { get; set; }
        public string PL_QB { get; set; }
        public string PLPreparedBy { get; set; }
        public string ClientProvideBy { get; set; }
    }
}
