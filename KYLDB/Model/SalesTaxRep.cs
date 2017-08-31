using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class SalesTaxRep
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
        public string Balance { get; set; }
        public string SalesTax { get; set; }
        public string SalesTaxNum { get; set; }
        public string LiquorTax { get; set; }
        public string U_OTax { get; set; }
        public string MemoForUpdate { get; set; }
    }
}
