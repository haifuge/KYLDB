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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource3 = new Microsoft.Reporting.WinForms.ReportDataSource();
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource4 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.TOTALBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.STPRBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.TOTALBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.STPRBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource3.Name = "dsTotal";
            reportDataSource3.Value = this.TOTALBindingSource;
            reportDataSource4.Name = "dtSTPR";
            reportDataSource4.Value = this.STPRBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource3);
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource4);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "KYLDB.Reports.StatisticReport.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(870, 584);
            this.reportViewer1.TabIndex = 0;
            // 
            // TOTALBindingSource
            // 
            this.TOTALBindingSource.DataSource = typeof(KYLDB.Model.TOTAL);
            // 
            // STPRBindingSource
            // 
            this.STPRBindingSource.DataSource = typeof(KYLDB.Model.STPR);
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