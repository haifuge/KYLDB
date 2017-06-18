using KYLDB.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYLDB
{
    public partial class ClientInfo : Form
    {
        List<AccountInfo> AccountInfos = new List<AccountInfo>();
        string saveStatus;
        public ClientInfo()
        {
            InitializeComponent();
            this.AutoScroll = true;
            editControls(false);
            btnSave.Enabled = false;
        }
        
        private void ClientInfo_Load(object sender, EventArgs e)
        {
            string sql = "select * from AccountInfo";
            DataTable dt = DBOperator.QuerySql(sql);
            AccountInfos = DBOperator.getListFromTable<AccountInfo>(dt);
            var acclist = from ac in AccountInfos
                          select ac.AccNum;
            AccNumList.DataSource = acclist.ToArray();

        }

        private void AccNumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accNum = AccNumList.Text;
            var acc = (from ac in AccountInfos
                      where ac.AccNum == accNum
                      select ac).First();
            tAccNum.Text = acc.AccNum;
            tEIN.Text = acc.EIN;
            tEntity.Text = acc.Entity;
            tTradeName.Text = acc.TradeName;
            tPayRep.Text = acc.PayRep;
            tCkRep.Text = acc.CkRep;
            tAccRep.Text = acc.AccRep;
            tBusAdd1.Text = acc.BusAdd1;
            tBusAdd2.Text = acc.BusAdd2;
            tBusCity.Text = acc.BusCity;
            tBusSt.Text = acc.BusSt;
            tBusZip.Text = acc.BusZip;
            tMailAdd1.Text = acc.MailAdd1;
            tMailAdd2.Text = acc.MailAdd2;
            tMailCity.Text = acc.MailCity;
            tMailSt.Text = acc.MailSt;
            tMailZip.Text = acc.MailZip;
            tHomeAdd.Text = acc.HomeAdd;
            tFax.Text = acc.Fax;
            tEmail.Text = acc.Email;
            tLanguage.Text = acc.Language;
            tContact1.Text = acc.Contact1;
            tContact1Tel1.Text = acc.Contact1Tel1;
            tContact1Tel2.Text = acc.Contact1Tel2;
            tContact2.Text = acc.Contact2;
            tContact2Tel1.Text = acc.Contact2Tel1;
            tContact2Tel2.Text = acc.Contact2Tel2;
            cPayType.Text = acc.PayType;
            cPayFreq.Text = acc.PayFreq;
            cTaxDepType.Text = acc.TaxDepType;
            dPayStartDate.Text = acc.PayStartDate;
            dPayCloseDate.Text = acc.PayCloseDate;
            tBank.Text = acc.Bank;
            tBankRtg.Text = acc.BankRtg;
            tBankAcc.Text = acc.BankAcc;
            dBankStartDate.Text = acc.BankStartDate;
            cDateIn.Text = acc.DateIn;
            cDateOut.Text = acc.DateOut;
            tTimeToDone.Text = acc.TimeToDone;
            tAveNumEE.Text = acc.AveNumEE;
            tNote.Text = acc.Note;
            cFedTaxFreq.Text = acc.FedTaxFreq;
            tEFTPS.Text = acc.EFTPS;
            cF8655.Text = acc.F8655;
            tEFTPSPin.Text = acc.EFTPSPin;
            tEFTPSPw.Text = acc.EFTPSPw;
            tState.Text = acc.State;
            cStateTaxFreq.Text = acc.StateTaxFreq;
            tStateWH.Text = acc.StateWH;
            tStateUser.Text = acc.StateUser;
            tStatePw.Text = acc.StatePw;
            tPhilaNum.Text = acc.PhilaNum;
            cPhilaTaxFreq.Text = acc.PhilaTaxFreq;
            cPhilaPayType.Text = acc.PhilaPayType;
            tPhilaEZReportN.Text = acc.PhilaEZReportN;
            tPhilaEZPw.Text = acc.PhilaEZPw;
            tPhilaOnlinePin.Text = acc.PhilaOnlinPin;
            tLocal.Text = acc.Local;
            tLocalPSD.Text = acc.LocalPSD;
            tLocalCollector.Text = acc.LocalCollector;
            tLocalTaxFreq.Text = acc.LocalTaxFreq;
            cLocalPayType.Text = acc.LocalPayType;
            tLocalUser.Text = acc.LocalUser;
            tLocalPw.Text = acc.LocalPw;
            tLST.Text = acc.LST;
            tLSTCollector.Text = acc.LSTCollector;
            tLSTTaxFreq.Text = acc.LSTTaxFreq;
            cLSTPayType.Text = acc.LSTPayType;
            tLSTUser.Text = acc.LSTUser;
            tLSTPW.Text = acc.LSTPW;
            tUC.Text = acc.UC;
            tUCNum.Text = acc.UCNum;
            cUCPayType.Text = acc.UCPayType;
            cUCUsername.Text = acc.UCUsername;
            tUCPassword.Text = acc.UCPassword;
            tUCContactEm.Text = acc.UCContaceEM;
            tPAUCQ1.Text = acc.PAUCQ1;
            tPAUCQ2.Text = acc.PAUCQ2;
            tPAUCQ3.Text = acc.PAUCQ3;
            dFirstCheckDate.Text = acc.FirstCheckDate;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (AccNumList.SelectedIndex < AccountInfos.Count - 1)
            {
                AccNumList.SelectedIndex = AccNumList.SelectedIndex + 1;
                btnPrev.Enabled = true;
            }
            else
                btnNext.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (AccNumList.SelectedIndex > 0)
            {
                AccNumList.SelectedIndex = AccNumList.SelectedIndex - 1;
                btnNext.Enabled = true;
            }
            else
                btnPrev.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            editControls(true);
            saveStatus = "edit";
            btnSave.Enabled = true; 
        }

        private void editControls(bool flag)
        {
            tAccNum.Enabled = flag;
            tEIN.Enabled = flag;
            tEntity.Enabled = flag;
            tTradeName.Enabled = flag;
            tPayRep.Enabled = flag;
            tCkRep.Enabled = flag;
            tAccRep.Enabled = flag;
            tBusAdd1.Enabled = flag;
            tBusAdd2.Enabled = flag;
            tBusCity.Enabled = flag;
            tBusSt.Enabled = flag;
            tBusZip.Enabled = flag;
            tMailAdd1.Enabled = flag;
            tMailAdd2.Enabled = flag;
            tMailCity.Enabled = flag;
            tMailSt.Enabled = flag;
            tMailZip.Enabled = flag;
            tHomeAdd.Enabled = flag;
            tFax.Enabled = flag;
            tEmail.Enabled = flag;
            tLanguage.Enabled = flag;
            tContact1.Enabled = flag;
            tContact1Tel1.Enabled = flag;
            tContact1Tel2.Enabled = flag;
            tContact2.Enabled = flag;
            tContact2Tel1.Enabled = flag;
            tContact2Tel2.Enabled = flag;
            cPayType.Enabled = flag;
            cPayFreq.Enabled = flag;
            cTaxDepType.Enabled = flag;
            dPayStartDate.Enabled = flag;
            dPayCloseDate.Enabled = flag;
            tBank.Enabled = flag;
            tBankRtg.Enabled = flag;
            tBankAcc.Enabled = flag;
            dBankStartDate.Enabled = flag;
            cDateIn.Enabled = flag;
            cDateOut.Enabled = flag;
            tTimeToDone.Enabled = flag;
            tAveNumEE.Enabled = flag;
            tNote.Enabled = flag;
            cFedTaxFreq.Enabled = flag;
            tEFTPS.Enabled = flag;
            cF8655.Enabled = flag;
            tEFTPSPin.Enabled = flag;
            tEFTPSPw.Enabled = flag;
            tState.Enabled = flag;
            cStateTaxFreq.Enabled = flag;
            tStateWH.Enabled = flag;
            tStateUser.Enabled = flag;
            tStatePw.Enabled = flag;
            tPhilaNum.Enabled = flag;
            cPhilaTaxFreq.Enabled = flag;
            cPhilaPayType.Enabled = flag;
            tPhilaEZReportN.Enabled = flag;
            tPhilaEZPw.Enabled = flag;
            tPhilaOnlinePin.Enabled = flag;
            tLocal.Enabled = flag;
            tLocalPSD.Enabled = flag;
            tLocalCollector.Enabled = flag;
            tLocalTaxFreq.Enabled = flag;
            cLocalPayType.Enabled = flag;
            tLocalUser.Enabled = flag;
            tLocalPw.Enabled = flag;
            tLST.Enabled = flag;
            tLSTCollector.Enabled = flag;
            tLSTTaxFreq.Enabled = flag;
            cLSTPayType.Enabled = flag;
            tLSTUser.Enabled = flag;
            tLSTPW.Enabled = flag;
            tUC.Enabled = flag;
            tUCNum.Enabled = flag;
            cUCPayType.Enabled = flag;
            cUCUsername.Enabled = flag;
            tUCPassword.Enabled = flag;
            tUCContactEm.Enabled = flag;
            tPAUCQ1.Enabled = flag;
            tPAUCQ2.Enabled = flag;
            tPAUCQ3.Enabled = flag;
            dFirstCheckDate.Enabled = flag;
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            editControls(true);
            btnSave.Enabled = true;
            saveStatus = "new";
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            btnSave.Enabled = false;
            btnEdit.Enabled = true;
            editControls(false);
        }
    }
}
