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
    public partial class AccountInfoRep : Form
    {
        private AccountInfoRep()
        {
            InitializeComponent();
        }

        private static AccountInfoRep singleton = null;
        public static AccountInfoRep GetInstance()
        {
            if (singleton == null)
                singleton = new AccountInfoRep();
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
        List<Model.ClientPayroll> AccountInfos = new List<Model.ClientPayroll>();
        private void AccountInfoRep_Load(object sender, EventArgs e)
        {
            string sql = "select * from ClientPayroll";
            DataTable dt = DBOperator.QuerySql(sql);
            AccountInfos = DBOperator.getListFromTable<Model.ClientPayroll>(dt);
            var acclist = from ac in AccountInfos
                          select ac.AccNum;
            comboBox1.DataSource = acclist.ToArray();
            this.reportViewer1.RefreshReport();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var acc = from ac in AccountInfos
                      where ac.AccNum==comboBox1.Text
                      select ac;
            this.AccountInfoBindingSource.DataSource = acc;
            this.reportViewer1.RefreshReport();
        }

        private void AccountInfoRep_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
