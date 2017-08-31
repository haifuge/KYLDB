using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class RepReport
    {
        public string AccNum { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (_name.Length > 25)
                    _name = _name.Substring(0, 22) + "...";
            }
        }
        public string AccRep { get; set; }
        public string PayRep { get; set; }
        public string CkRep { get; set; }
        public string PayType { get; set; }
        public string PayFreq { get; set; }
    }
}
