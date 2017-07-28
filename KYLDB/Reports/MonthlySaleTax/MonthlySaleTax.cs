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
            DBOperator.SetComboxRepData(comboBox1);
            string repCond = "";
            if (Main.cUser.UserLevel >= 10)
            {
                comboBox1.Enabled = true;
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.Text = Main.cUser.Rep;
                repCond = " Rep = '" + Main.cUser.Rep + "' and ";
            }
            string rep = Main.cUser.Rep;
            string month = DateTime.Now.AddMonths(-1).ToString("MMMM, yyyy");
            string sql = @"select Accountno as 'ID', Customer as 'Company', Contact, Phone, AltPhone, BalanceTotal as 'Balance', SalesTax, SalesTaxNum, 
                                  LiquorTax_Phila as 'LiquorTax', U_OTax from ClientDetail 
                            where "+repCond+@" (JobStatus='pending' 
                                  or (SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)') and JobStatus='current') 
                                  or (JobStatus<>'closed' and (LiquorTax_Phila='Yes' or U_OTax like 'Yes%')) )";
            DataTable dt = DBOperator.QuerySql(sql);
            List<SalesTaxRep> items = DBOperator.getListFromTable<SalesTaxRep>(dt);

            ReportParameter repTitle = new ReportParameter("repTitle", "Monthly Query - " + rep);
            ReportParameter repMonth = new ReportParameter("repMonth", month);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repMonth });
            ReportDataSource rds = new ReportDataSource("dsMonthlySalesTax", items);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
            this.WindowState = FormWindowState.Maximized;
        }

        private void MonthlySaleTax_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rep = comboBox1.Text;
            string month = DateTime.Now.AddMonths(-1).ToString("MMMM, yyyy");
            string sql = @"select Accountno as 'ID', Customer as 'Company', Contact, Phone, AltPhone, BalanceTotal as 'Balance', SalesTax, SalesTaxNum, 
                                  LiquorTax_Phila as 'LiquorTax', U_OTax from ClientDetail 
                            where  Rep = '" + comboBox1.Text + @"' 
                             and  (JobStatus='pending' 
                                  or (SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)') and JobStatus='current') 
                                  or (JobStatus<>'closed' and (LiquorTax_Phila='Yes' or U_OTax like 'Yes%')) )";
            DataTable dt = DBOperator.QuerySql(sql);
            List<SalesTaxRep> items = DBOperator.getListFromTable<SalesTaxRep>(dt);

            ReportParameter repTitle = new ReportParameter("repTitle", "Monthly Query - " + rep);
            ReportParameter repMonth = new ReportParameter("repMonth", month);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repMonth });
            ReportDataSource rds = new ReportDataSource("dsMonthlySalesTax", items);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }
    }
}
