using KYLDB.Forms;
using KYLDB.Model;
using KYLDB.Reports;
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
    public partial class ClientPayroll : Form
    {
        List<Model.ClientPayroll> ClientPayrolls = new List<Model.ClientPayroll>();
        DataTable dt_clients;
        private ClientPayroll()
        {
            InitializeComponent();

            editControls(false);
            AutoScroll = true;
            DBOperator.SetComboxRepData(tAccRep);
            DBOperator.SetComboxRepDataFirstName(tPayRep);
            DBOperator.SetComboxRepDataFirstName(tCkRep);
        }
        private static ClientPayroll singleton = null;
        public static ClientPayroll GetInstance()
        {
            if (singleton == null)
                singleton = new ClientPayroll();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        public void SetData(string accNum)
        {
            AccNumList.Text = accNum;
        }
        private void ClientInfo_Load(object sender, EventArgs e)
        {
            string sql = @" select cp.*, ccd.FirstCheckDate from ClientPayroll cp left join ClientCheckDate ccd on cp.AccNum=ccd.AccNum ";
            dt_clients = DBOperator.QuerySql(sql);
            //ClientPayrolls = DBOperator.getListFromTable<Model.ClientPayroll>(dt);
            var acclist = from ac in dt_clients.AsEnumerable()
                          select ac[0].ToString();
            AccNumList.DataSource = acclist.ToArray();
            
            var enList = from ac in dt_clients.AsEnumerable()
                         select ac[5].ToString();
            comboBox2.DataSource = enList.ToArray();
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);

            editControls(true);
            if (Main.cUser.UserLevel >= 10)
            {
                tAccRep.Enabled = false;
                tPayRep.Enabled = false;
                tCkRep.Enabled = false;
            }
            else
            {
                dFirstCheckDate.Enabled = false;
                tAccRep.Enabled = false;
                tPayRep.Enabled = false;
                tCkRep.Enabled = false;
            }
            dFirstCheckDate.Enabled = true;
        }
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            string entity = comboBox2.Text;
            var row = (from ac in dt_clients.AsEnumerable()
                       where ac[5].ToString() == entity
                       select ac).First();
            var acc = DBOperator.getObjectFromRow<Model.ClientPayroll>(row);
            AccNumList.Text = acc.AccNum;
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
            tpayStartDate.Text = acc.PayStartDate;
            tpayCloseDate.Text = acc.PayCloseDate;
            tBank.Text = acc.Bank;
            tBankRtg.Text = acc.BankRtg;
            tBankAcc.Text = acc.BankAcc;            
            tbankStartDate.Text = acc.BankStartDate;
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
            dFirstCheckDate.Text = acc.FirstCheckDate.Trim()==""?null: acc.FirstCheckDate.Trim();
        }
        private void AccNumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            string accNum = AccNumList.Text;
            var row = (from ac in dt_clients.AsEnumerable()
                       where ac[0].ToString() == accNum
                       select ac).First();
            var acc = DBOperator.getObjectFromRow<Model.ClientPayroll>(row);
            comboBox2.Text = acc.Entity;
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
            tpayStartDate.Text = acc.PayStartDate;
            tpayCloseDate.Text = acc.PayCloseDate;
            tBank.Text = acc.Bank;
            tBankRtg.Text = acc.BankRtg;
            tBankAcc.Text = acc.BankAcc;
            tbankStartDate.Text = acc.BankStartDate;
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
            dFirstCheckDate.Text = acc.FirstCheckDate.Trim()==""?"1/1/"+DateTime.Now.Year.ToString(): acc.FirstCheckDate.Trim();
        }
        private void btnMain_Click(object sender, EventArgs e)
        {
            AccountViewList avl = AccountViewList.GetInstance();
            avl.MdiParent = this.MdiParent;
            avl.Show();
            this.Close();
        }
        private void btnMailing_Click(object sender, EventArgs e)
        {
            if (AccNumList.SelectedIndex > 0)
            {
                AccNumList.SelectedIndex = AccNumList.SelectedIndex - 1;
                btnMain.Enabled = true;
            }
        }

        private void lblFolder_Click(object sender, EventArgs e)
        {
            editControls(true);
        }

        private void editControls(bool flag)
        {
            tAccNum.Enabled = false;
            tEIN.Enabled = false;
            tEntity.Enabled = false;
            tTradeName.Enabled = false;
            tPayRep.Enabled = false;
            tCkRep.Enabled = false;
            tAccRep.Enabled = false;
            //tBusAdd1.Enabled = flag;
            //tBusAdd2.Enabled = flag;
            //tBusCity.Enabled = flag;
            //tBusSt.Enabled = flag;
            //tBusZip.Enabled = flag;
            tMailAdd1.Enabled = flag;
            tMailAdd2.Enabled = flag;
            tMailCity.Enabled = flag;
            tMailSt.Enabled = flag;
            tMailZip.Enabled = flag;
            tHomeAdd.Enabled = flag;
            //tFax.Enabled = flag;
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
    
        private void saveCurentItem()
        {
            string sql = "update ClientPayroll set EIN='" + tEIN.Text + "', AccRep='" + tAccRep.Text + "', PayRep='" + tPayRep.Text + "', CkRep='" + tCkRep.Text + "', Entity='" + tEntity.Text + "', TradeName='" + tTradeName.Text + "', BusAdd1='" + tBusAdd1.Text + "', BusAdd2='" + tBusAdd2.Text + "', BusCity='" + tBusCity.Text + "', BusSt='" + tBusSt.Text + "', BusZip='" + tBusZip.Text + @"', 
                                                 MailAdd1 = '" + tMailAdd1.Text + "', MailAdd2 = '" + tMailAdd2.Text + "', MailCity = '" + tMailCity.Text + "', MailSt = '" + tMailSt.Text + "', MailZip = '" + tMailZip.Text + "', HomeAdd = '" + tHomeAdd.Text + "', Contact1 = '" + tContact1.Text + "', Contact1Tel1 = '" + tContact1Tel1.Text + "', Contact1Tel2 = '" + tContact1Tel2.Text + "', Contact2 = '" + tContact2.Text + "', Contact2Tel1 = '" + tContact2Tel1.Text + @"', 
                                                 Contact2Tel2 = '" + tContact2Tel2.Text + "', Fax = '" + tFax.Text + "', Email = '" + tEmail.Text + "', Lauguage = '" + tLanguage.Text + "', PayStartDate = '" + dPayStartDate.Text + "', PayType = '" + cPayType.Text + "', PayFreq = '" + cPayFreq.Text + "', TaxDepType = '" + cTaxDepType.Text + "', Bank = '" + tBank.Text + "', BankRtg = '" + tBankRtg.Text + "', BankAcc = '" + tBankAcc.Text + "', BankStartDate = '" + dBankStartDate.Text + @"',
                                                 DateIn = '" + cDateIn.Text + "', DateOut = '" + cDateOut.Text + "', TimeToDone = '" + tTimeToDone.Text + "', AveNumEE = '" + tAveNumEE.Text + "', PayClosedDate = '" + dPayCloseDate.Text + "', Note = '" + tNote.Text + "', FedTaxFreq = '" + cFedTaxFreq.Text + "', EFTPS = '" + tEFTPS.Text + "', F8655 = '" + cF8655.Text + "', EFTPSPin = '" + tEFTPSPin.Text + "', EFTPSPw = '" + tEFTPSPw.Text + "', PhilaNum = '" + tPhilaNum.Text + @"',
                                                 PhilaTaxFreq = '" + cPhilaTaxFreq.Text + "', PhilaPayType = '" + cPhilaPayType.Text + "', PhilaEZReportNum = '" + tPhilaEZReportN.Text + "', PhilaEZPw = '" + tPhilaEZPw.Text + "', PhilaOnlinePin = '" + tPhilaOnlinePin.Text + "', Local = '" + tLocal.Text + "', LocalPSD = '" + tLocalPSD.Text + "', LocalCollector = '" + tLocalCollector.Text + "', LocalTaxFreq = '" + tLocalTaxFreq.Text + @"',
                                                 LocalPayType = '" + cLocalPayType.Text + "', LocalUser = '" + tLocalUser.Text + "', LocalPw = '" + tLocalPw.Text + "', LST = '" + tLST.Text + "', LSTCollector = '" + tLSTCollector.Text + "', LSTTaxFreq = '" + tLSTTaxFreq.Text + "', LSTPayType = '" + cLSTPayType.Text + "', LSTUser = '" + tLSTUser.Text + "', LSTPw = '" + tLSTPW.Text + "', UC = '" + tUC.Text + "', UCNum = '" + tUCNum.Text + "', UCPayType = '" + cUCPayType.Text + @"',
                                                 UCUsername = '" + cUCUsername.Text + "', UCPassword = '" + tUCPassword.Text + "', UCContaceEM = '" + tUCContactEm.Text + "', PAUCQ1 = '" + tPAUCQ1.Text.Replace("'", "''") + "', PAUCQ2 = '" + tPAUCQ2.Text.Replace("'", "''") + "', PAUCQ3 = '" + tPAUCQ3.Text.Replace("'", "''") + "', State = '" + tState.Text + @"',
                                                 StateTaxFreq = '" + cStateTaxFreq.Text + "', StateWH = '" + tStateWH.Text + "', StateUser = '" + tStateUser.Text + "', StatePw = '" + tStatePw.Text + @"'
                        where AccNum = '" + tAccNum.Text + "'";
            DBOperator.ExecuteSql(sql);
            sql = " select cp.*, ccd.FirstCheckDate from ClientPayroll cp left join ClientCheckDate ccd on cp.AccNum = ccd.AccNum ";
            dt_clients = DBOperator.QuerySql(sql);
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ClientPayrollRep aiRep = ClientPayrollRep.GetInstance();
            aiRep.MdiParent = this.MdiParent;
            aiRep.Show();
            aiRep.SetData(AccNumList.Text);
        }

        private void ClientInfo_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void dFirstCheckDate_ValueChanged(object sender, EventArgs e)
        {
            string accNum = tAccNum.Text;
            string sql = "delete ClientCheckDate where AccNum='" + accNum + @"'; 
                         insert into ClientCheckDate values('" + accNum + "','" + dFirstCheckDate.Text + "');";
            DBOperator.ExecuteSql(sql);

            sql = " select cp.*, ccd.FirstCheckDate from ClientPayroll cp left join ClientCheckDate ccd on cp.AccNum = ccd.AccNum ";
            dt_clients = DBOperator.QuerySql(sql);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            saveCurentItem();
            MessageBox.Show("Client payroll is saved");
        }

        private void dPayStartDate_ValueChanged(object sender, EventArgs e)
        {
            tpayStartDate.Text = dPayStartDate.Text;
        }

        private void dPayCloseDate_ValueChanged(object sender, EventArgs e)
        {
            tpayCloseDate.Text = dPayCloseDate.Text;
        }

        private void dBankStartDate_ValueChanged(object sender, EventArgs e)
        {
            tbankStartDate.Text = dBankStartDate.Text;
        }
    }
}
