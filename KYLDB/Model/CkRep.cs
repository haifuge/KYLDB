using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class CkRep
    {
        public string AccNum { get; set; }
        private string _name;
        public string Name
        {
            get { return _name; }
            set
            {
                _name = value;
                if (_name.Length > 20)
                    _name = _name.Substring(0, 17) + "...";
            }
        }
        public string PayType { get; set; }
        public string PayFreq { get; set; }
        public string CkDate { get; set; }
        public string FedTaxFreq { get; set; }
        public string StateTaxFreq { get; set; }
        public string PhilaTaxFreq { get; set; }
        public string Datain { get; set; }
        public string Dataout { get; set; }
    }
}
