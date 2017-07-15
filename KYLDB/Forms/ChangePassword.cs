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
    public partial class ChangePassword : Form
    {
        private static ChangePassword singleton = null;
        public static ChangePassword GetInstance()
        {
            if (singleton == null)
                singleton = new ChangePassword();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private ChangePassword()
        {
            InitializeComponent();
            txtUsername.Text = Main.cUser.UserName;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string nPwd1 = txtNewPassword1.Text;
            string nPwd2 = txtNewPassword2.Text;
            if (nPwd1 == "")
            {
                MessageBox.Show("Please input New Password1");
                txtNewPassword1.Focus();
                return;
            }
            if (nPwd2 == "")
            {
                MessageBox.Show("Please input New Password2");
                txtNewPassword2.Focus();
                return;
            }
            if (nPwd1 != nPwd2)
            {
                MessageBox.Show("Two new passwords are not same!");
                txtNewPassword1.Focus();
                return;
            }
            string sql = "select * from Representative where UserName='"+txtUsername.Text+ "' and Password ='"+txtOldPassword.Text+"'; ";
            DataTable dt = DBOperator.QuerySql(sql);
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("Please input right Password!");
                txtOldPassword.Focus();
                return;
            }
            sql= "update Representative set Password='"+ nPwd1 + "' where UserName='" + txtUsername.Text + "'";
            DBOperator.ExecuteSql(sql);
            MessageBox.Show("Password has been changed.");

        }

        private void ChangePassword_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
