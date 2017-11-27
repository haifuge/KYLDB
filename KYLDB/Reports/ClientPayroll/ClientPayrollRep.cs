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

namespace KYLDB.Reports
{
    public partial class ClientPayrollRep : Form
    {
        private ClientPayrollRep()
        {
            InitializeComponent();
        }

        private static ClientPayrollRep singleton = null;
        public static ClientPayrollRep GetInstance()
        {
            if (singleton == null)
                singleton = new ClientPayrollRep();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        public void SetData(string accNum)
        {
            comboBox1.Text = accNum;
        }
        List<Model.ClientPayroll> ClientPayrolls = new List<Model.ClientPayroll>();
        private void ClientPayrollRep_Load(object sender, EventArgs e)
        {
            string sql="";
            if (Main.cUser.UserLevel > 5)
                sql = "select AccNum from ClientPayroll";
            else
                sql = "select AccNum from ClientPayroll where AccRep='" + Main.cUser.Rep+"' or PayRep = '"+Main.cUser.Rep+"' or CkRep='"+Main.cUser.Rep+"'";
            DataTable dt = DBOperator.QuerySql(sql);
            var acclist = from ac in dt.AsEnumerable()
                          select ac[0].ToString();
            comboBox1.DataSource = acclist.ToArray();
            //this.reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string sql = "select * from ClientPayroll where AccNum='" + comboBox1.Text + "'";
            DataTable dt = DBOperator.QuerySql(sql);
            var acc = DBOperator.getObjectFromRow<Model.ClientPayroll>(dt.Rows[0]);
            this.ClientPayrollBindingSource.DataSource = acc;
            sql = "select FirstCheckDate from ClientCheckDate where AccNum='"+acc.AccNum+"'";
            string firstCheckDate = "";
            dt = DBOperator.QuerySql(sql);
            if (dt.Rows.Count == 0)
                firstCheckDate = "1/1/" + DateTime.Now.Year.ToString();
            else
                firstCheckDate = dt.Rows[0][0].ToString();
            ReportParameter fcd = new ReportParameter("firstCheckDate", firstCheckDate);
            reportViewer1.LocalReport.SetParameters(new ReportParameter[] { fcd });
            this.reportViewer1.RefreshReport();
        }

        private void ClientPayrollRep_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
