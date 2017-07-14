﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace KYLDB.Reports.LabelFolderReport
{
    public partial class LabelFolderReport : Form
    {
        private static LabelFolderReport singleton = null;
        public static LabelFolderReport GetInstance()
        {
            if (singleton == null)
                singleton = new LabelFolderReport();
            return singleton;
        }
        public new void Show()
        {
            this.Visible = true;
            base.Show();
            this.BringToFront();
        }
        private LabelFolderReport()
        {
            InitializeComponent();
        }

        private void LabelFolderReport_Load(object sender, EventArgs e)
        {

            this.reportViewer1.RefreshReport();
        }

        private void LabelFolderReport_FormClosed(object sender, FormClosedEventArgs e)
        {
            singleton = null;
        }
    }
}
