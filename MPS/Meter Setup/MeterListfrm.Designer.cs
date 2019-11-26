namespace MPS.Meter_Setup
{
    partial class MeterListfrm
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
            this.dgvMeterList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column6 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column9 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column10 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column11 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column12 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column13 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnRefresh = new System.Windows.Forms.Button();
            this.cboMeterTypeCode = new System.Windows.Forms.ComboBox();
            this.cboMeterBoxCode = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.txtMeterModel = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtMeterNo = new System.Windows.Forms.TextBox();
            this.btnSearch = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvMeterList
            // 
            this.dgvMeterList.AllowUserToAddRows = false;
            this.dgvMeterList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvMeterList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column6,
            this.Column7,
            this.Column8,
            this.Column9,
            this.Column10,
            this.Column11,
            this.Column12,
            this.Column13});
            this.dgvMeterList.Location = new System.Drawing.Point(38, 142);
            this.dgvMeterList.Name = "dgvMeterList";
            this.dgvMeterList.Size = new System.Drawing.Size(1244, 453);
            this.dgvMeterList.TabIndex = 16;
            this.dgvMeterList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvMeterList_CellClick);
            this.dgvMeterList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvMeterList_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Meter No";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Meter Model";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Install Date ";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Voltage";
            this.Column5.Name = "Column5";
            // 
            // Column6
            // 
            this.Column6.HeaderText = "Manufacture By";
            this.Column6.Name = "Column6";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "Status";
            this.Column7.Name = "Column7";
            // 
            // Column8
            // 
            this.Column8.HeaderText = "Meter Box Code";
            this.Column8.Name = "Column8";
            // 
            // Column9
            // 
            this.Column9.HeaderText = "Meter Box Sequence";
            this.Column9.Name = "Column9";
            // 
            // Column10
            // 
            this.Column10.HeaderText = "Meter Type Code";
            this.Column10.Name = "Column10";
            // 
            // Column11
            // 
            this.Column11.HeaderText = "";
            this.Column11.Name = "Column11";
            this.Column11.Text = "View Detail";
            this.Column11.UseColumnTextForLinkValue = true;
            // 
            // Column12
            // 
            this.Column12.HeaderText = "";
            this.Column12.Name = "Column12";
            this.Column12.Text = "Edit";
            this.Column12.UseColumnTextForLinkValue = true;
            // 
            // Column13
            // 
            this.Column13.HeaderText = "";
            this.Column13.Name = "Column13";
            this.Column13.Text = "Delete";
            this.Column13.UseColumnTextForLinkValue = true;
            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new System.Drawing.Point(1136, 96);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(100, 23);
            this.btnRefresh.TabIndex = 25;
            this.btnRefresh.Text = "Refresh";
            this.btnRefresh.UseVisualStyleBackColor = true;
            this.btnRefresh.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // cboMeterTypeCode
            // 
            this.cboMeterTypeCode.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMeterTypeCode.FormattingEnabled = true;
            this.cboMeterTypeCode.Location = new System.Drawing.Point(1050, 34);
            this.cboMeterTypeCode.Name = "cboMeterTypeCode";
            this.cboMeterTypeCode.Size = new System.Drawing.Size(176, 25);
            this.cboMeterTypeCode.TabIndex = 23;
            // 
            // cboMeterBoxCode
            // 
            this.cboMeterBoxCode.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cboMeterBoxCode.FormattingEnabled = true;
            this.cboMeterBoxCode.Location = new System.Drawing.Point(732, 34);
            this.cboMeterBoxCode.Name = "cboMeterBoxCode";
            this.cboMeterBoxCode.Size = new System.Drawing.Size(176, 25);
            this.cboMeterBoxCode.TabIndex = 24;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.Location = new System.Drawing.Point(937, 36);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(107, 17);
            this.label4.TabIndex = 19;
            this.label4.Text = "Meter Type Code:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(627, 36);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(99, 17);
            this.label3.TabIndex = 20;
            this.label3.Text = "MeterBox Code:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(324, 36);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(83, 17);
            this.label2.TabIndex = 21;
            this.label2.Text = "Meter Model:";
            // 
            // txtMeterModel
            // 
            this.txtMeterModel.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeterModel.Location = new System.Drawing.Point(413, 33);
            this.txtMeterModel.Name = "txtMeterModel";
            this.txtMeterModel.Size = new System.Drawing.Size(176, 26);
            this.txtMeterModel.TabIndex = 17;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(35, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 17);
            this.label1.TabIndex = 22;
            this.label1.Text = "Meter No:";
            // 
            // txtMeterNo
            // 
            this.txtMeterNo.Font = new System.Drawing.Font("Myanmar3", 8.999999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMeterNo.Location = new System.Drawing.Point(104, 33);
            this.txtMeterNo.Name = "txtMeterNo";
            this.txtMeterNo.Size = new System.Drawing.Size(176, 26);
            this.txtMeterNo.TabIndex = 18;
            // 
            // btnSearch
            // 
            this.btnSearch.Location = new System.Drawing.Point(990, 96);
            this.btnSearch.Name = "btnSearch";
            this.btnSearch.Size = new System.Drawing.Size(100, 23);
            this.btnSearch.TabIndex = 26;
            this.btnSearch.Text = "Search";
            this.btnSearch.UseVisualStyleBackColor = true;
            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
            // 
            // MeterListfrm
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1326, 626);
            this.Controls.Add(this.dgvMeterList);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.cboMeterTypeCode);
            this.Controls.Add(this.cboMeterBoxCode);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtMeterModel);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtMeterNo);
            this.Controls.Add(this.btnSearch);
            this.Font = new System.Drawing.Font("Myanmar3", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "MeterListfrm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Meter List";
            this.Load += new System.EventHandler(this.MeterListfrm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvMeterList)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvMeterList;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column6;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column7;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column8;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column9;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column10;
        private System.Windows.Forms.DataGridViewLinkColumn Column11;
        private System.Windows.Forms.DataGridViewLinkColumn Column12;
        private System.Windows.Forms.DataGridViewLinkColumn Column13;
        private System.Windows.Forms.Button btnRefresh;
        private System.Windows.Forms.ComboBox cboMeterTypeCode;
        private System.Windows.Forms.ComboBox cboMeterBoxCode;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtMeterModel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtMeterNo;
        private System.Windows.Forms.Button btnSearch;
    }
}