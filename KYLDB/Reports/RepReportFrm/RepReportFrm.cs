﻿using KYLDB.Model;
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

namespace KYLDB.Reports.RepReportFrm
{
    public partial class RepReportFrm : Form
    {
        private static RepReportFrm singleton = null;
        public static RepReportFrm GetInstance()
        {
            if (singleton == null)
                singleton = new RepReportFrm();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private RepReportFrm()
        {
            InitializeComponent();
        }

        private void RepReportFrm_Load(object sender, EventArgs e)
        {
            DBOperator.SetComboxRepData(cmbRep);
            string repCond = "";
            string ckrepCond = "";
            if (Main.cUser.UserLevel >= Setting.ReporterLevel)
            {
                cmbRep.Enabled = true;
                cmbRep.SelectedIndex = 0;
            }
            else
            {
                cmbRep.Enabled = false;
                cmbRep.SelectedValue = Main.cUser.Rep;
                repCond = " and cp.PayRep = '" + Main.cUser.Rep + "' ";
                ckrepCond = " and cp.CkRep = '" + Main.cUser.Rep + "' ";
            }
            string sql = @"select cp.AccNum, cp.Entity as 'Name', cp.AccRep, cp.PayRep, cp.CkRep, cp.PayType, cp.PayFreq 
                            from ClientPayroll cp inner join ClientDetail cd on cp.accnum=cd.AccountNo 
                            where cd.JobStatus in ('Current', 'Pending') and cd.Payroll like 'Yes%' " + repCond+@" order by cp.AccNum";
            DataTable dt = DBOperator.QuerySql(sql);
            List<RepReport> payRep = DBOperator.getListFromTable<RepReport>(dt);
            ReportParameter rep = new ReportParameter("rep", cmbRep.Text);
            ReportParameter repn = new ReportParameter("payRepn", dt.Rows.Count.ToString());

            ReportDataSource dsRep = new ReportDataSource("dsPayrollRep", payRep);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dsRep);
            sql = @"select cp.AccNum, cp.Entity as 'Name', cp.AccRep, cp.PayRep, cp.CkRep, cp.PayType, cp.PayFreq 
                    from ClientPayroll cp inner join ClientDetail cd on cp.accnum=cd.AccountNo 
                    where cd.JobStatus in ('Current', 'Pending') and cd.Payroll like 'Yes%' " + ckrepCond + @"  order by cp.AccNum";
            dt = DBOperator.QuerySql(sql);

            ReportParameter ckrepn = new ReportParameter("ckRepn", dt.Rows.Count.ToString());
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rep, repn, ckrepn });

            List<RepReport> ckrep = DBOperator.getListFromTable<RepReport>(dt);
            ReportDataSource dsck = new ReportDataSource("dsCheckRep", ckrep);
            reportViewer1.LocalReport.DataSources.Add(dsck);
            reportViewer1.RefreshReport();
        }

        private void RepReportFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
        

        private void cmbRep_SelectedIndexChanged(object sender, EventArgs e)
        {
            string Paycondition = "";
            string CkCondition = "";
            string re = cmbRep.Text;
            if (re == "All")
            {
                Paycondition = "";
            }
            else
            {
                Paycondition = " and cp.PayRep='" + cmbRep.SelectedValue.ToString() + "' ";
                CkCondition = " and cp.CkRep='" + cmbRep.SelectedValue.ToString() + "' ";
            }
            string sql = @"select cp.AccNum, cp.Entity as 'Name', cp.AccRep, cp.PayRep, cp.CkRep, cp.PayType, cp.PayFreq 
                            from ClientPayroll cp inner join ClientDetail cd on cp.accnum=cd.AccountNo 
                            where cd.JobStatus in ('Current', 'Pending') and cd.Payroll like 'Yes%'  " + Paycondition+" order by cp.AccNum";
            DataTable dt = DBOperator.QuerySql(sql);
            List<RepReport> payRep = DBOperator.getListFromTable<RepReport>(dt);
            ReportParameter rep = new ReportParameter("rep", re);
            ReportParameter repn = new ReportParameter("payRepn", dt.Rows.Count.ToString());

            ReportDataSource dsRep = new ReportDataSource("dsPayrollRep", payRep);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dsRep);
            sql = @"select cp.AccNum, cp.Entity as 'Name', cp.AccRep, cp.PayRep, cp.CkRep, cp.PayType, cp.PayFreq 
                    from ClientPayroll cp inner join ClientDetail cd on cp.accnum=cd.AccountNo 
                    where cd.JobStatus in ('Current', 'Pending') and cd.Payroll like 'Yes%'  " + CkCondition+"  order by cp.AccNum";
            dt = DBOperator.QuerySql(sql);

            ReportParameter ckrepn = new ReportParameter("ckRepn", dt.Rows.Count.ToString());
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rep, repn, ckrepn });

            List<RepReport> ckrep = DBOperator.getListFromTable<RepReport>(dt);
            ReportDataSource dsck = new ReportDataSource("dsCheckRep", ckrep);
            reportViewer1.LocalReport.DataSources.Add(dsck);
            reportViewer1.RefreshReport();
        }
    }
}
