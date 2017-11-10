using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KYLDB.Model;
using Microsoft.Reporting.WinForms;

namespace KYLDB.Reports.PayrollRepNumFrm
{
    public partial class PayrollRepNumFrm : Form
    {
        private static PayrollRepNumFrm singleton = null;
        public static PayrollRepNumFrm GetInstance()
        {
            if (singleton == null)
                singleton = new PayrollRepNumFrm();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private PayrollRepNumFrm()
        {
            InitializeComponent();
        }

        private void PayrollRepNumFrm_Load(object sender, EventArgs e)
        {
            string sql = @"select r.Rep as 'Rep', count(ar.Rep) as 'AccRep', count(pr.PayrollRep) as 'PayRep', COUNT(cr.PaycheckRep) as 'CkRep'
                            from Representative r 
                            left join ClientDetail ar on r.Rep=ar.Rep and ar.JobStatus in ('Current', 'Yearly', 'Pending') and ar.Payroll like 'Yes%'
                            left join ClientDetail pr on r.Rep=pr.PayrollRep and pr.JobStatus in ('Current', 'Yearly', 'Pending') and pr.Payroll like 'Yes%'
                            left join ClientDetail cr on r.Rep=cr.PaycheckRep and cr.JobStatus in ('Current', 'Yearly', 'Pending') and cr.Payroll like 'Yes%'
                            group by r.Rep
                            order by r.Rep";
            //  and cr.JosStatus='Current' and cr.Payroll like 'Yes%'

            DataTable dt = DBOperator.QuerySql(sql);
            List<PayrollRepNum> reps = DBOperator.getListFromTable<PayrollRepNum>(dt);
            sql = "select count(1) from ClientPayroll";
            string total = DBOperator.QuerySql(sql).Rows[0][0].ToString();
            ReportParameter totalParameter = new ReportParameter("total", total);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { totalParameter });
            //ReportDataSource rds = new ReportDataSource("dsPayrollRepNum", reps);
            //reportViewer1.LocalReport.DataSources.Add(rds);
            PayrollRepNumBindingSource.DataSource = reps;
            this.reportViewer1.RefreshReport();
        }

        private void PayrollRepNumFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
