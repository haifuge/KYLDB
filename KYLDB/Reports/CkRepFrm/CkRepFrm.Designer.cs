namespace KYLDB.Reports.CkRepFrm
{
    partial class CkRepFrm
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
            this.button1 = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comMonth = new System.Windows.Forms.ComboBox();
            this.cmbRep = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
            this.comYear = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(677, 8);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(140, 30);
            this.button1.TabIndex = 19;
            this.button1.Text = "Generate Report";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(262, 16);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 18;
            this.label2.Text = "Month: ";
            // 
            // comMonth
            // 
            this.comMonth.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comMonth.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comMonth.FormattingEnabled = true;
            this.comMonth.Items.AddRange(new object[] {
            "January",
            "February",
            "March",
            "April",
            "May",
            "June",
            "July",
            "August",
            "Sepetember",
            "October",
            "November",
            "December"});
            this.comMonth.Location = new System.Drawing.Point(330, 12);
            this.comMonth.Name = "comMonth";
            this.comMonth.Size = new System.Drawing.Size(121, 24);
            this.comMonth.TabIndex = 15;
            // 
            // cmbRep
            // 
            this.cmbRep.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cmbRep.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cmbRep.FormattingEnabled = true;
            this.cmbRep.Location = new System.Drawing.Point(107, 12);
            this.cmbRep.Name = "cmbRep";
            this.cmbRep.Size = new System.Drawing.Size(130, 24);
            this.cmbRep.TabIndex = 16;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(61, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(42, 17);
            this.label1.TabIndex = 13;
            this.label1.Text = "Rep: ";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(840, 8);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(140, 30);
            this.button2.TabIndex = 19;
            this.button2.Text = "Generate All Rep";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // reportViewer1
            // 
            this.reportViewer1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportViewer1.LocalReport.ReportEmbeddedResource = "KYLDB.Reports.CkRepFrm.Report1.rdlc";
            this.reportViewer1.Location = new System.Drawing.Point(0, 45);
            this.reportViewer1.Name = "reportViewer1";
            this.reportViewer1.ServerReport.BearerToken = null;
            this.reportViewer1.Size = new System.Drawing.Size(1012, 513);
            this.reportViewer1.TabIndex = 20;
            // 
            // comYear
            // 
            this.comYear.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comYear.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comYear.FormattingEnabled = true;
            this.comYear.Location = new System.Drawing.Point(525, 12);
            this.comYear.Name = "comYear";
            this.comYear.Size = new System.Drawing.Size(121, 24);
            this.comYear.TabIndex = 15;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(471, 16);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 17);
            this.label3.TabIndex = 18;
            this.label3.Text = "Year: ";
            // 
            // CkRepFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1009, 557);
            this.Controls.Add(this.reportViewer1);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comYear);
            this.Controls.Add(this.comMonth);
            this.Controls.Add(this.cmbRep);
            this.Controls.Add(this.label1);
            this.Name = "CkRepFrm";
            this.Text = "Ck Rep";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.CkRepFrm_FormClosed);
            this.Load += new System.EventHandler(this.CkRepFrm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comMonth;
        private System.Windows.Forms.ComboBox cmbRep;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button2;
        private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
        private System.Windows.Forms.ComboBox comYear;
        private System.Windows.Forms.Label label3;
    }
}