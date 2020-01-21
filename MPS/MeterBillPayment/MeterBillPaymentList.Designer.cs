namespace MPS.MeterBillPayment {
    partial class MeterBillPaymentList {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing) {
            if (disposing && (components != null)) {
                components.Dispose();
                }
            base.Dispose(disposing);
            }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent() {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterBillPaymentList));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.cboQuarter = new System.Windows.Forms.ComboBox();
            this.cboTownship = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.dtptoDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.txtCustomerCode = new System.Windows.Forms.TextBox();
            this.txtBillCodeNo = new System.Windows.Forms.TextBox();
            this.txtCustomerName = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.gvmeterbillinvoice = new System.Windows.Forms.DataGridView();
            this.MeterBillID = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CustomerName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TownshipName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.QuarterName = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterBillCode = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.InvoiceDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.ServicesFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.MeterFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.StreetLightFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.TotalFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.UsageUnit = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CurrentMonthUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PreviousMonthUnits = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdvanceMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CreditMoney = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Remark = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.HorsePowerFees = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditonalFees1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditonalFees2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.AdditonalFees3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Edit = new System.Windows.Forms.DataGridViewLinkColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvmeterbillinvoice)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.cboQuarter);
            this.groupBox1.Controls.Add(this.cboTownship);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.dtptoDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.txtCustomerCode);
            this.groupBox1.Controls.Add(this.txtBillCodeNo);
            this.groupBox1.Controls.Add(this.txtCustomerName);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.label7);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(0, 0);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(664, 184);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search By";
            // 
            // cboQuarter
            // 
            this.cboQuarter.Font = new System.Drawing.Font("Myanmar3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboQuarter.FormattingEnabled = true;
            this.cboQuarter.Location = new System.Drawing.Point(434, 68);
            this.cboQuarter.Name = "cboQuarter";
            this.cboQuarter.Size = new System.Drawing.Size(224, 22);
            this.cboQuarter.TabIndex = 11;
            // 
            // cboTownship
            // 
            this.cboTownship.Font = new System.Drawing.Font("Myanmar3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTownship.FormattingEnabled = true;
            this.cboTownship.Location = new System.Drawing.Point(434, 33);
            this.cboTownship.Name = "cboTownship";
            this.cboTownship.Size = new System.Drawing.Size(224, 22);
            this.cboTownship.TabIndex = 12;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(542, 143);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(100, 26);
            this.btnCancel.TabIndex = 10;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(434, 143);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(102, 26);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // dtptoDate
            // 
            this.dtptoDate.Location = new System.Drawing.Point(98, 77);
            this.dtptoDate.Name = "dtptoDate";
            this.dtptoDate.Size = new System.Drawing.Size(200, 20);
            this.dtptoDate.TabIndex = 8;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Location = new System.Drawing.Point(98, 33);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(200, 20);
            this.dtpFromDate.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 77);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 6;
            this.label3.Text = "To Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 33);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 13);
            this.label4.TabIndex = 7;
            this.label4.Text = "From Date:";
            // 
            // txtCustomerCode
            // 
            this.txtCustomerCode.Location = new System.Drawing.Point(98, 149);
            this.txtCustomerCode.Name = "txtCustomerCode";
            this.txtCustomerCode.Size = new System.Drawing.Size(194, 20);
            this.txtCustomerCode.TabIndex = 1;
            // 
            // txtBillCodeNo
            // 
            this.txtBillCodeNo.Location = new System.Drawing.Point(434, 112);
            this.txtBillCodeNo.Name = "txtBillCodeNo";
            this.txtBillCodeNo.Size = new System.Drawing.Size(224, 20);
            this.txtBillCodeNo.TabIndex = 1;
            // 
            // txtCustomerName
            // 
            this.txtCustomerName.Location = new System.Drawing.Point(98, 115);
            this.txtCustomerName.Name = "txtCustomerName";
            this.txtCustomerName.Size = new System.Drawing.Size(194, 20);
            this.txtCustomerName.TabIndex = 1;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(330, 77);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(76, 13);
            this.label6.TabIndex = 1;
            this.label6.Text = "Quarter Name:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 146);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Customer Code:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(330, 39);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(87, 13);
            this.label5.TabIndex = 1;
            this.label5.Text = "Township Name:";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(330, 115);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(98, 13);
            this.label7.TabIndex = 1;
            this.label7.Text = "Meter Bill Code No:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 115);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Customer Name:";
            // 
            // gvmeterbillinvoice
            // 
            this.gvmeterbillinvoice.AllowUserToAddRows = false;
            this.gvmeterbillinvoice.AllowUserToDeleteRows = false;
            this.gvmeterbillinvoice.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvmeterbillinvoice.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MeterBillID,
            this.CustomerName,
            this.TownshipName,
            this.QuarterName,
            this.MeterBillCode,
            this.InvoiceDate,
            this.ServicesFees,
            this.MeterFees,
            this.StreetLightFees,
            this.TotalFees,
            this.UsageUnit,
            this.CurrentMonthUnits,
            this.PreviousMonthUnits,
            this.AdvanceMoney,
            this.CreditMoney,
            this.Remark,
            this.HorsePowerFees,
            this.AdditonalFees1,
            this.AdditonalFees2,
            this.AdditonalFees3,
            this.Edit});
            this.gvmeterbillinvoice.Location = new System.Drawing.Point(0, 190);
            this.gvmeterbillinvoice.Name = "gvmeterbillinvoice";
            this.gvmeterbillinvoice.ReadOnly = true;
            this.gvmeterbillinvoice.Size = new System.Drawing.Size(1355, 209);
            this.gvmeterbillinvoice.TabIndex = 1;
            this.gvmeterbillinvoice.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.gvmeterbillinvoice_CellClick);
            // 
            // MeterBillID
            // 
            this.MeterBillID.DataPropertyName = "MeterBillID";
            this.MeterBillID.HeaderText = "MeterBillID";
            this.MeterBillID.Name = "MeterBillID";
            this.MeterBillID.ReadOnly = true;
            this.MeterBillID.Visible = false;
            // 
            // CustomerName
            // 
            this.CustomerName.DataPropertyName = "CustomerName";
            this.CustomerName.HeaderText = "CustomerName";
            this.CustomerName.Name = "CustomerName";
            this.CustomerName.ReadOnly = true;
            // 
            // TownshipName
            // 
            this.TownshipName.DataPropertyName = "TownshipName";
            this.TownshipName.HeaderText = "TownshipName";
            this.TownshipName.Name = "TownshipName";
            this.TownshipName.ReadOnly = true;
            // 
            // QuarterName
            // 
            this.QuarterName.DataPropertyName = "QuarterName";
            this.QuarterName.HeaderText = "QuarterName";
            this.QuarterName.Name = "QuarterName";
            this.QuarterName.ReadOnly = true;
            // 
            // MeterBillCode
            // 
            this.MeterBillCode.DataPropertyName = "MeterBillCode";
            this.MeterBillCode.HeaderText = "MeterBillCode";
            this.MeterBillCode.Name = "MeterBillCode";
            this.MeterBillCode.ReadOnly = true;
            // 
            // InvoiceDate
            // 
            this.InvoiceDate.DataPropertyName = "InvoiceDate";
            this.InvoiceDate.HeaderText = "InvoiceDate";
            this.InvoiceDate.Name = "InvoiceDate";
            this.InvoiceDate.ReadOnly = true;
            // 
            // ServicesFees
            // 
            this.ServicesFees.DataPropertyName = "ServicesFees";
            this.ServicesFees.HeaderText = "ServicesFees";
            this.ServicesFees.Name = "ServicesFees";
            this.ServicesFees.ReadOnly = true;
            // 
            // MeterFees
            // 
            this.MeterFees.DataPropertyName = "MeterFees";
            this.MeterFees.HeaderText = "MeterFees";
            this.MeterFees.Name = "MeterFees";
            this.MeterFees.ReadOnly = true;
            // 
            // StreetLightFees
            // 
            this.StreetLightFees.DataPropertyName = "StreetLightFees";
            this.StreetLightFees.HeaderText = "StreetLightFees";
            this.StreetLightFees.Name = "StreetLightFees";
            this.StreetLightFees.ReadOnly = true;
            // 
            // TotalFees
            // 
            this.TotalFees.DataPropertyName = "TotalFees";
            this.TotalFees.HeaderText = "TotalFees";
            this.TotalFees.Name = "TotalFees";
            this.TotalFees.ReadOnly = true;
            // 
            // UsageUnit
            // 
            this.UsageUnit.DataPropertyName = "UsageUnit";
            this.UsageUnit.HeaderText = "UsageUnit";
            this.UsageUnit.Name = "UsageUnit";
            this.UsageUnit.ReadOnly = true;
            // 
            // CurrentMonthUnits
            // 
            this.CurrentMonthUnits.DataPropertyName = "CurrentMonthUnit";
            this.CurrentMonthUnits.HeaderText = "CurrentMonthUnits";
            this.CurrentMonthUnits.Name = "CurrentMonthUnits";
            this.CurrentMonthUnits.ReadOnly = true;
            // 
            // PreviousMonthUnits
            // 
            this.PreviousMonthUnits.DataPropertyName = "PreviousMonthUnit";
            this.PreviousMonthUnits.HeaderText = "PreviousMonthUnits";
            this.PreviousMonthUnits.Name = "PreviousMonthUnits";
            this.PreviousMonthUnits.ReadOnly = true;
            // 
            // AdvanceMoney
            // 
            this.AdvanceMoney.DataPropertyName = "AdvanceMoney";
            this.AdvanceMoney.HeaderText = "AdvanceMoney";
            this.AdvanceMoney.Name = "AdvanceMoney";
            this.AdvanceMoney.ReadOnly = true;
            // 
            // CreditMoney
            // 
            this.CreditMoney.DataPropertyName = "CreditAmount";
            this.CreditMoney.HeaderText = "Credit Amount";
            this.CreditMoney.Name = "CreditMoney";
            this.CreditMoney.ReadOnly = true;
            // 
            // Remark
            // 
            this.Remark.DataPropertyName = "Remark";
            this.Remark.HeaderText = "Remark";
            this.Remark.Name = "Remark";
            this.Remark.ReadOnly = true;
            // 
            // HorsePowerFees
            // 
            this.HorsePowerFees.DataPropertyName = "HorsePowerFees";
            this.HorsePowerFees.HeaderText = "Horse Power Fees";
            this.HorsePowerFees.Name = "HorsePowerFees";
            this.HorsePowerFees.ReadOnly = true;
            // 
            // AdditonalFees1
            // 
            this.AdditonalFees1.DataPropertyName = "AdditionalFees1";
            this.AdditonalFees1.HeaderText = "AdditonalFees1";
            this.AdditonalFees1.Name = "AdditonalFees1";
            this.AdditonalFees1.ReadOnly = true;
            // 
            // AdditonalFees2
            // 
            this.AdditonalFees2.DataPropertyName = "AdditionalFees2";
            this.AdditonalFees2.HeaderText = "AdditonalFees2";
            this.AdditonalFees2.Name = "AdditonalFees2";
            this.AdditonalFees2.ReadOnly = true;
            // 
            // AdditonalFees3
            // 
            this.AdditonalFees3.DataPropertyName = "AdditionalFees3";
            this.AdditonalFees3.HeaderText = "AdditonalFees3";
            this.AdditonalFees3.Name = "AdditonalFees3";
            this.AdditonalFees3.ReadOnly = true;
            // 
            // Edit
            // 
            this.Edit.HeaderText = "Action";
            this.Edit.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.Edit.Name = "Edit";
            this.Edit.ReadOnly = true;
            this.Edit.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.Edit.Text = "Payment";
            this.Edit.UseColumnTextForLinkValue = true;
            // 
            // MeterBillPaymentList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1353, 406);
            this.Controls.Add(this.gvmeterbillinvoice);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MeterBillPaymentList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meter Bill Payment List";
            this.Load += new System.EventHandler(this.MeterBillPaymentUI_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvmeterbillinvoice)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCustomerCode;
        private System.Windows.Forms.TextBox txtCustomerName;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.DateTimePicker dtptoDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cboQuarter;
        private System.Windows.Forms.ComboBox cboTownship;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.TextBox txtBillCodeNo;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.DataGridView gvmeterbillinvoice;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterBillID;
        private System.Windows.Forms.DataGridViewTextBoxColumn CustomerName;
        private System.Windows.Forms.DataGridViewTextBoxColumn TownshipName;
        private System.Windows.Forms.DataGridViewTextBoxColumn QuarterName;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterBillCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn InvoiceDate;
        private System.Windows.Forms.DataGridViewTextBoxColumn ServicesFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn StreetLightFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn TotalFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn UsageUnit;
        private System.Windows.Forms.DataGridViewTextBoxColumn CurrentMonthUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn PreviousMonthUnits;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdvanceMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn CreditMoney;
        private System.Windows.Forms.DataGridViewTextBoxColumn Remark;
        private System.Windows.Forms.DataGridViewTextBoxColumn HorsePowerFees;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditonalFees1;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditonalFees2;
        private System.Windows.Forms.DataGridViewTextBoxColumn AdditonalFees3;
        private System.Windows.Forms.DataGridViewLinkColumn Edit;
        }
    }