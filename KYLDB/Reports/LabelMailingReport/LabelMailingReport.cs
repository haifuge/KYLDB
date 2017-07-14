using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYLDB.Reports.LabelMailingReport
{
    public partial class LabelMailingReport : Form
    {
        private static LabelMailingReport singleton = null;
        public static LabelMailingReport GetInstance()
        {
            if (singleton == null)
                singleton = new LabelMailingReport();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private LabelMailingReport()
        {
            InitializeComponent();
        }

        private void LabelMailingReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }

        private void LabelMailingReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
