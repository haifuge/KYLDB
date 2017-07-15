using KYLDB.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYLDB.Reports.MonthlySaleTax
{
    public partial class MonthlySaleTax : Form
    {
        private MonthlySaleTax()
        {
            InitializeComponent();
        }

        private static MonthlySaleTax singleton = null;
        public static MonthlySaleTax GetInstance()
        {
            if (singleton == null)
                singleton = new MonthlySaleTax();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }

        private void MonthlySaleTax_Load(object sender, EventArgs e)
        {
        }

        private void MonthlySaleTax_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rep = Main.cUser.Rep;
            string month = comboBox2.Text;
            string sql = @"select Accountno as 'ID', Customer as 'Company', Contact, Phone, AltPhone, BalanceTotal as 'Balance', SalesTax, SalesTaxNum, 
                                  LiquorTax_Phila as 'LiquorTax', U_OTax from ClientDetail 
                            where Rep='"+rep+ @"'  
                             and (JobStatus='pending' 
                                  or (SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)') and JobStatus='current') 
                                  or (JobStatus<>'closed' and (LiquorTax_Phila='Yes' or U_OTax like 'Yes%')) )";
            DataTable dt = DBOperator.QuerySql(sql);
            List<SalesTaxRep> items = DBOperator.getListFromTable<SalesTaxRep>(dt);
            
            ReportParameter repTitle = new ReportParameter("repTitle", rep);
            ReportParameter repMonth = new ReportParameter("repMonth", month);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repMonth });
            ReportDataSource rds = new ReportDataSource("dsMonthlySalesTax", items);
            reportViewer1.LocalReport.DataSources.Add(rds);
            
            reportViewer1.RefreshReport();
        }
    }
}
