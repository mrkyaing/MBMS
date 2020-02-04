namespace MPS {
    partial class PolePC2HHUDB {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(PolePC2HHUDB));
            this.dgvPoleList = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.cbofileName = new System.Windows.Forms.ComboBox();
            this.btnSave2HHUDB = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.btnSearch = new System.Windows.Forms.Button();
            this.label14 = new System.Windows.Forms.Label();
            this.label13 = new System.Windows.Forms.Label();
            this.label11 = new System.Windows.Forms.Label();
            this.txtSearchPoleName = new System.Windows.Forms.TextBox();
            this.cboSearchQuarterName = new System.Windows.Forms.ComboBox();
            this.cboSearchTransformerName = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoleList)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvPoleList
            // 
            this.dgvPoleList.AllowUserToAddRows = false;
            this.dgvPoleList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvPoleList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8});
            this.dgvPoleList.Location = new System.Drawing.Point(21, 214);
            this.dgvPoleList.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.dgvPoleList.Name = "dgvPoleList";
            this.dgvPoleList.Size = new System.Drawing.Size(534, 186);
            this.dgvPoleList.TabIndex = 12;
            this.dgvPoleList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvPoleList_DataBindingComplete);
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Pole No";
            this.Column2.Name = "Column2";
            this.Column2.Width = 90;
            // 
            // Column3
            // 
            this.Column3.HeaderText = "GPS-X";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "GPS-Y";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Transformer Name";
            this.Column5.Name = "Column5";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Quarter Name";
            this.Column8.Name = "Column8";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.cbofileName);
            this.groupBox2.Controls.Add(this.btnSave2HHUDB);
            this.groupBox2.Controls.Add(this.btnRefresh);
            this.groupBox2.Controls.Add(this.btnSearch);
            this.groupBox2.Controls.Add(this.label14);
            this.groupBox2.Controls.Add(this.label13);
            this.groupBox2.Controls.Add(this.label11);
            this.groupBox2.Controls.Add(this.txtSearchPoleName);
            this.groupBox2.Controls.Add(this.cboSearchQuarterName);
            this.groupBox2.Controls.Add(this.cboSearchTransformerName);
            this.groupBox2.Location = new System.Drawing.Point(12, 12);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.groupBox2.Size = new System.Drawing.Size(722, 194);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Pole data to HHU Database file.";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(6, 100);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 16);
            this.label2.TabIndex = 36;
            this.label2.Text = "Db File:";
            // 
            // cbofileName
            // 
            this.cbofileName.Font = new System.Drawing.Font("Myanmar3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cbofileName.FormattingEnabled = true;
            this.cbofileName.Location = new System.Drawing.Point(87, 92);
            this.cbofileName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cbofileName.Name = "cbofileName";
            this.cbofileName.Size = new System.Drawing.Size(191, 24);
            this.cbofileName.TabIndex = 35;
            // 
            // btnSave2HHUDB
            // 
            this.btnSave2HHUDB.Location = new System.Drawing.Point(593, 139);
            this.btnSave2HHUDB.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSave2HHUDB.Name = "btnSave2HHUDB";
            this.btnSave2HHUDB.Size = new System.Drawing.Size(107, 27);
            this.btnSave2HHUDB.TabIndex = 11;
            this.btnSave2HHUDB.Text = "Save To HHU DB";
            this.btnSave2HHUDB.UseVisualStyleBackColor = true;
            this.btnSave2HHUDB.Click += new System.EventHandler(this.btnSave2HHUDB_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(498, 139);
            this.btnRefresh.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 27);
            this.btnRefresh.TabIndex = 11;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(403, 139);
            this.btnSearch.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 27);
            this.btnSearch.TabIndex = 10;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // label14
            // 
            this.label14.AutoSize = true;
            this.label14.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label14.Location = new System.Drawing.Point(339, 99);
            this.label14.Name = "label14";
            this.label14.Size = new System.Drawing.Size(84, 17);
            this.label14.TabIndex = 10;
            this.label14.Text = "Quarter Name";
            // 
            // label13
            // 
            this.label13.AutoSize = true;
            this.label13.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label13.Location = new System.Drawing.Point(339, 43);
            this.label13.Name = "label13";
            this.label13.Size = new System.Drawing.Size(108, 17);
            this.label13.TabIndex = 10;
            this.label13.Text = "Transformer Name";
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.Location = new System.Drawing.Point(6, 43);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(52, 17);
            this.label11.TabIndex = 10;
            this.label11.Text = "Pole No";
            // 
            // txtSearchPoleName
            // 
            this.txtSearchPoleName.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtSearchPoleName.Location = new System.Drawing.Point(87, 40);
            this.txtSearchPoleName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtSearchPoleName.Name = "txtSearchPoleName";
            this.txtSearchPoleName.Size = new System.Drawing.Size(191, 26);
            this.txtSearchPoleName.TabIndex = 7;
            // 
            // cboSearchQuarterName
            // 
            this.cboSearchQuarterName.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchQuarterName.FormattingEnabled = true;
            this.cboSearchQuarterName.Location = new System.Drawing.Point(502, 89);
            this.cboSearchQuarterName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSearchQuarterName.Name = "cboSearchQuarterName";
            this.cboSearchQuarterName.Size = new System.Drawing.Size(192, 27);
            this.cboSearchQuarterName.TabIndex = 9;
            // 
            // cboSearchTransformerName
            // 
            this.cboSearchTransformerName.Font = new System.Drawing.Font("Myanmar3", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboSearchTransformerName.FormattingEnabled = true;
            this.cboSearchTransformerName.Location = new System.Drawing.Point(502, 39);
            this.cboSearchTransformerName.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.cboSearchTransformerName.Name = "cboSearchTransformerName";
            this.cboSearchTransformerName.Size = new System.Drawing.Size(192, 27);
            this.cboSearchTransformerName.TabIndex = 8;
            // 
            // PolePC2HHUDB
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(759, 452);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.dgvPoleList);
            this.Font = new System.Drawing.Font("Myanmar3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "PolePC2HHUDB";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Pole data to  HHU DB";
            this.Load += new System.EventHandler(this.Polefrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvPoleList)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.DataGridView dgvPoleList;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Label label14;
        private System.Windows.Forms.Label label13;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.TextBox txtSearchPoleName;
        private System.Windows.Forms.ComboBox cboSearchQuarterName;
        private System.Windows.Forms.ComboBox cboSearchTransformerName;
        private System.Windows.Forms.Button btnSave2HHUDB;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox cbofileName;
        }
    }