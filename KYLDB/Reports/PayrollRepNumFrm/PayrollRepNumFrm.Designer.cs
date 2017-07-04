namespace KYLDB.Reports.PayrollRepNumFrm
{
    partial class PayrollRepNumFrm
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
            Microsoft.Reporting.WinForms.ReportDataSource reportDataSource2 = new Microsoft.Reporting.WinForms.ReportDataSource();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.PayrollRepNumBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.PayrollRepNumBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // reportViewer1
            // 
            this.reportViewer1.Dock = System.Windows.Forms.DockStyle.Fill;
            reportDataSource2.Name = "dsPayrollRepNum";
            reportDataSource2.Value = this.PayrollRepNumBindingSource;
            this.reportViewer1.LocalReport.DataSources.Add(reportDataSource2);
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "KYLDB.Reports.PayrollRepNumFrm.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 0);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1039, 600);
            this.reportViewer1.TabIndex = 0;
            // 
            // PayrollRepNumBindingSource
            // 
            this.PayrollRepNumBindingSource.DataSource = typeof(KYLDB.Model.PayrollRepNum);
            // 
            // PayrollRepNumFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1039, 600);
            this.Controls.Add(this.reportViewer1);
            this.Name = "PayrollRepNumFrm";
            this.Text = "PayrollRepNumFrm";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PayrollRepNumFrm_FormClosed);
            this.Load += new System.EventHandler(this.PayrollRepNumFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.PayrollRepNumBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.BindingSource PayrollRepNumBindingSource;
    }
}