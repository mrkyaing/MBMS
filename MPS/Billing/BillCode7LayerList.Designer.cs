namespace MPS.Billing
{
    partial class BillCode7LayerList
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
            this.dgvBillCode7LayerList = new System.Windows.Forms.DataGridView();
            this.Column1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column4 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column5 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Column7 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.Column8 = new System.Windows.Forms.DataGridViewLinkColumn();
            this.btnAddNewBillCode = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillCode7LayerList)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvBillCode7LayerList
            // 
            this.dgvBillCode7LayerList.AllowUserToAddRows = false;
            this.dgvBillCode7LayerList.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvBillCode7LayerList.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.Column1,
            this.Column2,
            this.Column3,
            this.Column4,
            this.Column5,
            this.Column7,
            this.Column8});
            this.dgvBillCode7LayerList.Location = new System.Drawing.Point(37, 97);
            this.dgvBillCode7LayerList.Name = "dgvBillCode7LayerList";
            this.dgvBillCode7LayerList.Size = new System.Drawing.Size(643, 350);
            this.dgvBillCode7LayerList.TabIndex = 0;
            this.dgvBillCode7LayerList.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgvBillCode7LayerList_CellClick);
            this.dgvBillCode7LayerList.DataBindingComplete += new System.Windows.Forms.DataGridViewBindingCompleteEventHandler(this.dgvBillCode7LayerList_DataBindingComplete);
            // 
            // Column1
            // 
            this.Column1.HeaderText = "ID";
            this.Column1.Name = "Column1";
            this.Column1.Visible = false;
            // 
            // Column2
            // 
            this.Column2.HeaderText = "Bill Code No";
            this.Column2.Name = "Column2";
            // 
            // Column3
            // 
            this.Column3.HeaderText = "Bill Code Type";
            this.Column3.Name = "Column3";
            // 
            // Column4
            // 
            this.Column4.HeaderText = "Created Date";
            this.Column4.Name = "Column4";
            // 
            // Column5
            // 
            this.Column5.HeaderText = "Created  User";
            this.Column5.Name = "Column5";
            // 
            // Column7
            // 
            this.Column7.HeaderText = "";
            this.Column7.Name = "Column7";
            this.Column7.Text = "Edit";
            this.Column7.UseColumnTextForLinkValue = true;
            // 
            // Column8
            // 
            this.Column8.HeaderText = "";
            this.Column8.Name = "Column8";
            this.Column8.Text = "Delete";
            this.Column8.UseColumnTextForLinkValue = true;
            // 
            // btnAddNewBillCode
            // 
            this.btnAddNewBillCode.Location = new System.Drawing.Point(543, 43);
            this.btnAddNewBillCode.Name = "btnAddNewBillCode";
            this.btnAddNewBillCode.Size = new System.Drawing.Size(137, 27);
            this.btnAddNewBillCode.TabIndex = 1;
            this.btnAddNewBillCode.Text = "Add New Bill Code";
            this.btnAddNewBillCode.UseVisualStyleBackColor = true;
            this.btnAddNewBillCode.Click += new System.EventHandler(this.btnAddNewBillCode_Click);
            // 
            // BillCode7LayerList
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 14F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(710, 476);
            this.Controls.Add(this.btnAddNewBillCode);
            this.Controls.Add(this.dgvBillCode7LayerList);
            this.Font = new System.Drawing.Font("Myanmar3", 8.249999F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "BillCode7LayerList";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "BillCode7 Layer List";
            this.Load += new System.EventHandler(this.BillCode7LayerList_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvBillCode7LayerList)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvBillCode7LayerList;
        private System.Windows.Forms.Button btnAddNewBillCode;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column1;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column2;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column3;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column4;
        private System.Windows.Forms.DataGridViewTextBoxColumn Column5;
        private System.Windows.Forms.DataGridViewLinkColumn Column7;
        private System.Windows.Forms.DataGridViewLinkColumn Column8;
        }
}