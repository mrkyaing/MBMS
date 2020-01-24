namespace MPS.PC2HHUDB {
    partial class MeterList2HHUDB {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterList2HHUDB));
            this.dgvMeterList = new System.Windows.Forms.DataGridView();
            this.MeterNo = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbofileName = new System.Windows.Forms.ComboBox();
            this.btnSave2HHUDB = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label13 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.txtmetermodelsearch = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.txtmeternoSearch = new System.Windows.Forms.TextBox();
            this.cbometerBox = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvMeterList
            // 
            this.dgvMeterList.AllowUserToAddRows = false;
            this.dgvMeterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.MeterNo,
            this.Column3,
            this.Column4});
            this.dgvMeterList.Location = new System.Drawing.Point(23, 186);
            this.dgvMeterList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvMeterList.Name = "dgvMeterList";
            this.dgvMeterList.Size = new System.Drawing.Size(561, 200);
            this.dgvMeterList.TabIndex = 12;
            // 
            // MeterNo
            // 
            this.MeterNo.DataPropertyName = "MeterNo";
            this.MeterNo.HeaderText = "Meter No";
            this.MeterNo.Name = "MeterNo";
            this.MeterNo.Width = 90;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "Model";
            this.Column3.HeaderText = "Model";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "InstalledDate";
            this.Column4.HeaderText = "Installed Date";
            this.Column4.Name = "Column4";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbofileName);
            this.groupBox2.Controls.Add(this.btnSave2HHUDB);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.txtmetermodelsearch);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtmeternoSearch);
            this.groupBox2.Controls.Add(this.dgvMeterList);
            this.groupBox2.Controls.Add(this.cbometerBox);
            this.groupBox2.Location = new System.Drawing.Point(16, 11);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(600, 422);
            this.groupBox2.TabIndex = 11;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pole data to HHU Database file.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(284, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(49, 17);
            this.label2.TabIndex = 34;
            this.label2.Text = "Db File:";
            // 
            // cbofileName
            // 
            this.cbofileName.Font = new System.Drawing.Font("Myanmar3", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbofileName.FormattingEnabled = true;
            this.cbofileName.Location = new System.Drawing.Point(363, 60);
            this.cbofileName.Name = "cbofileName";
            this.cbofileName.Size = new System.Drawing.Size(191, 25);
            this.cbofileName.TabIndex = 33;
            // 
            // btnSave2HHUDB
            // 
            this.btnSave2HHUDB.Location = new System.Drawing.Point(477, 104);
            this.btnSave2HHUDB.Name = "btnSave2HHUDB";
            this.btnSave2HHUDB.Size = new System.Drawing.Size(107, 27);
            this.btnSave2HHUDB.TabIndex = 11;
            this.btnSave2HHUDB.Text = "Save To HHU DB";
            this.btnSave2HHUDB.UseVisualStyleBackColor = true;
            this.btnSave2HHUDB.Click += new System.EventHandler(this.btnSave2HHUDB_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(382, 101);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 29);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(287, 101);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 29);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(4, 124);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(63, 16);
            this.label13.TabIndex = 10;
            this.label13.Text = "Meter Box:";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(6, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(46, 16);
            this.label1.TabIndex = 10;
            this.label1.Text = "Model :";
            // 
            // txtmetermodelsearch
            // 
            this.txtmetermodelsearch.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmetermodelsearch.Location = new System.Drawing.Point(74, 82);
            this.txtmetermodelsearch.Name = "txtmetermodelsearch";
            this.txtmetermodelsearch.Size = new System.Drawing.Size(164, 23);
            this.txtmetermodelsearch.TabIndex = 7;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 46);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(56, 16);
            this.label11.TabIndex = 10;
            this.label11.Text = "Meter No";
            // 
            // txtmeternoSearch
            // 
            this.txtmeternoSearch.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtmeternoSearch.Location = new System.Drawing.Point(74, 44);
            this.txtmeternoSearch.Name = "txtmeternoSearch";
            this.txtmeternoSearch.Size = new System.Drawing.Size(164, 23);
            this.txtmeternoSearch.TabIndex = 7;
            // 
            // cbometerBox
            // 
            this.cbometerBox.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbometerBox.FormattingEnabled = true;
            this.cbometerBox.Location = new System.Drawing.Point(73, 114);
            this.cbometerBox.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbometerBox.Name = "cbometerBox";
            this.cbometerBox.Size = new System.Drawing.Size(175, 25);
            this.cbometerBox.TabIndex = 8;
            // 
            // MeterList2HHUDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(642, 436);
            this.Controls.Add(this.groupBox2);
            this.Font = new System.Drawing.Font("Myanmar3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "MeterList2HHUDB";
            this.Text = "Meter List 2 HHU DB";
            this.Load += new System.EventHandler(this.MeterList2HHUDB_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.DataGridView dgvMeterList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnSave2HHUDB;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtmeternoSearch;
        private System.Windows.Forms.ComboBox cbometerBox;
        private System.Windows.Forms.DataGridViewTextBoxColumn MeterNo;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtmetermodelsearch;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbofileName;
        }
    }