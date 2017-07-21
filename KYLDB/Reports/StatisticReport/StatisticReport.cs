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
            string sql = @"select i.Rep, i.I, p.P, c.C, cs.CS, i.I+ p.P+c.C+cs.CS as 'Total' from
                            (select r.Rep, count(cdi.Rep) as 'I'
                            from Representative r left join ClientDetail cdi on r.Rep=cdi.Rep and cdi.CustomerType in ('Individual', 'SINGLE MEMBER LLC', 'SOLE PROPRIETORSHIP')
                            group by r.Rep) i,
                            (select r.Rep,count(cdp.Rep) as 'P'
                            from Representative r left join ClientDetail cdp on r.rep=cdp.Rep and cdp.CustomerType in ('GERNERAL PARTNER LLC','PARTNERSHIP','Limited Partnership')
                            group by r.Rep) p,
                            (select r.Rep,count(cdc.Rep) as 'C'
                            from Representative r left join ClientDetail cdc on r.Rep=cdc.Rep and cdc.CustomerType in ('CORP.','CORP.LLC','Corporate')
                            group by r.Rep) c,
                            (select r.Rep, COUNT(cdcs.Rep) as 'CS'
                            from Representative r left join ClientDetail cdcs on r.Rep=cdcs.Rep and cdcs.CustomerType in ('S Corp.')
                            group by r.Rep) cs
                            where i.Rep=p.Rep and p.Rep=c.Rep and c.Rep=cs.Rep";
            DataTable dt = DBOperator.QuerySql(sql);
            TOTALBindingSource.DataSource = dt;

            sql = @"select i.Rep, i.ST, p.PR, c.Liquor, cs.UO, i.ST+p.PR+c.Liquor+cs.UO as 'Total' from
                    (select r.Rep, count(st.Rep) as 'ST'
                    from Representative r left join ClientDetail st on r.Rep=st.Rep and st.SalesTax='Yes'
                    group by r.Rep) i,
                    (select r.Rep,count(pr.Rep) as 'PR'
                    from Representative r left join ClientDetail pr on r.rep=pr.Rep and pr.Payroll like 'Yes%'
                    group by r.Rep) p,
                    (select r.Rep,count(liq.Rep) as 'Liquor'
                    from Representative r left join ClientDetail liq on r.Rep=liq.Rep and liq.LiquorTax_Phila like 'Yes%'
                    group by r.Rep) c,
                    (select r.Rep, COUNT(uo.Rep) as 'UO'
                    from Representative r left join ClientDetail uo on r.Rep=uo.Rep and uo.U_OTax like 'Yes%'
                    group by r.Rep) cs
                    where i.Rep=p.Rep and p.Rep=c.Rep and c.Rep=cs.Rep";
            dt = DBOperator.QuerySql(sql);
            STPRBindingSource.DataSource = dt;

            sql = @"select i.Rep, i.I, p.P, c.C, cs.CS, i.I+ p.P+c.C+cs.CS as 'Total' from
                    (select r.Rep, count(cdi.Rep) as 'I'
                    from Representative r left join ClientDetail cdi on r.Rep=cdi.Rep and cdi.JobStatus = 'Pending' and cdi.CustomerType in ('Individual', 'SINGLE MEMBER LLC', 'SOLE PROPRIETORSHIP')
                    group by r.Rep) i,
                    (select r.Rep,count(cdp.Rep) as 'P'
                    from Representative r left join ClientDetail cdp on r.rep=cdp.Rep and cdp.JobStatus = 'Pending' and cdp.CustomerType in ('GERNERAL PARTNER LLC','PARTNERSHIP','Limited Partnership')
                    group by r.Rep) p,
                    (select r.Rep,count(cdc.Rep) as 'C'
                    from Representative r left join ClientDetail cdc on r.Rep=cdc.Rep and cdc.JobStatus = 'Pending' and cdc.CustomerType in ('CORP.','CORP.LLC','Corporate')
                    group by r.Rep) c,
                    (select r.Rep, COUNT(cdcs.Rep) as 'CS'
                    from Representative r left join ClientDetail cdcs on r.Rep=cdcs.Rep and cdcs.JobStatus = 'Pending' and cdcs.CustomerType in ('S Corp.')
                    group by r.Rep) cs
                    where i.Rep=p.Rep and p.Rep=c.Rep and c.Rep=cs.Rep";
            dt = DBOperator.QuerySql(sql);
            List<TOTAL> items = DBOperator.getListFromTable<TOTAL>(dt);
            ReportDataSource peding = new ReportDataSource("dsPending", items);
            reportViewer1.LocalReport.DataSources.Add(peding);

            sql = @"select i.Rep, i.I, p.P, c.C, cs.CS, i.I+ p.P+c.C+cs.CS as 'Total' from
                    (select r.Rep, count(cdi.Rep) as 'I'
                    from Representative r left join ClientDetail cdi on r.Rep=cdi.Rep and cdi.JobStatus = 'Yearly' and cdi.CustomerType in ('Individual', 'SINGLE MEMBER LLC', 'SOLE PROPRIETORSHIP')
                    group by r.Rep) i,
                    (select r.Rep,count(cdp.Rep) as 'P'
                    from Representative r left join ClientDetail cdp on r.rep=cdp.Rep and cdp.JobStatus = 'Yearly' and cdp.CustomerType in ('GERNERAL PARTNER LLC','PARTNERSHIP','Limited Partnership')
                    group by r.Rep) p,
                    (select r.Rep,count(cdc.Rep) as 'C'
                    from Representative r left join ClientDetail cdc on r.Rep=cdc.Rep and cdc.JobStatus = 'Yearly' and cdc.CustomerType in ('CORP.','CORP.LLC','Corporate')
                    group by r.Rep) c,
                    (select r.Rep, COUNT(cdcs.Rep) as 'CS'
                    from Representative r left join ClientDetail cdcs on r.Rep=cdcs.Rep and cdcs.JobStatus = 'Yearly' and cdcs.CustomerType in ('S Corp.')
                    group by r.Rep) cs
                    where i.Rep=p.Rep and p.Rep=c.Rep and c.Rep=cs.Rep";
            dt = DBOperator.QuerySql(sql);
            items = DBOperator.getListFromTable<TOTAL>(dt);
            ReportDataSource yearly = new ReportDataSource("dsYearly", items);
            reportViewer1.LocalReport.DataSources.Add(yearly);

            sql = @"select i.Rep, i.I, p.P, c.C, cs.CS, i.I+ p.P+c.C+cs.CS as 'Total' from
                    (select r.Rep, count(cdi.Rep) as 'I'
                    from Representative r left join ClientDetail cdi on r.Rep=cdi.Rep and cdi.JobStatus = 'Current' and cdi.CustomerType in ('Individual', 'SINGLE MEMBER LLC', 'SOLE PROPRIETORSHIP')
                    group by r.Rep) i,
                    (select r.Rep,count(cdp.Rep) as 'P'
                    from Representative r left join ClientDetail cdp on r.rep=cdp.Rep and cdp.JobStatus = 'Current' and cdp.CustomerType in ('GERNERAL PARTNER LLC','PARTNERSHIP','Limited Partnership')
                    group by r.Rep) p,
                    (select r.Rep,count(cdc.Rep) as 'C'
                    from Representative r left join ClientDetail cdc on r.Rep=cdc.Rep and cdc.JobStatus = 'Current' and cdc.CustomerType in ('CORP.','CORP.LLC','Corporate')
                    group by r.Rep) c,
                    (select r.Rep, COUNT(cdcs.Rep) as 'CS'
                    from Representative r left join ClientDetail cdcs on r.Rep=cdcs.Rep and cdcs.JobStatus = 'Current' and cdcs.CustomerType in ('S Corp.')
                    group by r.Rep) cs
                    where i.Rep=p.Rep and p.Rep=c.Rep and c.Rep=cs.Rep";
            dt = DBOperator.QuerySql(sql);
            items = DBOperator.getListFromTable<TOTAL>(dt);
            ReportDataSource current = new ReportDataSource("dsCurrent", items);
            reportViewer1.LocalReport.DataSources.Add(current);

            sql = @"declare @year int
                    set @year=Year(getdate())-1
                    select i.Rep, i.I, p.P, c.C, cs.CS, i.I+ p.P+c.C+cs.CS as 'Total' from
                    (select r.Rep, count(cdi.Rep) as 'I'
                    from Representative r left join ClientDetail cdi on r.Rep=cdi.Rep and cdi.TaxPrepared = @year and cdi.CustomerType in ('Individual', 'SINGLE MEMBER LLC', 'SOLE PROPRIETORSHIP')
                    group by r.Rep) i,
                    (select r.Rep,count(cdp.Rep) as 'P'
                    from Representative r left join ClientDetail cdp on r.rep=cdp.Rep and cdp.TaxPrepared = @year and cdp.CustomerType in ('GERNERAL PARTNER LLC','PARTNERSHIP','Limited Partnership')
                    group by r.Rep) p,
                    (select r.Rep,count(cdc.Rep) as 'C'
                    from Representative r left join ClientDetail cdc on r.Rep=cdc.Rep and cdc.TaxPrepared = @year and cdc.CustomerType in ('CORP.','CORP.LLC','Corporate')
                    group by r.Rep) c,
                    (select r.Rep, COUNT(cdcs.Rep) as 'CS'
                    from Representative r left join ClientDetail cdcs on r.Rep=cdcs.Rep and cdcs.TaxPrepared = @year and cdcs.CustomerType in ('S Corp.')
                    group by r.Rep) cs
                    where i.Rep=p.Rep and p.Rep=c.Rep and c.Rep=cs.Rep";
            dt = DBOperator.QuerySql(sql);
            items = DBOperator.getListFromTable<TOTAL>(dt);
            ReportDataSource done = new ReportDataSource("dsDone", items);
            reportViewer1.LocalReport.DataSources.Add(done);

            sql = @"declare @year int
                    set @year=Year(getdate())-1
                    select i.Rep, i.I, p.P, c.C, cs.CS, i.I+ p.P+c.C+cs.CS as 'Total' from
                    (select r.Rep, count(cdi.Rep) as 'I'
                    from Representative r left join ClientDetail cdi on r.Rep=cdi.Rep and (cdi.TaxPrepared <> @year or cdi.TaxPrepared='' or cdi.TaxPrepared is null) and ((cdi.JobStatus='Closed' and Year(cdi.EndDate)=@year) or (cdi.JobStatus<>'Closed' and Year(cdi.EndDate)<Year(getdate()))) and cdi.CustomerType in ('Individual', 'SINGLE MEMBER LLC', 'SOLE PROPRIETORSHIP')
                    group by r.Rep) i,
                    (select r.Rep,count(cdp.Rep) as 'P'
                    from Representative r left join ClientDetail cdp on r.rep=cdp.Rep and (cdp.TaxPrepared <> @year or cdp.TaxPrepared='' or cdp.TaxPrepared is null) and ((cdp.JobStatus='Closed' and Year(cdp.EndDate)=@year) or (cdp.JobStatus<>'Closed' and Year(cdp.EndDate)<Year(getdate()))) and cdp.CustomerType in ('GERNERAL PARTNER LLC','PARTNERSHIP','Limited Partnership')
                    group by r.Rep) p,
                    (select r.Rep,count(cdc.Rep) as 'C'
                    from Representative r left join ClientDetail cdc on r.Rep=cdc.Rep and (cdc.TaxPrepared <> @year or cdc.TaxPrepared='' or cdc.TaxPrepared is null) and ((cdc.JobStatus='Closed' and Year(cdc.EndDate)=@year) or (cdc.JobStatus<>'Closed' and Year(cdc.EndDate)<Year(getdate()))) and cdc.CustomerType in ('CORP.','CORP.LLC','Corporate')
                    group by r.Rep) c,
                    (select r.Rep, COUNT(cdcs.Rep) as 'CS'
                    from Representative r left join ClientDetail cdcs on r.Rep=cdcs.Rep and (cdcs.TaxPrepared <> @year or cdcs.TaxPrepared='' or cdcs.TaxPrepared is null) and ((cdcs.JobStatus='Closed' and Year(cdcs.EndDate)=@year) or (cdcs.JobStatus<>'Closed' and Year(cdcs.EndDate)<Year(getdate()))) and cdcs.CustomerType in ('S Corp.')
                    group by r.Rep) cs
                    where i.Rep=p.Rep and p.Rep=c.Rep and c.Rep=cs.Rep";
            dt = DBOperator.QuerySql(sql);
            items = DBOperator.getListFromTable<TOTAL>(dt);
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
