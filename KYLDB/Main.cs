using KYLDB.Forms;
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

namespace KYLDB
{
    public partial class Main : Form
    {
        Form curForm;
        public Main()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //DataTable dt = DBOperator.ExecSQL("select * from detection");
            //MessageBox.Show("there are " + dt.Rows.Count + " lines in detection.");
        }

        private void clientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientInfo ci = new ClientInfo();
            ci.MdiParent = this;
            curForm = ci;
            ci.Show();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            if (curForm != null)
            {
                curForm.Width = this.Width - 50;
                curForm.Height = this.Height - 80;
            }
        }

        private void dataImportExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataImportExport die = new DataImportExport();
            die.MdiParent = this;
            die.Show();
        }

        private void accountInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountInfoRep aiRep = new AccountInfoRep();
            aiRep.MdiParent = this;
            aiRep.Show();
        }

        private void viewClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountViewList avl = new AccountViewList();
            avl.MdiParent = this;
            avl.Show();
        }
    }
}
