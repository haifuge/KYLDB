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

namespace KYLDB.Reports.StatisticReport
{
    public partial class StatisticReport : Form
    {
        private static StatisticReport singleton = null;
        public static StatisticReport GetInstance()
        {
            if (singleton == null)
                singleton = new StatisticReport();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        public StatisticReport()
        {
            InitializeComponent();
        }

        private void StatisticReport_Load(object sender, EventArgs e)
        {
            string sql = @"select *, I+P+C+CS as 'Total' from (
                            select r.Rep, count(cdi.Rep) as 'I', count(cdp.Rep) as 'P', count(cdc.Rep) as 'C', COUNT(cdcs.Rep) as 'CS'
                            from Representative r 
                            left join clientDetail cdi on r.Rep=cdi.Rep and cdi.CustomerType in ('Individual', 'SINGLE MEMBER LLC', 'SOLE PROPRIETORSHIP')
                            left join ClientDetail cdp on r.rep=cdp.Rep and cdp.CustomerType in ('GENERAL PARTNER LLC','PARTNERSHIP','Limited Partnership')
                            left join clientDetail cdc on r.Rep=cdc.Rep and cdc.CustomerType in ('CORP.','CORP.LLC','Corporate')
                            left join ClientDetail cdcs on r.Rep=cdcs.Rep and cdcs.CustomerType in ('S Corp.')
                            group by r.Rep) a";
            DataTable dt = DBOperator.QuerySql(sql);
            TOTALBindingSource.DataSource = dt;

            sql = @"select r.Rep, count(st.Rep) as 'ST', count(pr.Rep) as 'PR', count(liq.Rep) as 'Liquor', COUNT(uo.Rep) as 'UO'
                    from Representative r 
                    left join clientDetail st on r.Rep=st.Rep and st.SalesTax='Yes'
                    left join ClientDetail pr on r.rep=pr.Rep and pr.Payroll like 'Yes%'
                    left join clientDetail liq on r.Rep=liq.Rep and liq.LiquorTax_Phila like 'Yes%'
                    left join ClientDetail uo on r.Rep=uo.Rep and uo.U_OTax like 'Yes%'
                    group by r.Rep";
            dt = DBOperator.QuerySql(sql);
            STPRBindingSource.DataSource = dt;

            sql = @"select *, I+P+C+CS as 'Total' from (
                        select r.Rep, count(cdi.Rep) as 'I', count(cdp.Rep) as 'P', count(cdc.Rep) as 'C', COUNT(cdcs.Rep) as 'CS'
                        from Representative r 
                        left join clientDetail cdi on r.Rep=cdi.Rep and cdi.CustomerType in ('Individual', 'SINGLE MEMBER LLC', 'SOLE PROPRIETORSHIP')
                        left join ClientDetail cdp on r.rep=cdp.Rep and cdp.CustomerType in ('GENERAL PARTNER LLC','PARTNERSHIP','Limited Partnership')
                        left join clientDetail cdc on r.Rep=cdc.Rep and cdc.CustomerType in ('CORP.','CORP.LLC','Corporate')
                        left join ClientDetail cdcs on r.Rep=cdcs.Rep and cdcs.CustomerType in ('S Corp.')
                        group by r.Rep) a";
            List<TOTAL> items = DBOperator.getListFromTable<TOTAL>(dt);
            ReportDataSource peding = new ReportDataSource("dsPending", items);
            reportViewer1.LocalReport.DataSources.Add(peding);

            ReportDataSource yearly = new ReportDataSource("dsYearly", items);
            reportViewer1.LocalReport.DataSources.Add(yearly);

            ReportDataSource current = new ReportDataSource("dsCurrent", items);
            reportViewer1.LocalReport.DataSources.Add(current);

            ReportDataSource done = new ReportDataSource("dsDone", items);
            reportViewer1.LocalReport.DataSources.Add(done);

            ReportDataSource notdone = new ReportDataSource("dsNotDone", items);
            reportViewer1.LocalReport.DataSources.Add(notdone);

            this.reportViewer1.RefreshReport();
        }

        private void StatisticReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
