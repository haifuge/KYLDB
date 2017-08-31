using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class QuarterPayroll
    {
        public string ID { get; set; }
        private string _company;
        public string Company
        {
            get { return _company; }
            set
            {
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
                if (phone.Length>12)
                {
                    phone = phone.Substring(0, 12).Trim();
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
                if (aphone.Length > 12)
                {
                    aphone = aphone.Substring(0, 12).Trim();
                }
            }
        }
        public string Balance { get; set; }
        public string PayrollLocal { get; set; }
        public string PayrollRep { get; set; }
        public string PaycheckRep { get; set; }
        public string MemoForUpdate { get; set; }
    }
}
