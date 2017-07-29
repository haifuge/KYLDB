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
using KYLDB.Reports.QuarterBillFrm;
using KYLDB.Model;
using KYLDB.Reports.StatisticReport;
using KYLDB.Reports.LabelMailingReport;
using KYLDB.Reports.LabelFolderReport;

namespace KYLDB
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();
        }
        public static User cUser = null;
        private void Form1_Load(object sender, EventArgs e)
        {
#if DEBUG
            Login l = new Login();
            l.ShowDialog();
            if (cUser == null) { this.Close(); }
            this.Text = "KYL - " + cUser.FirstName;
            if(cUser.UserLevel>= Setting.AdminLevel)
            {
                repManageToolStripMenuItem.Visible = true;
                dataToolStripMenuItem.Visible = true; 
                statisticReportToolStripMenuItem.Visible=true;
                payrollRepNumToolStripMenuItem.Visible = true;
                quarterBillToolStripMenuItem.Visible = true;
            }
            else 
            {
                repManageToolStripMenuItem.Visible = false;
                dataToolStripMenuItem.Visible = false;
                statisticReportToolStripMenuItem.Visible = false;
                payrollRepNumToolStripMenuItem.Visible = false;
                quarterBillToolStripMenuItem.Visible = false;
            }
            if (cUser.UserLevel >= Setting.ReporterLevel)
            {
                reportsToolStripMenuItem.Visible = true;
            }
            else
            {
                reportsToolStripMenuItem.Visible = false;
            }
            payCheckToolStripMenuItem.Visible = false;
            clientDetailToolStripMenuItem.Visible = false;
            clientInfoToolStripMenuItem.Visible = false;
            ClientPayrollToolStripMenuItem.Visible = false;
#endif
#if RELEASE
            cUser = new User() { Rep = "C", LastName = "Chow", FirstName = "Charles", UserLevel = 10 };
#endif
        }

        private void clientInfoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ClientPayroll ci = ClientPayroll.GetInstance();
            ci.MdiParent = this;
            ci.Show();
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

        private void quarterBillToolStripMenuItem_Click(object sender, EventArgs e)
        {
            QuarterBillFrm qbf = QuarterBillFrm.GetInstance();
            qbf.MdiParent = this;
            qbf.Show();
        }

        private void statisticReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            StatisticReport sr = StatisticReport.GetInstance();
            sr.MdiParent = this;
            sr.Show();
        }

        private void clientDetailToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Forms.ClientDetail cd = Forms.ClientDetail.GetInstance();
            cd.MdiParent = this;
            cd.Show();
        }

        private void labelMailingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LabelMailingReport lmp = LabelMailingReport.GetInstance();
            lmp.MdiParent = this;
            lmp.Show();
        }

        private void labelFolderToolStripMenuItem_Click(object sender, EventArgs e)
        {
            LabelFolderReport lfp = LabelFolderReport.GetInstance();
            lfp.MdiParent = this;
            lfp.Show();
        }

        private void changePasswordToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ChangePassword cp = ChangePassword.GetInstance();
            cp.MdiParent = this;
            cp.Show();
        }
    }
}
