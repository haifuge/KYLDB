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
    public partial class PayCheckFrm : Form
    {
        public PayCheckFrm()
        {
            InitializeComponent();
        }
        List<Model.ClientPayroll> ClientPayrolls = new List<Model.ClientPayroll>();
        private void PayCheckFrm_Load(object sender, EventArgs e)
        {
            string sql = "select * from ClientPayroll";
            DataTable dt = DBOperator.QuerySql(sql);
            ClientPayrolls = DBOperator.getListFromTable<Model.ClientPayroll>(dt);
            var acclist = from ac in ClientPayrolls
                          select ac.AccNum;
            comboBox1.DataSource = acclist.ToArray();

            var enList = from ac in ClientPayrolls
                         select ac.Entity;
            comboBox2.DataSource = enList.ToArray();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var acc = (from ac in ClientPayrolls
                      where ac.AccNum == comboBox1.Text
                      select ac).First();
            txtAccNum.Text = acc.AccNum;
            txtCustomer.Text = acc.Entity;
            txtPayType.Text = acc.PayType;
            txtPayFreq.Text = acc.PayFreq;
            txtFedTaxFreq.Text = acc.FedTaxFreq;
            txtStateTaxFreq.Text = acc.StateTaxFreq;
            txtLocalTaxFreq.Text = acc.LocalTaxFreq;
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var acc = (from ac in ClientPayrolls
                      where ac.Entity == comboBox2.Text
                      select ac).First();
            txtAccNum.Text = acc.AccNum;
            txtCustomer.Text = acc.Entity;
            txtPayType.Text = acc.PayType;
            txtPayFreq.Text = acc.PayFreq;
            txtFedTaxFreq.Text = acc.FedTaxFreq;
            txtStateTaxFreq.Text = acc.StateTaxFreq;
            txtLocalTaxFreq.Text = acc.LocalTaxFreq;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountViewList avl = AccountViewList.GetInstance();
            avl.MdiParent = this.MdiParent;
            avl.Show();
            this.Close();
        }
    }
}
