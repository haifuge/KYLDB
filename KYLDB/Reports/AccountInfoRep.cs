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

        private void AccountInfoRep_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
            string sql = "select * from AccountInfo";
            DataTable dt = DBOperator.QuerySql(sql);
            this.AccountInfoBindingSource.DataSource = dt;
        }
    }
}
