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
    public partial class ClientDetail : Form
    {
        private static ClientDetail singleton = null;
        public static ClientDetail GetInstance()
        {
            if (singleton == null)
                singleton = new ClientDetail();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        public ClientDetail()
        {
            InitializeComponent();
        }
        
        List<KYLDB.Model.ClientDetail> details = new List<KYLDB.Model.ClientDetail>();
        private void ClientDetail_Load(object sender, EventArgs e)
        {
            string sql = "select * from ClientDetail";
            DataTable dt = DBOperator.QuerySql(sql);
            details = DBOperator.getListFromTable<KYLDB.Model.ClientDetail>(dt);
            var accNum = from acc in details
                         select acc.AccountNo;
            AccNumList.DataSource = accNum.ToList();
            var company = from acc in details
                          select acc.Customer;
            comboBox2.DataSource = company;
            AccNumList.SelectedIndex = 0;
            comboBox2.SelectedIndex = 0;
            AccNumList.SelectedIndexChanged += AccNumList_SelectedIndexChanged;
            comboBox2.SelectedIndexChanged += ComboBox2_SelectedIndexChanged;
        }

        private void ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = from acc in details
                      where acc.Customer == comboBox2.Text
                      select acc;
        }

        private void AccNumList_SelectedIndexChanged(object sender, EventArgs e)
        {
            var obj = from acc in details
                      where acc.AccountNo == AccNumList.Text
                      select acc;
        }

        private void ClientDetail_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
