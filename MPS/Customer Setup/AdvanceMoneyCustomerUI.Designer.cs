namespace MPS.Customer_Setup {
    partial class AdvanceMoneyCustomerUI {
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
            this.gvadvancemoneycustomer = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.gvadvancemoneycustomer)).BeginInit();
            this.SuspendLayout();
            // 
            // gvadvancemoneycustomer
            // 
            this.gvadvancemoneycustomer.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvadvancemoneycustomer.Location = new System.Drawing.Point(12, 47);
            this.gvadvancemoneycustomer.Name = "gvadvancemoneycustomer";
            this.gvadvancemoneycustomer.Size = new System.Drawing.Size(970, 268);
            this.gvadvancemoneycustomer.TabIndex = 0;
            // 
            // AdvanceMoneyCustomerUI
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(994, 327);
            this.Controls.Add(this.gvadvancemoneycustomer);
            this.Name = "AdvanceMoneyCustomerUI";
            this.Text = "AdvanceMoneyCustomerUI";
            this.Load += new System.EventHandler(this.AdvanceMoneyCustomerUI_Load);
            ((System.ComponentModel.ISupportInitialize)(this.gvadvancemoneycustomer)).EndInit();
            this.ResumeLayout(false);

            }

        #endregion
        private System.Windows.Forms.DataGridView gvadvancemoneycustomer;
        }
    }