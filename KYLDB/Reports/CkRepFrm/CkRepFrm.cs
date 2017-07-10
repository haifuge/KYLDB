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

namespace KYLDB.Reports.CkRepFrm
{
    public partial class CkRepFrm : Form
    {
        private static CkRepFrm singleton = null;
        public static CkRepFrm GetInstance()
        {
            if (singleton == null)
                singleton = new CkRepFrm();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private CkRepFrm()
        {
            InitializeComponent();
        }

        private void CkRepFrm_Load(object sender, EventArgs e)
        {
            DBOperator.SetComboxRepDataFirstName(cmbRep);
            cmbRep.SelectedIndex = 0;
            comMonth.SelectedIndex = 0;
            int year = DateTime.Now.Year;
            for(int i = 0; i < 5; i++)
            {
                comYear.Items.Add(year--);
            }
            comYear.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ReportParameter rep = new ReportParameter("rep", cmbRep.Text);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rep });
            string sql = @"select AccNum, Entity as 'Name', PayType, PayFreq, 
	                            case when FirstCheckDate='' then CONVERT(VARCHAR(20), DATEADD(year, DATEDIFF(year, '', getdate()), ''), 101) 
		                             when FirstCheckDate is null then CONVERT(VARCHAR(20), DATEADD(year, DATEDIFF(year, '', getdate()), ''), 101) 
		                             else FirstCheckDate end as 'CkDate'
                            from ClientPayroll
                            where CkRep='" + cmbRep.Text + "'";
            DataTable dt = DBOperator.QuerySql(sql);
            List<CkRep> items=DBOperator.getListFromTable<CkRep>(dt);
            for (int i = 0; i < items.Count; i++)
            {
                string payFreq = items[i].PayFreq;
                DateTime date = DateTime.Parse(items[i].CkDate);
                string checkDate = "";
                switch (payFreq)
                {
                    case "Monthly":
                        date = date.AddMonths(comMonth.SelectedIndex);
                        checkDate = date.ToString("M/d");
                        break;
                    case "Semi-monthly":
                        date = new DateTime(DateTime.Now.Year - comYear.SelectedIndex, comMonth.SelectedIndex + 1, 15);
                        checkDate = date.ToString("M/d");
                        date = new DateTime(DateTime.Now.Year - comYear.SelectedIndex, comMonth.SelectedIndex + 1, 1).AddMonths(1).AddDays(-1);
                        checkDate += ", " + date.ToString("M/d");
                        break;
                    case "Bi-Weekly":
                        DateTime cMonth = new DateTime(DateTime.Now.Year - comYear.SelectedIndex, comMonth.SelectedIndex + 1, 1);
                        while (date < cMonth)
                        {
                            date = date.AddDays(14);
                        }
                        cMonth = cMonth.AddMonths(1);
                        while (date < cMonth)
                        {
                            checkDate += date.ToString("M/d") + ", ";
                            date = date.AddDays(14);
                        }
                        checkDate = checkDate.Substring(0, checkDate.Length - 2);
                        break;
                }
                items[i].CkDate = checkDate;
            }
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("dsCkRep", items);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void CkRepFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ReportParameter rep = new ReportParameter("rep", cmbRep.Text);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rep });
            string sql = @"select AccNum, Entity as 'Name', PayType, PayFreq, 
	                            case when FirstCheckDate='' then CONVERT(VARCHAR(20), DATEADD(year, DATEDIFF(year, '', getdate()), ''), 101) 
		                             when FirstCheckDate is null then CONVERT(VARCHAR(20), DATEADD(year, DATEDIFF(year, '', getdate()), ''), 101) 
		                             else FirstCheckDate end as 'CkDate'
                            from ClientPayroll";
            DataTable dt = DBOperator.QuerySql(sql);
            List<CkRep> items = DBOperator.getListFromTable<CkRep>(dt);
            for (int i = 0; i < items.Count; i++)
            {
                string payFreq = items[i].PayFreq;
                DateTime date = DateTime.Parse(items[i].CkDate);
                string checkDate = "";
                switch (payFreq)
                {
                    case "Monthly":
                        date = date.AddMonths(comMonth.SelectedIndex);
                        checkDate = date.ToString("M/d");
                        break;
                    case "Semi-monthly":
                        date = new DateTime(DateTime.Now.Year - comYear.SelectedIndex, comMonth.SelectedIndex + 1, 15);
                        checkDate = date.ToString("M/d");
                        date = new DateTime(DateTime.Now.Year - comYear.SelectedIndex, comMonth.SelectedIndex + 1, 1).AddMonths(1).AddDays(-1);
                        checkDate += ", " + date.ToString("M/d");
                        break;
                    case "Bi-Weekly":
                        DateTime cMonth = new DateTime(DateTime.Now.Year - comYear.SelectedIndex, comMonth.SelectedIndex + 1, 1);
                        while (date < cMonth)
                        {
                            date = date.AddDays(14);
                        }
                        cMonth = cMonth.AddMonths(1);
                        while (date < cMonth)
                        {
                            checkDate += date.ToString("M/d") + ", ";
                            date = date.AddDays(14);
                        }
                        checkDate = checkDate.Substring(0, checkDate.Length - 2);
                        break;
                }
                items[i].CkDate = checkDate;
            }
            reportViewer1.LocalReport.DataSources.Clear();
            ReportDataSource rds = new ReportDataSource("dsCkRep", items);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
