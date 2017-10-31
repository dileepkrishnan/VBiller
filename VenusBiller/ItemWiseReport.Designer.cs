namespace VenusBiller
{
    partial class ItemWiseReport
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ItemWiseReport));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbItemCode = new System.Windows.Forms.RadioButton();
            this.rdbTax = new System.Windows.Forms.RadioButton();
            this.rdbAmount = new System.Windows.Forms.RadioButton();
            this.rdbDate = new System.Windows.Forms.RadioButton();
            this.rdbNumber = new System.Windows.Forms.RadioButton();
            this.txtLastBill = new System.Windows.Forms.TextBox();
            this.txtItemCode = new System.Windows.Forms.TextBox();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtFirstBill = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpStartDate = new System.Windows.Forms.DateTimePicker();
            this.dtpEndDate = new System.Windows.Forms.DateTimePicker();
            this.btnGenerateAndPrint = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.btnGenerateAndView = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.groupBox2);
            this.groupBox1.Controls.Add(this.txtLastBill);
            this.groupBox1.Controls.Add(this.txtItemCode);
            this.groupBox1.Controls.Add(this.txtCustomerCode);
            this.groupBox1.Controls.Add(this.txtFirstBill);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Location = new System.Drawing.Point(19, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(368, 312);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbItemCode);
            this.groupBox2.Controls.Add(this.rdbTax);
            this.groupBox2.Controls.Add(this.rdbAmount);
            this.groupBox2.Controls.Add(this.rdbDate);
            this.groupBox2.Controls.Add(this.rdbNumber);
            this.groupBox2.Location = new System.Drawing.Point(87, 177);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(112, 129);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // rdbItemCode
            // 
            this.rdbItemCode.AutoSize = true;
            this.rdbItemCode.Location = new System.Drawing.Point(7, 103);
            this.rdbItemCode.Name = "rdbItemCode";
            this.rdbItemCode.Size = new System.Drawing.Size(73, 17);
            this.rdbItemCode.TabIndex = 8;
            this.rdbItemCode.Text = "Item Code";
            this.rdbItemCode.UseVisualStyleBackColor = true;
            // 
            // rdbTax
            // 
            this.rdbTax.AutoSize = true;
            this.rdbTax.Location = new System.Drawing.Point(7, 81);
            this.rdbTax.Name = "rdbTax";
            this.rdbTax.Size = new System.Drawing.Size(67, 17);
            this.rdbTax.TabIndex = 4;
            this.rdbTax.Text = "Tax Amt.";
            this.rdbTax.UseVisualStyleBackColor = true;
            // 
            // rdbAmount
            // 
            this.rdbAmount.AutoSize = true;
            this.rdbAmount.Location = new System.Drawing.Point(7, 59);
            this.rdbAmount.Name = "rdbAmount";
            this.rdbAmount.Size = new System.Drawing.Size(62, 17);
            this.rdbAmount.TabIndex = 5;
            this.rdbAmount.Text = "Bill Amt.";
            this.rdbAmount.UseVisualStyleBackColor = true;
            // 
            // rdbDate
            // 
            this.rdbDate.AutoSize = true;
            this.rdbDate.Location = new System.Drawing.Point(7, 37);
            this.rdbDate.Name = "rdbDate";
            this.rdbDate.Size = new System.Drawing.Size(64, 17);
            this.rdbDate.TabIndex = 6;
            this.rdbDate.Text = "Bill Date";
            this.rdbDate.UseVisualStyleBackColor = true;
            // 
            // rdbNumber
            // 
            this.rdbNumber.AutoSize = true;
            this.rdbNumber.Checked = true;
            this.rdbNumber.Location = new System.Drawing.Point(7, 15);
            this.rdbNumber.Name = "rdbNumber";
            this.rdbNumber.Size = new System.Drawing.Size(58, 17);
            this.rdbNumber.TabIndex = 7;
            this.rdbNumber.TabStop = true;
            this.rdbNumber.Text = "Bill No.";
            this.rdbNumber.UseVisualStyleBackColor = true;
            // 
            // txtLastBill
            // 
            this.txtLastBill.Location = new System.Drawing.Point(234, 65);
            this.txtLastBill.MaxLength = 6;
            this.txtLastBill.Name = "txtLastBill";
            this.txtLastBill.Size = new System.Drawing.Size(112, 20);
            this.txtLastBill.TabIndex = 2;
            this.txtLastBill.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtLastBill_KeyPress);
            // 
            // txtItemCode
            // 
            this.txtItemCode.Location = new System.Drawing.Point(87, 150);
            this.txtItemCode.MaxLength = 50;
            this.txtItemCode.Name = "txtItemCode";
            this.txtItemCode.Size = new System.Drawing.Size(112, 20);
            this.txtItemCode.TabIndex = 2;
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(87, 110);
            this.txtCustomerCode.MaxLength = 50;
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(112, 20);
            this.txtCustomerCode.TabIndex = 2;
            // 
            // txtFirstBill
            // 
            this.txtFirstBill.Location = new System.Drawing.Point(87, 65);
            this.txtFirstBill.MaxLength = 6;
            this.txtFirstBill.Name = "txtFirstBill";
            this.txtFirstBill.Size = new System.Drawing.Size(112, 20);
            this.txtFirstBill.TabIndex = 2;
            this.txtFirstBill.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtFirstBill_KeyPress);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(207, 68);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(20, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "To";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(44, 188);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(41, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Sort By";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 153);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(55, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Item Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 113);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(79, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Code";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(208, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "To";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(19, 66);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(66, 13);
            this.label4.TabIndex = 1;
            this.label4.Text = "Bill No. From";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 28);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Period From";
            // 
            // dtpStartDate
            // 
            this.dtpStartDate.CustomFormat = "dd-MM-yyyy";
            this.dtpStartDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpStartDate.Location = new System.Drawing.Point(87, 25);
            this.dtpStartDate.Name = "dtpStartDate";
            this.dtpStartDate.Size = new System.Drawing.Size(112, 20);
            this.dtpStartDate.TabIndex = 0;
            // 
            // dtpEndDate
            // 
            this.dtpEndDate.CustomFormat = "dd-MM-yyyy";
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.dtpEndDate.Location = new System.Drawing.Point(234, 26);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(112, 20);
            this.dtpEndDate.TabIndex = 0;
            // 
            // btnGenerateAndPrint
            // 
            this.btnGenerateAndPrint.Location = new System.Drawing.Point(406, 51);
            this.btnGenerateAndPrint.Name = "btnGenerateAndPrint";
            this.btnGenerateAndPrint.Size = new System.Drawing.Size(96, 23);
            this.btnGenerateAndPrint.TabIndex = 1;
            this.btnGenerateAndPrint.Text = "Generate && Print";
            this.btnGenerateAndPrint.UseVisualStyleBackColor = true;
            this.btnGenerateAndPrint.Click += new System.EventHandler(this.btnGenerateAndPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(406, 81);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGenerateAndView
            // 
            this.btnGenerateAndView.Location = new System.Drawing.Point(406, 22);
            this.btnGenerateAndView.Name = "btnGenerateAndView";
            this.btnGenerateAndView.Size = new System.Drawing.Size(96, 23);
            this.btnGenerateAndView.TabIndex = 3;
            this.btnGenerateAndView.Text = "Generate && View";
            this.btnGenerateAndView.UseVisualStyleBackColor = true;
            this.btnGenerateAndView.Click += new System.EventHandler(this.btnGenerateAndView_Click);
            // 
            // ItemWiseReport
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(514, 339);
            this.Controls.Add(this.btnGenerateAndView);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerateAndPrint);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "ItemWiseReport";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report  -  Item-wise";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox txtFirstBill;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.TextBox txtLastBill;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbTax;
        private System.Windows.Forms.RadioButton rdbAmount;
        private System.Windows.Forms.RadioButton rdbDate;
        private System.Windows.Forms.RadioButton rdbNumber;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Button btnGenerateAndPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGenerateAndView;
        private System.Windows.Forms.TextBox txtItemCode;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.RadioButton rdbItemCode;
    }
}