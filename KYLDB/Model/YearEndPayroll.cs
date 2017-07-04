using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class YearEndPayroll: BaseRepModel
    {
        public string Balance { get; set; }
        public string PayrollW2 { get; set; }
        public string Payrollrep { get; set; }
        public string Paycheck { get; set; }
    }
}
