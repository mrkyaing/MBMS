namespace MPS.MeterBillCalculation {
    partial class MeterBillCalculate {
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dtpfromDate = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.dtpToDate = new System.Windows.Forms.DateTimePicker();
            this.btnbillprocess = new System.Windows.Forms.Button();
            this.btnViewInvoices = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnViewInvoices);
            this.groupBox1.Controls.Add(this.btnbillprocess);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.dtpToDate);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.dtpfromDate);
            this.groupBox1.Location = new System.Drawing.Point(47, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(415, 190);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Bill Calculation Process";
            // 
            // dtpfromDate
            // 
            this.dtpfromDate.Location = new System.Drawing.Point(101, 34);
            this.dtpfromDate.Name = "dtpfromDate";
            this.dtpfromDate.Size = new System.Drawing.Size(200, 20);
            this.dtpfromDate.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(27, 41);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "From Date:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 92);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "To Date:";
            // 
            // dtpToDate
            // 
            this.dtpToDate.Location = new System.Drawing.Point(105, 85);
            this.dtpToDate.Name = "dtpToDate";
            this.dtpToDate.Size = new System.Drawing.Size(200, 20);
            this.dtpToDate.TabIndex = 2;
            // 
            // btnbillprocess
            // 
            this.btnbillprocess.Location = new System.Drawing.Point(105, 129);
            this.btnbillprocess.Name = "btnbillprocess";
            this.btnbillprocess.Size = new System.Drawing.Size(145, 34);
            this.btnbillprocess.TabIndex = 4;
            this.btnbillprocess.Text = "Bill Calculate Process";
            this.btnbillprocess.UseVisualStyleBackColor = true;
            this.btnbillprocess.Click += new System.EventHandler(this.btnbillprocess_Click);
            // 
            // btnViewInvoices
            // 
            this.btnViewInvoices.Location = new System.Drawing.Point(256, 129);
            this.btnViewInvoices.Name = "btnViewInvoices";
            this.btnViewInvoices.Size = new System.Drawing.Size(130, 34);
            this.btnViewInvoices.TabIndex = 5;
            this.btnViewInvoices.Text = "View Invoices";
            this.btnViewInvoices.UseVisualStyleBackColor = true;
            // 
            // MeterBillCalculate
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(499, 262);
            this.Controls.Add(this.groupBox1);
            this.Name = "MeterBillCalculate";
            this.Text = "Meter Bill Calculate";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker dtpfromDate;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtpToDate;
        private System.Windows.Forms.Button btnbillprocess;
        private System.Windows.Forms.Button btnViewInvoices;
        }
    }