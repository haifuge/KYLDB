using KYLDB.Model;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYLDB.Reports.MonthlySaleTax
{
    public partial class MonthlySaleTax : Form
    {
        public MonthlySaleTax()
        {
            InitializeComponent();
        }

        private static MonthlySaleTax singleton = null;
        public static MonthlySaleTax GetInstance()
        {
            if (singleton == null)
                singleton = new MonthlySaleTax();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }

        private void MonthlySaleTax_Load(object sender, EventArgs e)
        {
            string sql = "select Rep, FirstName+' '+ LastName as 'Name' from Representative order by FirstName, LastName";
            DataTable dt = DBOperator.QuerySql(sql);
            cmbRep.DataSource = dt;
            cmbRep.ValueMember = "Rep";
            cmbRep.DisplayMember = "Name";
            this.reportViewer1.RefreshReport();
        }

        private void MonthlySaleTax_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string rep = cmbRep.SelectedValue.ToString();
            string month = monthPicker.Text.ToString();
            MonthlyRepTitle mp = new MonthlyRepTitle { Rep = rep, Month = month };
            //List<MonthlyRepTitle> mps = new List<MonthlyRepTitle>();
            //mps.Add(mp);
            
            string sql = @"select Accountno, Customer, Contact, Phone, AltPhone, BalanceTotal, SalesTax, SalesTaxNum, 
                                  LiquorTax_Phila as 'LiquorTax', U_OTax from ClientDetail 
                            where Accountno = 'C1000'";
            DataTable dt = DBOperator.QuerySql(sql);
            List<MonthlyRep> items = DBOperator.getListFromTable<MonthlyRep>(dt);
            //reportViewer1.LocalReport.DataSources.Add(new Microsoft.Reporting.WinForms.ReportDataSource("dsMonthlySalesTax", items));
            //MonthlyRepBindingSource.DataSource = mp;
            var sales = from row in dt.AsEnumerable()
                        select row;
            MonthlyRepBindingSource.DataSource = sales.ToList();
            //ReportParameter rp = new ReportParameter("test", rep);
            //reportViewer1.LocalReport.SetParameters(new ReportParameter[] { rp });
            reportViewer1.Refresh();
        }
    }
}
