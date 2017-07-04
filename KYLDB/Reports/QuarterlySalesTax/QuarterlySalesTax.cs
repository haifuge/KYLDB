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
            cmbRep.DataSource = dt;
            cmbRep.ValueMember = "Rep";
            cmbRep.DisplayMember = "Name";
            DateTime time = new DateTime();
            int year = time.Year;
            for(int i = 0; i < 5; i++)
            {
                comYear.Items.Add(year);
                year--;
            }
        }

        private void QuarterlySalesTax_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rep = "Quarterly Query - "+cmbRep.SelectedValue.ToString();
            string quarter = "Quarter: " + comboBox2.Text + ", " + comYear.Text;
            string sql = @"select Accountno as 'ID', Customer as 'Company', Contact, Phone, AltPhone, BalanceTotal as 'Balance', SalesTax, SalesTaxNum, 
                                  LiquorTax_Phila as 'LiquorTax', U_OTax from ClientDetail 
                            where Accountno = 'C1000'";
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
