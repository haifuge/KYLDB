using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class BaseRepModel
    {
        public string ID { get; set; }
        public string Rep { get; set; }
        private string _company;
        public string Company
        {
            get { return _company; }
            set {
                _company = value;
                if (_company.Length > 25)
                    _company = _company.Substring(0, 22) + "...";
            }
        }
        public string Contact { get; set; }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value;
                if (phone.IndexOf('(') != -1)
                {
                    phone = phone.Substring(0, phone.IndexOf('('));
                }
            }
        }
        private string aphone;
        public string AltPhone
        {
            get { return aphone; }
            set
            {
                aphone = value;
                if (aphone.IndexOf('(') != -1)
                {
                    aphone = aphone.Substring(0, aphone.IndexOf('('));
                }
            }
        }
        public string MemoForUpdate { get; set; }
    }
}
