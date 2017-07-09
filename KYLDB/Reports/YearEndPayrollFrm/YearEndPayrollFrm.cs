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
            DateTime time = DateTime.Now;
            int year = time.Year;
            for (int i = 0; i < 5; i++)
            {
                comYear.Items.Add(year);
                year--;
            }
            comYear.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User cu = ((Main)this.MdiParent).cUser;
            string rep = "Year End Payroll - " + cu.Rep;
            string quarter = "Year: " + comYear.Text;
            string sql = @"select Accountno as 'ID', Customer as 'Company', Contact, Phone, AltPhone, BalanceTotal as 'Balance',
                                  Payroll as 'PayrollW2', PayRep as 'Payrollrep', CkRep as 'Paycheck', '' as MemoForUpdate
                            from clientdetail cd left join ClientPayroll cp on cd.AccountNo=cp.AccNum
                            where Rep='" + cu.Rep + @"'  
                             and (JobStatus='pending' 
                                  or (SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)') and JobStatus='current') 
                                  or (JobStatus<>'closed' and (LiquorTax_Phila='Yes' or U_OTax like 'Yes%'))
                                  or (JobStatus='closed' and SalesTax='closed(" + comboBox2.Text + "/" + comYear.Text + ")'))";
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
