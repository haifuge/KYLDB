using KYLDB.Model;
using KYLDB.Reports;
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
        private AccountViewList()
        {
            InitializeComponent();
        }
        private static AccountViewList singleton = null;
        public static AccountViewList GetInstance()
        {
            if (singleton == null)
                singleton = new AccountViewList();
            return singleton;
        }
        public new void Close()
        {
            this.Visible = false;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        DataTable dt;
        List<Model.ClientPayroll> AccountInfos = new List<Model.ClientPayroll>();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchList = from ac in AccountInfos
                             where ac.Entity.Contains(textBox1.Text.Trim())
                             select new
                             {
                                 id = ac.AccNum,
                                 Rep = ac.AccRep,
                                 Status = "Current",
                                 Customer = ac.Entity,
                                 Contact = ac.Contact1,
                                 BalanceTotal = 0,
                                 Phone = ac.Contact1Tel1,
                                 AltPhone = ac.Contact1Tel2,
                                 ClientDetail = "Detail",
                                 ClientPayroll = "Payroll Detail",
                                 Paycheck = "Paycheck"
                             };
            dataGridView1.DataSource = searchList.ToArray();
        }

        private void AccountViewList_Load(object sender, EventArgs e)
        {
            string sql = "select * from AccountInfo";
            dt = DBOperator.QuerySql(sql);
            AccountInfos = DBOperator.getListFromTable<Model.ClientPayroll>(dt);
            
            var searchList = from ac in AccountInfos
                             select new
                             {
                                 id = ac.AccNum,
                                 Rep = ac.AccRep,
                                 Status = "Current",
                                 Customer = ac.Entity,
                                 Contact = ac.Contact1,
                                 BalanceTotal = 0,
                                 Phone = ac.Contact1Tel1,
                                 AltPhone = ac.Contact1Tel2,
                                 ClientDetail = "Detail",
                                 ClientPayroll = "Payroll Detail",
                                 Paycheck = "Paycheck"
                             };
            dataGridView1.DataSource = searchList.ToArray();
            setLinkColumns();

            var acclist = from ac in AccountInfos
                          select ac.AccNum;
            comboBox1.DataSource = acclist.ToArray();
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);

            var enList = from ac in AccountInfos
                          select ac.Entity;
            comboBox2.DataSource = enList.ToArray();
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var searchList = from ac in AccountInfos
                             where ac.AccNum==comboBox1.Text
                             select new
                             {
                                 id = ac.AccNum,
                                 Rep = ac.AccRep,
                                 Status = "Current",
                                 Customer = ac.Entity,
                                 Contact = ac.Contact1,
                                 BalanceTotal = 0,
                                 Phone = ac.Contact1Tel1,
                                 AltPhone = ac.Contact1Tel2,
                                 ClientDetail = "Detail",
                                 ClientPayroll = "Payroll Detail",
                                 Paycheck = "Paycheck"
                             };
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = searchList.ToArray();
            setLinkColumns();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 8)
            {
                // detail
                
            }
            else if (e.ColumnIndex==9)
            {
                // payroll
                ClientPayroll ci = ClientPayroll.GetInstance();
                ci.MdiParent = this.MdiParent;
                ci.Show();
                ci.SetData(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            else if (e.ColumnIndex==10)
            {
                // paycheck
            }
        }

        private void setLinkColumns()
        {
            try
            {
                dataGridView1.Columns.Remove("ClientDetail");
                dataGridView1.Columns.Remove("ClientPayroll");
                dataGridView1.Columns.Remove("Paycheck");
            }
            catch { }
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
            paycheck.HeaderText = "Paycheck";
            paycheck.DataPropertyName = "Paycheck";
            paycheck.ActiveLinkColor = Color.White;
            paycheck.LinkBehavior = LinkBehavior.SystemDefault;
            paycheck.LinkColor = Color.Blue;
            paycheck.TrackVisitedState = true;
            paycheck.VisitedLinkColor = Color.YellowGreen;
            dataGridView1.Columns.Add(paycheck);
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            var searchList = from ac in AccountInfos
                             where ac.Entity == comboBox2.Text
                             select new
                             {
                                 id = ac.AccNum,
                                 Rep = ac.AccRep,
                                 Status = "Current",
                                 Customer = ac.Entity,
                                 Contact = ac.Contact1,
                                 BalanceTotal = 0,
                                 Phone = ac.Contact1Tel1,
                                 AltPhone = ac.Contact1Tel2,
                                 ClientDetail = "Detail",
                                 ClientPayroll = "Payroll Detail",
                                 Paycheck = "Paycheck"
                             };
            dataGridView1.DataSource = searchList.ToArray();
            //setLinkColumns();
        }

        private void AccountViewList_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
