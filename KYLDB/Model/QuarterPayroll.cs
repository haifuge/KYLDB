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
        private string contact;
        public string Contact
        {
            get { return contact; }
            set
            {
                contact = value;
                if (contact.Length > 25)
                    contact = contact.Substring(0, 22) + "...";
            }
        }
        private string phone;
        public string Phone
        {
            get { return phone; }
            set
            {
                phone = value == null ? "" : value;
                phone = phone.Length > 12 ? phone.Substring(0, 12) : phone;
            }
        }
        private string aphone;
        public string AltPhone
        {
            get { return aphone; }
            set
            {
                aphone = value == null ? "" : value;
                aphone = aphone.Length > 12 ? aphone.Substring(0, 12) : aphone;
            }
        }
        public string Balance { get; set; }
        public string PayrollLocal { get; set; }
        public string PayrollRep { get; set; }
        public string PaycheckRep { get; set; }
        public string MemoForUpdate { get; set; }
    }
}
