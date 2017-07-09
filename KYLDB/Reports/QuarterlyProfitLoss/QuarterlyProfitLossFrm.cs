using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KYLDB.Model;
using Microsoft.Reporting.WinForms;

namespace KYLDB.Reports.QuarterlyProfitALoss
{
    public partial class QuarterlyProfitLossFrm : Form
    {
        private static QuarterlyProfitLossFrm singleton = null;
        public static QuarterlyProfitLossFrm GetInstance()
        {
            if (singleton == null)
                singleton = new QuarterlyProfitLossFrm();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        public QuarterlyProfitLossFrm()
        {
            InitializeComponent();
        }

        private void QuarterlyProfitLoss_Load(object sender, EventArgs e)
        {
            DBOperator.SetComboxRepData(cmbRep);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User cu = ((Main)this.MdiParent).cUser;
            string rep = "Profit and Loss - " + cu.Rep;
            string month = "Month: "+monthPicker.Text.ToString();
            string sql = @"select Accountno as 'ID', Customer as 'Company', Contact, Phone, AltPhone, BalanceTotal as 'Balance', SalesTax, SalesTaxNum, 
                                  LiquorTax_Phila as 'LiquorTax', U_OTax from ClientDetail 
                            where Accountno = 'C1000'";
            DataTable dt = DBOperator.QuerySql(sql);
            List<QuarterlyProfitLoss> items = DBOperator.getListFromTable<QuarterlyProfitLoss>(dt);

            ReportParameter repTitle = new ReportParameter("repTitle", rep);
            ReportParameter repMonth = new ReportParameter("repMonth", month);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repMonth });
            ReportDataSource rds = new ReportDataSource("QuarterlyProfitLoss", items);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }

        private void QuarterlyProfitLoss_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
