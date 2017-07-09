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
            string sql = "select Rep, FirstName+' '+ LastName as 'Name' from Representative order by FirstName, LastName";
            DataTable dt = DBOperator.QuerySql(sql);
            DateTime time = DateTime.Now;
            int year = time.Year;
            for(int i = 0; i < 5; i++)
            {
                comYear.Items.Add(year);
                year--;
            }
            comYear.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void QuarterlySalesTax_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User cu = ((Main)this.MdiParent).cUser;
            string rep = "Quarterly Query - "+cu.Rep;
            string quarter = "Quarter: " + comboBox2.Text + ", " + comYear.Text;
            string sql = @"select Accountno as 'ID', Customer as 'Company', Contact, Phone, AltPhone, BalanceTotal as 'Balance', SalesTax, SalesTaxNum, 
                                  LiquorTax_Phila as 'LiquorTax', U_OTax from ClientDetail 
                            where Rep='" + cu.Rep + @"'  
                             and (JobStatus='pending' 
                                  or (SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)') and JobStatus='current') 
                                  or (JobStatus<>'closed' and (LiquorTax_Phila='Yes' or U_OTax like 'Yes%'))
                                  or (JobStatus='closed' and SalesTax='closed("+ comboBox2.Text +"/"+comYear.Text+ ")'))";
            DataTable dt = DBOperator.QuerySql(sql);
            List<SalesTaxRep> items = DBOperator.getListFromTable<SalesTaxRep>(dt);

            ReportParameter repTitle = new ReportParameter("repTitle", rep);
            ReportParameter repQuarter = new ReportParameter("repQuarter", quarter);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repQuarter });
            ReportDataSource rds = new ReportDataSource("dsQuarterlySalesTax", items);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }
    }
}
