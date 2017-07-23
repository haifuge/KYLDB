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

namespace KYLDB.Reports.QuarterlySalesTax
{
    public partial class QuarterlySalesTax : Form
    {
        private static QuarterlySalesTax singleton = null;
        public static QuarterlySalesTax GetInstance()
        {
            if (singleton == null)
                singleton = new QuarterlySalesTax();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private QuarterlySalesTax()
        {
            InitializeComponent();
        }

        private void QuarterlySalesTax_Load(object sender, EventArgs e)
        {
            string rep = Main.cUser.Rep;
            //string quarter = "Quarter: " + comboBox2.Text + ", " + comYear.Text;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string quarter="";
            DateTime now = DateTime.Now;
            switch (month)
            {
                case 1:
                case 2:
                case 3:
                    quarter = "Q4";
                    year = year - 1;
                    break;
                case 4:
                case 5:
                case 6:
                    quarter = "Q1";
                    break;
                case 7:
                case 8:
                case 9:
                    quarter = "Q2";
                    break;
                case 10:
                case 11:
                case 12:
                    quarter = "Q3";
                    break;
            }
            string sql = @"select Accountno as 'ID', Customer as 'Company', Contact, Phone, AltPhone, BalanceTotal as 'Balance', SalesTax, SalesTaxNum, 
                                  LiquorTax_Phila as 'LiquorTax', U_OTax from ClientDetail 
                            where Rep='" + rep + @"'  
                             and (JobStatus='pending' 
                                  or (SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)') and JobStatus='Current') 
                                  or (JobStatus<>'closed' and (LiquorTax_Phila='Yes' or U_OTax like 'Yes%'))
                                  or (JobStatus='closed' and SalesTax='closed(" + quarter + "/" + year.ToString() + ")'))";
            DataTable dt = DBOperator.QuerySql(sql);
            List<SalesTaxRep> items = DBOperator.getListFromTable<SalesTaxRep>(dt);

            ReportParameter repTitle = new ReportParameter("repTitle", "Quarterly Query - " + rep);
            ReportParameter repQuarter = new ReportParameter("repQuarter", "Quarter: " + quarter+", "+year.ToString());
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repQuarter });
            ReportDataSource rds = new ReportDataSource("dsQuarterlySalesTax", items);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }

        private void QuarterlySalesTax_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
        
    }
}
