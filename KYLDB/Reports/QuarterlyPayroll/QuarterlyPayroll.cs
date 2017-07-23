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

namespace KYLDB.Reports.QuarterlyPayroll
{
    public partial class QuarterlyPayroll : Form
    {
        private static QuarterlyPayroll singleton = null;
        public static QuarterlyPayroll GetInstance()
        {
            if (singleton == null)
                singleton = new QuarterlyPayroll();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private QuarterlyPayroll()
        {
            InitializeComponent();
        }

        private void QuarterPayroll_Load(object sender, EventArgs e)
        {
            //string sql = "select Rep, FirstName+' '+ LastName as 'Name' from Representative order by FirstName, LastName";
            //DataTable dt = DBOperator.QuerySql(sql);
            //cmbRep.DataSource = dt;
            //cmbRep.ValueMember = "Rep";
            //cmbRep.DisplayMember = "Name";
            //DateTime time = DateTime.Now;
            //int year = time.Year;
            //for (int i = 0; i < 5; i++)
            //{
            //    comYear.Items.Add(year);
            //    year--;
            //}
            //comYear.SelectedIndex = 0;
            //comboBox2.SelectedIndex = 0;
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string quarter = "";
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
            string rep = Main.cUser.Rep;
            //string quarter = "Quarter: " + comboBox2.Text + ", " + comYear.Text;
            string sql = @"select AccountNo as 'ID', Company, Contact, Phone, AltPhone, '' as MemoForUpdate,
                                  BalanceTotal as 'Balance', Payroll as 'PayrollLocal', PayrollRep, PaycheckRep
                           from ClientDetail
                           where Rep='" + rep + "' and payroll like 'Yes%'";
            DataTable dt = DBOperator.QuerySql(sql);
            List<QuarterPayroll> items = DBOperator.getListFromTable<QuarterPayroll>(dt);
            ReportParameter repTitle = new ReportParameter("repTitle", "Quarterly Query - " + rep);
            ReportParameter repQuarter = new ReportParameter("repQuarter", quarter);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repQuarter });
            ReportDataSource rds = new ReportDataSource("dsQuarterlyPayroll", items);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void QuarterPayroll_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
