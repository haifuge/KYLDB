using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYLDB.Forms
{
    public partial class RepManagement : Form
    {
        private RepManagement()
        {
            InitializeComponent();
        }
        private static RepManagement singleton = null;
        public static RepManagement GetInstance()
        {
            if (singleton == null)
                singleton = new RepManagement();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }

        private void RepManagement_Load(object sender, EventArgs e)
        {
            string sql = "select * from Representative";
            DataTable dt = DBOperator.QuerySql(sql);
            dataGridView1.DataSource = dt;
        }

        private void RepManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
