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

        private void MonthlySaleTax_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
