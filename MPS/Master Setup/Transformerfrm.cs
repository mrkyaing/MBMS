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
                        string oldTransformerName;                        
                        Transformer updateTransformer = (from tf in mbsEntities.Transformers where tf.TransformerID == TransformerID select tf).FirstOrDefault();
                        oldTransformerName = updateTransformer.TransformerName;              
                       
                        updateTransformer.TransformerName = txtTransformerName.Text;
                        updateTransformer.Model = txtTransformerModel.Text;
                        updateTransformer.CountryOfOrgin = txtCountryOrgin.Text;
                        updateTransformer.FullLoadLoss =Convert.ToInt32( txtFullLoadLoss.Text);
                        updateTransformer.ImpendanceVoltage =Convert.ToInt32( txtImpedanceVoltage.Text);
                        updateTransformer.EfficiencyLoad =Convert.ToInt32( txtEfficiency.Text);
                        updateTransformer.TappingRange = txtTappingRange.Text;
                        updateTransformer.TypeofCooling = txtTypeOfCooling.Text;
                        updateTransformer.VectorGroup = txtVectorGroup.Text;
                        updateTransformer.VoltageRatio= Convert.ToInt32( txtVoltageRatio.Text);
                        updateTransformer.Standard = txtStandard.Text;
                        updateTransformer.NoloadLoss =Convert.ToInt32( txtNoLoadLoss.Text);
                        updateTransformer.RatedOutputPower =Convert.ToInt32( txtRatedPower.Text);
                        updateTransformer.Maker = txtmaker.Text;
                        
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
                        if (oldTransformerName != txtTransformerName.Text)
                        {                            
                            TransformerHistory transformerHistory = new TransformerHistory();
                            transformerHistory.TransformerID = Guid.NewGuid().ToString();
                            transformerHistory.OldTransformerName = oldTransformerName;
                            transformerHistory.TransformerName = updateTransformer.TransformerName;
                            transformerHistory.Model = updateTransformer.Model;
                            transformerHistory.CountryOfOrgin = updateTransformer.CountryOfOrgin;
                            transformerHistory.FullLoadLoss = updateTransformer.FullLoadLoss;
                            transformerHistory.ImpendanceVoltage = updateTransformer.ImpendanceVoltage;
                            transformerHistory.EfficiencyLoad = updateTransformer.EfficiencyLoad;
                            transformerHistory.TappingRange = updateTransformer.TappingRange;
                            transformerHistory.TypeofCooling = updateTransformer.TypeofCooling;
                            transformerHistory.VectorGroup = updateTransformer.VectorGroup;
                            transformerHistory.VoltageRatio = updateTransformer.VoltageRatio;
                            transformerHistory.Standard = updateTransformer.Standard;
                            transformerHistory.NoloadLoss = updateTransformer.NoloadLoss;
                            transformerHistory.RatedOutputPower = updateTransformer.RatedOutputPower;
                            transformerHistory.Maker = updateTransformer.Maker;
                            transformerHistory.GPSX = 0;
                            transformerHistory.GPSY = 0;
                            transformerHistory.Status = "Disable";
                            transformerHistory.CreatedUserID = updateTransformer.UpdatedUserID;
                            transformerHistory.CreatedDate = DateTime.Now;
                            transformerHistory.QuarterID = updateTransformer.QuarterID;
                            transformerHistory.Active = true;                         
                            mbsEntities.TransformerHistories.Add(transformerHistory);
                            mbsEntities.SaveChanges();
                        }

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
                        Transformer transformer = new Transformer();
                        transformer.TransformerID = Guid.NewGuid().ToString();
                        transformer.TransformerName = txtTransformerName.Text;
                        transformer.Model = txtTransformerModel.Text;
                        transformer.CountryOfOrgin = txtCountryOrgin.Text;
                        transformer.FullLoadLoss = Convert.ToInt32(txtFullLoadLoss.Text==""?"0":txtFullLoadLoss.Text) ;
                        transformer.ImpendanceVoltage = Convert.ToInt32(txtImpedanceVoltage.Text==""?"0":txtImpedanceVoltage.Text);
                        transformer.EfficiencyLoad = Convert.ToInt32(txtEfficiency.Text=="" ?"0":txtEfficiency.Text);
                        transformer.TappingRange = txtTappingRange.Text==""?"0":txtTappingRange.Text;
                        transformer.TypeofCooling = txtTypeOfCooling.Text==""?"0":txtTypeOfCooling.Text;
                        transformer.VectorGroup = txtVectorGroup.Text;
                        transformer.VoltageRatio = Convert.ToInt32(txtVoltageRatio.Text=="" ?"0":txtVoltageRatio.Text);
                        transformer.Standard = txtStandard.Text =="" ?"0":txtStandard.Text;
                        transformer.NoloadLoss = Convert.ToInt32(txtNoLoadLoss.Text =="" ?"0":txtNoLoadLoss.Text);
                        transformer.RatedOutputPower = Convert.ToInt32(txtRatedPower.Text ==""?"0":txtRatedPower.Text);
                        transformer.Maker = txtmaker.Text;
                        if (rdoEnable.Checked == true)
                        {
                            transformer.Status = "Enable";
                        }
                        else
                        {
                            transformer.Status = "Disable";
                        }
                        transformer.QuarterID = cboQuarterName.SelectedValue.ToString();                       
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
            txtmaker.Text = string.Empty;
            txtCountryOrgin.Text = string.Empty;
            txtImpedanceVoltage.Text = string.Empty;
            cboQuarterName.SelectedIndex = 0;
            txtEfficiency.Text = string.Empty;
            txtFullLoadLoss.Text = string.Empty;
            txtNoLoadLoss.Text = string.Empty;
            txtRatedPower.Text = string.Empty;
            txtTypeOfCooling.Text = string.Empty;
            txtVectorGroup.Text = string.Empty;
            txtVoltageRatio.Text = string.Empty;
            rdoEnable.Checked = true;
            txtStandard.Text = string.Empty;
            txtTappingRange.Text = string.Empty;
           
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
                btnSave.Text = "Update";
                Transformer transformer = (from tf in mbsEntities.Transformers where tf.TransformerID == TransformerID select tf).FirstOrDefault();
                txtTransformerName.Text = transformer.TransformerName;
                txtTransformerModel.Text = transformer.Model;
                txtmaker.Text = transformer.Maker;
                txtCountryOrgin.Text =transformer.CountryOfOrgin;
                txtTappingRange.Text = transformer.TappingRange;
                txtStandard.Text = transformer.Standard;
                txtRatedPower.Text =Convert.ToString( transformer.RatedOutputPower);
                txtImpedanceVoltage.Text =Convert.ToString( transformer.ImpendanceVoltage);
                txtEfficiency.Text =Convert.ToString( transformer.EfficiencyLoad);
                txtTypeOfCooling.Text = transformer.TypeofCooling;
                txtVectorGroup.Text = transformer.VectorGroup;
                txtVoltageRatio.Text =Convert.ToString( transformer.VoltageRatio);
                txtNoLoadLoss.Text =Convert.ToString( transformer.NoloadLoss);
                txtFullLoadLoss.Text =Convert.ToString( transformer.FullLoadLoss);
                
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

       

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
