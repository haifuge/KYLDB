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
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            txtPwd.PasswordChar = '*';
            txtPwd.MaxLength = 20;
            txtUsername.MaxLength = 20;
        }

        private void button2_Click(object sender, EventArgs e)
        {

            string sql = @"select Rep, LastName, FirstName, Userlevel, UserName 
                           from [dbo].[Representative] 
                           where username='" + txtUsername.Text+"' and Password='"+txtPwd.Text+"'";
            DataTable dt = DBOperator.QuerySql(sql);
            if (dt.Rows.Count > 0)
            {
                Main.cUser = new Model.User()
                {
                    Rep = dt.Rows[0]["Rep"].ToString(),
                    LastName = dt.Rows[0]["LastName"].ToString(),
                    FirstName = dt.Rows[0]["FirstName"].ToString(),
                    UserLevel = int.Parse(dt.Rows[0]["UserLevel"].ToString()),
                    UserName=dt.Rows[0]["UserName"].ToString()
                };
                this.Close();
            }
            else
            {
                MessageBox.Show("Username or Password is wrong!");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode==Keys.Enter)
            {
                button2_Click(button2, new EventArgs());
            }
        }
    }
}
