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

namespace KYLDB.Reports.QuarterBillFrm
{
    public partial class QuarterBillFrm : Form
    {
        private static QuarterBillFrm singleton = null;
        public static QuarterBillFrm GetInstance()
        {
            if (singleton == null)
                singleton = new QuarterBillFrm();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private QuarterBillFrm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int year = int.Parse(comYear.Text);
            int qtr = comboBox1.SelectedIndex + 1;
            string thisQStart = "", thisQEnd = "";
            string lastQStart = "", lastQEnd = "";
            switch (qtr)
            {
                case 1:
                    thisQStart = "1/1/" + year;
                    thisQEnd = "3/31/" + year;
                    lastQStart = "10/1/" + (year - 1);
                    lastQEnd = "12/31/" + (year - 1);
                    break;
                case 2:
                    thisQStart = "4/1/" + year;
                    thisQEnd = "6/30/" + year;
                    lastQStart = "1/1/" + year;
                    lastQEnd = "3/31/" + year;
                    break;
                case 3:
                    thisQStart = "7/1/" + year;
                    thisQEnd = "9/30/" + year;
                    lastQStart = "4/1/" + year;
                    lastQEnd = "6/30/" + year;
                    break;
                case 4:
                    thisQStart = "10/1/" + year;
                    thisQEnd = "12/31/" + year;
                    lastQStart = "7/1/" + year;
                    lastQEnd = "9/30/" + year;
                    break;
            }
            string sql = @"select a.AccNum, a.Customer, a.NumOfCkThisQtr, a.NumOfCkLastQtr, 
                                  a.NumOfCkThisQtr-a.NumOfCkLastQtr as 'Difference', a.CkFee, 
                                  Convert(varchar(20),convert(money,a.CkFee)*a.NumOfCkThisQtr) as 'BillAmt'
                             from(
	                            select cp.AccNum, cp.Entity as 'Customer', ISNULL(SUM(p.NumOfCk),0) as NumOfCkThisQtr, 
                                       ISNULL(SUM(p2.NumOfCk),0) as NumOfCkLastQtr, isnull(p.CkFee,0) as 'CkFee'
	                            from ClientPayroll cp 
	                            left join PayCheck p on cp.AccNum=p.AccNum and p.PostDate between '" + thisQStart + "' and '"+ thisQEnd + @"'
	                            left join PayCheck p2 on cp.AccNum=p2.AccNum and p2.PostDate between '"+ lastQStart + "' and '"+ lastQEnd + @"'
                                group by cp.AccNum, cp.Entity, p.CkFee
                            ) a order by a.AccNum";
            DataTable dt = DBOperator.QuerySql(sql);
            List<QuarterBill> items = DBOperator.getListFromTable<QuarterBill>(dt);

            ReportParameter yearP = new ReportParameter("year", year.ToString());
            ReportParameter quarter = new ReportParameter("quarter", comboBox1.Text);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { yearP, quarter });
            ReportDataSource rds = new ReportDataSource("dsQtrBill", items);
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }

        private void QuarterBillFrm_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            for(int i = 0; i < 5; i++)
            {
                comYear.Items.Add(year - i);
            }
            this.reportViewer1.RefreshReport();
        }

        private void QuarterBillFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
