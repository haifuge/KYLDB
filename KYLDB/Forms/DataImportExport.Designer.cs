namespace KYLDB.Forms
{
    partial class DataImportExport
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
            this.tabpage = new System.Windows.Forms.TabControl();
            this.DataImport = new System.Windows.Forms.TabPage();
            this.DataExport = new System.Windows.Forms.TabPage();
            this.cTableList = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnImport = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.tFilePath = new System.Windows.Forms.TextBox();
            this.btnSelectFile = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.tSavePath = new System.Windows.Forms.TextBox();
            this.btnExport = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.cExportTable = new System.Windows.Forms.ComboBox();
            this.progressBar2 = new System.Windows.Forms.ProgressBar();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.tabpage.SuspendLayout();
            this.DataImport.SuspendLayout();
            this.DataExport.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabpage
            // 
            this.tabpage.Controls.Add(this.DataImport);
            this.tabpage.Controls.Add(this.DataExport);
            this.tabpage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabpage.Location = new System.Drawing.Point(0, 0);
            this.tabpage.Name = "tabpage";
            this.tabpage.SelectedIndex = 0;
            this.tabpage.Size = new System.Drawing.Size(743, 410);
            this.tabpage.TabIndex = 0;
            // 
            // DataImport
            // 
            this.DataImport.Controls.Add(this.progressBar1);
            this.DataImport.Controls.Add(this.btnSelectFile);
            this.DataImport.Controls.Add(this.tFilePath);
            this.DataImport.Controls.Add(this.btnImport);
            this.DataImport.Controls.Add(this.label2);
            this.DataImport.Controls.Add(this.label1);
            this.DataImport.Controls.Add(this.cTableList);
            this.DataImport.Location = new System.Drawing.Point(4, 25);
            this.DataImport.Name = "DataImport";
            this.DataImport.Padding = new System.Windows.Forms.Padding(3);
            this.DataImport.Size = new System.Drawing.Size(735, 381);
            this.DataImport.TabIndex = 0;
            this.DataImport.Text = "Data Import";
            this.DataImport.UseVisualStyleBackColor = true;
            // 
            // DataExport
            // 
            this.DataExport.Controls.Add(this.progressBar2);
            this.DataExport.Controls.Add(this.btnSave);
            this.DataExport.Controls.Add(this.tSavePath);
            this.DataExport.Controls.Add(this.btnExport);
            this.DataExport.Controls.Add(this.label3);
            this.DataExport.Controls.Add(this.label4);
            this.DataExport.Controls.Add(this.cExportTable);
            this.DataExport.Location = new System.Drawing.Point(4, 25);
            this.DataExport.Name = "DataExport";
            this.DataExport.Padding = new System.Windows.Forms.Padding(3);
            this.DataExport.Size = new System.Drawing.Size(735, 381);
            this.DataExport.TabIndex = 1;
            this.DataExport.Text = "Data Export";
            this.DataExport.UseVisualStyleBackColor = true;
            // 
            // cTableList
            // 
            this.cTableList.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cTableList.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cTableList.FormattingEnabled = true;
            this.cTableList.Location = new System.Drawing.Point(213, 72);
            this.cTableList.Name = "cTableList";
            this.cTableList.Size = new System.Drawing.Size(172, 24);
            this.cTableList.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(100, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 17);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select File:";
            // 
            // btnImport
            // 
            this.btnImport.Location = new System.Drawing.Point(225, 241);
            this.btnImport.Name = "btnImport";
            this.btnImport.Size = new System.Drawing.Size(100, 29);
            this.btnImport.TabIndex = 2;
            this.btnImport.Text = "Import";
            this.btnImport.UseVisualStyleBackColor = true;
            this.btnImport.Click += new System.EventHandler(this.btnImport_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(100, 75);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(91, 17);
            this.label2.TabIndex = 1;
            this.label2.Text = "Import Table:";
            // 
            // tFilePath
            // 
            this.tFilePath.Location = new System.Drawing.Point(183, 162);
            this.tFilePath.Name = "tFilePath";
            this.tFilePath.Size = new System.Drawing.Size(365, 22);
            this.tFilePath.TabIndex = 3;
            // 
            // btnSelectFile
            // 
            this.btnSelectFile.Location = new System.Drawing.Point(564, 162);
            this.btnSelectFile.Name = "btnSelectFile";
            this.btnSelectFile.Size = new System.Drawing.Size(106, 24);
            this.btnSelectFile.TabIndex = 4;
            this.btnSelectFile.Text = "Open File";
            this.btnSelectFile.UseVisualStyleBackColor = true;
            this.btnSelectFile.Click += new System.EventHandler(this.btnSelectFile_Click);
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(546, 181);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(106, 24);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // tSavePath
            // 
            this.tSavePath.Location = new System.Drawing.Point(165, 181);
            this.tSavePath.Name = "tSavePath";
            this.tSavePath.Size = new System.Drawing.Size(365, 22);
            this.tSavePath.TabIndex = 10;
            // 
            // btnExport
            // 
            this.btnExport.Location = new System.Drawing.Point(207, 260);
            this.btnExport.Name = "btnExport";
            this.btnExport.Size = new System.Drawing.Size(100, 29);
            this.btnExport.TabIndex = 9;
            this.btnExport.Text = "Export";
            this.btnExport.UseVisualStyleBackColor = true;
            this.btnExport.Click += new System.EventHandler(this.button2_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(82, 94);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(92, 17);
            this.label3.TabIndex = 7;
            this.label3.Text = "Export Table:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(82, 184);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(70, 17);
            this.label4.TabIndex = 8;
            this.label4.Text = "Save File:";
            // 
            // cExportTable
            // 
            this.cExportTable.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.cExportTable.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.cExportTable.FormattingEnabled = true;
            this.cExportTable.Location = new System.Drawing.Point(195, 91);
            this.cExportTable.Name = "cExportTable";
            this.cExportTable.Size = new System.Drawing.Size(172, 24);
            this.cExportTable.TabIndex = 6;
            // 
            // progressBar2
            // 
            this.progressBar2.Location = new System.Drawing.Point(393, 265);
            this.progressBar2.Name = "progressBar2";
            this.progressBar2.Size = new System.Drawing.Size(259, 23);
            this.progressBar2.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar2.TabIndex = 12;
            this.progressBar2.Visible = false;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(347, 247);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(305, 23);
            this.progressBar1.TabIndex = 5;
            this.progressBar1.UseWaitCursor = true;
            this.progressBar1.Visible = false;
            // 
            // DataImportExport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(743, 410);
            this.Controls.Add(this.tabpage);
            this.Name = "DataImportExport";
            this.Text = "DataImportExport";
            this.Load += new System.EventHandler(this.DataImportExport_Load);
            this.tabpage.ResumeLayout(false);
            this.DataImport.ResumeLayout(false);
            this.DataImport.PerformLayout();
            this.DataExport.ResumeLayout(false);
            this.DataExport.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabpage;
        private System.Windows.Forms.TabPage DataImport;
        private System.Windows.Forms.Button btnSelectFile;
        private System.Windows.Forms.TextBox tFilePath;
        private System.Windows.Forms.Button btnImport;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cTableList;
        private System.Windows.Forms.TabPage DataExport;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.TextBox tSavePath;
        private System.Windows.Forms.Button btnExport;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cExportTable;
        private System.Windows.Forms.ProgressBar progressBar2;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}