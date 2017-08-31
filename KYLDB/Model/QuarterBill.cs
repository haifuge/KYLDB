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
        private string _customer;
        public string Customer
        {
            get { return _customer; }
            set
            {
                _customer = value;
                if (_customer.Length > 25)
                    _customer = _customer.Substring(0, 22) + "...";
            }
        }
        public int NumOfCkThisQtr { get; set; }
        public int NumOfCkLastQtr { get; set; }
        public int Difference { get; set; }
        public string CkFee { get; set; }
        public string BillAmt { get; set; }
    }
}
