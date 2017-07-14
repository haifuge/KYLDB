using KYLDB.Reports.ClientDetail;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYLDB.Forms
{
    public partial class ClientDetail : Form
    {
        private static ClientDetail singleton = null;
        public static ClientDetail GetInstance()
        {
            if (singleton == null)
                singleton = new ClientDetail();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        public ClientDetail()
        {
            InitializeComponent();
        }
        
        List<KYLDB.Model.ClientDetail> details = new List<KYLDB.Model.ClientDetail>();
        KYLDB.Model.ClientDetail cAcc;
        private void ClientDetail_Load(object sender, EventArgs e)
        {
            string sql = "select * from ClientDetail";
            DataTable dt = DBOperator.QuerySql(sql);
            details = DBOperator.getListFromTable<KYLDB.Model.ClientDetail>(dt);
            var accNum = from acc in details
                         select acc.AccountNo;
            AccNumList.DataSource = accNum.ToList();
            var company = from acc in details
                          select acc.Customer;
            comboBox2.DataSource = company.ToList();
            AccNumList.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            AccNumList.SelectedIndexChanged += AccNumList_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
            enableTxt(true);
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = from acc in details
                      where acc.Customer == comboBox2.Text
                      select acc;
            cAcc = obj.First();
            setTxtValue(cAcc);
        }

        private void AccNumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = from acc in details
                      where acc.AccountNo == AccNumList.Text
                      select acc;
            cAcc = obj.First();
            setTxtValue(cAcc);
        }

        private void ClientDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
        private void setTxtValue(KYLDB.Model.ClientDetail detail)
        {
            txtAccNum.Text = detail.AccountNo;
            txtCustomer.Text = detail.Customer;
            txtRep.Text = detail.Rep;
            txtCkRep.Text = detail.PaycheckRep;
            txtPayrollRep.Text = detail.PayrollRep;
            txtCompany.Text = detail.Company;
            txtStatus.Text = detail.JobStatus;
            txtBalance.Text = detail.BalanceTotal;
            txtContact.Text = detail.Contact;
            txtFirstName.Text = detail.FirstName;
            txtMI.Text = detail.MI;
            txtLastName.Text = detail.LastName;
            txtOwners.Text = detail.Owners;
            txtPhone.Text = detail.Phone;
            txtAltPhone.Text = detail.AltPhone;
            txtFax.Text = detail.Fax;
            txtSaleTax.Text = detail.SalesTax;
            txtSalesTaxNum.Text = detail.SalesTaxNum;
            txtPayroll.Text = detail.Payroll;
            txtMailto1.Text = detail.Mailto1;
            txtMailto2.Text = detail.Mailto2;
            txtMailto3.Text = detail.Mailto3;
            txtMailto4.Text = detail.Mailto4;
            txtMailto5.Text = detail.Mailto5;
            txtMailto.Text = detail.Mailto;
            txtBusAdd1.Text = detail.BusAdd1;
            txtBusAdd2.Text = detail.BusAdd2;
            txtBusAdd3.Text = detail.BusAdd3;
            txtBusAdd4.Text = detail.BusAdd4;
            txtBusAdd5.Text = detail.BusAdd5;
            txtBusAdd.Text = detail.BusAdd;
            txtEIN.Text = detail.EIN;
            txtFee.Text = detail.Fee;
            txtCustomerType.Text = detail.CustomerType;
            txtYearEnd.Text = detail.YearEnd;
            txtTaxInfo.Text = detail.TaxInfo;
            txtTaxPrepared.Text = detail.TaxPrepared;
            txtLiquorTaxPhila.Text = detail.LiquorTax_Phila;
            txtUOTax.Text = detail.U_OTax;
            txtStartDate.Text = detail.StartDate;
            txtEndDate.Text = detail.EndDate;
            lblOwnerSS.Text = detail.OwnerSS;
            txtNote.Text = detail.Note;
        }
        private void enableTxt(bool bl)
        {
            txtAccNum.ReadOnly = bl;
            txtCustomer.ReadOnly = bl;
            txtRep.ReadOnly = bl;
            txtCkRep.ReadOnly = bl;
            txtPayrollRep.ReadOnly = bl;
            txtCompany.ReadOnly = bl;
            txtStatus.ReadOnly = bl;
            txtBalance.ReadOnly = bl;
            txtContact.ReadOnly = bl;
            txtFirstName.ReadOnly = bl;
            txtMI.ReadOnly = bl;
            txtLastName.ReadOnly = bl;
            txtOwners.ReadOnly = bl;
            txtPhone.ReadOnly = bl;
            txtAltPhone.ReadOnly = bl;
            txtFax.ReadOnly = bl;
            txtSaleTax.ReadOnly = bl;
            txtSalesTaxNum.ReadOnly = bl;
            txtPayroll.ReadOnly = bl;
            txtMailto1.ReadOnly = bl;
            txtMailto2.ReadOnly = bl;
            txtMailto3.ReadOnly = bl;
            txtMailto4.ReadOnly = bl;
            txtMailto5.ReadOnly = bl;
            txtMailto.ReadOnly = bl;
            txtBusAdd1.ReadOnly = bl;
            txtBusAdd2.ReadOnly = bl;
            txtBusAdd3.ReadOnly = bl;
            txtBusAdd4.ReadOnly = bl;
            txtBusAdd5.ReadOnly = bl;
            txtBusAdd.ReadOnly = bl;
            txtEIN.ReadOnly = bl;
            txtFee.ReadOnly = bl;
            txtCustomerType.ReadOnly = bl;
            txtYearEnd.ReadOnly = bl;
            txtTaxInfo.ReadOnly = bl;
            txtTaxPrepared.ReadOnly = bl;
            txtLiquorTaxPhila.ReadOnly = bl;
            txtUOTax.ReadOnly = bl;
            txtStartDate.ReadOnly = bl;
            txtEndDate.ReadOnly = bl;
            txtOwnerSS.ReadOnly = bl;
            txtNote.ReadOnly = bl;
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ClientDetailRep cdr = ClientDetailRep.GetInstance();
            cdr.MdiParent = this.MdiParent;
            cdr.setData(cAcc);
            cdr.Show();
        }
    }
}
