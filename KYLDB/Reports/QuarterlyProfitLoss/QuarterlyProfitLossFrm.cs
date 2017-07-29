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
            WindowState = FormWindowState.Maximized;
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
            string month = DateTime.Now.AddMonths(-1).ToString("MMMMM, yyyy");
            string year = (DateTime.Now.Year-1).ToString();
            string sql = @"select AccountNo as 'ID', Company, Contact, Phone, AltPhone
                            from ClientDetail
                            where "+repCond+@" (JobStatus in ('Current', 'Yearly','Pending') 
                                  or ((SalesTax in ('Closed(1Q/" + year + ")','Closed(2Q/" + year + ")','Closed(3Q/" + year + ")','Closed(4Q/" + year + @")') 
                                        or Payroll in ('Closed(1Q/" + year + ")','Closed(2Q/" + year + ")','Closed(3Q/" + year + ")','Closed(4Q/" + year + @")')) 
                                        and JobStatus = 'Closed' and EndDate between '1/1/"+year+"' and '12/31/"+year+"'))";
            DataTable dt = DBOperator.QuerySql(sql);
            List<QuarterlyProfitLoss> items = DBOperator.getListFromTable<QuarterlyProfitLoss>(dt);

            ReportParameter repTitle = new ReportParameter("repTitle", "Profit and Loss - " + rep);
            ReportParameter repMonth = new ReportParameter("repMonth", "Month: " + month);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repMonth });
            ReportDataSource rds = new ReportDataSource("QuarterlyProfitLoss", items);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }
        
        private void QuarterlyProfitLoss_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rep = comboBox1.SelectedValue.ToString();
            string condition = "";
            if (rep != "All")
            {
                condition = " Rep = '" + rep + "' and ";
            }
            string month = DateTime.Now.AddMonths(-1).ToString("MMMMM, yyyy");
            string year = (DateTime.Now.Year - 1).ToString();
            string sql = @"select AccountNo as 'ID', Company, Contact, Phone, AltPhone
                            from ClientDetail
                            where " + condition + @"  (JobStatus in ('Current', 'Yearly','Pending') 
                                  or ((SalesTax in ('Closed(1Q/" + year + ")','Closed(2Q/" + year + ")','Closed(3Q/" + year + ")','Closed(4Q/" + year + @")') 
                                        or Payroll in ('Closed(1Q/" + year + ")','Closed(2Q/" + year + ")','Closed(3Q/" + year + ")','Closed(4Q/" + year + @")')) 
                                        and JobStatus = 'Closed' and EndDate between '1/1/" + year + "' and '12/31/" + year + "'))";
            DataTable dt = DBOperator.QuerySql(sql);
            List<QuarterlyProfitLoss> items = DBOperator.getListFromTable<QuarterlyProfitLoss>(dt);

            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter repTitle = new ReportParameter("repTitle", "Profit and Loss - " + rep);
            ReportParameter repMonth = new ReportParameter("repMonth", "Month: " + month);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repMonth });
            ReportDataSource rds = new ReportDataSource("QuarterlyProfitLoss", items);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }
    }
}
