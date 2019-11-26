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
    public partial class MeterBoxfrm : Form
    {
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String UserID { get; set; }
        string meterBoxID;
        public Boolean isEdit { get; set; }
        MeterBox meterBox = new MeterBox();
        MeterBoxController meterBoxController = new MeterBoxController();
        public MeterBoxfrm()
        {
            InitializeComponent();
        }

        private void MeterBoxfrm_Load(object sender, EventArgs e)
        {
            bindPole();
            FormRefresh();
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
            else if (txtMeterBoxQty.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtMeterBoxQty, "Error");
                tooltip.Show("Please fill up Available MeterBox Qty!", txtMeterBoxQty);
                txtMeterBoxQty.Focus();
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
                    int editMeterBoxCount = 0 ;
                    MeterBox updateMeterBox = (from mb in mbmsEntities.MeterBoxes where mb.MeterBoxID == meterBoxID select mb).FirstOrDefault();
                    if (txtMeterBoxCode.Text != updateMeterBox.MeterBoxCode)
                    {
                        editMeterBoxCount = (from mb in mbmsEntities.MeterBoxes where mb.MeterBoxCode == txtMeterBoxCode.Text && mb.Active == true select mb).ToList().Count;
                    }

                    if (editMeterBoxCount > 0)
                    {
                        tooltip.SetToolTip(txtMeterBoxCode, "Error");
                        tooltip.Show("Meter Box Code is already exist!", txtMeterBoxCode);
                        return;
                    }
                    
                    updateMeterBox.MeterBoxCode = txtMeterBoxCode.Text;
                    updateMeterBox.Box = Convert.ToInt32(txtMeterBox.Text);
                    updateMeterBox.AvailableInMBQty = Convert.ToInt32(txtMeterBoxQty.Text);
                    updateMeterBox.PoleID = cboPoleNo.SelectedValue.ToString();
                    updateMeterBox.UpdatedUserID = UserID;
                    updateMeterBox.UpdatedDate = DateTime.Now;
                    meterBoxController.UpdateMeterBox(updateMeterBox);
                    MessageBox.Show("Successfully updated Meterbox!", "Update");
                    Clear();
                    FormRefresh();
                }
                else
                {
                    int meterBoxCodeCount = 0;
                    meterBoxCodeCount = (from mb in mbmsEntities.MeterBoxes where mb.MeterBoxCode == txtMeterBoxCode.Text && mb.Active == true select mb).ToList().Count;

                    if (meterBoxCodeCount > 0)
                    {
                        tooltip.SetToolTip(txtMeterBoxCode, "Error");
                        tooltip.Show("Meter Box Code is already exist!", txtMeterBoxCode);
                        return;
                    }
                    try
                    {
                        meterBox.MeterBoxID = Guid.NewGuid().ToString();
                        meterBox.MeterBoxCode = txtMeterBoxCode.Text;
                        meterBox.Box = Convert.ToInt32(txtMeterBox.Text);
                        meterBox.AvailableInMBQty = Convert.ToInt32(txtMeterBoxQty.Text);
                        meterBox.PoleID = cboPoleNo.SelectedValue.ToString();
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
            txtMeterBoxQty.Text = string.Empty;
            cboPoleNo.SelectedIndex = 0;
        }
        public void FormRefresh()
        {
            dgvMeterboxList.AutoGenerateColumns = false;
            dgvMeterboxList.DataSource = (from mb in mbmsEntities.MeterBoxes where mb.Active == true orderby mb.MeterBoxCode descending select mb).ToList();
        }

        private void dgvMeterboxList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvMeterboxList.Rows)
            {
                MeterBox meterBox = (MeterBox)row.DataBoundItem;
                row.Cells[0].Value = meterBox.MeterBoxID;
                row.Cells[1].Value = meterBox.MeterBoxCode;
                row.Cells[2].Value = meterBox.Pole.PoleNo;
                row.Cells[3].Value = meterBox.Box;
                row.Cells[4].Value = meterBox.AvailableInMBQty;
            }
        }

        private void dgvMeterboxList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 6)
                {
                    //DeleteForMeterBox
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
                else if (e.ColumnIndex == 5)
                {
                    //EditMeterBox
                    DataGridViewRow row = dgvMeterboxList.Rows[e.RowIndex];
                    meterBoxID = Convert.ToString(row.Cells[0].Value);
                    txtMeterBoxCode.Text = Convert.ToString(row.Cells[1].Value);
                    cboPoleNo.Text = Convert.ToString(row.Cells[2].Value);
                    txtMeterBox.Text = Convert.ToString(row.Cells[3].Value);
                    txtMeterBoxQty.Text = Convert.ToString(row.Cells[4].Value);
                    isEdit = true;

                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
