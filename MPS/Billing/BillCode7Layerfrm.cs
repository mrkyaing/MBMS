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
            else if (txtAmount.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtAmount, "Error");
                tooltip.Show("Please fill up Amount !", txtAmount);
                hasError = false;
            }
            else if (txtLowerLimit.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtLowerLimit, "Error");
                tooltip.Show("Please fill up Lower Limit !", txtLowerLimit);
                hasError = false;
            }
            else if (txtUpperLimit.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtUpperLimit, "Error");
                tooltip.Show("Please fill up Upper Limit !", txtUpperLimit);
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
                    //billCode7Layer.LowerLimit = Convert.ToDecimal(txtLowerLimit.Text);
                    //billCode7Layer.UpperLimit = Convert.ToDecimal(txtUpperLimit.Text);
                    //billCode7Layer.AmountPerUnit = Convert.ToDecimal(txtAmount.Text);
                    billCode7Layer.Active = true;
                    billCode7Layer.CreatedUserID = UserID;
                    billCode7Layer.CreatedDate = DateTime.Now;
                    billCode7LayerController.Save(billCode7Layer);
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
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
        (e.KeyChar != '.'))
            {
                e.Handled = true;
            }

            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1))
            {
                e.Handled = true;
            }
        }
    }
}
