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
    public partial class PayCheckFrm : Form
    {
        private static PayCheckFrm singleton = null;
        public static PayCheckFrm GetInstance()
        {
            if (singleton == null)
                singleton = new PayCheckFrm();
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

        private PayCheckFrm()
        {
            InitializeComponent();
        }
        int rows = 0;
        string cRep = "";
        List<Model.ClientPayroll> ClientPayrolls = new List<Model.ClientPayroll>();
        private void PayCheckFrm_Load(object sender, EventArgs e)
        {
            string sql = "select * from ClientPayroll where AccRep='"+Main.cUser.Rep+"' or PayRep='"+Main.cUser.FirstName+"' or CkRep='"+Main.cUser.FirstName+"'";
            DataTable dt = DBOperator.QuerySql(sql);
            ClientPayrolls = DBOperator.getListFromTable<Model.ClientPayroll>(dt);
            var acclist = from ac in ClientPayrolls
                          select ac.AccNum;
            comboBox1.DataSource = acclist.ToArray();

            var enList = from ac in ClientPayrolls
                         select ac.Entity;
            comboBox2.DataSource = enList.ToArray();
            //comboBox2.SelectedIndex = 0;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            this.comboBox2.SelectedIndexChanged += new System.EventHandler(this.comboBox2_SelectedIndexChanged);
            comboBox1.SelectedIndex = 0;

            sql = "select * from CkfeeTypePrice";
            dt = DBOperator.QuerySql(sql);
            comCkFee.ValueMember = "Price";
            comCkFee.DisplayMember = "CkfeeType";
            comCkFee.DataSource = dt;
            this.comCkFee.SelectedIndexChanged += new System.EventHandler(this.comCkFee_SelectedIndexChanged);
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
            cRep = acc.AccNum;
            fillGridview(cRep);
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
            cRep = acc.AccNum;
            fillGridview(cRep);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AccountViewList avl = AccountViewList.GetInstance();
            avl.MdiParent = this.MdiParent;
            avl.Show();
            this.Close();
        }
        private void fillGridview(string accNum)
        {
            
            dataGridView1.DataSource = null;
            dataGridView1.Columns.Clear();

            string sql = @"select Id, PostDate, CkDate, CkStartNum, CkEndNum, NumOfCk, CkFee, BillAmount, Preparer, Comment, 'Save' as 'Save', 'Delete' as 'Delete'
                           from PayCheck where AccNum='" + accNum + "'";
            DataTable dt = DBOperator.QuerySql(sql);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].ReadOnly = true;
            dataGridView1.Columns[5].ReadOnly = true;
            dataGridView1.Columns[7].ReadOnly = true;
            dataGridView1.Columns[0].Visible = false;
            rows = dt.Rows.Count;
            dataGridView1.Columns.Remove("Save");
            dataGridView1.Columns.Remove("Delete");

            DataGridViewLinkColumn save = new DataGridViewLinkColumn();
            save.HeaderText = "Save";
            save.DataPropertyName = "Save";
            save.ActiveLinkColor = Color.White;
            save.LinkBehavior = LinkBehavior.SystemDefault;
            save.LinkColor = Color.Blue;
            save.TrackVisitedState = true;
            save.VisitedLinkColor = Color.YellowGreen;
            dataGridView1.Columns.Add(save);

            DataGridViewLinkColumn delete = new DataGridViewLinkColumn();
            delete.HeaderText = "Delete";
            delete.DataPropertyName = "Delete";
            delete.ActiveLinkColor = Color.White;
            delete.LinkBehavior = LinkBehavior.SystemDefault;
            delete.LinkColor = Color.Blue;
            delete.TrackVisitedState = true;
            delete.VisitedLinkColor = Color.YellowGreen;
            dataGridView1.Columns.Add(delete);
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql = "";
            if (e.ColumnIndex == 10)
            {
                // save
                if (dataGridView1.CurrentRow.Index >= rows)
                {
                    sql = @" insert into PayCheck 
                             values('" + cRep + @"',
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + @"',
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + @"',
                                    " + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + @",
                                    " + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + @",
                                    " + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() + @",
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() + @"',
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() + @"',
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() + @"',
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() + "'); ";
                }
                else
                {
                    sql = @" update PayCheck 
                                set CkDate='" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + @"', 
                                    CkStartNum=" + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + @", 
                                    CkEndNum=" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + @", 
                                    NumOfCk=" + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() + @", 
                                    CkFee='" + dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() + @"',
                                    BillAmount='" + dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() + @"', 
                                    Preparer='" + dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() + @"', 
                                    Comment='" + dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() + @"'
                                where Id =" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
                DBOperator.ExecuteSql(sql);
                MessageBox.Show("data is saved.");
            }
            else if (e.ColumnIndex == 11)
            {
                // delete
                sql = " delete PayCheck where Id =" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                DBOperator.ExecuteSql(sql);
                MessageBox.Show("data is deleted.");
            }
            fillGridview(cRep);
        }

        private void PayCheckFrm_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            //for(int i = 0; i < e.Row.Index; i++)
            //{
            //    string date = dataGridView1.Rows[i].Cells[0].Value.ToString();
            //    date = date.Split(' ')[0];
            //    string today = DateTime.Now.ToShortDateString();
            //    if (date == today)
            //    {
            //        MessageBox.Show("There already is a Check Issue today");
            //        e.Row.ReadOnly = true;
            //        return;
            //    }
            //}
            e.Row.ReadOnly = false;
            if (e.Row.Index>0)
            {
                int ckEndNum = 0;
                int.TryParse(dataGridView1.Rows[e.Row.Index-1].Cells[4].Value.ToString(), out ckEndNum);
                dataGridView1.Rows[e.Row.Index].Cells[3].Value = ckEndNum + 1;
            }
            e.Row.Cells[1].Value = DateTime.Now.ToShortDateString();
            e.Row.Cells[8].Value = Main.cUser.Rep;
            e.Row.Cells[10].Value = "save";
            e.Row.Cells[11].Value = "delete";
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex==4)
            {
                int ckStartNum = 0;
                if (!int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString(), out ckStartNum))
                {
                    MessageBox.Show("Please input a number in CkStartNum");
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    return;
                }
                int ckEndNum = 0;
                if (!int.TryParse(dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString(), out ckEndNum))
                {
                    MessageBox.Show("Please input a number in CkEndNum");
                    dataGridView1.CurrentCell = dataGridView1.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    return;
                }
                dataGridView1.Rows[e.RowIndex].Cells[5].Value = ckEndNum - ckStartNum;
            }
        }
        public void SetAccNum(string accNum)
        {
            comboBox1.Text = accNum;
        }

        private void dataGridView1_CurrentCellChanged(object sender, EventArgs e)
        {
            try
            {
                if (dataGridView1.CurrentCell.ColumnIndex == 6)
                {
                    Rectangle rect = dataGridView1.GetCellDisplayRectangle(dataGridView1.CurrentCell.ColumnIndex, dataGridView1.CurrentCell.RowIndex, false);
                    string cFee = dataGridView1.CurrentCell.Value.ToString();
                    comCkFee.Text = cFee;
                    comCkFee.Left = rect.Left + dataGridView1.Location.X;
                    comCkFee.Top = rect.Top + dataGridView1.Location.Y;
                    comCkFee.Width = rect.Width;
                    comCkFee.Height = rect.Height+1;
                    comCkFee.Visible = true;
                }
                else
                {
                    comCkFee.Visible = false;
                }
            }
            catch { }
        }

        private void comCkFee_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                dataGridView1.CurrentCell.Value = comCkFee.Text;
                dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[7].Value = "$"+(decimal.Parse(comCkFee.SelectedValue.ToString()) * decimal.Parse(dataGridView1.Rows[dataGridView1.CurrentCell.RowIndex].Cells[5].Value.ToString())).ToString("0.00");
            }
            catch { }
            //dataGridView1.CurrentCell.Tag = comCkFee.;
        }
    }
}
