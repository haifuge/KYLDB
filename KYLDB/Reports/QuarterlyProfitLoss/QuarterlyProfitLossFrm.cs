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

namespace KYLDB.Reports.QuarterlyProfitALoss
{
    public partial class QuarterlyProfitLossFrm : Form
    {
        private static QuarterlyProfitLossFrm singleton = null;
        public static QuarterlyProfitLossFrm GetInstance()
        {
            if (singleton == null)
                singleton = new QuarterlyProfitLossFrm();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        public QuarterlyProfitLossFrm()
        {
            InitializeComponent();
        }

        private void QuarterlyProfitLoss_Load(object sender, EventArgs e)
        {
            string rep = Main.cUser.Rep;
            string month = DateTime.Now.AddMonths(-1).ToString("MMMMM, yyyy");
            string year = DateTime.Now.Year.ToString();
            string sql = @"select AccountNo as 'ID', Company, Contact, Phone, AltPhone
                            from ClientDatail
                            where Rep = '" + Main.cUser.Rep + @"' 
                             and (JobStatus in ('Current', 'Yearly','Pending') 
                                  or ((SalesTax in ('Closed(1Q/2016)','Closed(2Q/2016)','Closed(3Q/2016)','Closed(4Q/2016)') or Payroll in ('Closed(1Q/2016)','Closed(2Q/2016)','Closed(3Q/2016)','Closed(4Q/2016)')) 
                                        and JobStatus = 'Closed' and EndDate between '1/1/'"+year+"' and '12/31/"+year+"')";
            DataTable dt = DBOperator.QuerySql(sql);
            List<QuarterlyProfitLoss> items = DBOperator.getListFromTable<QuarterlyProfitLoss>(dt);

            ReportParameter repTitle = new ReportParameter("repTitle", "Profit and Loss - " + rep);
            ReportParameter repMonth = new ReportParameter("repMonth", "Month: " + month);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repMonth });
            ReportDataSource rds = new ReportDataSource("QuarterlyProfitLoss", items);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
           
        }

        private void QuarterlyProfitLoss_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
