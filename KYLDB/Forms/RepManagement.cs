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
        int rows = 0;
        private void RepManagement_Load(object sender, EventArgs e)
        {
            string sql = "select *, 'save' as 'Save', 'delete' as 'Delete' from Representative order by Id";
            DataTable dt = DBOperator.QuerySql(sql);
            rows = dt.Rows.Count;
            dataGridView1.DataSource = dt;

            dataGridView1.Columns.Remove("Save");
            dataGridView1.Columns.Remove("Delete");

            DataGridViewLinkColumn save = new DataGridViewLinkColumn();
            //clientDetail.UseColumnTextForLinkValue = true;
            save.HeaderText = "Save";
            save.DataPropertyName = "Save";
            save.ActiveLinkColor = Color.White;
            save.LinkBehavior = LinkBehavior.SystemDefault;
            save.LinkColor = Color.Blue;
            save.TrackVisitedState = true;
            save.VisitedLinkColor = Color.YellowGreen;
            dataGridView1.Columns.Add(save);

            DataGridViewLinkColumn delete = new DataGridViewLinkColumn();
            //clientPayroll.UseColumnTextForLinkValue = true;
            delete.HeaderText = "Delete";
            delete.DataPropertyName = "Delete";
            delete.ActiveLinkColor = Color.White;
            delete.LinkBehavior = LinkBehavior.SystemDefault;
            delete.LinkColor = Color.Blue;
            delete.TrackVisitedState = true;
            delete.VisitedLinkColor = Color.YellowGreen;
            dataGridView1.Columns.Add(delete);
        }

        private void RepManagement_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string sql = "";
            if (e.ColumnIndex == 10)
            {
                // save
                if (dataGridView1.CurrentRow.Index>=rows)
                {
                    sql = @" insert into Representative 
                             values('" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + @"',
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + @"',
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + @"',
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + @"',
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() + @"',
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() + @"',
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() + @"',
                                    '" + dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() + @"',
                                    " + dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() + "); ";
                }
                else
                {
                    sql = @" update Representative 
                                set Rep='" + dataGridView1.Rows[e.RowIndex].Cells[1].Value.ToString() + @"', 
                                    LastName='" + dataGridView1.Rows[e.RowIndex].Cells[2].Value.ToString() + @"', 
                                    FirstName='" + dataGridView1.Rows[e.RowIndex].Cells[3].Value.ToString() + @"', 
                                    email='" + dataGridView1.Rows[e.RowIndex].Cells[4].Value.ToString() + @"', 
                                    Note='" + dataGridView1.Rows[e.RowIndex].Cells[5].Value.ToString() + @"', 
                                    ReportTo='" + dataGridView1.Rows[e.RowIndex].Cells[6].Value.ToString() + @"', 
                                    UserName='" + dataGridView1.Rows[e.RowIndex].Cells[7].Value.ToString() + @"', 
                                    Password='" + dataGridView1.Rows[e.RowIndex].Cells[8].Value.ToString() + @"', 
                                    UserLevel=" + dataGridView1.Rows[e.RowIndex].Cells[9].Value.ToString() + @" 
                                where Id=" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                }
                DBOperator.ExecuteSql(sql);
                MessageBox.Show("data is saved.");
            }
            else if (e.ColumnIndex == 11)
            {
                // delete
                sql = " delete Representative where Id=" + dataGridView1.Rows[e.RowIndex].Cells[0].Value.ToString();
                DBOperator.ExecuteSql(sql);
                MessageBox.Show("data is deleted.");
            }
            sql = " select *, 'save' as 'Save', 'delete' as 'Delete' from Representative order by Id";
            DataTable dt = DBOperator.QuerySql(sql);
            dataGridView1.DataSource = null;
            dataGridView1.Rows.Clear();
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt;
            rows = dt.Rows.Count;

            dataGridView1.Columns.Remove("Save");
            dataGridView1.Columns.Remove("Delete");

            DataGridViewLinkColumn save = new DataGridViewLinkColumn();
            //clientDetail.UseColumnTextForLinkValue = true;
            save.HeaderText = "Save";
            save.DataPropertyName = "Save";
            save.ActiveLinkColor = Color.White;
            save.LinkBehavior = LinkBehavior.SystemDefault;
            save.LinkColor = Color.Blue;
            save.TrackVisitedState = true;
            save.VisitedLinkColor = Color.YellowGreen;
            dataGridView1.Columns.Add(save);

            DataGridViewLinkColumn delete = new DataGridViewLinkColumn();
            //clientPayroll.UseColumnTextForLinkValue = true;
            delete.HeaderText = "Delete";
            delete.DataPropertyName = "Delete";
            delete.ActiveLinkColor = Color.White;
            delete.LinkBehavior = LinkBehavior.SystemDefault;
            delete.LinkColor = Color.Blue;
            delete.TrackVisitedState = true;
            delete.VisitedLinkColor = Color.YellowGreen;
            dataGridView1.Columns.Add(delete);
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells[10].Value = "save";
            e.Row.Cells[11].Value = "delete";
        }
    }
}
