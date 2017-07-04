namespace KYLDB
{
    partial class Main
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
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.Client = new System.Windows.Forms.ToolStripMenuItem();
            this.clientInfoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewClientsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.dataImportExportToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.reportsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ClientPayrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.monthlySalesTaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quarterlySaleTaxToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.quarterlyPayrollToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repManageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.repManageToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.quarterlyPLToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Client,
            this.dataToolStripMenuItem,
            this.reportsToolStripMenuItem,
            this.repManageToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(1122, 28);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // Client
            // 
            this.Client.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clientInfoToolStripMenuItem,
            this.viewClientsToolStripMenuItem});
            this.Client.Name = "Client";
            this.Client.Size = new System.Drawing.Size(59, 24);
            this.Client.Text = "Client";
            // 
            // clientInfoToolStripMenuItem
            // 
            this.clientInfoToolStripMenuItem.Name = "clientInfoToolStripMenuItem";
            this.clientInfoToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.clientInfoToolStripMenuItem.Text = "Client Info";
            this.clientInfoToolStripMenuItem.Click += new System.EventHandler(this.clientInfoToolStripMenuItem_Click);
            // 
            // viewClientsToolStripMenuItem
            // 
            this.viewClientsToolStripMenuItem.Name = "viewClientsToolStripMenuItem";
            this.viewClientsToolStripMenuItem.Size = new System.Drawing.Size(164, 26);
            this.viewClientsToolStripMenuItem.Text = "View Clients";
            this.viewClientsToolStripMenuItem.Click += new System.EventHandler(this.viewClientsToolStripMenuItem_Click);
            // 
            // dataToolStripMenuItem
            // 
            this.dataToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.dataImportExportToolStripMenuItem});
            this.dataToolStripMenuItem.Name = "dataToolStripMenuItem";
            this.dataToolStripMenuItem.Size = new System.Drawing.Size(53, 24);
            this.dataToolStripMenuItem.Text = "Data";
            // 
            // dataImportExportToolStripMenuItem
            // 
            this.dataImportExportToolStripMenuItem.Name = "dataImportExportToolStripMenuItem";
            this.dataImportExportToolStripMenuItem.Size = new System.Drawing.Size(214, 26);
            this.dataImportExportToolStripMenuItem.Text = "Data Import/Export";
            this.dataImportExportToolStripMenuItem.Click += new System.EventHandler(this.dataImportExportToolStripMenuItem_Click);
            // 
            // reportsToolStripMenuItem
            // 
            this.reportsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ClientPayrollToolStripMenuItem,
            this.monthlySalesTaxToolStripMenuItem,
            this.quarterlySaleTaxToolStripMenuItem,
            this.quarterlyPayrollToolStripMenuItem,
            this.quarterlyPLToolStripMenuItem});
            this.reportsToolStripMenuItem.Name = "reportsToolStripMenuItem";
            this.reportsToolStripMenuItem.Size = new System.Drawing.Size(72, 24);
            this.reportsToolStripMenuItem.Text = "Reports";
            // 
            // ClientPayrollToolStripMenuItem
            // 
            this.ClientPayrollToolStripMenuItem.Name = "ClientPayrollToolStripMenuItem";
            this.ClientPayrollToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.ClientPayrollToolStripMenuItem.Text = "Client Payroll";
            this.ClientPayrollToolStripMenuItem.Click += new System.EventHandler(this.ClientPayrollToolStripMenuItem_Click);
            // 
            // monthlySalesTaxToolStripMenuItem
            // 
            this.monthlySalesTaxToolStripMenuItem.Name = "monthlySalesTaxToolStripMenuItem";
            this.monthlySalesTaxToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.monthlySalesTaxToolStripMenuItem.Text = "Monthly - Sales Tax";
            this.monthlySalesTaxToolStripMenuItem.Click += new System.EventHandler(this.monthlySalesTaxToolStripMenuItem_Click);
            // 
            // quarterlySaleTaxToolStripMenuItem
            // 
            this.quarterlySaleTaxToolStripMenuItem.Name = "quarterlySaleTaxToolStripMenuItem";
            this.quarterlySaleTaxToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.quarterlySaleTaxToolStripMenuItem.Text = "Quarterly - Sale Tax";
            this.quarterlySaleTaxToolStripMenuItem.Click += new System.EventHandler(this.quarterlySaleTaxToolStripMenuItem_Click);
            // 
            // quarterlyPayrollToolStripMenuItem
            // 
            this.quarterlyPayrollToolStripMenuItem.Name = "quarterlyPayrollToolStripMenuItem";
            this.quarterlyPayrollToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.quarterlyPayrollToolStripMenuItem.Text = "Quarterly - Payroll";
            this.quarterlyPayrollToolStripMenuItem.Click += new System.EventHandler(this.quarterlyPayrollToolStripMenuItem_Click);
            // 
            // repManageToolStripMenuItem
            // 
            this.repManageToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.repManageToolStripMenuItem1});
            this.repManageToolStripMenuItem.Name = "repManageToolStripMenuItem";
            this.repManageToolStripMenuItem.Size = new System.Drawing.Size(101, 24);
            this.repManageToolStripMenuItem.Text = "RepManage";
            // 
            // repManageToolStripMenuItem1
            // 
            this.repManageToolStripMenuItem1.Name = "repManageToolStripMenuItem1";
            this.repManageToolStripMenuItem1.Size = new System.Drawing.Size(164, 26);
            this.repManageToolStripMenuItem1.Text = "RepManage";
            this.repManageToolStripMenuItem1.Click += new System.EventHandler(this.repManageToolStripMenuItem1_Click);
            // 
            // quarterlyPLToolStripMenuItem
            // 
            this.quarterlyPLToolStripMenuItem.Name = "quarterlyPLToolStripMenuItem";
            this.quarterlyPLToolStripMenuItem.Size = new System.Drawing.Size(212, 26);
            this.quarterlyPLToolStripMenuItem.Text = "Quarterly - P&L";
            this.quarterlyPLToolStripMenuItem.Click += new System.EventHandler(this.quarterlyPLToolStripMenuItem_Click);
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1122, 642);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Main";
            this.Text = "Form1";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.Resize += new System.EventHandler(this.Main_Resize);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem Client;
        private System.Windows.Forms.ToolStripMenuItem clientInfoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem dataImportExportToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem reportsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ClientPayrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem viewClientsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repManageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem repManageToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem monthlySalesTaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quarterlySaleTaxToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quarterlyPayrollToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem quarterlyPLToolStripMenuItem;
    }
}

