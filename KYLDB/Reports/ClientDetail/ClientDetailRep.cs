using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYLDB.Reports.ClientDetail
{
    public partial class ClientDetailRep : Form
    {
        private static ClientDetailRep singleton = null;
        public static ClientDetailRep GetInstance()
        {
            if (singleton == null)
                singleton = new ClientDetailRep();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private ClientDetailRep()
        {
            InitializeComponent();
        }

        private void ClientDetailRep_Load(object sender, EventArgs e)
        {
            this.reportViewer1.RefreshReport();
        }

        private void ClientDetailRep_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
