using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KYLDB.Model
{
    public class ClientPayroll
    {
        // 80
        public string AccNum { get; set; }
        public string EIN { get; set; }
        public string AccRep { get; set; }
        public string PayRep { get; set; }
        public string CkRep { get; set; }
        public string Entity { get; set; }
        public string TradeName { get; set; }
        public string BusAdd1 { get; set; }
        public string BusAdd2 { get; set; }
        public string BusCity { get; set; }
        public string BusSt { get; set; }
        public string BusZip { get; set; }
        public string MailAdd1 { get; set; }
        public string MailAdd2 { get; set; }
        public string MailCity { get; set; }
        public string MailSt { get; set; }
        public string MailZip { get; set; }
        public string HomeAdd { get; set; }
        public string Fax { get; set; }
        public string Email { get; set; }
        public string Language { get; set; }
        public string Contact1 { get; set; }
        public string Contact1Tel1 { get; set; }
        public string Contact1Tel2 { get; set; }
        public string Contact2 { get; set; }
        public string Contact2Tel1 { get; set; }
        public string Contact2Tel2 { get; set; }
        public string PayType { get; set; }
        public string PayFreq { get; set; }
        public string TaxDepType { get; set; }
        private string _paystartDate;
        public string PayStartDate
        {
            get { return _paystartDate; }
            set
            {
                try
                {
                    DateTime.Parse(value);
                    _paystartDate = value;
                }
                catch
                {
                    _paystartDate = null;
                }
            }
        }
        public string PayCloseDate { get; set; }
        public string Bank { get; set; }
        public string BankRtg { get; set; }
        public string BankAcc { get; set; }
        private string _bankStartDate;
        public string BankStartDate
        {
            get { return _bankStartDate; }
            set
            {
                try
                {
                    DateTime.Parse(value);
                    _bankStartDate = value;
                }
                catch
                {
                    _bankStartDate = null;
                }
            }
        }
        public string DateIn { get; set; }
        public string DateOut { get; set; }
        public string TimeToDone { get; set; }
        public string AveNumEE { get; set; }
        public string Note { get; set; }
        public string FedTaxFreq { get; set; }
        public string EFTPS { get; set; }
        public string F8655 { get; set; }
        public string EFTPSPin { get; set; }
        public string EFTPSPw { get; set; }
        public string State { get; set; }
        public string StateTaxFreq { get; set; }
        public string StateWH { get; set; }
        public string StateUser { get; set; }
        public string StatePw { get; set; }
        public string PhilaNum { get; set; }
        public string PhilaTaxFreq { get; set; }
        public string PhilaPayType { get; set; }
        public string PhilaEZReportN { get; set; }
        public string PhilaEZPw { get; set; }
        public string PhilaOnlinPin { get; set; }
        public string Local { get; set; }
        public string LocalPSD { get; set; }
        public string LocalCollector { get; set; }
        public string LocalTaxFreq { get; set; }
        public string LocalPayType { get; set; }
        public string LocalUser { get; set; }
        public string LocalPw { get; set; }
        public string LST { get; set; }
        public string LSTCollector { get; set; }
        public string LSTTaxFreq { get; set; }
        public string LSTPayType { get; set; }
        public string LSTUser { get; set; }
        public string LSTPW { get; set; }
        public string UC { get; set; }
        public string UCNum { get; set; }
        public string UCPayType { get; set; }
        public string UCUsername { get; set; }
        public string UCPassword { get; set; }
        public string UCContaceEM { get; set; }
        public string PAUCQ1 { get; set; }
        public string PAUCQ2 { get; set; }
        public string PAUCQ3 { get; set; }
        private string _firstcheckdate;
        public string FirstCheckDate
        {
            get { return _firstcheckdate; }
            set
            {
                if (value == "" || value == null)
                    _firstcheckdate = "1/1/" + DateTime.Now.Year.ToString();
                else
                    _firstcheckdate = value;
            }
        }
    }
}
