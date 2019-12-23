namespace MPS.MeterBillCalculation {
    partial class ViewMeterBillInvoice {
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
            this.Print = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnPrint = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label6 = new System.Windows.Forms.Label();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label5 = new System.Windows.Forms.Label();
            this.dtptoDate = new System.Windows.Forms.DateTimePicker();
            this.dtpFromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.cboQuarter = new System.Windows.Forms.ComboBox();
            this.cbotransformer = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.gvmeterbillinvoice)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
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
            this.Edit,
            this.Print});
            this.gvmeterbillinvoice.Location = new System.Drawing.Point(-2, 192);
            this.gvmeterbillinvoice.Name = "gvmeterbillinvoice";
            this.gvmeterbillinvoice.ReadOnly = true;
            this.gvmeterbillinvoice.Size = new System.Drawing.Size(1235, 209);
            this.gvmeterbillinvoice.TabIndex = 0;
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
            this.Edit.Text = "Edit";
            this.Edit.UseColumnTextForLinkValue = true;
            // 
            // Print
            // 
            this.Print.HeaderText = "Action";
            this.Print.LinkBehavior = System.Windows.Forms.LinkBehavior.AlwaysUnderline;
            this.Print.Name = "Print";
            this.Print.ReadOnly = true;
            this.Print.Text = "Print";
            this.Print.UseColumnTextForLinkValue = true;
            // 
            // btnPrint
            // 
            this.btnPrint.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPrint.Location = new System.Drawing.Point(1109, 407);
            this.btnPrint.Name = "btnPrint";
            this.btnPrint.Size = new System.Drawing.Size(113, 35);
            this.btnPrint.TabIndex = 1;
            this.btnPrint.Text = "Print All";
            this.btnPrint.UseVisualStyleBackColor = true;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.label6);
            this.groupBox1.Controls.Add(this.cboQuarter);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.cbotransformer);
            this.groupBox1.Controls.Add(this.label5);
            this.groupBox1.Controls.Add(this.dtptoDate);
            this.groupBox1.Controls.Add(this.dtpFromDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(24, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(735, 171);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Invoice Infromation";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.Red;
            this.label6.Location = new System.Drawing.Point(91, 91);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(17, 20);
            this.label6.TabIndex = 8;
            this.label6.Text = "*";
            // 
            // btnSearch
            // 
            this.btnSearch.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSearch.Location = new System.Drawing.Point(95, 120);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(98, 30);
            this.btnSearch.TabIndex = 5;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.Red;
            this.label5.Location = new System.Drawing.Point(91, 34);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(17, 20);
            this.label5.TabIndex = 9;
            this.label5.Text = "*";
            // 
            // dtptoDate
            // 
            this.dtptoDate.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtptoDate.Location = new System.Drawing.Point(95, 78);
            this.dtptoDate.Name = "dtptoDate";
            this.dtptoDate.Size = new System.Drawing.Size(264, 29);
            this.dtptoDate.TabIndex = 4;
            // 
            // dtpFromDate
            // 
            this.dtpFromDate.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpFromDate.Location = new System.Drawing.Point(95, 34);
            this.dtpFromDate.Name = "dtpFromDate";
            this.dtpFromDate.Size = new System.Drawing.Size(264, 29);
            this.dtpFromDate.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 78);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 34);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 3;
            this.label1.Text = "From Date:";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(365, 34);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(59, 20);
            this.label4.TabIndex = 10;
            this.label4.Text = "Quarter:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(365, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(90, 20);
            this.label3.TabIndex = 11;
            this.label3.Text = "Transformer :";
            // 
            // cboQuarter
            // 
            this.cboQuarter.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboQuarter.FormattingEnabled = true;
            this.cboQuarter.Location = new System.Drawing.Point(477, 33);
            this.cboQuarter.Name = "cboQuarter";
            this.cboQuarter.Size = new System.Drawing.Size(245, 28);
            this.cboQuarter.TabIndex = 8;
            this.cboQuarter.SelectedIndexChanged += new System.EventHandler(this.cboQuarter_SelectedIndexChanged);
            // 
            // cbotransformer
            // 
            this.cbotransformer.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbotransformer.FormattingEnabled = true;
            this.cbotransformer.Location = new System.Drawing.Point(477, 81);
            this.cbotransformer.Name = "cbotransformer";
            this.cbotransformer.Size = new System.Drawing.Size(245, 28);
            this.cbotransformer.TabIndex = 9;
            // 
            // btnCancel
            // 
            this.btnCancel.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(208, 120);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(98, 30);
            this.btnCancel.TabIndex = 5;
            this.btnCancel.Text = "Cancel";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // ViewMeterBillInvoice
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1234, 443);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnPrint);
            this.Controls.Add(this.gvmeterbillinvoice);
            this.Name = "ViewMeterBillInvoice";
            this.Text = "View Meter Bill Invoice";
            this.Load += new System.EventHandler(this.ViewMeterBillInvoice_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvmeterbillinvoice)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.DataGridView gvmeterbillinvoice;
        private System.Windows.Forms.Button btnPrint;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtptoDate;
        private System.Windows.Forms.DateTimePicker dtpFromDate;
        private System.Windows.Forms.Button btnSearch;
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
        private System.Windows.Forms.DataGridViewLinkColumn Print;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboQuarter;
        private System.Windows.Forms.ComboBox cbotransformer;
        private System.Windows.Forms.Button btnCancel;
        }
    }