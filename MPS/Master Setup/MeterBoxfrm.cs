﻿using MBMS.DAL;
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
    public partial class MeterBoxfrm : Form
    {
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String UserID { get; set; }
        string meterBoxID;
        public Boolean isEdit { get; set; }
        
        MeterBoxController meterBoxController = new MeterBoxController();
        private List<MeterBox> meterBoxList = new List<MeterBox>();
        public MeterBoxfrm()
        {
            InitializeComponent();
        }
        #region Data Permision for Role Mgt
        private bool CheckingRoleManagementFeature(string ProgramName) {
            bool IsAllowed = false;
            string roleID = mbmsEntities.Users.Where(x => x.Active == true && x.UserID == UserID).SingleOrDefault().RoleID;
            List<RoleManagement> rolemgtList = mbmsEntities.RoleManagements.Where(x => x.Active == true && x.RoleID == roleID).ToList();
            foreach (RoleManagement item in rolemgtList) {
                //bill payment Menu Permission CustomerView
                if (item.RoleFeatureName.Equals(ProgramName) && item.IsAllowed) IsAllowed = item.IsAllowed;
                }
            return IsAllowed;
            }
        #endregion
        private void MeterBoxfrm_Load(object sender, EventArgs e)
        {
            bindPole();
            bindMeterBoxName();
            FormRefresh();
            bindSearchPole();bindSearchQuarterName();
            txtMeterBox.MaxLength = 1;
        }
        public void bindMeterBoxName()
        {
            cboMeterBoxName.Items.Add("Single Box");
            cboMeterBoxName.Items.Add("Three Phase Box");
            cboMeterBoxName.Items.Add("Single Phase 4 Unit Box");
            cboMeterBoxName.SelectedIndex = 0;
        }
        public void bindPole()
        {
            List<Pole> poleList = new List<Pole>();
            Pole pole = new Pole();
            pole.PoleID = Convert.ToString(0);
            pole.PoleNo = "Select";
            poleList.Add(pole);
            poleList.AddRange(mbmsEntities.Poles.Where(x => x.Active == true).OrderBy(x=>x.PoleNo).ToList());
            cboPoleNo.DataSource = poleList;
            cboPoleNo.DisplayMember = "PoleNo";
            cboPoleNo.ValueMember = "PoleID";
        }

        public void bindSearchPole()
        {
            List<Pole> poleList = new List<Pole>();
            Pole pole = new Pole();
            pole.PoleID = Convert.ToString(0);
            pole.PoleNo = "Select";
            poleList.Add(pole);
            poleList.AddRange(mbmsEntities.Poles.Where(x => x.Active == true).OrderBy(x => x.PoleNo).ToList());
            cboSearchPoleNo.DataSource = poleList;
            cboSearchPoleNo.DisplayMember = "PoleNo";
            cboSearchPoleNo.ValueMember = "PoleID";
        }
        public void bindSearchQuarterName()
        {
            List<Quarter> quarterList = new List<Quarter>();
            Quarter quarter = new Quarter();
            quarter.QuarterID = Convert.ToString(0);
            quarter.QuarterNameInEng = "Select";
            quarterList.Add(quarter);
            quarterList.AddRange(mbmsEntities.Quarters.Where(x => x.Active == true).OrderBy(x => x.QuarterNameInEng).ToList());
            cboSearchQuarterName.DataSource = quarterList;
            cboSearchQuarterName.DisplayMember = "QuarterNameInEng";
            cboSearchQuarterName.ValueMember = "QuarterID";
        }
        public bool checkValidation()
        {
            Boolean hasError = true;
            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.ToolTipTitle = "Error";

            if (txtMeterBoxCode.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtMeterBoxCode, "Error");
                tooltip.Show("Please fill up Meterbox Code!", txtMeterBoxCode);                
                txtMeterBoxCode.Focus();
                hasError = false;
            }
            else if (cboPoleNo.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboPoleNo, "Error");
                tooltip.Show("Please Choose Pole Name!", cboPoleNo);
                cboPoleNo.Focus();
                hasError = false;
            }
            else if (txtMeterBox.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtMeterBox, "Error");
                tooltip.Show("Please fill up MeterBox!", txtMeterBox);
                txtMeterBox.Focus();
                hasError = false;
            }            

            return hasError;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (!CheckingRoleManagementFeature("MeterBoxAdd")) {
                MessageBox.Show("Access Deined for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (checkValidation())
            {
                if (isEdit)
                {
                    int editMeterBoxCodeCount = 0 ; int editMeterBoxCount = 0;
                    MeterBox updateMeterBox = (from mb in mbmsEntities.MeterBoxes where mb.MeterBoxID == meterBoxID select mb).FirstOrDefault();
                    if (txtMeterBoxCode.Text != updateMeterBox.MeterBoxCode)
                    {
                        editMeterBoxCodeCount = (from mb in mbmsEntities.MeterBoxes where mb.MeterBoxCode == txtMeterBoxCode.Text && mb.Active == true select mb).ToList().Count;
                    }
                    if (txtMeterBox.Text != updateMeterBox.Box)
                    {
                        editMeterBoxCount = (from mb in mbmsEntities.MeterBoxes where mb.MeterBoxCode == txtMeterBox.Text &&mb.Pole.PoleNo==cboPoleNo.Text && mb.Active == true select mb).ToList().Count;
                    }

                    if (editMeterBoxCodeCount > 0)
                    {
                        tooltip.SetToolTip(txtMeterBoxCode, "Error");
                        tooltip.Show("Meter Box Code is already exist!", txtMeterBoxCode);
                        return;
                    }
                    if (editMeterBoxCount > 0)
                    {
                        tooltip.SetToolTip(txtMeterBox, "Error");
                        tooltip.Show("Meter Box is already exist!", txtMeterBox);
                        return;
                    }

                    updateMeterBox.MeterBoxCode = txtMeterBoxCode.Text;
                    updateMeterBox.Box = txtMeterBox.Text;
                    updateMeterBox.PoleID = cboPoleNo.SelectedValue.ToString();
                    updateMeterBox.MeterBoxName = cboMeterBoxName.Text.ToString();
                    updateMeterBox.UpdatedUserID = UserID;
                    updateMeterBox.UpdatedDate = DateTime.Now;
                    meterBoxController.UpdateMeterBox(updateMeterBox);
                    MessageBox.Show("Successfully updated Meterbox!", "Update");
                    isEdit = false;
                    btnSave.Text = "Save";
                    Clear();                                      
                    FormRefresh();
                }
                else
                {
                    MeterBox meterBox = new MeterBox();
                    int meterBoxCodeCount = 0;int meterBoxCount = 0;
                    meterBoxCodeCount = (from mb in mbmsEntities.MeterBoxes where mb.MeterBoxCode == txtMeterBoxCode.Text && mb.Active == true select mb).ToList().Count;
                    meterBoxCount= (from mb in mbmsEntities.MeterBoxes where mb.Box == txtMeterBox.Text &&mb.Pole.PoleNo==cboPoleNo.Text && mb.Active == true select mb).ToList().Count;
                    if (meterBoxCodeCount > 0)
                    {
                        tooltip.SetToolTip(txtMeterBoxCode, "Error");
                        tooltip.Show("Meter Box Code is already exist!", txtMeterBoxCode);
                        return;
                    }
                    if (meterBoxCount > 0)
                    {
                        tooltip.SetToolTip(txtMeterBox, "Error");
                        tooltip.Show("Meter Box is already exist!", txtMeterBox);
                        return;
                    }
                    try
                    {
                        meterBox.MeterBoxID = Guid.NewGuid().ToString();
                        meterBox.MeterBoxCode = txtMeterBoxCode.Text;
                        meterBox.Box = txtMeterBox.Text;
                        meterBox.PoleID = cboPoleNo.SelectedValue.ToString();
                        meterBox.MeterBoxName = cboMeterBoxName.Text;
                        meterBox.Active = true;
                        meterBox.CreatedUserID = UserID;
                        meterBox.CreatedDate = DateTime.Now;
                        meterBoxController.Save(meterBox);
                        MessageBox.Show("Successfully registered Meterbox! Please check it in 'Meterbox List'.", "Save Success");
                        Clear();
                        FormRefresh();
                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show("Error", "Error");
                    }
                }
            }
        }
        public void Clear()
        {
            txtMeterBox.Text = string.Empty;
            txtMeterBoxCode.Text = string.Empty;
            txtQuarterName.Text = string.Empty;
            cboPoleNo.SelectedIndex = 0;
            cboMeterBoxName.SelectedIndex = 0;
        }
        public void FormRefresh()
        {
            dgvMeterboxList.AutoGenerateColumns = false;
            dgvMeterboxList.DataSource = (from mb in mbmsEntities.MeterBoxes where mb.Active == true orderby mb.MeterBoxCode descending select mb).ToList();
        }
        public void loadData()
        {
            meterBoxList = (from mb in mbmsEntities.MeterBoxes
                        where mb.Active == true &&
                        mb.Pole.PoleNo == cboSearchPoleNo.Text || mb.MeterBoxCode == txtSearchMeterBoxCode.Text || mb.Pole.Transformer.Quarter.QuarterNameInEng == cboSearchQuarterName.Text
                        select mb).ToList();
            foundDataBind();

        }
        public void foundDataBind()
        {

            dgvMeterboxList.DataSource = "";

            if (meterBoxList.Count < 1)
            {
                MessageBox.Show("No data Found", "Cannot find");
                dgvMeterboxList.DataSource = "";
                return;
            }
            else
            {
                dgvMeterboxList.DataSource = meterBoxList;
            }
        }
        private void dgvMeterboxList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMeterboxList.Rows)
            {
                MeterBox meterBox = (MeterBox)row.DataBoundItem;
                row.Cells[0].Value = meterBox.MeterBoxID;
                row.Cells[1].Value = meterBox.MeterBoxCode;
                row.Cells[2].Value = meterBox.Pole.PoleNo;
                row.Cells[3].Value = meterBox.Pole.Transformer.Quarter.QuarterNameInEng;
                row.Cells[4].Value = meterBox.MeterBoxName;
                row.Cells[5].Value = meterBox.Box;
                
            }
        }

        private void dgvMeterboxList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 7)
                {
                    //DeleteForMeterBox
                    if (!CheckingRoleManagementFeature("MeterEditOrDelete")) {
                        MessageBox.Show("Access Deined for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        }
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {

                        DataGridViewRow row = dgvMeterboxList.Rows[e.RowIndex];
                        meterBoxID = Convert.ToString(row.Cells[0].Value);
                        MeterBox meterBoxobj = (MeterBox)row.DataBoundItem;
                        meterBoxobj = (from mb in mbmsEntities.MeterBoxes where mb.MeterBoxID == meterBoxobj.MeterBoxID select mb).FirstOrDefault();
                        var meterCount = (from m in meterBoxobj.Meters where m.Active == true select m).Count();
                        if (meterCount > 0)
                        {
                            MessageBox.Show("This Meterbox cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        dgvMeterboxList.DataSource = "";
                        MeterBox meterBox = (from mb in mbmsEntities.MeterBoxes where mb.MeterBoxID == meterBoxID select mb).FirstOrDefault();
                        meterBox.Active = false;
                        meterBox.DeletedUserID = UserID;
                        meterBox.DeletedDate = DateTime.Now;
                        meterBoxController.DeleteMeterBox(meterBox);
                        dgvMeterboxList.DataSource = (from mb in mbmsEntities.MeterBoxes where mb.Active == true orderby mb.MeterBoxCode descending select mb).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        FormRefresh();

                    }

                }
                else if (e.ColumnIndex == 6)
                {
                    //EditMeterBox
                    if (!CheckingRoleManagementFeature("MeterEditOrDelete")) {
                        MessageBox.Show("Access Deined for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        }
                    DataGridViewRow row = dgvMeterboxList.Rows[e.RowIndex];
                    meterBoxID = Convert.ToString(row.Cells[0].Value);
                    txtMeterBoxCode.Text = Convert.ToString(row.Cells[1].Value);
                    cboPoleNo.Text = Convert.ToString(row.Cells[2].Value);
                    txtQuarterName.Text = Convert.ToString(row.Cells[3].Value);
                    cboMeterBoxName.Text = Convert.ToString(row.Cells[4].Value);
                    txtMeterBox.Text = Convert.ToString(row.Cells[5].Value);                    
                    isEdit = true;
                    btnSave.Text = "Update";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void cboPoleNo_SelectedIndexChanged(object sender, EventArgs e)
        {
            mbmsEntities = new MBMSEntities();
            if (cboPoleNo.SelectedIndex > 0)
            {
                string poleID = Convert.ToString(cboPoleNo.SelectedValue);
                var PoleData = (from t in mbmsEntities.Poles where t.PoleID == poleID select t).FirstOrDefault();
                txtQuarterName.Text = PoleData.Transformer.Quarter.QuarterNameInEng;
            }
            else
            {
                txtQuarterName.Text = string.Empty;
            }
        }

        private void txtMeterBoxCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void cboPoleNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtMeterBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtQuarterName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtSearchMeterBoxCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void cboSearchQuarterName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void cboSearchPoleNo_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSearch_Click(this, new EventArgs());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearchMeterBoxCode.Text = string.Empty;
            cboSearchPoleNo.SelectedIndex = 0;
            cboSearchQuarterName.SelectedIndex = 0;
            FormRefresh();
        }

        private void MeterBoxfrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtMeterBoxCode);
            tooltip.Hide(cboPoleNo);
            tooltip.Hide(cboMeterBoxName);
            tooltip.Hide(txtMeterBox);
        }
    }
}
