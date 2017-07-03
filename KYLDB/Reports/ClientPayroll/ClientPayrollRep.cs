using KYLDB.Model;
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
            string sql = "select * from ClientPayroll";
            DataTable dt = DBOperator.QuerySql(sql);
            ClientPayrolls = DBOperator.getListFromTable<Model.ClientPayroll>(dt);
            var acclist = from ac in ClientPayrolls
                          select ac.AccNum;
            comboBox1.DataSource = acclist.ToArray();
            this.reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var acc = from ac in ClientPayrolls
                      where ac.AccNum==comboBox1.Text
                      select ac;
            this.ClientPayrollBindingSource.DataSource = acc;
            this.reportViewer1.RefreshReport();
        }

        private void ClientPayrollRep_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
