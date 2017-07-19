namespace KYLDB.Forms
{
    partial class PayCheckFrm
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
            this.label1 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBox2 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtAccNum = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomer = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.txtPayType = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.txtPayFreq = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txtFedTaxFreq = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.txtStateTaxFreq = new System.Windows.Forms.TextBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label9 = new System.Windows.Forms.Label();
            this.txtLocalTaxFreq = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.comCkFee = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(68, 17);
            this.label1.TabIndex = 0;
            this.label1.Text = "AccNum: ";
            // 
            // comboBox1
            // 
            this.comboBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(157, 15);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(155, 24);
            this.comboBox1.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(351, 18);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 17);
            this.label2.TabIndex = 0;
            this.label2.Text = "Customer:";
            // 
            // comboBox2
            // 
            this.comboBox2.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.SuggestAppend;
            this.comboBox2.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBox2.FormattingEnabled = true;
            this.comboBox2.Location = new System.Drawing.Point(470, 15);
            this.comboBox2.Name = "comboBox2";
            this.comboBox2.Size = new System.Drawing.Size(343, 24);
            this.comboBox2.TabIndex = 1;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(46, 61);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(64, 17);
            this.label3.TabIndex = 2;
            this.label3.Text = "AccNum:";
            // 
            // txtAccNum
            // 
            this.txtAccNum.Location = new System.Drawing.Point(157, 58);
            this.txtAccNum.Name = "txtAccNum";
            this.txtAccNum.ReadOnly = true;
            this.txtAccNum.Size = new System.Drawing.Size(155, 22);
            this.txtAccNum.TabIndex = 3;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(351, 61);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(76, 17);
            this.label4.TabIndex = 2;
            this.label4.Text = "Customer: ";
            // 
            // txtCustomer
            // 
            this.txtCustomer.Location = new System.Drawing.Point(470, 58);
            this.txtCustomer.Name = "txtCustomer";
            this.txtCustomer.ReadOnly = true;
            this.txtCustomer.Size = new System.Drawing.Size(343, 22);
            this.txtCustomer.TabIndex = 3;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(46, 89);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(72, 17);
            this.label5.TabIndex = 2;
            this.label5.Text = "Pay Type:";
            // 
            // txtPayType
            // 
            this.txtPayType.Location = new System.Drawing.Point(157, 86);
            this.txtPayType.Name = "txtPayType";
            this.txtPayType.ReadOnly = true;
            this.txtPayType.Size = new System.Drawing.Size(155, 22);
            this.txtPayType.TabIndex = 3;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(351, 89);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(69, 17);
            this.label6.TabIndex = 2;
            this.label6.Text = "Pay Freq:";
            // 
            // txtPayFreq
            // 
            this.txtPayFreq.Location = new System.Drawing.Point(470, 86);
            this.txtPayFreq.Name = "txtPayFreq";
            this.txtPayFreq.ReadOnly = true;
            this.txtPayFreq.Size = new System.Drawing.Size(155, 22);
            this.txtPayFreq.TabIndex = 3;
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(46, 117);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(96, 17);
            this.label7.TabIndex = 2;
            this.label7.Text = "Fed Tax Freq:";
            // 
            // txtFedTaxFreq
            // 
            this.txtFedTaxFreq.Location = new System.Drawing.Point(157, 114);
            this.txtFedTaxFreq.Name = "txtFedTaxFreq";
            this.txtFedTaxFreq.ReadOnly = true;
            this.txtFedTaxFreq.Size = new System.Drawing.Size(155, 22);
            this.txtFedTaxFreq.TabIndex = 3;
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(351, 117);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(105, 17);
            this.label8.TabIndex = 2;
            this.label8.Text = "State Tax Freq:";
            // 
            // txtStateTaxFreq
            // 
            this.txtStateTaxFreq.Location = new System.Drawing.Point(470, 114);
            this.txtStateTaxFreq.Name = "txtStateTaxFreq";
            this.txtStateTaxFreq.ReadOnly = true;
            this.txtStateTaxFreq.Size = new System.Drawing.Size(155, 22);
            this.txtStateTaxFreq.TabIndex = 3;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(838, 11);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(123, 28);
            this.button1.TabIndex = 4;
            this.button1.Text = "Main";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(656, 117);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(106, 17);
            this.label9.TabIndex = 2;
            this.label9.Text = "Local Tax Freq:";
            // 
            // txtLocalTaxFreq
            // 
            this.txtLocalTaxFreq.Location = new System.Drawing.Point(766, 114);
            this.txtLocalTaxFreq.Name = "txtLocalTaxFreq";
            this.txtLocalTaxFreq.ReadOnly = true;
            this.txtLocalTaxFreq.Size = new System.Drawing.Size(155, 22);
            this.txtLocalTaxFreq.TabIndex = 3;
            // 
            // dataGridView1
            // 
            this.dataGridView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 153);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(949, 403);
            this.dataGridView1.TabIndex = 5;
            this.dataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellContentClick);
            this.dataGridView1.CellEndEdit += new System.Windows.Forms.DataGridViewCellEventHandler(this.dataGridView1_CellEndEdit);
            this.dataGridView1.CurrentCellChanged += new System.EventHandler(this.dataGridView1_CurrentCellChanged);
            this.dataGridView1.DefaultValuesNeeded += new System.Windows.Forms.DataGridViewRowEventHandler(this.dataGridView1_DefaultValuesNeeded);
            // 
            // comCkFee
            // 
            this.comCkFee.FormattingEnabled = true;
            this.comCkFee.Location = new System.Drawing.Point(838, 61);
            this.comCkFee.Name = "comCkFee";
            this.comCkFee.Size = new System.Drawing.Size(121, 24);
            this.comCkFee.TabIndex = 6;
            this.comCkFee.Visible = false;
            this.comCkFee.SelectedIndexChanged += new System.EventHandler(this.comCkFee_SelectedIndexChanged);
            // 
            // PayCheckFrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(973, 568);
            this.Controls.Add(this.comCkFee);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtLocalTaxFreq);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txtStateTaxFreq);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.txtPayFreq);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txtFedTaxFreq);
            this.Controls.Add(this.txtCustomer);
            this.Controls.Add(this.txtPayType);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txtAccNum);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.comboBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label1);
            this.Name = "PayCheckFrm";
            this.Text = "Pay Check";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.PayCheckFrm_FormClosed);
            this.Load += new System.EventHandler(this.PayCheckFrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBox2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtAccNum;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtCustomer;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPayType;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txtPayFreq;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txtFedTaxFreq;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.TextBox txtStateTaxFreq;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtLocalTaxFreq;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.ComboBox comCkFee;
    }
}