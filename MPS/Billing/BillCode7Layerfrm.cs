using MBMS.DAL;
using MPS.BusinessLogic.BillingController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Billing
{
    public partial class BillCode7Layerfrm : Form
    {
       
        public string billCode7LayerID { get; set; }         
        public string UserID { get; set; }
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbsEntities = new MBMSEntities();
        BillCode7Layer billCode7Layer = new BillCode7Layer();
        BillCode7LayerController billCode7LayerController = new BillCode7LayerController();
        public Boolean isEdit { get; set; }
        public BillCode7Layerfrm()
        {
            InitializeComponent();
        }

        private void BillCode7Layerfrm_Load(object sender, EventArgs e)
        {
            gv7layer.AutoGenerateColumns = false;
            cboBillCodeType.Items.Add("Flat Type");
            cboBillCodeType.Items.Add("Block Type");
            cboBillCodeType.SelectedIndex = 0;
            if (isEdit)
            {
                BillCode7Layer billCode7Layer = (from b in mbsEntities.BillCode7Layer where b.BillCode7LayerID == billCode7LayerID select b).FirstOrDefault();
                txtBillCodeNo.Text =Convert.ToString( billCode7Layer.BillCode7LayerNo);
                cboBillCodeType.Text = billCode7Layer.BillCodeLayerType;
                //txtLowerLimit.Text = Convert.ToString(billCode7Layer.LowerLimit);
                //txtUpperLimit.Text = Convert.ToString(billCode7Layer.UpperLimit);
                //txtAmount.Text = Convert.ToString(billCode7Layer.AmountPerUnit);
            }
            }

        public bool checkValidation()
        {
            Boolean hasError = true;
            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.ToolTipTitle = "Error";
            //Validation
            if (txtBillCodeNo.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtBillCodeNo, "Error");
                tooltip.Show("Please fill up Bill Code No !", txtBillCodeNo);
                hasError = false;
            }
           
            return hasError;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            
            if (checkValidation())
            {
                if (isEdit)
                {
                    int editBillCodeNoCount = 0;
                    long editbillCodeNo =Convert.ToInt64( txtBillCodeNo.Text);
                    BillCode7Layer updateBillCode7Layer = (from b in mbsEntities.BillCode7Layer where b.BillCode7LayerID == billCode7LayerID select b).FirstOrDefault();
                    if (txtBillCodeNo.Text !=Convert.ToString( updateBillCode7Layer.BillCode7LayerNo))
                    {
                        editBillCodeNoCount = (from b in mbsEntities.BillCode7Layer where b.BillCode7LayerNo == editbillCodeNo && b.Active == true select b).ToList().Count;
                    }

                    if (editBillCodeNoCount > 0)
                    {
                        tooltip.SetToolTip(txtBillCodeNo, "Error");
                        tooltip.Show("Bill Code No is already exist!", txtBillCodeNo);
                        return;
                    }
                 
                    updateBillCode7Layer.BillCode7LayerNo =Convert.ToInt64( txtBillCodeNo.Text);
                    updateBillCode7Layer.BillCodeLayerType = cboBillCodeType.Text;
                    //updateBillCode7Layer.LowerLimit = Convert.ToDecimal(txtLowerLimit.Text);
                    //updateBillCode7Layer.UpperLimit = Convert.ToDecimal(txtUpperLimit.Text);
                    //updateBillCode7Layer.AmountPerUnit = Convert.ToDecimal(txtAmount.Text);
                    updateBillCode7Layer.UpdatedUserID = UserID;
                    updateBillCode7Layer.UpdatedDate = DateTime.Now;
                    billCode7LayerController.UpdateBillCode7Layer(updateBillCode7Layer);
                    MessageBox.Show("Successfully Update!", "Update");
                    Clear();
                    BillCode7LayerList billcode7LayerListForm = new BillCode7LayerList();
                    billcode7LayerListForm.Show();
                    this.Close();
                }
                else
                {
                         
                     if (gv7layer.Rows.Count == 0) {
                        MessageBox.Show("please define 7 layers information firstly!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        }
                    int billCodeNoCount = 0;
                    long billCodeNo =Convert.ToInt64( txtBillCodeNo.Text);
                    billCodeNoCount = (from b in mbsEntities.BillCode7Layer where b.BillCode7LayerNo == billCodeNo && b.Active == true select b).ToList().Count;
                    if (billCodeNoCount > 0)
                    {
                        tooltip.SetToolTip(txtBillCodeNo, "Error");
                        tooltip.Show("Bill Code No is already exist!", txtBillCodeNo);
                        return;
                    }
                    billCode7Layer.BillCode7LayerID = Guid.NewGuid().ToString();
                    billCode7Layer.BillCode7LayerNo = Convert.ToInt64(txtBillCodeNo.Text);
                    billCode7Layer.BillCodeLayerType = cboBillCodeType.Text;
                    billCode7Layer.Active = true;
                    billCode7Layer.CreatedUserID = UserID;
                    billCode7Layer.CreatedDate = DateTime.Now;
                    billCode7LayerController.Save(billCode7Layer);
                    foreach(DataGridViewRow row in gv7layer.Rows) {
                        BillCode7LayerDetail billCode7LayerDetail = new BillCode7LayerDetail();
                        billCode7LayerDetail.BillCode7LayerDetailID = Guid.NewGuid().ToString();
                        billCode7LayerDetail.BillCode7LayerID = billCode7Layer.BillCode7LayerID;
                        billCode7LayerDetail.LowerLimit = Convert.ToDecimal(row.Cells[0].Value);
                        billCode7LayerDetail.UpperLimit = Convert.ToDecimal(row.Cells[1].Value);
                        billCode7LayerDetail.RateUnit = Convert.ToDecimal(row.Cells[2].Value);
                        billCode7LayerDetail.AmountPerUnit = Convert.ToDecimal(row.Cells[3].Value);
                        billCode7LayerDetail.Active = true;
                        billCode7LayerDetail.CreatedDate = DateTime.Now;
                        billCode7LayerDetail.CreatedUserID = UserID;
                        mbsEntities.BillCode7LayerDetail.Add(billCode7LayerDetail);
                        }
                    mbsEntities.SaveChanges();
                    MessageBox.Show("Success", "Save Success");
                    Clear();
                }
            }
        }

        public void Clear()
        {
            txtAmount.Text = string.Empty;
            txtBillCodeNo.Text = string.Empty;
            txtLowerLimit.Text = string.Empty;
            txtUpperLimit.Text = string.Empty;
            cboBillCodeType.SelectedIndex = 0;
        }

        private void txtBillCodeNo_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
                e.Handled = true;
            }
        }

     
        private void btnAdd_Click(object sender, EventArgs e) {        
            string[] row = new string[] { txtLowerLimit.Text, txtUpperLimit.Text, txtRateUnit.Text,txtAmount.Text };
            if (checkBillCode7LayerDetailRecord()) {
                gv7layer.Rows.Add(row);
                txtAmount.Text = txtLowerLimit.Text = txtUpperLimit.Text = txtRateUnit.Text = string.Empty;
                }
            }

        private bool checkBillCode7LayerDetailRecord() {
            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.ToolTipTitle = "Error";
            if (txtLowerLimit.Text.Trim() == string.Empty) {
                tooltip.SetToolTip(txtLowerLimit, "Error");
                tooltip.Show("Please fill up Lower Limit !", txtLowerLimit);
                return false;
                }
            else if (txtUpperLimit.Text.Trim() == string.Empty) {
                tooltip.SetToolTip(txtUpperLimit, "Error");
                tooltip.Show("Please fill up Upper Limit !", txtUpperLimit);
                return false;
                }
            else if (Convert.ToDecimal(txtLowerLimit.Text) > Convert.ToDecimal(txtUpperLimit.Text)) {
                tooltip.SetToolTip(txtRateUnit, "Error");
                tooltip.Show("Lower limit should not greater than upper limit !", txtRateUnit);
                return false;
                }
          
            else if (txtRateUnit.Text.Trim() == string.Empty) {
                tooltip.SetToolTip(txtRateUnit, "Error");
                tooltip.Show("Please define Rate Unit by filling up lower limit and upper limit !", txtRateUnit);
                return false;
                }
            else if (txtAmount.Text.Trim() == string.Empty) {
                tooltip.SetToolTip(txtAmount, "Error");
                tooltip.Show("Please fill up Amount Per Unit!", txtAmount);
                return false;
                }
            foreach(DataGridViewRow row in gv7layer.Rows) {
              decimal lowerlimit = Convert.ToDecimal(row.Cells[0].Value);
             decimal upperlimit= Convert.ToDecimal(row.Cells[1].Value);
                if(Convert.ToDecimal(txtLowerLimit.Text)==lowerlimit || Convert.ToDecimal(txtUpperLimit.Text) == upperlimit) {
                    tooltip.SetToolTip(txtLowerLimit, "Error");
                    tooltip.Show("Lower  and Upper Limit are already defined.", txtLowerLimit);
                    return false;
                    }
                else if (Convert.ToDecimal(txtLowerLimit.Text) <= upperlimit) {
                    tooltip.SetToolTip(txtLowerLimit, "Error");
                    tooltip.Show("Lower Limit data are already defined.", txtLowerLimit);
                    return false;
                    }
                else if (Convert.ToDecimal(txtLowerLimit.Text) >= upperlimit && Convert.ToDecimal(txtLowerLimit.Text) <= upperlimit) {
                    tooltip.SetToolTip(txtLowerLimit, "Error");
                    tooltip.Show("Lower Limit data are already defined.", txtLowerLimit);
                    return false;
                    }
                else if (Convert.ToDecimal(txtUpperLimit.Text) >= upperlimit && Convert.ToDecimal(txtUpperLimit.Text) <= upperlimit) {
                    tooltip.SetToolTip(txtUpperLimit, "Error");
                    tooltip.Show("Upper Limit data are already defined.", txtUpperLimit);
                    return false;
                    }
                }
            return true;
            }

        private void gv7layer_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                //Delete function
                if (e.ColumnIndex ==4) {
                    DataGridViewRow row = gv7layer.Rows[e.RowIndex];
                    //BillCode7LayerDetail billCode7LayerDetail = (BillCode7LayerDetail)row.DataBoundItem;//get the selected row's data 
                    //billCode7LayerDetailList.Remove(billCode7LayerDetail);
                    gv7layer.Rows.Remove(row);
                    }//end of delete function
                }
            }

      

        private void txtUpperLimit_KeyDown(object sender, KeyEventArgs e){
            if (e.KeyCode == Keys.Enter) {
                if(Convert.ToDecimal(txtLowerLimit.Text)> Convert.ToDecimal(txtUpperLimit.Text)) {
                    MessageBox.Show("Lower Limit is greater than upper limit.", "Invalid", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
              else  txtRateUnit.Text =Convert.ToString(Convert.ToDecimal(txtUpperLimit.Text)-(Convert.ToDecimal(txtLowerLimit.Text) - 1) );
                }
            }

        private void txtLowerLimit_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
            (e.KeyChar != '.')) {
                e.Handled = true;
                }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
                e.Handled = true;
                }
            }

        private void txtUpperLimit_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.')) {
                e.Handled = true;
                }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
                e.Handled = true;
                }
            }

        private void txtAmount_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
       (e.KeyChar != '.')) {
                e.Handled = true;
                }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
                e.Handled = true;
                }
            }
        }
}
