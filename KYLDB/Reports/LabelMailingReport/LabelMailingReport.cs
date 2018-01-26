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

namespace KYLDB.Reports.LabelMailingReport
{
    public partial class LabelMailingReport : Form
    {
        private static LabelMailingReport singleton = null;
        public static LabelMailingReport GetInstance()
        {
            if (singleton == null)
                singleton = new LabelMailingReport();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private LabelMailingReport()
        {
            InitializeComponent();
        }

        private void LabelMailingReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void LabelMailingReport_Load(object sender, EventArgs e)
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
            comboBox1.SelectedIndex = 0;
            setReport();
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            WindowState = FormWindowState.Maximized;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            setReport();
        }
        private void setReport()
        {
            string sql = @"select Mailto1, Mailto2, Mailto3, Mailto4, Mailto5 from ClientDetail where AccountNo='" + comboBox1.Text + "'";
            DataTable dt = DBOperator.QuerySql(sql);
            reportViewer1.LocalReport.DataSources.Clear();
            ReportParameter mailto1 = new ReportParameter("mailto1", dt.Rows[0][0].ToString());
            ReportParameter mailto2 = new ReportParameter("mailto2", dt.Rows[0][1].ToString());
            ReportParameter mailto3 = new ReportParameter("mailto3", dt.Rows[0][2].ToString());
            ReportParameter mailto4 = new ReportParameter("mailto4", "mail to 4....."); //dt.Rows[0][3].ToString());
            ReportParameter mailto5 = new ReportParameter("mailto5", "mail to 5.....");// dt.Rows[0][4].ToString());
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { mailto1, mailto2, mailto3, mailto4, mailto5 });
            this.reportViewer1.RefreshReport();
        }
        public void setAccNum(string aNum)
        {
            comboBox1.Text = aNum;
        }
    }
}
