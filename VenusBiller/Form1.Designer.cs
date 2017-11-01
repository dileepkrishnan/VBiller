using System.Windows.Forms.VisualStyles;

namespace VenusBiller
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dateTimePicker1 = new System.Windows.Forms.DateTimePicker();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.txtBillNumber = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtPartyAddress = new System.Windows.Forms.TextBox();
            this.txtPartyName = new System.Windows.Forms.TextBox();
            this.txtPartyCode = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label17 = new System.Windows.Forms.Label();
            this.txtCessAmount = new System.Windows.Forms.TextBox();
            this.label15 = new System.Windows.Forms.Label();
            this.txtPresentBalance = new System.Windows.Forms.TextBox();
            this.label14 = new System.Windows.Forms.Label();
            this.txtRoundOff = new System.Windows.Forms.TextBox();
            this.label13 = new System.Windows.Forms.Label();
            this.txtGrandTotal = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.label12 = new System.Windows.Forms.Label();
            this.txtGstAmount = new System.Windows.Forms.TextBox();
            this.txtSpecialDiscountAmount = new System.Windows.Forms.TextBox();
            this.txtSubTotal = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.txtSpecialDiscountPercentage = new System.Windows.Forms.TextBox();
            this.txtDiscount = new System.Windows.Forms.TextBox();
            this.txtTotal = new System.Windows.Forms.TextBox();
            this.txtRoundedTotal = new System.Windows.Forms.TextBox();
            this.label16 = new System.Windows.Forms.Label();
            this.btnSaveAndPrint = new System.Windows.Forms.Button();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.dgvItems = new Syncfusion.Windows.Forms.Grid.GridDataBoundGrid();
            this.ItemNumber = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.ItemCode = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.Remove = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.ItemName = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.MaximumRetailPrice = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.Quantity = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.Rate = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.DiscountPercent = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.GstPercent = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.CessPercent = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.NetAmount = new Syncfusion.Windows.Forms.Grid.GridBoundColumn();
            this.groupBox5 = new System.Windows.Forms.GroupBox();
            this.label18 = new System.Windows.Forms.Label();
            this.cboSalesType = new System.Windows.Forms.ComboBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).BeginInit();
            this.groupBox5.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dateTimePicker1);
            this.groupBox1.Controls.Add(this.textBox2);
            this.groupBox1.Controls.Add(this.txtBillNumber);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.groupBox1.Location = new System.Drawing.Point(12, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(209, 91);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            // 
            // dateTimePicker1
            // 
            this.dateTimePicker1.CustomFormat = "dd-MM-yyyy";
            this.dateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dateTimePicker1.Location = new System.Drawing.Point(70, 63);
            this.dateTimePicker1.Name = "dateTimePicker1";
            this.dateTimePicker1.Size = new System.Drawing.Size(127, 20);
            this.dateTimePicker1.TabIndex = 4;
            this.dateTimePicker1.TabStop = false;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(70, 38);
            this.textBox2.Name = "textBox2";
            this.textBox2.ReadOnly = true;
            this.textBox2.Size = new System.Drawing.Size(127, 20);
            this.textBox2.TabIndex = 3;
            this.textBox2.TabStop = false;
            this.textBox2.Text = "2 Cash";
            // 
            // txtBillNumber
            // 
            this.txtBillNumber.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtBillNumber.ForeColor = System.Drawing.Color.Red;
            this.txtBillNumber.Location = new System.Drawing.Point(70, 12);
            this.txtBillNumber.Name = "txtBillNumber";
            this.txtBillNumber.ReadOnly = true;
            this.txtBillNumber.Size = new System.Drawing.Size(127, 21);
            this.txtBillNumber.TabIndex = 3;
            this.txtBillNumber.TabStop = false;
            this.txtBillNumber.Text = "1234";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(6, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Bill Date";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 2;
            this.label2.Text = "Price Type";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(40, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Bill No.";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.label6);
            this.groupBox3.Controls.Add(this.label5);
            this.groupBox3.Controls.Add(this.label4);
            this.groupBox3.Controls.Add(this.txtPartyAddress);
            this.groupBox3.Controls.Add(this.txtPartyName);
            this.groupBox3.Controls.Add(this.txtPartyCode);
            this.groupBox3.Location = new System.Drawing.Point(248, 1);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(394, 91);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(6, 63);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(45, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Address";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(6, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(35, 13);
            this.label5.TabIndex = 6;
            this.label5.Text = "Name";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(6, 14);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 6;
            this.label4.Text = "Party Code";
            // 
            // txtPartyAddress
            // 
            this.txtPartyAddress.Location = new System.Drawing.Point(76, 62);
            this.txtPartyAddress.Name = "txtPartyAddress";
            this.txtPartyAddress.Size = new System.Drawing.Size(307, 20);
            this.txtPartyAddress.TabIndex = 5;
            this.txtPartyAddress.TabStop = false;
            // 
            // txtPartyName
            // 
            this.txtPartyName.Location = new System.Drawing.Point(76, 37);
            this.txtPartyName.Name = "txtPartyName";
            this.txtPartyName.Size = new System.Drawing.Size(307, 20);
            this.txtPartyName.TabIndex = 1;
            this.txtPartyName.TabStop = false;
            // 
            // txtPartyCode
            // 
            this.txtPartyCode.Location = new System.Drawing.Point(76, 12);
            this.txtPartyCode.Name = "txtPartyCode";
            this.txtPartyCode.Size = new System.Drawing.Size(307, 20);
            this.txtPartyCode.TabIndex = 1;
            this.txtPartyCode.DoubleClick += new System.EventHandler(this.txtPartyCode_DoubleClick);
            this.txtPartyCode.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtPartyCode_KeyPress);
            this.txtPartyCode.KeyUp += new System.Windows.Forms.KeyEventHandler(this.txtPartyCode_KeyUp);
            this.txtPartyCode.Leave += new System.EventHandler(this.txtPartyCode_Leave);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label17);
            this.groupBox2.Controls.Add(this.txtCessAmount);
            this.groupBox2.Controls.Add(this.label15);
            this.groupBox2.Controls.Add(this.txtPresentBalance);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.txtRoundOff);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.txtGrandTotal);
            this.groupBox2.Controls.Add(this.label10);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.label12);
            this.groupBox2.Controls.Add(this.txtGstAmount);
            this.groupBox2.Controls.Add(this.txtSpecialDiscountAmount);
            this.groupBox2.Controls.Add(this.txtSubTotal);
            this.groupBox2.Controls.Add(this.label7);
            this.groupBox2.Controls.Add(this.label8);
            this.groupBox2.Controls.Add(this.label9);
            this.groupBox2.Controls.Add(this.txtSpecialDiscountPercentage);
            this.groupBox2.Controls.Add(this.txtDiscount);
            this.groupBox2.Controls.Add(this.txtTotal);
            this.groupBox2.Location = new System.Drawing.Point(12, 382);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(435, 226);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            // 
            // label17
            // 
            this.label17.AutoSize = true;
            this.label17.Location = new System.Drawing.Point(6, 166);
            this.label17.Name = "label17";
            this.label17.Size = new System.Drawing.Size(51, 13);
            this.label17.TabIndex = 20;
            this.label17.Text = "Cess Amt";
            // 
            // txtCessAmount
            // 
            this.txtCessAmount.Location = new System.Drawing.Point(76, 164);
            this.txtCessAmount.Name = "txtCessAmount";
            this.txtCessAmount.ReadOnly = true;
            this.txtCessAmount.Size = new System.Drawing.Size(121, 20);
            this.txtCessAmount.TabIndex = 19;
            this.txtCessAmount.TabStop = false;
            this.txtCessAmount.Text = "0.0";
            // 
            // label15
            // 
            this.label15.AutoSize = true;
            this.label15.Location = new System.Drawing.Point(213, 42);
            this.label15.Name = "label15";
            this.label15.Size = new System.Drawing.Size(85, 13);
            this.label15.TabIndex = 18;
            this.label15.Text = "Present Balance";
            // 
            // txtPresentBalance
            // 
            this.txtPresentBalance.Location = new System.Drawing.Point(305, 39);
            this.txtPresentBalance.Name = "txtPresentBalance";
            this.txtPresentBalance.ReadOnly = true;
            this.txtPresentBalance.Size = new System.Drawing.Size(121, 20);
            this.txtPresentBalance.TabIndex = 17;
            this.txtPresentBalance.TabStop = false;
            this.txtPresentBalance.Text = "0.0";
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Location = new System.Drawing.Point(213, 17);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(54, 13);
            this.label14.TabIndex = 16;
            this.label14.Text = "Round off";
            // 
            // txtRoundOff
            // 
            this.txtRoundOff.Location = new System.Drawing.Point(305, 13);
            this.txtRoundOff.Name = "txtRoundOff";
            this.txtRoundOff.ReadOnly = true;
            this.txtRoundOff.Size = new System.Drawing.Size(121, 20);
            this.txtRoundOff.TabIndex = 15;
            this.txtRoundOff.TabStop = false;
            this.txtRoundOff.Text = "0.0";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Location = new System.Drawing.Point(6, 191);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 13);
            this.label13.TabIndex = 14;
            this.label13.Text = "Grand Total";
            // 
            // txtGrandTotal
            // 
            this.txtGrandTotal.Location = new System.Drawing.Point(76, 190);
            this.txtGrandTotal.Name = "txtGrandTotal";
            this.txtGrandTotal.ReadOnly = true;
            this.txtGrandTotal.Size = new System.Drawing.Size(121, 20);
            this.txtGrandTotal.TabIndex = 13;
            this.txtGrandTotal.TabStop = false;
            this.txtGrandTotal.Text = "0.0";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(6, 140);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(50, 13);
            this.label10.TabIndex = 10;
            this.label10.Text = "GST Amt";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(6, 116);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 13);
            this.label11.TabIndex = 11;
            this.label11.Text = "Sub Total";
            // 
            // label12
            // 
            this.label12.AutoSize = true;
            this.label12.Location = new System.Drawing.Point(6, 91);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(67, 13);
            this.label12.TabIndex = 12;
            this.label12.Text = "Spl Disc Amt";
            // 
            // txtGstAmount
            // 
            this.txtGstAmount.Location = new System.Drawing.Point(76, 139);
            this.txtGstAmount.Name = "txtGstAmount";
            this.txtGstAmount.ReadOnly = true;
            this.txtGstAmount.Size = new System.Drawing.Size(121, 20);
            this.txtGstAmount.TabIndex = 7;
            this.txtGstAmount.TabStop = false;
            this.txtGstAmount.Text = "0.0";
            // 
            // txtSpecialDiscountAmount
            // 
            this.txtSpecialDiscountAmount.Location = new System.Drawing.Point(76, 88);
            this.txtSpecialDiscountAmount.Name = "txtSpecialDiscountAmount";
            this.txtSpecialDiscountAmount.Size = new System.Drawing.Size(121, 20);
            this.txtSpecialDiscountAmount.TabIndex = 8;
            this.txtSpecialDiscountAmount.TabStop = false;
            this.txtSpecialDiscountAmount.Text = "0.0";
            this.txtSpecialDiscountAmount.Click += new System.EventHandler(this.txtSpecialDiscountAmount_Click);
            this.txtSpecialDiscountAmount.TextChanged += new System.EventHandler(this.txtSpecialDiscountAmount_TextChanged);
            this.txtSpecialDiscountAmount.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSpecialDiscountAmount_KeyPress);
            // 
            // txtSubTotal
            // 
            this.txtSubTotal.Location = new System.Drawing.Point(76, 114);
            this.txtSubTotal.Name = "txtSubTotal";
            this.txtSubTotal.ReadOnly = true;
            this.txtSubTotal.Size = new System.Drawing.Size(121, 20);
            this.txtSubTotal.TabIndex = 8;
            this.txtSubTotal.TabStop = false;
            this.txtSubTotal.Text = "0.0";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(6, 64);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(57, 13);
            this.label7.TabIndex = 6;
            this.label7.Text = "Spl Disc %";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(6, 40);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(49, 13);
            this.label8.TabIndex = 6;
            this.label8.Text = "Discount";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(6, 15);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(31, 13);
            this.label9.TabIndex = 6;
            this.label9.Text = "Total";
            // 
            // txtSpecialDiscountPercentage
            // 
            this.txtSpecialDiscountPercentage.Location = new System.Drawing.Point(76, 63);
            this.txtSpecialDiscountPercentage.Name = "txtSpecialDiscountPercentage";
            this.txtSpecialDiscountPercentage.ReadOnly = true;
            this.txtSpecialDiscountPercentage.ShortcutsEnabled = false;
            this.txtSpecialDiscountPercentage.Size = new System.Drawing.Size(121, 20);
            this.txtSpecialDiscountPercentage.TabIndex = 4;
            this.txtSpecialDiscountPercentage.Text = "0.0";
            // 
            // txtDiscount
            // 
            this.txtDiscount.Location = new System.Drawing.Point(76, 38);
            this.txtDiscount.Name = "txtDiscount";
            this.txtDiscount.ReadOnly = true;
            this.txtDiscount.Size = new System.Drawing.Size(121, 20);
            this.txtDiscount.TabIndex = 5;
            this.txtDiscount.TabStop = false;
            this.txtDiscount.Text = "0.0";
            // 
            // txtTotal
            // 
            this.txtTotal.Location = new System.Drawing.Point(76, 13);
            this.txtTotal.Name = "txtTotal";
            this.txtTotal.ReadOnly = true;
            this.txtTotal.Size = new System.Drawing.Size(121, 20);
            this.txtTotal.TabIndex = 5;
            this.txtTotal.TabStop = false;
            this.txtTotal.Text = "0.0";
            // 
            // txtRoundedTotal
            // 
            this.txtRoundedTotal.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRoundedTotal.ForeColor = System.Drawing.Color.Red;
            this.txtRoundedTotal.Location = new System.Drawing.Point(884, 384);
            this.txtRoundedTotal.Name = "txtRoundedTotal";
            this.txtRoundedTotal.ReadOnly = true;
            this.txtRoundedTotal.Size = new System.Drawing.Size(149, 30);
            this.txtRoundedTotal.TabIndex = 17;
            this.txtRoundedTotal.TabStop = false;
            this.txtRoundedTotal.Text = "0";
            // 
            // label16
            // 
            this.label16.AutoSize = true;
            this.label16.Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label16.Location = new System.Drawing.Point(817, 387);
            this.label16.Name = "label16";
            this.label16.Size = new System.Drawing.Size(61, 25);
            this.label16.TabIndex = 18;
            this.label16.Text = "Total";
            // 
            // btnSaveAndPrint
            // 
            this.btnSaveAndPrint.Enabled = false;
            this.btnSaveAndPrint.Location = new System.Drawing.Point(884, 438);
            this.btnSaveAndPrint.Name = "btnSaveAndPrint";
            this.btnSaveAndPrint.Size = new System.Drawing.Size(149, 23);
            this.btnSaveAndPrint.TabIndex = 4;
            this.btnSaveAndPrint.Text = "Save &&& Print";
            this.btnSaveAndPrint.UseVisualStyleBackColor = true;
            this.btnSaveAndPrint.Click += new System.EventHandler(this.btnSaveAndPrint_Click);
            // 
            // btnSave
            // 
            this.btnSave.Enabled = false;
            this.btnSave.Location = new System.Drawing.Point(884, 470);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(149, 23);
            this.btnSave.TabIndex = 5;
            this.btnSave.Text = "&Save";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(884, 499);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(149, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "&Close";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.dgvItems);
            this.groupBox4.Location = new System.Drawing.Point(9, 95);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(1027, 276);
            this.groupBox4.TabIndex = 19;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Items";
            // 
            // dgvItems
            // 
            this.dgvItems.AllowDragSelectedCols = true;
            this.dgvItems.AllowResizeToFit = false;
            this.dgvItems.AllowSelection = Syncfusion.Windows.Forms.Grid.GridSelectionFlags.Cell;
            this.dgvItems.BackColor = System.Drawing.Color.White;
            this.dgvItems.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.dgvItems.ColorStyles = Syncfusion.Windows.Forms.ColorStyles.Office2007Blue;
            this.dgvItems.ControllerOptions = ((Syncfusion.Windows.Forms.Grid.GridControllerOptions)(((Syncfusion.Windows.Forms.Grid.GridControllerOptions.ClickCells | Syncfusion.Windows.Forms.Grid.GridControllerOptions.SelectCells) 
            | Syncfusion.Windows.Forms.Grid.GridControllerOptions.ResizeCells)));
            this.dgvItems.DefaultRowHeight = 22;
            this.dgvItems.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dgvItems.ExcelLikeSelectionFrame = true;
            this.dgvItems.GridBoundColumns.AddRange(new Syncfusion.Windows.Forms.Grid.GridBoundColumn[] {
            this.ItemNumber,
            this.ItemCode,
            this.Remove,
            this.ItemName,
            this.MaximumRetailPrice,
            this.Quantity,
            this.Rate,
            this.DiscountPercent,
            this.GstPercent,
            this.CessPercent,
            this.NetAmount});
            this.dgvItems.GridOfficeScrollBars = Syncfusion.Windows.Forms.OfficeScrollBars.Office2007;
            this.dgvItems.GridVisualStyles = Syncfusion.Windows.Forms.GridVisualStyles.Office2007Blue;
            this.dgvItems.Location = new System.Drawing.Point(3, 16);
            this.dgvItems.Name = "dgvItems";
            this.dgvItems.Office2007ScrollBars = true;
            this.dgvItems.OptimizeInsertRemoveCells = true;
            this.dgvItems.Properties.RowHeaders = false;
            this.dgvItems.ResizeColsBehavior = Syncfusion.Windows.Forms.Grid.GridResizeCellsBehavior.None;
            this.dgvItems.ResizeRowsBehavior = Syncfusion.Windows.Forms.Grid.GridResizeCellsBehavior.None;
            this.dgvItems.ShowCurrentCellBorderBehavior = Syncfusion.Windows.Forms.Grid.GridShowCurrentCellBorder.GrayWhenLostFocus;
            this.dgvItems.Size = new System.Drawing.Size(1021, 257);
            this.dgvItems.SmartSizeBox = false;
            this.dgvItems.SortBehavior = Syncfusion.Windows.Forms.Grid.GridSortBehavior.None;
            this.dgvItems.TabIndex = 3;
            this.dgvItems.Text = "gridDataBoundGrid1";
            this.dgvItems.ThemesEnabled = true;
            this.dgvItems.UseListChangedEvent = true;
            this.dgvItems.UseRightToLeftCompatibleTextBox = true;
            this.dgvItems.VerticalScrollTips = true;
            this.dgvItems.PrepareViewStyleInfo += new Syncfusion.Windows.Forms.Grid.GridPrepareViewStyleInfoEventHandler(this.dgvItems_PrepareViewStyleInfo);
            this.dgvItems.CurrentCellStartEditing += new System.ComponentModel.CancelEventHandler(this.dgvItems_CurrentCellStartEditing);
            this.dgvItems.CurrentCellChanged += new System.EventHandler(this.dgvItems_CurrentCellChanged);
            this.dgvItems.CurrentCellEditingComplete += new System.EventHandler(this.dgvItems_CurrentCellEditingComplete);
            this.dgvItems.CurrentCellControlDoubleClick += new System.Windows.Forms.ControlEventHandler(this.dgvItems_CurrentCellControlDoubleClick);
            this.dgvItems.CurrentCellKeyPress += new System.Windows.Forms.KeyPressEventHandler(this.dgvItems_CurrentCellKeyPress);
            this.dgvItems.CurrentCellKeyDown += new System.Windows.Forms.KeyEventHandler(this.dgvItems_CurrentCellKeyDown);
            // 
            // ItemNumber
            // 
            this.ItemNumber.HeaderText = "Sl/No.";
            this.ItemNumber.Hidden = false;
            this.ItemNumber.MappingName = "ItemNumber";
            this.ItemNumber.Position = 1;
            this.ItemNumber.ReadOnly = true;
            this.ItemNumber.StyleInfo.AllowEnter = true;
            this.ItemNumber.StyleInfo.CellType = "TextBox";
            this.ItemNumber.Width = 50;
            // 
            // ItemCode
            // 
            this.ItemCode.HeaderText = "Item Code";
            this.ItemCode.Hidden = false;
            this.ItemCode.MappingName = "Code";
            this.ItemCode.Position = 2;
            this.ItemCode.ReadOnly = true;
            this.ItemCode.StyleInfo.CellType = "TextBox";
            this.ItemCode.StyleInfo.DisplayMember = "Code";
            this.ItemCode.StyleInfo.ShowButtons = Syncfusion.Windows.Forms.Grid.GridShowButtons.Hide;
            this.ItemCode.Width = 130;
            // 
            // Remove
            // 
            this.Remove.HeaderText = "(-)";
            this.Remove.Hidden = false;
            this.Remove.MappingName = "Remove";
            this.Remove.Position = 3;
            this.Remove.StyleInfo.CellType = "PushButton";
            this.Remove.StyleInfo.Interior = new Syncfusion.Drawing.BrushInfo(System.Drawing.Color.Red);
            this.Remove.Width = 25;
            // 
            // ItemName
            // 
            this.ItemName.HeaderText = "Item Description";
            this.ItemName.Hidden = false;
            this.ItemName.MappingName = "Name";
            this.ItemName.Position = 4;
            this.ItemName.ReadOnly = true;
            this.ItemName.Width = 320;
            // 
            // MaximumRetailPrice
            // 
            this.MaximumRetailPrice.HeaderText = "Mrp";
            this.MaximumRetailPrice.Hidden = false;
            this.MaximumRetailPrice.MappingName = "MaximumRetailPrice";
            this.MaximumRetailPrice.Position = 5;
            this.MaximumRetailPrice.ReadOnly = true;
            this.MaximumRetailPrice.Width = 70;
            // 
            // Quantity
            // 
            this.Quantity.HeaderText = "Qty";
            this.Quantity.Hidden = false;
            this.Quantity.MappingName = "Quantity";
            this.Quantity.Position = 6;
            this.Quantity.Width = 65;
            // 
            // Rate
            // 
            this.Rate.HeaderText = "Rate";
            this.Rate.Hidden = false;
            this.Rate.MappingName = "Rate";
            this.Rate.Position = 7;
            this.Rate.ReadOnly = true;
            this.Rate.Width = 65;
            // 
            // DiscountPercent
            // 
            this.DiscountPercent.HeaderText = "Disc%";
            this.DiscountPercent.Hidden = false;
            this.DiscountPercent.MappingName = "DiscountPercent";
            this.DiscountPercent.Position = 8;
            this.DiscountPercent.Width = 65;
            // 
            // GstPercent
            // 
            this.GstPercent.HeaderText = "Gst%";
            this.GstPercent.Hidden = false;
            this.GstPercent.MappingName = "GstPercent";
            this.GstPercent.Position = 9;
            this.GstPercent.ReadOnly = true;
            this.GstPercent.Width = 65;
            // 
            // CessPercent
            // 
            this.CessPercent.HeaderText = "Cess%";
            this.CessPercent.Hidden = false;
            this.CessPercent.MappingName = "CessPercent";
            this.CessPercent.Position = 10;
            this.CessPercent.ReadOnly = true;
            this.CessPercent.Width = 65;
            // 
            // NetAmount
            // 
            this.NetAmount.HeaderText = "Net Amount";
            this.NetAmount.Hidden = false;
            this.NetAmount.MappingName = "NetAmount";
            this.NetAmount.Position = 11;
            this.NetAmount.ReadOnly = true;
            this.NetAmount.StyleInfo.Format = "";
            this.NetAmount.Width = 90;
            // 
            // groupBox5
            // 
            this.groupBox5.Controls.Add(this.label18);
            this.groupBox5.Controls.Add(this.cboSalesType);
            this.groupBox5.Location = new System.Drawing.Point(657, 1);
            this.groupBox5.Name = "groupBox5";
            this.groupBox5.Size = new System.Drawing.Size(205, 91);
            this.groupBox5.TabIndex = 21;
            this.groupBox5.TabStop = false;
            // 
            // label18
            // 
            this.label18.AutoSize = true;
            this.label18.Location = new System.Drawing.Point(8, 16);
            this.label18.Name = "label18";
            this.label18.Size = new System.Drawing.Size(60, 13);
            this.label18.TabIndex = 22;
            this.label18.Text = "Sales Type";
            // 
            // cboSalesType
            // 
            this.cboSalesType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cboSalesType.FormattingEnabled = true;
            this.cboSalesType.Location = new System.Drawing.Point(74, 13);
            this.cboSalesType.Name = "cboSalesType";
            this.cboSalesType.Size = new System.Drawing.Size(121, 21);
            this.cboSalesType.TabIndex = 2;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1048, 620);
            this.Controls.Add(this.groupBox5);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSave);
            this.Controls.Add(this.btnSaveAndPrint);
            this.Controls.Add(this.label16);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.txtRoundedTotal);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Bill Entry - Venus Distributors";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgvItems)).EndInit();
            this.groupBox5.ResumeLayout(false);
            this.groupBox5.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.DateTimePicker dateTimePicker1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox txtBillNumber;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txtPartyCode;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.TextBox txtPartyAddress;
        private System.Windows.Forms.TextBox txtPartyName;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.TextBox txtGrandTotal;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.TextBox txtGstAmount;
        private System.Windows.Forms.TextBox txtSubTotal;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txtSpecialDiscountPercentage;
        private System.Windows.Forms.TextBox txtDiscount;
        private System.Windows.Forms.TextBox txtTotal;
        private System.Windows.Forms.Label label15;
        private System.Windows.Forms.TextBox txtPresentBalance;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.TextBox txtRoundOff;
        private System.Windows.Forms.Label label16;
        private System.Windows.Forms.TextBox txtRoundedTotal;
        private System.Windows.Forms.Button btnSaveAndPrint;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox4;
        private Syncfusion.Windows.Forms.Grid.GridDataBoundGrid dgvItems;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn ItemNumber;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn ItemCode;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn ItemName;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn MaximumRetailPrice;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn Quantity;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn Rate;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn DiscountPercent;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn GstPercent;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn CessPercent;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn NetAmount;
        private System.Windows.Forms.Label label17;
        private System.Windows.Forms.TextBox txtCessAmount;
        private System.Windows.Forms.TextBox txtSpecialDiscountAmount;
        private Syncfusion.Windows.Forms.Grid.GridBoundColumn Remove;
        private System.Windows.Forms.GroupBox groupBox5;
        private System.Windows.Forms.Label label18;
        private System.Windows.Forms.ComboBox cboSalesType;
    }
}

