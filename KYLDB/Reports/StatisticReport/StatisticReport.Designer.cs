namespace KYLDB.Reports.StatisticReport
{
    partial class StatisticReport
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.TOTALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.STPRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            ((System.ComponentModel.ISupportInitialize)(this.TOTALBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STPRBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // TOTALBindingSource
            // 
            this.TOTALBindingSource.DataSource = typeof(KYLDB.Model.TOTAL);
            // 
            // STPRBindingSource
            // 
            this.STPRBindingSource.DataSource = typeof(KYLDB.Model.STPR);
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            reportDataSource1.Name = "dsTotal";
            reportDataSource1.Value = this.TOTALBindingSource;
            reportDataSource2.Name = "dtSTPR";
            reportDataSource2.Value = this.STPRBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "KYLDB.Reports.StatisticReport.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(870, 584);
            this.reportViewer1.TabIndex = 0;
            // 
            // StatisticReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(870, 584);
            this.Controls.Add(this.reportViewer1);
            this.Name = "StatisticReport";
            this.Text = "StatisticReport";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.StatisticReport_FormClosed);
            this.Load += new System.EventHandler(this.StatisticReport_Load);
            ((System.ComponentModel.ISupportInitialize)(this.TOTALBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.STPRBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource TOTALBindingSource;
        private System.Windows.Forms.BindingSource STPRBindingSource;
    }
}