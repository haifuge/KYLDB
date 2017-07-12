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
        public ClientDetailRep()
        {
            InitializeComponent();
        }

        private void ClientDetailRep_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }
    }
}
