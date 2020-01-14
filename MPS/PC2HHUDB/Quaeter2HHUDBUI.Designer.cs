namespace MPS.PC2HHUDB {
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
            this.dgvQuarterList = new System.Windows.Forms.DataGridView();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.btnSave2HHUDB = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuarterList)).BeginInit();
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
            this.dgvQuarterList.Location = new System.Drawing.Point(44, 79);
            this.dgvQuarterList.Name = "dgvQuarterList";
            this.dgvQuarterList.Size = new System.Drawing.Size(524, 171);
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
            this.btnSave2HHUDB.Location = new System.Drawing.Point(461, 42);
            this.btnSave2HHUDB.Name = "btnSave2HHUDB";
            this.btnSave2HHUDB.Size = new System.Drawing.Size(107, 31);
            this.btnSave2HHUDB.TabIndex = 27;
            this.btnSave2HHUDB.Text = "Save To HHU DB";
            this.btnSave2HHUDB.UseVisualStyleBackColor = true;
            this.btnSave2HHUDB.Click += new System.EventHandler(this.btnSave2HHUDB_Click);
            // 
            // Quaeter2HHUDBUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(585, 263);
            this.Controls.Add(this.btnSave2HHUDB);
            this.Controls.Add(this.dgvQuarterList);
            this.Name = "Quaeter2HHUDBUI";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Querter(Village) 2 HHU DB";
            this.Load += new System.EventHandler(this.Quaeter2HHUDBUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvQuarterList)).EndInit();
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
        }
    }