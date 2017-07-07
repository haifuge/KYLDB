using KYLDB.Forms;
using KYLDB.Reports;
using KYLDB.Reports.MonthlySaleTax;
using KYLDB.Reports.QuarterlyPayroll;
using KYLDB.Reports.QuarterlySalesTax;
using KYLDB.Reports.QuarterlyProfitALoss;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using KYLDB.Reports.YearEndPayrollFrm;
using KYLDB.Reports.PayrollRepNumFrm;
using KYLDB.Reports.RepReportFrm;
using KYLDB.Reports.CkRepFrm;

namespace KYLDB
{
    public partial class Main : Form
    {
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
            ClientPayroll ci = ClientPayroll.GetInstance();
            ci.MdiParent = this;
            ci.Show();
        }

        private void Main_Resize(object sender, EventArgs e)
        {
            
        }

        private void dataImportExportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DataImportExport die = DataImportExport.GetInstance();
            die.MdiParent = this;
            die.Show();
        }

        private void ClientPayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientPayrollRep aiRep = ClientPayrollRep.GetInstance();
            aiRep.MdiParent = this;
            aiRep.Show();
        }

        private void viewClientsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AccountViewList avl = AccountViewList.GetInstance();
            avl.MdiParent = this;
            avl.Show();
        }

        private void repManageToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            RepManagement rm = RepManagement.GetInstance();
            rm.MdiParent = this;
            rm.Show();
        }

        private void monthlySalesTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MonthlySaleTax mst = MonthlySaleTax.GetInstance();
            mst.MdiParent = this;
            mst.Show();
        }

        private void quarterlySaleTaxToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuarterlySalesTax mst = QuarterlySalesTax.GetInstance();
            mst.MdiParent = this;
            mst.Show();
        }

        private void quarterlyPayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuarterlyPayroll mst = QuarterlyPayroll.GetInstance();
            mst.MdiParent = this;
            mst.Show();
        }

        private void quarterlyPLToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuarterlyProfitLossFrm qpl = QuarterlyProfitLossFrm.GetInstance();
            qpl.MdiParent = this;
            qpl.Show();
        }

        private void yearEndPayrollToolStripMenuItem_Click(object sender, EventArgs e)
        {
            YearEndPayrollFrm yep = YearEndPayrollFrm.GetInstance();
            yep.MdiParent = this;
            yep.Show();
        }

        private void payrollRepNumToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayrollRepNumFrm prf = PayrollRepNumFrm.GetInstance();
            prf.MdiParent = this;
            prf.Show();
        }

        private void repReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RepReportFrm rrf = RepReportFrm.GetInstance();
            rrf.MdiParent = this;
            rrf.Show();
        }

        private void ckRepToolStripMenuItem_Click(object sender, EventArgs e)
        {
            CkRepFrm crf = CkRepFrm.GetInstance();
            crf.MdiParent = this;
            crf.Show();
        }

        private void payCheckToolStripMenuItem_Click(object sender, EventArgs e)
        {
            PayCheckFrm pcf = PayCheckFrm.GetInstance();
            pcf.MdiParent = this;
            pcf.Show();
        }
    }
}
