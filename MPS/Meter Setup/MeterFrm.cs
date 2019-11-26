using MBMS.DAL;
using MPS.BusinessLogic.MeterController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Meter_Setup
{
    public partial class MeterFrm : Form
    {
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String UserID { get; set; }
        public String meterID { get; set; }
        public Boolean isEdit { get; set; }
        Meter meter = new Meter();
        MeterController meterController = new MeterController();
        public MeterFrm()
        {
            InitializeComponent();
        }

        private void MeterFrm_Load(object sender, EventArgs e)
        {
            bindMeterBoxCode();
            bindMeterTypeCode();
            if (isEdit)
            {
                Meter meter = (from m in mbmsEntities.Meters where m.MeterID == meterID select m).FirstOrDefault();
                txtMeterNo.Text = meter.MeterNo;
                 txtMeterModel.Text = meter.Model ;
                dtpInstallDate.Value=Convert.ToDateTime( meter.InstalledDate);
                txtLosses.Text=Convert.ToString( meter.Losses );
                txtMultiplier.Text =Convert.ToString( meter.Multiplier);
                txtHp.Text =Convert.ToString( meter.HP);
                txtVoltage.Text= Convert.ToString( meter.Voltage) ;
                txtAMP.Text= meter.AMP;
                txtStandard.Text=Convert.ToString( meter.Standard);
                if (meter.Status == "Enable")
                {
                    rdoEnable.Checked = true;
                }
                else
                {
                    rdoDisable.Checked = true;
                }
                txtiMax.Text=Convert.ToString( meter.iMax);
                txtKVA.Text=Convert.ToString( meter.KVA) ;
                txtManufacture.Text= meter.ManufactureBy;
                txtFrequency.Text = Convert.ToString(meter.Frequency);
                cboMeterBoxCode.Text = meter.MeterBox.MeterBoxCode;
                txtMeterBoxSequence.Text = meter.MeterBoxSequence;
                cboMeterTypeCode.Text = meter.MeterType.MeterTypeCode;
            }
        }
        public void bindMeterBoxCode()
        {
            List<MeterBox> meterboxList = new List<MeterBox>();
            MeterBox meterbox = new MeterBox();
            meterbox.MeterBoxID = Convert.ToString(0);
            meterbox.MeterBoxCode = "Select";
            meterboxList.Add(meterbox);
            meterboxList.AddRange(mbmsEntities.MeterBoxes.Where(x => x.Active == true).OrderBy(x=>x.MeterBoxCode).ToList());
            cboMeterBoxCode.DataSource = meterboxList;
            cboMeterBoxCode.DisplayMember = "MeterBoxCode";
            cboMeterBoxCode.ValueMember = "MeterBoxID";
        }
        public void bindMeterTypeCode()
        {
            List<MeterType> meterTypeList = new List<MeterType>();
            MeterType meterType = new MeterType();
            meterType.MeterTypeID = Convert.ToString(0);
            meterType.MeterTypeCode = "Select";
            meterTypeList.Add(meterType);
            meterTypeList.AddRange(mbmsEntities.MeterTypes.Where(x => x.Active == true).OrderBy(x=>x.MeterTypeCode).ToList());
            cboMeterTypeCode.DataSource = meterTypeList;
            cboMeterTypeCode.DisplayMember = "MeterTypeCode";
            cboMeterTypeCode.ValueMember = "MeterTypeID";
        }
        public bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.ToolTipTitle = "Error";
            if (txtMeterNo.Text == string.Empty)
            {
                tooltip.SetToolTip(txtMeterNo, "Error");
                tooltip.Show("Please fill up Meter No !", txtMeterNo);
                hasError = false;
            }
            else if (txtMeterModel.Text == string.Empty)
            {
                tooltip.SetToolTip(txtMeterModel, "Error");
                tooltip.Show("Please fill up Meter Model!", txtMeterModel);
                hasError = false;
            }
            else if (dtpInstallDate.Value.ToString() == "")
            {
                tooltip.SetToolTip(dtpInstallDate, "Error");
                tooltip.Show("Please Select Install Date!", dtpInstallDate);
                hasError = false;
            }
            else if (txtVoltage.Text == string.Empty)
            {
                tooltip.SetToolTip(txtVoltage, "Error");
                tooltip.Show("Please fill up Voltage!", txtVoltage);
                hasError = false;
            }
            else if (txtManufacture.Text == string.Empty)
            {
                tooltip.SetToolTip(txtManufacture, "Error");
                tooltip.Show("Please fill up Manufacture By!", txtManufacture);
                hasError = false;
            }
            else if (cboMeterBoxCode.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboMeterBoxCode, "Error");
                tooltip.Show("Please choose Meter Box Code!", cboMeterBoxCode);
                hasError = false;
            }
            else if (cboMeterTypeCode.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboMeterTypeCode, "Error");
                tooltip.Show("Please choose Meter Type Code!", cboMeterTypeCode);
                hasError = false;
            }
            else if (txtMeterBoxSequence.Text == string.Empty)
            {
                tooltip.SetToolTip(txtMeterBoxSequence, "Error");
                tooltip.Show("Please fill up Meter Box Sequence!", txtMeterBoxSequence);
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
                    int editMeterCount = 0;
                    Meter updateMeter = (from m in mbmsEntities.Meters where m.MeterID == meterID select m).FirstOrDefault();
                    if (txtMeterNo.Text != updateMeter.MeterNo)
                    {
                        editMeterCount = (from m in mbmsEntities.Meters where m.MeterNo == txtMeterNo.Text && m.Active == true select m).ToList().Count;
                    }

                    if (editMeterCount > 0)
                    {
                        tooltip.SetToolTip(txtMeterNo, "Error");
                        tooltip.Show("Meter No is already exist!", txtMeterNo);
                        return;
                    }
                    updateMeter.MeterNo = txtMeterNo.Text;
                    updateMeter.Model = txtMeterModel.Text;
                    updateMeter.InstalledDate = dtpInstallDate.Value.Date;
                    updateMeter.Losses = Convert.ToInt32(txtLosses.Text);
                    updateMeter.Multiplier = Convert.ToInt32(txtMultiplier.Text);
                    updateMeter.HP = Convert.ToInt32(txtHp.Text);
                    updateMeter.Voltage = Convert.ToInt32(txtVoltage.Text);
                    updateMeter.AMP = txtAMP.Text;
                    updateMeter.Standard = Convert.ToInt32(txtStandard.Text);
                    if (rdoEnable.Checked == true)
                    {
                        updateMeter.Status = "Enable";
                    }
                    else
                    {
                        updateMeter.Status = "Disable";
                    }
                    updateMeter.iMax = Convert.ToInt32(txtiMax.Text);
                    updateMeter.KVA = Convert.ToInt32(txtKVA.Text);
                    updateMeter.ManufactureBy = txtManufacture.Text;
                    updateMeter.Frequency = Convert.ToInt32(txtFrequency.Text);
                    updateMeter.MeterBoxID = cboMeterBoxCode.SelectedValue.ToString();
                    updateMeter.MeterBoxSequence = txtMeterBoxSequence.Text;
                    updateMeter.MeterTypeID = cboMeterTypeCode.SelectedValue.ToString();
                    updateMeter.UpdatedUserID = UserID;
                    updateMeter.UpdatedDate = DateTime.Now;
                    meterController.UpdateMeter(updateMeter);
                    MessageBox.Show("Successfully updated Meter!", "Update");
                    Clear();
                    MeterListfrm meterListForm = new MeterListfrm();
                    meterListForm.Show();
                    this.Close();
                }
                else
                {
                    int meterNoCount = 0;
                    meterNoCount = (from m in mbmsEntities.Meters where m.MeterNo == txtMeterNo.Text && m.Active == true select m).ToList().Count;

                    if (meterNoCount > 0)
                    {
                        tooltip.SetToolTip(txtMeterNo, "Error");
                        tooltip.Show("Meter No is already exist!", txtMeterNo);
                        return;
                    }
                    meter.MeterID = Guid.NewGuid().ToString();
                    meter.MeterNo = txtMeterNo.Text;
                    meter.Model = txtMeterModel.Text;
                    meter.InstalledDate = dtpInstallDate.Value.Date;
                    meter.Losses = Convert.ToInt32(txtLosses.Text);
                    meter.Multiplier = Convert.ToInt32(txtMultiplier.Text);
                    meter.HP = Convert.ToInt32(txtHp.Text);
                    meter.Voltage = Convert.ToInt32(txtVoltage.Text);
                    meter.AMP = txtAMP.Text;
                    meter.Standard = Convert.ToInt32(txtStandard.Text);
                    if (rdoEnable.Checked == true)
                    {
                        meter.Status = "Enable";
                    }
                    else
                    {
                        meter.Status = "Disable";
                    }
                    meter.iMax = Convert.ToInt32(txtiMax.Text);
                    meter.KVA = Convert.ToInt32(txtKVA.Text);
                    meter.ManufactureBy = txtManufacture.Text;
                    meter.Frequency = Convert.ToInt32(txtFrequency.Text);
                    meter.MeterBoxID = cboMeterBoxCode.SelectedValue.ToString();
                    meter.MeterBoxSequence = txtMeterBoxSequence.Text;
                    meter.MeterTypeID = cboMeterTypeCode.SelectedValue.ToString();
                    meter.Active = true;
                    meter.CreatedUserID = UserID;
                    meter.CreatedDate = DateTime.Now;
                    meterController.Save(meter);
                    MessageBox.Show("Successfully registered Meter! Please check it in 'Meter List'.", "Save Success");
                    Clear();
                }
            }
            
        }
        public void Clear()
        {
            txtAMP.Text = string.Empty;
            txtFrequency.Text = string.Empty;
            txtHp.Text = string.Empty;
            txtiMax.Text = string.Empty;
            txtKVA.Text = string.Empty;
            txtLosses.Text = string.Empty;
            txtManufacture.Text = string.Empty;
            txtMeterBoxSequence.Text = string.Empty;
            txtMeterModel.Text = string.Empty;
            txtMeterNo.Text = string.Empty;
            txtMultiplier.Text = string.Empty;
            txtStandard.Text = string.Empty;
            txtVoltage.Text = string.Empty;
            dtpInstallDate.Value = DateTime.Now;
            cboMeterBoxCode.SelectedIndex = 0;
            cboMeterTypeCode.SelectedIndex = 0;
            rdoEnable.Checked = true;

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
