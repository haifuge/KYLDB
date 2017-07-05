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

namespace KYLDB.Reports.QuarterlyPayroll
{
    public partial class QuarterlyPayroll : Form
    {
        private static QuarterlyPayroll singleton = null;
        public static QuarterlyPayroll GetInstance()
        {
            if (singleton == null)
                singleton = new QuarterlyPayroll();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private QuarterlyPayroll()
        {
            InitializeComponent();
        }

        private void QuarterPayroll_Load(object sender, EventArgs e)
        {
            string sql = "select Rep, FirstName+' '+ LastName as 'Name' from Representative order by FirstName, LastName";
            DataTable dt = DBOperator.QuerySql(sql);
            cmbRep.DataSource = dt;
            cmbRep.ValueMember = "Rep";
            cmbRep.DisplayMember = "Name";
            DateTime time = DateTime.Now;
            int year = time.Year;
            for (int i = 0; i < 5; i++)
            {
                comYear.Items.Add(year);
                year--;
            }
            comYear.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rep = "Quarterly Query - " + cmbRep.SelectedValue.ToString();
            string quarter = "Quarter: " + comboBox2.Text + ", " + comYear.Text;
            string sql = @"select AccNum as 'ID', Entity as 'Company', isnull(Contact1, Contact2) as 'Contact', Contact1Tel1 as 'Phone', Contact1Tel2 as 'AltPhone',
                            '0' as 'Balance', 'Yes (3)' as 'PayrollLocal', PayRep as 'PayrollRep', CkRep as 'PaycheckRep', '' as MemoForUpdate
                            from ClientPayroll
                            where AccNum = 'C1026'";
            DataTable dt = DBOperator.QuerySql(sql);
            List<QuarterPayroll> items = DBOperator.getListFromTable<QuarterPayroll>(dt);

            ReportParameter repTitle = new ReportParameter("repTitle", rep);
            ReportParameter repQuarter = new ReportParameter("repQuarter", quarter);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { repTitle, repQuarter });
            ReportDataSource rds = new ReportDataSource("dsQuarterlyPayroll", items);
            reportViewer1.LocalReport.DataSources.Add(rds);
            reportViewer1.RefreshReport();
        }

        private void QuarterPayroll_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}