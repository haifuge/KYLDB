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
        public AccountInfoRep()
        {
            InitializeComponent();
        }
        List<AccountInfo> AccountInfos = new List<AccountInfo>();
        private void AccountInfoRep_Load(object sender, EventArgs e)
        {
            string sql = "select * from AccountInfo";
            DataTable dt = DBOperator.QuerySql(sql);
            AccountInfos = DBOperator.getListFromTable<AccountInfo>(dt);
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
    }
}
