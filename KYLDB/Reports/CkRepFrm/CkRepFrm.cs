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
            this.WindowState = FormWindowState.Maximized;
            DBOperator.SetComboxRepData(cmbRep);
            cmbRep.SelectedIndex = DateTime.Now.Month-1;
            comMonth.SelectedIndex = 0;
            int year = DateTime.Now.Year;
            for(int i = 0; i < 5; i++)
            {
                comYear.Items.Add(year--);
            }
            comYear.SelectedIndex = 0;
            if (Main.cUser.UserLevel >= Setting.ReporterLevel)
            {
                cmbRep.Enabled = true;
                cmbRep.SelectedIndex = 0;
            }
            else
            {
                cmbRep.Enabled = false;
                cmbRep.Text = Main.cUser.FirstName+" "+Main.cUser.LastName;
                cmbRep.SelectedValue = Main.cUser.Rep;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] mdays = new int[] { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            string re = cmbRep.SelectedValue.ToString();
            ReportParameter rep = new ReportParameter("rep", re);
            string condition = "";
            if (re != "All")
            {
                condition = " where cp.CkRep = '" + re + "' ";
            }
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rep });
            string sql = @"select cp.AccNum, cp.Entity as 'Name', cp.PayType, cp.PayFreq, 
	                            case when ccd.FirstCheckDate='' then CONVERT(VARCHAR(20), DATEADD(year, DATEDIFF(year, '', getdate()), ''), 101) 
		                             when ccd.FirstCheckDate is null then CONVERT(VARCHAR(20), DATEADD(year, DATEDIFF(year, '', getdate()), ''), 101) 
		                             else ccd.FirstCheckDate end as 'CkDate',FedTaxFreq, DateIn as 'Datain', DateOut as 'Dataout', PhilaTaxFreq, StateTaxFreq
                            from ClientPayroll cp 
                            inner join ClientDetail cd on cp.AccNum=cd.AccountNo and cd.JobStatus='Current' and cp.PayType in ('Actual Check', 'Paper Check', 'PDF', 'No Check', 'Check Register', 'Tax Deposit')
                            left join ClientCheckDate ccd on cp.AccNum=ccd.AccNum" + condition + " order by cp.AccNum";
            DataTable dt = DBOperator.QuerySql(sql);
            List<CkRep> items=DBOperator.getListFromTable<CkRep>(dt);
            for (int i = 0; i < items.Count; i++)
            {
                string payFreq = items[i].PayFreq;
                DateTime date = DateTime.Parse(items[i].CkDate);
                int day = date.Day;
                string checkDate = "";
                DateTime cMonth = new DateTime(DateTime.Now.Year - comYear.SelectedIndex, comMonth.SelectedIndex + 1, 1);
                switch (payFreq)
                {
                    case "Monthly":
                        if (day > mdays[comMonth.SelectedIndex])
                            day = mdays[comMonth.SelectedIndex];
                        date = new DateTime(DateTime.Now.Year - comYear.SelectedIndex, comMonth.SelectedIndex + 1, day);
                        checkDate = date.ToString("M/d");
                        break;
                    case "Semi-monthly":
                        if (day > mdays[comMonth.SelectedIndex])
                            day = mdays[comMonth.SelectedIndex];
                        if (day > 15)
                            day -= 15;
                        date = new DateTime(DateTime.Now.Year - comYear.SelectedIndex, comMonth.SelectedIndex + 1, day);
                        checkDate = date.ToString("M/d");
                        if (day == 15)
                            date = date.AddDays(mdays[comMonth.SelectedIndex] - 15);
                        else
                            date = date.AddDays(15);
                        checkDate += ", " + date.ToString("M/d");
                        break;
                    case "Bi-Weekly":
                    case "Biweekly":
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
                        if(checkDate.Length>2)
                            checkDate = checkDate.Substring(0, checkDate.Length - 2);
                        break;
                    case "Weekly":
                        if (date < cMonth)
                        {
                            while (date.Year != cMonth.Year && date.Month != cMonth.Month)
                            {
                                date = date.AddDays(7);
                            }
                            while (date.Month == cMonth.Month)
                            {
                                checkDate += date.ToString("M/d") + ", ";
                                date = date.AddDays(7);
                            }
                        }
                        else
                        {
                            while (date.Year != cMonth.Year && date.Month != cMonth.Month)
                            {
                                date = date.AddDays(-7);
                            }
                            while (date.Month == cMonth.Month)
                            {
                                checkDate = date.ToString("M/d") + ", "+ checkDate;
                                date = date.AddDays(-7);
                            }
                        }
                        if (checkDate.Length > 2)
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
    }
}
