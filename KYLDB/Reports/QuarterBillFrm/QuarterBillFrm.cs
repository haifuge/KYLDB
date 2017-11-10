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
        
        private void QuarterBillFrm_Load(object sender, EventArgs e)
        {
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            string quarter = "";
            string thisQStart = "", thisQEnd = "";
            string lastQStart = "", lastQEnd = "";
            switch (month)
            {
                case 1:
                case 2:
                case 3:
                    thisQStart = "1/1/" + year;
                    thisQEnd = "3/31/" + year;
                    lastQStart = "10/1/" + (year - 1);
                    lastQEnd = "12/31/" + (year - 1);
                    quarter = "Q4";
                    break;
                case 4:
                case 5:
                case 6:
                    thisQStart = "4/1/" + year;
                    thisQEnd = "6/30/" + year;
                    lastQStart = "1/1/" + year;
                    lastQEnd = "3/31/" + year;
                    quarter = "Q1";
                    break;
                case 7:
                case 8:
                case 9:
                    thisQStart = "7/1/" + year;
                    thisQEnd = "9/30/" + year;
                    lastQStart = "4/1/" + year;
                    lastQEnd = "6/30/" + year;
                    quarter = "Q2";
                    break;
                case 10:
                case 11:
                case 12:
                    thisQStart = "10/1/" + year;
                    thisQEnd = "12/31/" + year;
                    lastQStart = "7/1/" + year;
                    lastQEnd = "9/30/" + year;
                    quarter = "Q3";
                    break;
            }
            cmbQuarter.Text = quarter;
            year = DateTime.Now.Year;
            for(int i=0;i<3;i++)
            {
                cmbYear.Items.Add(year-i);
            }
            cmbYear.SelectedIndex = 0;
            string sql = @"select a.AccNum, a.Customer, a.NumOfCkThisQtr, a.NumOfCkLastQtr, a.CkFee,
                                  a.NumOfCkThisQtr-a.NumOfCkLastQtr as 'Difference', convert(varchar(20),a.BillAmt) as 'BillAmt'
                            from(
	                            select cp.AccNum, cp.Entity as 'Customer', ISNULL(SUM(p.NumOfCk),0) as NumOfCkThisQtr, 
                                        ISNULL(SUM(p2.NumOfCk),0) as NumOfCkLastQtr, max(p.CkFee) as 'CkFee',
                                        sum(case when p.BillAmount is null then 0 else Convert(money,REPLACE(p.BillAmount,'$','')) end) as 'BillAmt'
	                            from ClientPayroll cp 
	                            left join PayCheck p on cp.AccNum=p.AccNum and p.PostDate between '" + thisQStart + "' and '" + thisQEnd + @"'
	                            left join PayCheck p2 on cp.AccNum=p2.AccNum and p2.PostDate between '" + lastQStart + "' and '" + lastQEnd + @"'
                                group by cp.AccNum, cp.Entity
                            ) a where a.BillAmt>0 order by a.AccNum";
            DataTable dt = DBOperator.QuerySql(sql);
            List<QuarterBill> items = DBOperator.getListFromTable<QuarterBill>(dt);
            ReportParameter yearP = new ReportParameter("year", year.ToString());
            ReportParameter quarterp = new ReportParameter("quarter", quarter);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { yearP, quarterp });
            ReportDataSource rds = new ReportDataSource("dsQtrBill", items);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }

        private void QuarterBillFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            string quarter = cmbQuarter.Text;
            int year = int.Parse(cmbYear.Text);
            string thisQStart = "", thisQEnd = "";
            string lastQStart = "", lastQEnd = "";
            switch (quarter)
            {
                case "Q1":
                    thisQStart = "1/1/" + year;
                    thisQEnd = "3/31/" + year;
                    lastQStart = "10/1/" + (year - 1);
                    lastQEnd = "12/31/" + (year - 1);
                    break;
                case "Q2":
                    thisQStart = "4/1/" + year;
                    thisQEnd = "6/30/" + year;
                    lastQStart = "1/1/" + year;
                    lastQEnd = "3/31/" + year;
                    break;
                case "Q3":
                    thisQStart = "7/1/" + year;
                    thisQEnd = "9/30/" + year;
                    lastQStart = "4/1/" + year;
                    lastQEnd = "6/30/" + year;
                    break;
                case "Q4":
                    thisQStart = "10/1/" + year;
                    thisQEnd = "12/31/" + year;
                    lastQStart = "7/1/" + year;
                    lastQEnd = "9/30/" + year;
                    break;
            }
            string sql = @"select a.AccNum, a.Customer, a.NumOfCkThisQtr, a.NumOfCkLastQtr, a.CkFee,
                                  a.NumOfCkThisQtr-a.NumOfCkLastQtr as 'Difference', convert(varchar(20),a.BillAmt) as 'BillAmt'
                             from(
	                            select cp.AccNum, cp.Entity as 'Customer', ISNULL(SUM(p.NumOfCk),0) as NumOfCkThisQtr, 
                                       ISNULL(SUM(p2.NumOfCk),0) as NumOfCkLastQtr, max(p.CkFee) as 'CkFee',
                                       sum(case when p.BillAmount is null then 0 else Convert(money,REPLACE(p.BillAmount,'$','')) end) as 'BillAmt'
	                            from ClientPayroll cp 
	                            left join PayCheck p on cp.AccNum=p.AccNum and p.PostDate between '" + thisQStart + "' and '" + thisQEnd + @"'
	                            left join PayCheck p2 on cp.AccNum=p2.AccNum and p2.PostDate between '" + lastQStart + "' and '" + lastQEnd + @"'
                                group by cp.AccNum, cp.Entity
                            ) a order by a.AccNum";
            DataTable dt = DBOperator.QuerySql(sql);
            List<QuarterBill> items = DBOperator.getListFromTable<QuarterBill>(dt);
            ReportParameter yearP = new ReportParameter("year", year.ToString());
            ReportParameter quarterp = new ReportParameter("quarter", quarter);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { yearP, quarterp });
            ReportDataSource rds = new ReportDataSource("dsQtrBill", items);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }
    }
}
