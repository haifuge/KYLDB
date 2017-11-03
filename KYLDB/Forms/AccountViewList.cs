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
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        DataTable dt;
        List<Model.ClientDetail> ClientDetails = new List<Model.ClientDetail>();
        private void btnSearch_Click(object sender, EventArgs e)
        {
            var searchList = from ac in ClientDetails
                             where ac.Customer.Contains(textBox1.Text.Trim().ToUpper())
                             select new
                             {
                                 id = ac.AccountNo,
                                 Rep = ac.Rep,
                                 Status = ac.JobStatus,
                                 Customer = ac.Customer,
                                 Contact = ac.Contact,
                                 BalanceTotal = ac.BalanceTotal,
                                 Phone = ac.Phone,
                                 AltPhone = ac.AltPhone,
                                 ClientDetail = "Detail",
                                 ClientPayroll = "Payroll Detail",
                                 Paycheck = "Paycheck"
                             };
            dataGridView1.DataSource = searchList.ToArray();
        }

        private void AccountViewList_Load(object sender, EventArgs e)
        {
            string sql;
            if (Main.cUser.UserLevel == 10)
                sql = "select * from ClientDetail";
            else
                sql = "select * from ClientDetail where Rep='"+Main.cUser.Rep+ "' or PaycheckRep='" + Main.cUser.Rep + "' or PayrollRep='" + Main.cUser.Rep + "'";
            dt = DBOperator.QuerySql(sql);
            ClientDetails = DBOperator.getListFromTable<Model.ClientDetail>(dt);
            
            var searchList = from ac in ClientDetails
                             select new
                             {
                                 id = ac.AccountNo,
                                 Rep = ac.Rep,
                                 Status = ac.JobStatus,
                                 Customer = ac.Customer,
                                 Contact = ac.Contact,
                                 BalanceTotal = ac.BalanceTotal,
                                 Phone = ac.Phone,
                                 AltPhone = ac.AltPhone,
                                 ClientDetail = "Detail",
                                 ClientPayroll = "Payroll Detail",
                                 Paycheck = "Paycheck"
                             };
            dataGridView1.DataSource = searchList.ToArray();
            setLinkColumns();
            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;

            var acclist = from ac in ClientDetails
                          select ac.AccountNo;
            comboBox1.DataSource = acclist.ToArray();
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);

            var enList = from ac in ClientDetails
                          select ac.Customer;
            comboBox2.DataSource = enList.ToArray();
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);

            this.WindowState = FormWindowState.Maximized;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var searchList = from ac in ClientDetails
                             where ac.AccountNo==comboBox1.Text
                             select new
                             {
                                 id = ac.AccountNo,
                                 Rep = ac.Rep,
                                 Status = ac.JobStatus,
                                 Customer = ac.Customer,
                                 Contact = ac.Contact,
                                 BalanceTotal = ac.BalanceTotal,
                                 Phone = ac.Phone,
                                 AltPhone = ac.AltPhone,
                                 ClientDetail = "Detail",
                                 ClientPayroll = "Payroll Detail",
                                 Paycheck = "Paycheck"
                             };
            comboBox2.Text = searchList.FirstOrDefault().Customer;
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
                ClientDetail cd = ClientDetail.GetInstance();
                cd.MdiParent = this.MdiParent;
                cd.Show();
                cd.SetData(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            else if (e.ColumnIndex==9)
            {
                // payroll
                string accNum = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sql = "select * from ClientPayroll where AccNum='" + accNum + "'";
                if(DBOperator.QuerySql(sql).Rows.Count==0)
                {
                    MessageBox.Show("This client doesn't have Payroll");
                    return;
                }
                ClientPayroll ci = ClientPayroll.GetInstance();
                ci.MdiParent = this.MdiParent;
                ci.Show();
                ci.SetData(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
            }
            else if (e.ColumnIndex==10)
            {
                string accNum = dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                string sql = "select * from ClientPayroll where AccNum='" + accNum + "' and PayFreq<>'Quarterly'";
                if (DBOperator.QuerySql(sql).Rows.Count == 0)
                {
                    MessageBox.Show("This client doesn't need Paycheck");
                    return;
                }
                // paycheck
                PayCheckFrm pcf = PayCheckFrm.GetInstance();
                pcf.MdiParent = this.MdiParent;
                pcf.Show();
                pcf.SetAccNum(dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString());
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
            var searchList = from ac in ClientDetails
                             where ac.Customer == comboBox2.Text
                             select new
                             {
                                 id = ac.AccountNo,
                                 Rep = ac.Rep,
                                 Status = ac.JobStatus,
                                 Customer = ac.Customer,
                                 Contact = ac.Contact,
                                 BalanceTotal = ac.BalanceTotal,
                                 Phone = ac.Phone,
                                 AltPhone = ac.AltPhone,
                                 ClientDetail = "Detail",
                                 ClientPayroll = "Payroll Detail",
                                 Paycheck = "Paycheck"
                             };
            comboBox1.Text = searchList.FirstOrDefault().id;
            dataGridView1.DataSource = searchList.ToArray();
            //setLinkColumns();
        }

        private void AccountViewList_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                btnSearch_Click(btnSearch, new EventArgs());
            }
        }
    }
}
