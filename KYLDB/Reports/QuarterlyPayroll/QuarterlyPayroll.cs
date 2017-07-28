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
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string quarter = "";
            DateTime now = DateTime.Now;
            string closed = "";
            switch (month)
            {
                case 1:
                case 2:
                case 3:
                    quarter = "Q4";
                    year = year - 1;
                    closed = "Closed(Q1/" + year + "), Closed(Q2/" + year + "), Closed(Q3/" + year + "), Closed(Q4/" + year + ")";
                    break;
                case 4:
                case 5:
                case 6:
                    quarter = "Q1";
                    closed = "Closed(Q1/" + year + ")";
                    break;
                case 7:
                case 8:
                case 9:
                    quarter = "Q2";
                    closed = "Closed(Q1/" + year + "), Closed(Q2/" + year + ")";
                    break;
                case 10:
                case 11:
                case 12:
                    quarter = "Q3";
                    closed = "Closed(Q1/" + year + "), Closed(Q2/" + year + "), Closed(Q3/" + year + ")";
                    break;
            }
            string rep = Main.cUser.Rep;
            //string quarter = "Quarter: " + comboBox2.Text + ", " + comYear.Text;
            string sql = @"select AccountNo as 'ID', Company, Contact, Phone, AltPhone, '' as MemoForUpdate,
                                  BalanceTotal as 'Balance', Payroll as 'PayrollLocal', PayrollRep, PaycheckRep
                           from ClientDetail
                           where "+ repCond+@" ((JobStatus='Pending')
                                or (JobStatus='Current' and Payroll like 'Yes%')
                                or (Payroll in ("+closed+") and JobStatus in ('Closed', 'Current') ))";
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

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int month = DateTime.Now.Month;
            int year = DateTime.Now.Year;
            string quarter = "";
            DateTime now = DateTime.Now;
            string closed = "";
            switch (month)
            {
                case 1:
                case 2:
                case 3:
                    quarter = "Q4";
                    year = year - 1;
                    closed = "Closed(Q1/" + year + "), Closed(Q2/" + year + "), Closed(Q3/" + year + "), Closed(Q4/" + year + ")";
                    break;
                case 4:
                case 5:
                case 6:
                    quarter = "Q1";
                    closed = "Closed(Q1/" + year + ")";
                    break;
                case 7:
                case 8:
                case 9:
                    quarter = "Q2";
                    closed = "Closed(Q1/" + year + "), Closed(Q2/" + year + ")";
                    break;
                case 10:
                case 11:
                case 12:
                    quarter = "Q3";
                    closed = "Closed(Q1/" + year + "), Closed(Q2/" + year + "), Closed(Q3/" + year + ")";
                    break;
            }
            string rep = comboBox1.Text;
            string sql = @"select AccountNo as 'ID', Company, Contact, Phone, AltPhone, '' as MemoForUpdate,
                                  BalanceTotal as 'Balance', Payroll as 'PayrollLocal', PayrollRep, PaycheckRep
                           from ClientDetail
                           where  Rep = '" + comboBox1.Text + @"' 
                             and  ((JobStatus='Pending')
                                or (JobStatus='Current' and Payroll like 'Yes%')
                                or (Payroll in (" + closed + ") and JobStatus in ('Closed', 'Current') ))";
            DataTable dt = DBOperator.QuerySql(sql);
            List<QuarterPayroll> items = DBOperator.getListFromTable<QuarterPayroll>(dt);
            ReportParameter repTitle = new ReportParameter("repTitle", "Quarterly Query - " + rep);
            ReportParameter repQuarter = new ReportParameter("repQuarter", quarter);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repQuarter });
            ReportDataSource rds = new ReportDataSource("dsQuarterlyPayroll", items);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
