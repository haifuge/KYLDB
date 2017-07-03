using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class MonthlyRep
    {
        public string ID { get; set; }
        public string Company { get; set; }
        public string Contact { get; set; }
        public string Phone { get; set; }
        public string AltPhone { get; set; }
        public double Balance { get; set; }
        public string SalesTax { get; set; }
        public string SalesTaxNum { get; set; }
        public string LiquorTax { get; set; }
        public string U_OTax { get; set; }
        public string MemoForUpdate { get; set; }
    }
}
