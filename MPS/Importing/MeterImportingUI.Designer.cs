namespace MPS.Importing {
    partial class MeterImportingUI {
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MeterImportingUI));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.btnSelect = new System.Windows.Forms.Button();
            this.gvCustomer = new System.Windows.Forms.DataGridView();
            this.ofdSelect = new System.Windows.Forms.OpenFileDialog();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.progressBar1);
            this.groupBox1.Controls.Add(this.btnSave);
            this.groupBox1.Controls.Add(this.btnSelect);
            this.groupBox1.Location = new System.Drawing.Point(60, 17);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.groupBox1.Size = new System.Drawing.Size(419, 144);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Importing Meter Information:";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(167, 57);
            this.btnSave.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(135, 35);
            this.btnSave.TabIndex = 0;
            this.btnSave.Text = "Save to System";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // btnSelect
            // 
            this.btnSelect.Location = new System.Drawing.Point(53, 57);
            this.btnSelect.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.btnSelect.Name = "btnSelect";
            this.btnSelect.Size = new System.Drawing.Size(106, 35);
            this.btnSelect.TabIndex = 0;
            this.btnSelect.Text = "Select File";
            this.btnSelect.UseVisualStyleBackColor = true;
            this.btnSelect.Click += new System.EventHandler(this.btnSelect_Click);
            // 
            // gvCustomer
            // 
            this.gvCustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvCustomer.Location = new System.Drawing.Point(13, 171);
            this.gvCustomer.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.gvCustomer.Name = "gvCustomer";
            this.gvCustomer.Size = new System.Drawing.Size(1072, 260);
            this.gvCustomer.TabIndex = 1;
            // 
            // ofdSelect
            // 
            this.ofdSelect.FileName = "openFileDialog1";
            this.ofdSelect.FileOk += new System.ComponentModel.CancelEventHandler(this.ofdSelect_FileOk);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(53, 113);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(249, 23);
            this.progressBar1.TabIndex = 2;
            this.progressBar1.Visible = false;
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 19);
            this.label1.TabIndex = 2;
            this.label1.Text = "Status:";
            // 
            // MeterImportingUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 19F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1093, 435);
            this.Controls.Add(this.gvCustomer);
            this.Controls.Add(this.groupBox1);
            this.Font = new System.Drawing.Font("Myanmar3", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "MeterImportingUI";
            this.Text = "Meter Importing";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvCustomer)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.Button btnSelect;
        private System.Windows.Forms.DataGridView gvCustomer;
        private System.Windows.Forms.OpenFileDialog ofdSelect;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label label1;
    }
    }