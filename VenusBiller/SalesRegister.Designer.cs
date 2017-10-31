namespace VenusBiller
{
    partial class SalesRegister
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SalesRegister));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.rdbBoth = new System.Windows.Forms.RadioButton();
            this.rdbB2C = new System.Windows.Forms.RadioButton();
            this.rdbB2B = new System.Windows.Forms.RadioButton();
            this.label6 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
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
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpStartDate);
            this.groupBox1.Controls.Add(this.dtpEndDate);
            this.groupBox1.Location = new System.Drawing.Point(19, 15);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(238, 211);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Report Parameters";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.rdbBoth);
            this.groupBox2.Controls.Add(this.rdbB2C);
            this.groupBox2.Controls.Add(this.rdbB2B);
            this.groupBox2.Location = new System.Drawing.Point(87, 104);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(112, 93);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // rdbBoth
            // 
            this.rdbBoth.AutoSize = true;
            this.rdbBoth.Location = new System.Drawing.Point(6, 61);
            this.rdbBoth.Name = "rdbBoth";
            this.rdbBoth.Size = new System.Drawing.Size(47, 17);
            this.rdbBoth.TabIndex = 5;
            this.rdbBoth.Text = "Both";
            this.rdbBoth.UseVisualStyleBackColor = true;
            // 
            // rdbB2C
            // 
            this.rdbB2C.AutoSize = true;
            this.rdbB2C.Location = new System.Drawing.Point(6, 38);
            this.rdbB2C.Name = "rdbB2C";
            this.rdbB2C.Size = new System.Drawing.Size(51, 17);
            this.rdbB2C.TabIndex = 6;
            this.rdbB2C.Text = "B 2 C";
            this.rdbB2C.UseVisualStyleBackColor = true;
            // 
            // rdbB2B
            // 
            this.rdbB2B.AutoSize = true;
            this.rdbB2B.Checked = true;
            this.rdbB2B.Location = new System.Drawing.Point(6, 15);
            this.rdbB2B.Name = "rdbB2B";
            this.rdbB2B.Size = new System.Drawing.Size(51, 17);
            this.rdbB2B.TabIndex = 7;
            this.rdbB2B.TabStop = true;
            this.rdbB2B.Text = "B 2 B";
            this.rdbB2B.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(26, 115);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(60, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Sales Type";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(61, 68);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(20, 13);
            this.label3.TabIndex = 1;
            this.label3.Text = "To";
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
            this.dtpEndDate.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtpEndDate.Location = new System.Drawing.Point(87, 65);
            this.dtpEndDate.Name = "dtpEndDate";
            this.dtpEndDate.Size = new System.Drawing.Size(112, 20);
            this.dtpEndDate.TabIndex = 0;
            // 
            // btnGenerateAndPrint
            // 
            this.btnGenerateAndPrint.Location = new System.Drawing.Point(279, 51);
            this.btnGenerateAndPrint.Name = "btnGenerateAndPrint";
            this.btnGenerateAndPrint.Size = new System.Drawing.Size(96, 23);
            this.btnGenerateAndPrint.TabIndex = 1;
            this.btnGenerateAndPrint.Text = "Generate && Print";
            this.btnGenerateAndPrint.UseVisualStyleBackColor = true;
            this.btnGenerateAndPrint.Click += new System.EventHandler(this.btnGenerateAndPrint_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(279, 81);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(96, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // btnGenerateAndView
            // 
            this.btnGenerateAndView.Location = new System.Drawing.Point(279, 20);
            this.btnGenerateAndView.Name = "btnGenerateAndView";
            this.btnGenerateAndView.Size = new System.Drawing.Size(96, 23);
            this.btnGenerateAndView.TabIndex = 3;
            this.btnGenerateAndView.Text = "Generate && View";
            this.btnGenerateAndView.UseVisualStyleBackColor = true;
            this.btnGenerateAndView.Click += new System.EventHandler(this.btnGenerateAndView_Click);
            // 
            // SalesRegister
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(396, 235);
            this.Controls.Add(this.btnGenerateAndView);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnGenerateAndPrint);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SalesRegister";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Report  -  Sales Register";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DateTimePicker dtpEndDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpStartDate;
        private System.Windows.Forms.Button btnGenerateAndPrint;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Button btnGenerateAndView;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton rdbBoth;
        private System.Windows.Forms.RadioButton rdbB2C;
        private System.Windows.Forms.RadioButton rdbB2B;
        private System.Windows.Forms.Label label6;
    }
}