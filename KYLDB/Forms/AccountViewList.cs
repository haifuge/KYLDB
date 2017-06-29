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

namespace KYLDB.Forms
{
    public partial class AccountViewList : Form
    {
        public AccountViewList()
        {
            InitializeComponent();
        }
        DataTable dt;
        List<AccountInfo> AccountInfos = new List<AccountInfo>();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchList = from ac in AccountInfos
                             where ac.Entity.Contains(textBox1.Text.Trim())
                             select new { id = ac.AccNum, Rep = ac.AccRep, Status = "Current", Customer = ac.EIN,
                                          Contact = ac.Contact1, BalanceTotal = 0, Phone = ac.Contact1Tel1,
                                          AltPhone = ac.Contact1Tel2, ClientDetail = "Detail", ClientPayroll="Payroll Detail",
                                          Paycheck="Paycheck"
                                        };
            dataGridView1.DataSource = searchList.ToArray();
            dataGridView1.Columns.Remove("ClientDetail");
            dataGridView1.Columns.Remove("ClientPayroll");
            dataGridView1.Columns.Remove("Paycheck");
            DataGridViewLinkColumn clientDetail = new DataGridViewLinkColumn();
            //clientDetail.UseColumnTextForLinkValue = true;
            clientDetail.HeaderText = "ClientDetail";
            clientDetail.DataPropertyName = "ClientDetail";
            clientDetail.ActiveLinkColor = Color.White;
            clientDetail.LinkBehavior = LinkBehavior.SystemDefault;
            clientDetail.LinkColor = Color.Blue;
            clientDetail.TrackVisitedState = true;
            clientDetail.VisitedLinkColor = Color.YellowGreen;
            dataGridView1.Columns.Add(clientDetail);

            DataGridViewLinkColumn clientPayroll = new DataGridViewLinkColumn();
            //clientPayroll.UseColumnTextForLinkValue = true;
            clientPayroll.HeaderText = "ClientPayroll";
            clientPayroll.DataPropertyName = "ClientPayroll";
            clientPayroll.ActiveLinkColor = Color.White;
            clientPayroll.LinkBehavior = LinkBehavior.SystemDefault;
            clientPayroll.LinkColor = Color.Blue;
            clientPayroll.TrackVisitedState = true;
            clientPayroll.VisitedLinkColor = Color.YellowGreen;
            dataGridView1.Columns.Add(clientPayroll);

            DataGridViewLinkColumn paycheck = new DataGridViewLinkColumn();
            //paycheck.UseColumnTextForLinkValue = true;
            paycheck.HeaderText = "ClientDetail";
            paycheck.DataPropertyName = "ClientDetail";
            paycheck.ActiveLinkColor = Color.White;
            paycheck.LinkBehavior = LinkBehavior.SystemDefault;
            paycheck.LinkColor = Color.Blue;
            paycheck.TrackVisitedState = true;
            paycheck.VisitedLinkColor = Color.YellowGreen;
            dataGridView1.Columns.Add(paycheck);
            //dataGridView1.Refresh();

        }

        private void AccountViewList_Load(object sender, EventArgs e)
        {
            string sql = "select * from AccountInfo";
            dt = DBOperator.QuerySql(sql);
            AccountInfos = DBOperator.getListFromTable<AccountInfo>(dt);
            var acclist = from ac in AccountInfos
                          select ac.AccNum;
            comboBox1.DataSource = acclist.ToArray();
            var enList = from ac in AccountInfos
                          select ac.Entity;
            comboBox2.DataSource = enList.ToArray();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            MessageBox.Show(e.ColumnIndex + ", " + e.RowIndex);
        }
    }
}
