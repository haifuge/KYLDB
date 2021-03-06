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

namespace KYLDB.Reports.YearEndPayrollFrm
{
    public partial class YearEndPayrollFrm : Form
    {
        private static YearEndPayrollFrm singleton = null;
        public static YearEndPayrollFrm GetInstance()
        {
            if (singleton == null)
                singleton = new YearEndPayrollFrm();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private YearEndPayrollFrm()
        {
            InitializeComponent();
        }

        private void YearEndPayrollFrm_Load(object sender, EventArgs e)
        {
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
                comboBox1.SelectedValue = Main.cUser.Rep;
                repCond = " Rep = '" + Main.cUser.Rep + "' and ";
            }
            string rep = Main.cUser.Rep;
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            if (month != 12)
                year--;
            string sql = @"select Accountno as 'ID', Customer as 'Company', Contact, Phone, AltPhone, BalanceTotal as 'Balance',
                                  Payroll as 'PayrollW2', PayRep as 'Payrollrep', CkRep as 'Paycheck', '' as MemoForUpdate
                            from clientdetail cd left join ClientPayroll cp on cd.AccountNo=cp.AccNum
                            where "+ repCond+@" (JobStatus='pending' 
                                  or (SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)') and JobStatus='current') 
                                  or (JobStatus<>'closed' and (LiquorTax_Phila='Yes' or U_OTax like 'Yes%'))
                                  or (JobStatus='closed' and SalesTax in ('closed(Q1/" + year + ")', 'closed(Q2/" + year + ")','closed(Q3/" + year + ")','closed(Q4/" + year + @")')))
                            order by cd.JobStatus, cd.Accountno";
            DataTable dt = DBOperator.QuerySql(sql);
            List<YearEndPayroll> items = DBOperator.getListFromTable<YearEndPayroll>(dt);

            ReportParameter repTitle = new ReportParameter("repTitle", "Year End Payroll - " + rep);
            ReportParameter repYear = new ReportParameter("repYear", "Year: " + year);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repYear });
            ReportDataSource rds = new ReportDataSource("dsYearEndPayroll", items);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string rep = comboBox1.SelectedValue.ToString();
            string condition = "";
            if (rep != "All")
            {
                condition = " Rep='" + rep + "' and";
            }
            int year = DateTime.Now.Year;
            int month = DateTime.Now.Month;
            if (month != 12)
                year--;
            string sql = @"select Accountno as 'ID', Customer as 'Company', Contact, Phone, AltPhone, BalanceTotal as 'Balance',
                                  Payroll as 'PayrollW2', PayRep as 'Payrollrep', CkRep as 'Paycheck', '' as MemoForUpdate
                            from clientdetail cd left join ClientPayroll cp on cd.AccountNo=cp.AccNum
                            where "+condition+@" (JobStatus='pending' 
                                  or (SalesTax in ('Monthly','Monthly(w/ Prepay)','Monthly(Sugar)') and JobStatus='current') 
                                  or (JobStatus<>'closed' and (LiquorTax_Phila='Yes' or U_OTax like 'Yes%'))
                                  or (JobStatus='closed' and SalesTax in ('closed(Q1/" + year + ")', 'closed(Q2/" + year + ")','closed(Q3/" + year + ")','closed(Q4/" + year + @")')))
                            order by cd.JobStatus, cd.Accountno";
            DataTable dt = DBOperator.QuerySql(sql);
            List<YearEndPayroll> items = DBOperator.getListFromTable<YearEndPayroll>(dt);

            ReportParameter repTitle = new ReportParameter("repTitle", "Year End Payroll - " + rep);
            ReportParameter repYear = new ReportParameter("repYear", "Year: " + year);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repYear });
            ReportDataSource rds = new ReportDataSource("dsYearEndPayroll", items);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }
    }
}
