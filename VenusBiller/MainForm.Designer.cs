namespace VenusBiller
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.btnNewBill = new System.Windows.Forms.Button();
            this.btnBillWiseReport = new System.Windows.Forms.Button();
            this.btnItemWiseReport = new System.Windows.Forms.Button();
            this.btnTaxCategoryWiseReport = new System.Windows.Forms.Button();
            this.btnSalesRegister = new System.Windows.Forms.Button();
            this.btnSalesreturn = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnNewBill
            // 
            this.btnNewBill.Location = new System.Drawing.Point(269, 86);
            this.btnNewBill.Name = "btnNewBill";
            this.btnNewBill.Size = new System.Drawing.Size(101, 83);
            this.btnNewBill.TabIndex = 0;
            this.btnNewBill.Text = "New Bill";
            this.btnNewBill.UseVisualStyleBackColor = true;
            this.btnNewBill.Click += new System.EventHandler(this.btnNewBill_Click);
            // 
            // btnBillWiseReport
            // 
            this.btnBillWiseReport.Location = new System.Drawing.Point(33, 232);
            this.btnBillWiseReport.Name = "btnBillWiseReport";
            this.btnBillWiseReport.Size = new System.Drawing.Size(101, 83);
            this.btnBillWiseReport.TabIndex = 0;
            this.btnBillWiseReport.Text = "Bill Wise";
            this.btnBillWiseReport.UseVisualStyleBackColor = true;
            this.btnBillWiseReport.Click += new System.EventHandler(this.btnBillWiseReport_Click);
            // 
            // btnItemWiseReport
            // 
            this.btnItemWiseReport.Location = new System.Drawing.Point(182, 232);
            this.btnItemWiseReport.Name = "btnItemWiseReport";
            this.btnItemWiseReport.Size = new System.Drawing.Size(101, 83);
            this.btnItemWiseReport.TabIndex = 0;
            this.btnItemWiseReport.Text = "Item Wise";
            this.btnItemWiseReport.UseVisualStyleBackColor = true;
            this.btnItemWiseReport.Click += new System.EventHandler(this.btnItemWiseReport_Click);
            // 
            // btnTaxCategoryWiseReport
            // 
            this.btnTaxCategoryWiseReport.Location = new System.Drawing.Point(331, 232);
            this.btnTaxCategoryWiseReport.Name = "btnTaxCategoryWiseReport";
            this.btnTaxCategoryWiseReport.Size = new System.Drawing.Size(101, 83);
            this.btnTaxCategoryWiseReport.TabIndex = 0;
            this.btnTaxCategoryWiseReport.Text = "Monthly Summary";
            this.btnTaxCategoryWiseReport.UseVisualStyleBackColor = true;
            this.btnTaxCategoryWiseReport.Click += new System.EventHandler(this.btnTaxCategoryWiseReport_Click);
            // 
            // btnSalesRegister
            // 
            this.btnSalesRegister.Location = new System.Drawing.Point(480, 232);
            this.btnSalesRegister.Name = "btnSalesRegister";
            this.btnSalesRegister.Size = new System.Drawing.Size(101, 83);
            this.btnSalesRegister.TabIndex = 0;
            this.btnSalesRegister.Text = "Sales Register";
            this.btnSalesRegister.UseVisualStyleBackColor = true;
            this.btnSalesRegister.Click += new System.EventHandler(this.btnSalesRegister_Click);
            // 
            // btnSalesreturn
            // 
            this.btnSalesreturn.Location = new System.Drawing.Point(629, 232);
            this.btnSalesreturn.Name = "btnSalesreturn";
            this.btnSalesreturn.Size = new System.Drawing.Size(101, 83);
            this.btnSalesreturn.TabIndex = 0;
            this.btnSalesreturn.Text = "Sales Return";
            this.btnSalesreturn.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(417, 86);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(101, 83);
            this.button1.TabIndex = 0;
            this.button1.Text = "Modify Bill";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(762, 511);
            this.Controls.Add(this.btnSalesreturn);
            this.Controls.Add(this.btnSalesRegister);
            this.Controls.Add(this.btnTaxCategoryWiseReport);
            this.Controls.Add(this.btnItemWiseReport);
            this.Controls.Add(this.btnBillWiseReport);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.btnNewBill);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Venus Distributors - Billing Assistant";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnNewBill;
        private System.Windows.Forms.Button btnBillWiseReport;
        private System.Windows.Forms.Button btnItemWiseReport;
        private System.Windows.Forms.Button btnTaxCategoryWiseReport;
        private System.Windows.Forms.Button btnSalesRegister;
        private System.Windows.Forms.Button btnSalesreturn;
        private System.Windows.Forms.Button button1;
    }
}