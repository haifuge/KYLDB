using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class MonthlyRepTitle
    {
        private string _rep;
        private string _month;
        public string Rep { get { return "Monthly Query - " + _rep; } set { _rep = value; } }
        public string Month { get { return "Month: " + _month; } set { _month = value; } }
    }
}
