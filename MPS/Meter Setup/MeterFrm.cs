﻿using MBMS.DAL;
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
        public string UserID { get; set; }
        public string meterID { get; set; }
        public bool isEdit { get; set; }  
        MeterController meterController = new MeterController();
        public MeterFrm() {
            InitializeComponent();
        }
        private void MeterFrm_Load(object sender, EventArgs e) {
            bindMeterBoxCode();
            bindMeterTypeCode();
            if (isEdit)  {
                btnSave.Text = "Update";
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
                txtPhrase.Text = meter.Phrase;
                txtWire.Text = meter.Wire;
                txtAvailableYear.Text =Convert.ToString( meter.AvailableYear);
                txtClass.Text = meter.Class;
                txtConstant.Text = meter.Constant;
                txtBasicCurrent.Text = meter.BasicCurrent;
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
                cboMeterSequence.Text = meter.MeterBoxSequence;
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
                txtMeterNo.Focus();
                hasError = false;
            }
            else if (txtMeterModel.Text == string.Empty)
            {
                tooltip.SetToolTip(txtMeterModel, "Error");
                tooltip.Show("Please fill up Meter Model!", txtMeterModel);
                txtMeterModel.Focus();
                hasError = false;
            }
            else if (dtpInstallDate.Value.ToString() == "")
            {
                tooltip.SetToolTip(dtpInstallDate, "Error");
                tooltip.Show("Please Select Install Date!", dtpInstallDate);
                dtpInstallDate.Focus();
                hasError = false;
            }
            else if (txtPhrase.Text == string.Empty)
            {
                tooltip.SetToolTip(txtPhrase, "Error");
                tooltip.Show("Please fill up Phrase!", txtPhrase);
                txtPhrase.Focus();
                hasError = false;
            }
            else if (txtWire.Text == string.Empty)
            {
                tooltip.SetToolTip(txtWire, "Error");
                tooltip.Show("Please fill up Wire!", txtWire);
                txtWire.Focus();
                hasError = false;
            }
            else if (txtBasicCurrent.Text == string.Empty)
            {
                tooltip.SetToolTip(txtBasicCurrent, "Error");
                tooltip.Show("Please fill up Basic Current!", txtBasicCurrent);
                txtBasicCurrent.Focus();
                hasError = false;
            }
            else if (txtiMax.Text == string.Empty)
            {
                tooltip.SetToolTip(txtiMax, "Error");
                tooltip.Show("Please fill up Max Current!", txtiMax);
                txtiMax.Focus();
                hasError = false;
            }
            else if (txtVoltage.Text == string.Empty)
            {
                tooltip.SetToolTip(txtVoltage, "Error");
                tooltip.Show("Please fill up Voltage!", txtVoltage);
                txtVoltage.Focus();
                hasError = false;
            }
            else if (txtManufacture.Text == string.Empty)
            {
                tooltip.SetToolTip(txtManufacture, "Error");
                tooltip.Show("Please fill up Manufacture By!", txtManufacture);
                txtManufacture.Focus();
                hasError = false;
            }
            else if (txtAvailableYear.Text == string.Empty)
            {
                tooltip.SetToolTip(txtAvailableYear, "Error");
                tooltip.Show("Please fill up Available Year!", txtAvailableYear);
                txtAvailableYear.Focus();
                hasError = false;
            }
            else if (cboMeterBoxCode.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboMeterBoxCode, "Error");
                tooltip.Show("Please choose Meter Box Code!", cboMeterBoxCode);
                cboMeterBoxCode.Focus();
                hasError = false;
            }
            else if (cboMeterSequence.Text == string.Empty)
            {
                tooltip.SetToolTip(cboMeterSequence, "Error");
                tooltip.Show("Please choose up Meter Box Sequence!", cboMeterSequence);
                cboMeterSequence.Focus();
                hasError = false;
            }
            else if (cboMeterTypeCode.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboMeterTypeCode, "Error");
                tooltip.Show("Please choose Meter Type Code!", cboMeterTypeCode);
                cboMeterTypeCode.Focus();
                hasError = false;
            }            
            
            else if (txtLosses.Text == string.Empty)
            {
                tooltip.SetToolTip(txtLosses, "Error");
                tooltip.Show("Please fill up Losses!", txtLosses);
                txtLosses.Focus();
                hasError = false;
            }
            else if (txtMultiplier.Text == string.Empty)
            {
                tooltip.SetToolTip(txtMultiplier, "Error");
                tooltip.Show("Please fill up Multiplier!", txtMultiplier);
                txtMultiplier.Focus();
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
                    int editMeterCount = 0; int editmeterBoxNoCount = 0;
                    Meter updateMeter = (from m in mbmsEntities.Meters where m.MeterID == meterID select m).FirstOrDefault();                  

                    if (cboMeterSequence.Text != updateMeter.MeterBoxSequence)
                    {
                        string meterboxId = cboMeterBoxCode.SelectedValue.ToString();
                        editmeterBoxNoCount = (from m in mbmsEntities.Meters where m.MeterBoxSequence == cboMeterSequence.Text && m.MeterBoxID==meterboxId && m.Active == true select m).ToList().Count;
                    }
                    if (editmeterBoxNoCount > 0)
                    {
                        tooltip.SetToolTip(cboMeterSequence, "Error");
                        tooltip.Show("MeterBox Sequence No is already used!", cboMeterSequence);
                        return;
                    }
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
                    updateMeter.Phrase = txtPhrase.Text;
                    updateMeter.Wire = txtWire.Text;
                    updateMeter.BasicCurrent = txtBasicCurrent.Text;
                    updateMeter.Constant = txtConstant.Text;
                    updateMeter.AvailableYear =Convert.ToInt32( txtAvailableYear.Text);
                    updateMeter.Class = txtClass.Text;
                    updateMeter.iMax = Convert.ToInt32(txtiMax.Text);
                    updateMeter.KVA = Convert.ToInt32(txtKVA.Text);
                    updateMeter.ManufactureBy = txtManufacture.Text;
                    updateMeter.Frequency = Convert.ToInt32(txtFrequency.Text);
                    updateMeter.MeterBoxID = cboMeterBoxCode.SelectedValue.ToString();
                    updateMeter.MeterBoxSequence = cboMeterSequence.Text;
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
                    Meter meter = new Meter();
                    int meterNoCount = 0; int meterBoxNoCount = 0;
                    string meterboxId = cboMeterBoxCode.SelectedValue.ToString();               
                    meterBoxNoCount = (from m in mbmsEntities.Meters where m.MeterBoxSequence == cboMeterSequence.Text && m.MeterBoxID== meterboxId && m.Active == true select m).ToList().Count;
                   
                    if (meterBoxNoCount > 0)
                    {
                        tooltip.SetToolTip(cboMeterSequence, "Error");
                        tooltip.Show("MeterBox Sequence No is already used!", cboMeterSequence);
                        return;
                    }
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
                    meter.HP = Convert.ToInt32(txtHp.Text == "" ? "0" : txtHp.Text);
                    meter.Voltage = Convert.ToInt32(txtVoltage.Text);
                    meter.AMP = txtAMP.Text==""?"0":txtAMP.Text ;
                    meter.Standard = Convert.ToInt32(txtStandard.Text ==""?"0" :txtStandard.Text);
                    if (rdoEnable.Checked == true)
                    {
                        meter.Status = "Enable";
                    }
                    else
                    {
                        meter.Status = "Disable";
                    }
                    meter.Phrase = txtPhrase.Text;
                    meter.Wire = txtWire.Text;
                    meter.BasicCurrent = txtBasicCurrent.Text;
                    meter.Constant = txtConstant.Text ==""?"0":txtConstant.Text;
                    meter.AvailableYear = Convert.ToInt32(txtAvailableYear.Text);
                    meter.Class = txtClass.Text == "" ?"0" :txtClass.Text;

                    meter.iMax = Convert.ToInt32(txtiMax.Text);
                    meter.KVA = Convert.ToInt32(txtKVA.Text ==""?"0" :txtKVA.Text);
                    meter.ManufactureBy = txtManufacture.Text;
                    meter.Frequency = Convert.ToInt32(txtFrequency.Text == "" ? "0" :txtFrequency.Text);
                    meter.MeterBoxID = cboMeterBoxCode.SelectedValue.ToString();
                    meter.MeterBoxSequence = cboMeterSequence.Text;
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
            cboMeterSequence.Enabled = false;
            txtMeterModel.Text = string.Empty;
            txtMeterNo.Text = string.Empty;
            txtMultiplier.Text = string.Empty;
            txtStandard.Text = string.Empty;
            txtVoltage.Text = string.Empty;
            dtpInstallDate.Value = DateTime.Now;
            cboMeterBoxCode.SelectedIndex = 0;
            cboMeterTypeCode.SelectedIndex = 0;
            rdoEnable.Checked = true;
            txtAvailableYear.Text = string.Empty;
            txtBasicCurrent.Text = string.Empty;
            txtClass.Text = string.Empty;
            txtConstant.Text = string.Empty;
            txtWire.Text = string.Empty;
            txtPhrase.Text = string.Empty;
                

        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cboMeterBoxCode_SelectedIndexChanged(object sender, EventArgs e)
        {
            mbmsEntities = new MBMSEntities();
            if (cboMeterBoxCode.SelectedIndex > 0)
            {
                cboMeterSequence.Items.Clear();
                string meterBoxID = Convert.ToString(cboMeterBoxCode.SelectedValue);
                var meterBoxData = (from m in mbmsEntities.MeterBoxes where m.MeterBoxID == meterBoxID select m).FirstOrDefault();
                if (meterBoxData.MeterBoxName == "Single Box" || meterBoxData.MeterBoxName == "Three Phase Box")
                {
                    cboMeterSequence.Enabled = true;
                    cboMeterSequence.Items.Add(meterBoxData.Box + "1");
                }else if (meterBoxData.MeterBoxName == "Single Phase 4 Unit Box")
                {
                    cboMeterSequence.Enabled = true;
                    cboMeterSequence.Items.Add(meterBoxData.Box + "1");
                    cboMeterSequence.Items.Add(meterBoxData.Box + "2");
                    cboMeterSequence.Items.Add(meterBoxData.Box + "3");
                    cboMeterSequence.Items.Add(meterBoxData.Box + "4");
                }       
            }
            else
            {
                cboMeterSequence.Enabled = false;
            }
        }

        private void MeterFrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtMeterNo);
            tooltip.Hide(txtMeterModel);
            tooltip.Hide(dtpInstallDate);
            tooltip.Hide(txtPhrase);
            tooltip.Hide(txtWire);
            tooltip.Hide(txtBasicCurrent);
            tooltip.Hide(txtiMax);
            tooltip.Hide(txtVoltage);
            tooltip.Hide(txtManufacture);
            tooltip.Hide(txtAvailableYear);
            tooltip.Hide(cboMeterBoxCode);
            tooltip.Hide(cboMeterSequence);
            tooltip.Hide(cboMeterTypeCode);
            tooltip.Hide(txtLosses);
            tooltip.Hide(txtMultiplier);
        }
    }
}
