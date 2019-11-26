using MBMS.DAL;
using MPS.BusinessLogic.MasterSetUpController;
using MPS.Master_Setup;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS
{
    public partial class Transformerfrm : Form
    {
        public string TransformerID { get; set; }
        public string UserID { get; set; }
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbsEntities = new MBMSEntities();
        Transformer transformer = new Transformer();
        TransformerController transformerController = new TransformerController();
        public Boolean isEdit { get; set; }
        public Transformerfrm()
        {
            InitializeComponent();
        }
        public bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.ToolTipTitle = "Error";
            //Validation
            if (txtTransformerName.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtTransformerName, "Error");
                tooltip.Show("Please fill up Transformer name!", txtTransformerName);
                hasError = false;
            }
            else if (txtTransformerModel.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtTransformerModel, "Error");
                tooltip.Show("Please fill up Transformer model!", txtTransformerModel);
                hasError = false;
            }
            else if (cboQuarterName.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboQuarterName, "Error");
                tooltip.Show("Please choose Quarter name!", cboQuarterName);
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
                    int TransformerName = 0;
                    TransformerName = (from tn in mbsEntities.Transformers where tn.TransformerName.Trim() == txtTransformerName.Text.Trim() && tn.TransformerID != TransformerID && tn.Active==true select tn).ToList().Count;
                    if (TransformerName == 0)
                    {
                        Transformer updateTransformer = (from tf in mbsEntities.Transformers where tf.TransformerID == TransformerID select tf).FirstOrDefault();
                        updateTransformer.TransformerName = txtTransformerName.Text;
                        updateTransformer.Model = txtTransformerModel.Text;
                        updateTransformer.GPSX = Convert.ToDecimal(txtGPSX.Text);
                        updateTransformer.GPSY = Convert.ToDecimal(txtGPSY.Text);
                        updateTransformer.Address = txtAddress.Text;
                        if (rdoEnable.Checked == true)
                        {
                            updateTransformer.Status = "Enable";
                        }
                        else
                        {
                            updateTransformer.Status = "Disable";
                        }
                        updateTransformer.QuarterID = cboQuarterName.SelectedValue.ToString();
                        updateTransformer.UpdatedUserID = UserID;
                        updateTransformer.UpdateDate = DateTime.Now;
                        transformerController.UpdateTransformer(updateTransformer);
                        MessageBox.Show("Successfully updated Transformer!", "Update");
                        Clear();
                        TransformerListfrm transformerListfrm = new TransformerListfrm();
                        transformerListfrm.Show();
                        this.Close();
                    }
                    else if (TransformerName > 0)
                    {
                        tooltip.SetToolTip(txtTransformerName, "Error");
                        tooltip.Show("This Transformer Name is already exist!", txtTransformerName);
                    }

                }
                else
                {
                    int TransformerName = 0;
                    TransformerName = (from tn in mbsEntities.Transformers where tn.TransformerName.Trim() == txtTransformerName.Text.Trim() && tn.Active==true select tn).ToList().Count;
                    if (TransformerName == 0)
                    {
                        transformer.TransformerID = Guid.NewGuid().ToString();
                        transformer.TransformerName = txtTransformerName.Text;
                        transformer.Model = txtTransformerModel.Text;
                        transformer.GPSX = Convert.ToDecimal(txtGPSX.Text);
                        transformer.GPSY = Convert.ToDecimal(txtGPSY.Text);
                        if (rdoEnable.Checked == true)
                        {
                            transformer.Status = "Enable";
                        }
                        else
                        {
                            transformer.Status = "Disable";
                        }
                        transformer.QuarterID = cboQuarterName.SelectedValue.ToString();
                        transformer.Address = txtAddress.Text;
                        transformer.Active = true;
                        transformer.CreatedUserID = UserID;
                        transformer.CreatedDate = DateTime.Now;
                        transformerController.Save(transformer);
                        MessageBox.Show("Successfully registered Trasformer! Please check it in 'Transformer List'.", "Save Success");
                        Clear();
                    }
                    else if (TransformerName > 0)
                    {
                        tooltip.SetToolTip(txtTransformerName, "Error");
                        tooltip.Show("This Transformer Name is already exist!", txtTransformerName);
                    }
                }
            }

        }
        public void Clear()
        {
            txtTransformerName.Text = string.Empty;
            txtTransformerModel.Text = string.Empty;
            txtGPSX.Text = string.Empty;
            txtGPSY.Text = string.Empty;
            txtAddress.Text = string.Empty;
            cboQuarterName.SelectedIndex = 0;
            rdoEnable.Checked = true;
           
        }
        public void bindQuarter()
        {
            List<Quarter> quarterList = new List<Quarter>();
            Quarter quarter = new Quarter();
            quarter.QuarterID = Convert.ToString(0);
            quarter.QuarterNameInEng = "Select";
            quarterList.Add(quarter);
            quarterList.AddRange(mbsEntities.Quarters.Where(x => x.Active == true).OrderBy(x=> x.QuarterNameInEng).ToList());
            cboQuarterName.DataSource = quarterList;
            cboQuarterName.DisplayMember = "QuarterNameInEng";
            cboQuarterName.ValueMember = "QuarterID";
        }

        private void Transformerfrm_Load(object sender, EventArgs e)
        {
            bindQuarter();
            if (isEdit)
            {
                Transformer transformer = (from tf in mbsEntities.Transformers where tf.TransformerID == TransformerID select tf).FirstOrDefault();
                txtTransformerName.Text = transformer.TransformerName;
                txtTransformerModel.Text = transformer.Model;
                txtGPSX.Text = Convert.ToString(transformer.GPSX);
                txtGPSY.Text = Convert.ToString( transformer.GPSY);
                txtAddress.Text = transformer.Address;
                if (transformer.Status == "Enable")
                {
                    rdoEnable.Checked = true;
                }
                else
                {
                    rdoDisable.Checked = true;
                }
                cboQuarterName.Text = transformer.Quarter.QuarterNameInEng;
            }
        }

        private void txtGPSX_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void txtGPSY_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (((e.KeyChar < 48 || e.KeyChar > 57) && e.KeyChar != 8 && e.KeyChar != 46))
            {
                e.Handled = true;
                return;
            }

            // checks to make sure only 1 decimal is allowed
            if (e.KeyChar == 46)
            {
                if ((sender as TextBox).Text.IndexOf(e.KeyChar) != -1)
                    e.Handled = true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
