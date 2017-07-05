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
            DBOperator.SetComboxRepDataFirstName(cmbRep);
        }

        private void RepReportFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string sql = @"select AccNum, Entity as 'Name', AccRep, PayRep, CkRep, PayType, PayFreq 
                            from ClientPayroll
                            where PayRep='"+cmbRep.Text+"'";
            DataTable dt = DBOperator.QuerySql(sql);
            List<RepReport> payRep = DBOperator.getListFromTable<RepReport>(dt);
            ReportParameter rep = new ReportParameter("rep", cmbRep.Text);
            ReportParameter repn = new ReportParameter("payRepn", dt.Rows.Count.ToString());
            
            ReportDataSource dsRep = new ReportDataSource("dsPayrollRep", payRep);
            reportViewer1.LocalReport.DataSources.Clear();
            reportViewer1.LocalReport.DataSources.Add(dsRep);
            sql = @"select AccNum, Entity as 'Name', AccRep, PayRep, CkRep, PayType, PayFreq 
                            from ClientPayroll
                            where CkRep='" + cmbRep.Text + "'";
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