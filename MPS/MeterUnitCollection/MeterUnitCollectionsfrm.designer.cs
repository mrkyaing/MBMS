namespace MPS.MeterUnitCollect {
    partial class MeterUnitCollectionsfrm {
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
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cboTransformer = new System.Windows.Forms.ComboBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btncollectmeterunit = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.cboTownship = new System.Windows.Forms.ComboBox();
            this.dtptoDate = new System.Windows.Forms.DateTimePicker();
            this.dtpfromDate = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.gvnodemeter = new System.Windows.Forms.DataGridView();
            this.btnSave = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvnodemeter)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(15, 39);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(78, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "From Date:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label4);
            this.groupBox1.Controls.Add(this.cboTransformer);
            this.groupBox1.Controls.Add(this.btnCancel);
            this.groupBox1.Controls.Add(this.btncollectmeterunit);
            this.groupBox1.Controls.Add(this.label3);
            this.groupBox1.Controls.Add(this.cboTownship);
            this.groupBox1.Controls.Add(this.dtptoDate);
            this.groupBox1.Controls.Add(this.dtpfromDate);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.Location = new System.Drawing.Point(78, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(472, 265);
            this.groupBox1.TabIndex = 1;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Meter Unit Collection Process";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(11, 173);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(90, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Transformer :";
            // 
            // cboTransformer
            // 
            this.cboTransformer.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTransformer.FormattingEnabled = true;
            this.cboTransformer.Location = new System.Drawing.Point(106, 173);
            this.cboTransformer.Name = "cboTransformer";
            this.cboTransformer.Size = new System.Drawing.Size(259, 28);
            this.cboTransformer.TabIndex = 4;
            // 
            // btnCancel
            // 
            this.btnCancel.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnCancel.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCancel.Location = new System.Drawing.Point(254, 223);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(122, 30);
            this.btnCancel.TabIndex = 2;
            this.btnCancel.Text = "Clear";
            this.btnCancel.UseVisualStyleBackColor = false;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btncollectmeterunit
            // 
            this.btncollectmeterunit.BackColor = System.Drawing.Color.DodgerBlue;
            this.btncollectmeterunit.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btncollectmeterunit.ForeColor = System.Drawing.Color.Black;
            this.btncollectmeterunit.Location = new System.Drawing.Point(100, 223);
            this.btncollectmeterunit.Name = "btncollectmeterunit";
            this.btncollectmeterunit.Size = new System.Drawing.Size(145, 30);
            this.btncollectmeterunit.TabIndex = 2;
            this.btncollectmeterunit.Text = "Collect Meter Unit";
            this.btncollectmeterunit.UseVisualStyleBackColor = false;
            this.btncollectmeterunit.Click += new System.EventHandler(this.btncollectmeterunit_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(15, 131);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(75, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Township :";
            // 
            // cboTownship
            // 
            this.cboTownship.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboTownship.FormattingEnabled = true;
            this.cboTownship.Location = new System.Drawing.Point(107, 131);
            this.cboTownship.Name = "cboTownship";
            this.cboTownship.Size = new System.Drawing.Size(259, 28);
            this.cboTownship.TabIndex = 2;
            // 
            // dtptoDate
            // 
            this.dtptoDate.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtptoDate.Location = new System.Drawing.Point(107, 89);
            this.dtptoDate.Name = "dtptoDate";
            this.dtptoDate.Size = new System.Drawing.Size(259, 29);
            this.dtptoDate.TabIndex = 1;
            // 
            // dtpfromDate
            // 
            this.dtpfromDate.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.dtpfromDate.Location = new System.Drawing.Point(107, 36);
            this.dtpfromDate.Name = "dtpfromDate";
            this.dtpfromDate.Size = new System.Drawing.Size(259, 29);
            this.dtpfromDate.TabIndex = 1;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(15, 89);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(62, 20);
            this.label2.TabIndex = 0;
            this.label2.Text = "To Date:";
            // 
            // gvnodemeter
            // 
            this.gvnodemeter.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvnodemeter.Location = new System.Drawing.Point(78, 283);
            this.gvnodemeter.Name = "gvnodemeter";
            this.gvnodemeter.Size = new System.Drawing.Size(472, 211);
            this.gvnodemeter.TabIndex = 6;
            // 
            // btnSave
            // 
            this.btnSave.BackColor = System.Drawing.Color.DodgerBlue;
            this.btnSave.Font = new System.Drawing.Font("Myanmar3", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSave.ForeColor = System.Drawing.Color.Black;
            this.btnSave.Location = new System.Drawing.Point(178, 500);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(145, 30);
            this.btnSave.TabIndex = 2;
            this.btnSave.Text = "Save Meter Unit";
            this.btnSave.UseVisualStyleBackColor = false;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // MeterUnitCollectionsfrm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(616, 525);
            this.Controls.Add(this.gvnodemeter);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.btnSave);
            this.Name = "MeterUnitCollectionsfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meter Unit Collections";
            this.Load += new System.EventHandler(this.MeterUnitCollectionsfrm_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvnodemeter)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtptoDate;
        private System.Windows.Forms.DateTimePicker dtpfromDate;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cboTownship;
        private System.Windows.Forms.Button btncollectmeterunit;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cboTransformer;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.DataGridView gvnodemeter;
        private System.Windows.Forms.Button btnSave;
        }
    }