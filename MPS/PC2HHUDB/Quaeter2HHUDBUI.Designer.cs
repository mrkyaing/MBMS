﻿namespace MPS.PC2HHUDB {
    partial class Quaeter2HHUDBUI {
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Quaeter2HHUDBUI));
            this.dgvQuarterList = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave2HHUDB = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtQuarterCode = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cbofileName = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuarterList)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvQuarterList
            // 
            this.dgvQuarterList.AllowUserToAddRows = false;
            this.dgvQuarterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvQuarterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column8});
            this.dgvQuarterList.Location = new System.Drawing.Point(32, 202);
            this.dgvQuarterList.Name = "dgvQuarterList";
            this.dgvQuarterList.Size = new System.Drawing.Size(527, 184);
            this.dgvQuarterList.TabIndex = 26;
            // 
            // Column2
            // 
            this.Column2.DataPropertyName = "QuarterCode";
            this.Column2.HeaderText = "Quarter Code";
            this.Column2.Name = "Column2";
            this.Column2.Width = 80;
            // 
            // Column3
            // 
            this.Column3.DataPropertyName = "QuarterNameInEng";
            this.Column3.HeaderText = "Quarter Name Eng";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.DataPropertyName = "QuarterNameInMM";
            this.Column4.HeaderText = "Quarter Name MM";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.DataPropertyName = "TownshipID";
            this.Column5.HeaderText = "Township Name";
            this.Column5.Name = "Column5";
            // 
            // Column8
            // 
            this.Column8.DataPropertyName = "Address";
            this.Column8.HeaderText = "Address";
            this.Column8.Name = "Column8";
            // 
            // btnSave2HHUDB
            // 
            this.btnSave2HHUDB.Location = new System.Drawing.Point(587, 85);
            this.btnSave2HHUDB.Name = "btnSave2HHUDB";
            this.btnSave2HHUDB.Size = new System.Drawing.Size(121, 31);
            this.btnSave2HHUDB.TabIndex = 27;
            this.btnSave2HHUDB.Text = "Save To HHU DB";
            this.btnSave2HHUDB.UseVisualStyleBackColor = true;
            this.btnSave2HHUDB.Click += new System.EventHandler(this.btnSave2HHUDB_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(17, 37);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 16);
            this.label1.TabIndex = 29;
            this.label1.Text = "Quarter Code";
            // 
            // txtQuarterCode
            // 
            this.txtQuarterCode.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtQuarterCode.Location = new System.Drawing.Point(111, 34);
            this.txtQuarterCode.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.txtQuarterCode.Name = "txtQuarterCode";
            this.txtQuarterCode.Size = new System.Drawing.Size(191, 22);
            this.txtQuarterCode.TabIndex = 28;
            this.txtQuarterCode.KeyDown += new System.Windows.Forms.KeyEventHandler(this.txtQuarterCode_KeyDown);
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(388, 85);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(89, 29);
            this.btnSearch.TabIndex = 27;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(492, 85);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(89, 29);
            this.btnRefresh.TabIndex = 30;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // cbofileName
            // 
            this.cbofileName.FormattingEnabled = true;
            this.cbofileName.Location = new System.Drawing.Point(467, 34);
            this.cbofileName.Name = "cbofileName";
            this.cbofileName.Size = new System.Drawing.Size(191, 22);
            this.cbofileName.TabIndex = 31;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.749999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(385, 37);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 16);
            this.label2.TabIndex = 32;
            this.label2.Text = "Db File:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.btnSave2HHUDB);
            this.groupBox1.Controls.Add(this.cbofileName);
            this.groupBox1.Controls.Add(this.btnSearch);
            this.groupBox1.Controls.Add(this.btnRefresh);
            this.groupBox1.Controls.Add(this.txtQuarterCode);
            this.groupBox1.Location = new System.Drawing.Point(12, 32);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(734, 164);
            this.groupBox1.TabIndex = 33;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Quarter Data to HHU Data File";
            // 
            // Quaeter2HHUDBUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(766, 424);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dgvQuarterList);
            this.Font = new System.Drawing.Font("Myanmar3", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Quaeter2HHUDBUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Querter(Village) 2 HHU DB";
            this.Load += new System.EventHandler(this.Quaeter2HHUDBUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuarterList)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.DataGridView dgvQuarterList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.Button btnSave2HHUDB;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtQuarterCode;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cbofileName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.GroupBox groupBox1;
    }
    }