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
            if (Main.cUser.UserLevel >= Setting.ReporterLevel)
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
            int mon = DateTime.Now.Month;
            string monthCond = "";
            switch (mon)
            {
                case 1:
                case 2:
                case 4:
                case 5:
                case 7:
                case 8:
                case 10:
                case 11:
                    monthCond = "SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)')";
                    break;
                case 3:
                    monthCond = "SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)', 'Quarterly', 'Closed(1Q/" + DateTime.Now.AddMonths(-1).Year.ToString() + ")')";
                    break;
                case 9:
                    monthCond = "SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)', 'Quarterly', 'Closed(3Q/" + DateTime.Now.AddMonths(-1).Year.ToString() + ")')";
                    break;
                case 6:
                    monthCond = "SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)', 'Quarterly', 'Half-Year', 'Closed(2Q/" + DateTime.Now.AddMonths(-1).Year.ToString() + ")')";
                    break;
                case 12:
                    monthCond = "SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)', 'Quarterly', 'Half-Year', 'Closed(4Q/" + DateTime.Now.AddMonths(-1).Year.ToString() + ")')";
                    break;
            }
            string month = DateTime.Now.AddMonths(-1).ToString("MMMM, yyyy");
            string sql = @"select Accountno as 'ID', Customer as 'Company', Contact, Phone, AltPhone, BalanceTotal as 'Balance', SalesTax, SalesTaxNum, 
                                  LiquorTax_Phila as 'LiquorTax', U_OTax from ClientDetail 
                            where "+repCond+ @" (JobStatus='pending' 
                                  or ("+ monthCond + @" and JobStatus='current') 
                                  or (JobStatus<>'closed' and (LiquorTax_Phila='Yes' or U_OTax like 'Yes%')) )
                            order by JobStatus, Accountno";
            DataTable dt = DBOperator.QuerySql(sql);
            int total = dt.Rows.Count;
            List<SalesTaxRep> items = DBOperator.getListFromTable<SalesTaxRep>(dt);
            ReportParameter repTitle = new ReportParameter("repTitle", "Monthly Query - " + rep);
            ReportParameter repMonth = new ReportParameter("repMonth", month);
            ReportParameter totalPar = new ReportParameter("totalNum", "Total #: "+total.ToString());
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repMonth, totalPar });
            ReportDataSource rds = new ReportDataSource("dsMonthlySalesTax", items);
            reportViewer1.LocalReport.DataSources.Clear();
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
            string rep = comboBox1.SelectedValue.ToString();
            string month = DateTime.Now.AddMonths(-1).ToString("MMMM, yyyy");
            string condition = "";
            if (rep != "All")
            {
                condition = " Rep = '" + rep + "' and ";
            }
            string sql = @"select Accountno as 'ID', Customer as 'Company', Contact, Phone, AltPhone, BalanceTotal as 'Balance', SalesTax, SalesTaxNum, 
                                  LiquorTax_Phila as 'LiquorTax', U_OTax from ClientDetail 
                            where " + condition + @"  (JobStatus='pending' 
                                  or (SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)') and JobStatus='current') 
                                  or (JobStatus<>'closed' and (LiquorTax_Phila='Yes' or U_OTax like 'Yes%')) )
                            order by JobStatus, Accountno";
            DataTable dt = DBOperator.QuerySql(sql);
            List<SalesTaxRep> items = DBOperator.getListFromTable<SalesTaxRep>(dt);
            int total = dt.Rows.Count;
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter repTitle = new ReportParameter("repTitle", "Monthly Query - " + rep);
            ReportParameter repMonth = new ReportParameter("repMonth", month);
            ReportParameter totalPar = new ReportParameter("totalNum", "Total #: " + total.ToString());
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repMonth, totalPar });
            ReportDataSource rds = new ReportDataSource("dsMonthlySalesTax", items);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }
    }
}
