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

namespace KYLDB.Reports.YearEndPayrollFrm
{
    public partial class YearEndPayrollFrm : Form
    {
        private static YearEndPayrollFrm singleton = null;
        public static YearEndPayrollFrm GetInstance()
        {
            if (singleton == null)
                singleton = new YearEndPayrollFrm();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private YearEndPayrollFrm()
        {
            InitializeComponent();
        }

        private void YearEndPayrollFrm_Load(object sender, EventArgs e)
        {
            DBOperator.SetComboxRepData(cmbRep);
            DateTime time = DateTime.Now;
            int year = time.Year;
            for (int i = 0; i < 5; i++)
            {
                comYear.Items.Add(year);
                year--;
            }
            comYear.SelectedIndex = 0;
            cmbRep.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rep = "Year End Payroll - " + cmbRep.SelectedValue.ToString();
            string quarter = "Year: " + comYear.Text;
            string sql = @"select AccNum as 'ID', Entity as 'Company', isnull(Contact1, Contact2) as 'Contact', Contact1Tel1 as 'Phone', Contact1Tel2 as 'AltPhone',
                            '0' as 'Balance', 'Yes (3)' as 'PayrollW2', PayRep as 'Payrollrep', CkRep as 'Paycheck', '' as MemoForUpdate
                            from ClientPayroll
                            where AccNum = 'C1026'";
            DataTable dt = DBOperator.QuerySql(sql);
            List<YearEndPayroll> items = DBOperator.getListFromTable<YearEndPayroll>(dt);

            ReportParameter repTitle = new ReportParameter("repTitle", rep);
            ReportParameter repYear = new ReportParameter("repYear", quarter);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repYear });
            ReportDataSource rds = new ReportDataSource("dsYearEndPayroll", items);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
