using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class QuarterBill
    {
        public string AccNum { get; set; }
        public string Customer { get; set; }
        public int NumOfCkThisQtr { get; set; }
        public int NumOfCkLastQtr { get; set; }
        public int Difference { get; set; }
        public string CkFee { get; set; }
        public string BillAmt { get; set; }
    }
}
