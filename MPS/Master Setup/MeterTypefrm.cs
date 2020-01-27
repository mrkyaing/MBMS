using MBMS.DAL;
using MPS.BusinessLogic.MasterSetUpController;
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
    public partial class MeterTypefrm : Form
    {
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String UserID { get; set; }
        string meterTypeID;
        public Boolean isEdit { get; set; }
       
        MeterTypeController meterTypeController = new MeterTypeController();
        public MeterTypefrm()
        {
            InitializeComponent();
        }

        private void MeterTypefrm_Load(object sender, EventArgs e)
        {
            FormRefresh();

        }
        public bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.ToolTipTitle = "Error";

            if (txtMeterTypeCode.Text == string.Empty)
            {
                tooltip.SetToolTip(txtMeterTypeCode, "Error");
                tooltip.Show("Please fill up Meter Type Code!", txtMeterTypeCode);
                hasError = false;
            }
            else if (txtMeterTypeDes.Text == string.Empty)
            {
                tooltip.SetToolTip(txtMeterTypeDes, "Error");
                tooltip.Show("Please fill up Meter Type Description!", txtMeterTypeDes);
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
                    int editMeterTypeCode = 0;
                    MeterType updateMeterType = (from mt in mbmsEntities.MeterTypes where mt.MeterTypeID == meterTypeID select mt).FirstOrDefault();
                    if (txtMeterTypeCode.Text != updateMeterType.MeterTypeCode)
                    {
                        editMeterTypeCode = (from mt in mbmsEntities.MeterTypes where mt.MeterTypeCode == txtMeterTypeCode.Text select mt).ToList().Count;
                    }
                    if (editMeterTypeCode > 0)
                    {
                        tooltip.SetToolTip(txtMeterTypeCode, "Error");
                        tooltip.Show("Meter Type Code is already exist!", txtMeterTypeCode);
                        return;
                    }
                    updateMeterType.MeterTypeCode = txtMeterTypeCode.Text;
                    updateMeterType.MeterTypeDescription = txtMeterTypeDes.Text;
                    updateMeterType.UpdatedUserID = UserID;
                    updateMeterType.UpdatedDate = DateTime.Now;
                    meterTypeController.UpdateMeterType(updateMeterType);
                    MessageBox.Show("Successfully updated Meter Type!", "Update");
                    isEdit = false;
                    btnSave.Text = "Save";
                    Clear();
                    FormRefresh();
                }
                else
                {
                    MeterType meterType = new MeterType();
                    int meterTypeCount = 0;
                    meterTypeCount = (from m in mbmsEntities.MeterTypes where m.MeterTypeCode == txtMeterTypeCode.Text && m.Active == true select m).ToList().Count;

                    if (meterTypeCount > 0)
                    {
                        tooltip.SetToolTip(txtMeterTypeCode, "Error");
                        tooltip.Show("MeterType Code is already exist!", txtMeterTypeCode);
                        return;
                    }
                    meterType.MeterTypeID = Guid.NewGuid().ToString();
                    meterType.MeterTypeCode = txtMeterTypeCode.Text;
                    meterType.MeterTypeDescription = txtMeterTypeDes.Text;
                    meterType.Active = true;
                    meterType.CreatedUserID = UserID;
                    meterType.CreatedDate = DateTime.Now;
                    meterTypeController.Save(meterType);
                    MessageBox.Show("Successfully registered Meter Type! Please check it in 'Meter Type List'.", "Save Success");
                    Clear();
                    FormRefresh();
                }
            }
        }
        public void Clear()
        {
            txtMeterTypeCode.Text = string.Empty;
            txtMeterTypeDes.Text = string.Empty;
        }
        public void FormRefresh()
        {
            dgvMeterTypeList.AutoGenerateColumns = false;
            dgvMeterTypeList.DataSource = (from mt in mbmsEntities.MeterTypes where mt.Active == true orderby mt.MeterTypeCode descending select mt).ToList();
        }

        private void dgvMeterTypeList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMeterTypeList.Rows)
            {
                MeterType meterType = (MeterType)row.DataBoundItem;
                row.Cells[0].Value = meterType.MeterTypeID;                   
                row.Cells[1].Value = meterType.MeterTypeCode;
                row.Cells[2].Value = meterType.MeterTypeDescription;

                }
        }

        private void dgvMeterTypeList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 4)
                {
                    //DeleteForMeterType
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvMeterTypeList.Rows[e.RowIndex];
                        meterTypeID = Convert.ToString(row.Cells[0].Value);
                        MeterType meterTypeObj = (MeterType)row.DataBoundItem;
                        meterTypeObj = (from mt in mbmsEntities.MeterTypes where mt.MeterTypeID == meterTypeObj.MeterTypeID select mt).FirstOrDefault();
                        var meterCount = (from m in meterTypeObj.Meters where m.Active == true select m).Count();
                        if (meterCount > 0)
                        {
                            MessageBox.Show("This Meter Type cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        dgvMeterTypeList.DataSource = "";
                        MeterType meterType = (from mt in mbmsEntities.MeterTypes where mt.MeterTypeID == meterTypeID select mt).FirstOrDefault();
                        meterType.Active = false;
                        meterType.DeletedUserID = UserID;
                        meterType.DeletedDate = DateTime.Now;
                        meterTypeController.DeleteMeterType(meterType);
                        dgvMeterTypeList.DataSource = (from mt in mbmsEntities.MeterTypes where mt.Active == true orderby mt.MeterTypeCode descending select mt).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        FormRefresh();
                    }

                }
                else if (e.ColumnIndex == 3)
                {
                    //EditMeterType
                    DataGridViewRow row = dgvMeterTypeList.Rows[e.RowIndex];
                    meterTypeID = Convert.ToString(row.Cells[0].Value);
                    txtMeterTypeCode.Text =Convert.ToString( row.Cells[1].Value);                        
                    txtMeterTypeDes.Text = Convert.ToString(row.Cells[2].Value);
                    isEdit = true;
                    btnSave.Text = "Update";                   

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtMeterTypeCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtMeterTypeDes_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }
    }
}
