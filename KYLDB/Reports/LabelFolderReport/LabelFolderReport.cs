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

namespace KYLDB.Reports.LabelFolderReport
{
    public partial class LabelFolderReport : Form
    {
        private static LabelFolderReport singleton = null;
        public static LabelFolderReport GetInstance()
        {
            if (singleton == null)
                singleton = new LabelFolderReport();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private LabelFolderReport()
        {
            InitializeComponent();
        }

        private void LabelFolderReport_Load(object sender, EventArgs e)
        {
            DBOperator.SetComboxRepData(comboBox1);
            string sql = "select AccountNo from ClientDetail ";
            string condition = "";
            if (Main.cUser.UserLevel >= Setting.ReporterLevel)
            {
                comboBox1.Enabled = true;
                comboBox1.SelectedIndex = 0;
            }
            else
            {
                comboBox1.Enabled = false;
                comboBox1.Text = Main.cUser.Rep;
                condition = " where Rep='" + Main.cUser.Rep + "'";
            }
            sql += condition;
            DataTable dt = DBOperator.QuerySql(sql);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "AccountNo";
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            comboBox1.SelectedIndex = 0;
            WindowState = FormWindowState.Maximized;
        }

        private void LabelFolderReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = @"select AccountNo, Contact, Customer, Company, Mailto1, Mailto2, Mailto3, Fee, 
                                  YearEnd, Phone, AltPhone,Fax, EIN, SalesTaxNum, StartDate, '2016' as 'corpNum' 
                           from ClientDetail where AccountNo='" + comboBox1.Text+"'";
            DataTable dt = DBOperator.QuerySql(sql);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter accountNo = new ReportParameter("accountNo", dt.Rows[0][0].ToString());
            ReportParameter contact = new ReportParameter("contact", dt.Rows[0][1].ToString());
            ReportParameter customer = new ReportParameter("customer", dt.Rows[0][2].ToString());
            ReportParameter company = new ReportParameter("company", "DBA:"+dt.Rows[0][3].ToString());
            ReportParameter mailto1 = new ReportParameter("mailto1", dt.Rows[0][4].ToString());
            ReportParameter mailto2 = new ReportParameter("mailto2", dt.Rows[0][5].ToString());
            ReportParameter mailto3 = new ReportParameter("mailto3", dt.Rows[0][6].ToString());
            ReportParameter fee = new ReportParameter("fee", dt.Rows[0][7].ToString());
            ReportParameter yearEnd = new ReportParameter("yearEnd", dt.Rows[0][8].ToString());
            ReportParameter phone = new ReportParameter("phone", dt.Rows[0][9].ToString());
            ReportParameter altphone = new ReportParameter("altphone", dt.Rows[0][10].ToString());
            ReportParameter fax = new ReportParameter("fax", dt.Rows[0][11].ToString());
            ReportParameter ein = new ReportParameter("ein", dt.Rows[0][12].ToString());
            ReportParameter saleTaxNum = new ReportParameter("saleTaxNum", dt.Rows[0][13].ToString());
            ReportParameter startDate = new ReportParameter("startDate", dt.Rows[0][14].ToString());
            ReportParameter corpNum = new ReportParameter("corpNum", dt.Rows[0][15].ToString());
            ReportParameter rep = new ReportParameter("rep", comboBox1.Text);
            reportViewer1.LocalReport.SetParameters(
                new ReportParameter[] {
                    accountNo, contact, customer, company, mailto1, mailto2, mailto3, fee, yearEnd, phone, altphone, fax, ein, saleTaxNum, startDate, corpNum, rep
                });
            this.reportViewer1.RefreshReport();
        }
        public void setAccNum(string aNum)
        {
            comboBox1.Text = aNum;
        }
    }
}
