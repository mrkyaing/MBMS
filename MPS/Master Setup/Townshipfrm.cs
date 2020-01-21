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
    public partial class Townshipfrm : Form
    {
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String UserID { get; set; }
        string TownshipID;
        public Boolean isEdit { get; set; }
        
        TownshipController townshipController = new TownshipController();
        public Townshipfrm()
        {
            InitializeComponent();
        }

        private void Townshipfrm_Load(object sender, EventArgs e)
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

            if (txtTownshipCode.Text == string.Empty)
            {
                tooltip.SetToolTip(txtTownshipCode, "Error");
                tooltip.Show("Please fill up Township code!", txtTownshipCode);
                hasError = false;
            }
            else if (txtTownshipNameEng.Text == string.Empty)
            {
                tooltip.SetToolTip(txtTownshipNameEng, "Error");
                tooltip.Show("Please fill up Township Name (English)!", txtTownshipNameEng);
                hasError = false;
            }
            else if (txtTowsshipNameMM.Text == string.Empty)
            {
                tooltip.SetToolTip(txtTowsshipNameMM, "Error");
                tooltip.Show("Please fill up Township Name (Myanmar)!", txtTowsshipNameMM);
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
                    int editTownshipCodeCount = 0, editTownshipNameEngCount=0, editTownshipNameMM=0;
                    
                    Township updateTownship = (from t in mbmsEntities.Townships where t.TownshipID == TownshipID select t).FirstOrDefault();
                    if (txtTownshipCode.Text != updateTownship.TownshipCode)
                    {
                        editTownshipCodeCount = (from t in mbmsEntities.Townships where ( t.TownshipCode== txtTownshipCode.Text ) && t.Active==true select t).ToList().Count;
                    }
                    if (txtTownshipNameEng.Text != updateTownship.TownshipNameInEng)
                    {
                        editTownshipNameEngCount = (from t in mbmsEntities.Townships where (t.TownshipNameInEng == txtTownshipNameEng.Text) && t.Active==true select t).ToList().Count;
                    }
                    if (txtTowsshipNameMM.Text != updateTownship.TownshipNameInMM)
                    {
                        editTownshipNameMM = (from t in mbmsEntities.Townships where (t.TownshipNameInMM == txtTowsshipNameMM.Text) && t.Active==true  select t).ToList().Count;
                    }

                    if (editTownshipCodeCount > 0)
                    {
                        tooltip.SetToolTip(txtTownshipCode, "Error");
                        tooltip.Show("Township Code is already exist!", txtTownshipCode);
                        return;
                    }
                    if (editTownshipNameEngCount > 0)
                    {
                        tooltip.SetToolTip(txtTownshipNameEng, "Error");
                        tooltip.Show("Township Name is already exist!", txtTownshipNameEng);
                        return;
                    }
                    if (editTownshipNameEngCount > 0)
                    {
                        tooltip.SetToolTip(txtTowsshipNameMM, "Error");
                        tooltip.Show("Township Name is already exist!", txtTowsshipNameMM);
                        return;
                    }
                    updateTownship.TownshipCode = txtTownshipCode.Text;
                    updateTownship.TownshipNameInEng = txtTownshipNameEng.Text;
                    updateTownship.TownshipNameInMM = txtTowsshipNameMM.Text;
                    updateTownship.UpdatedUserID = UserID;
                    updateTownship.UpdatedDate = DateTime.Now;
                    townshipController.UpdatedByTownshipID(updateTownship);
                    MessageBox.Show("Successfully updated Township!", "Update");
                    Clear();
                    FormRefresh();
                }
                else
                {
                    Township township = new Township();
                    int townshipCodeCount=0, townshipNameEng=0, townshipNameMM=0;
                    townshipCodeCount = (from t in mbmsEntities.Townships where t.TownshipCode == txtTownshipCode.Text  && t.Active==true select t).ToList().Count;
                    townshipNameEng = (from t in mbmsEntities.Townships where t.TownshipNameInEng == txtTownshipNameEng.Text && t.Active==true select t).ToList().Count;
                    townshipNameMM = (from t in mbmsEntities.Townships where t.TownshipNameInMM == txtTowsshipNameMM.Text && t.Active==true select t).ToList().Count;

                    if (townshipCodeCount > 0)
                    {
                        tooltip.SetToolTip(txtTownshipCode, "Error");
                        tooltip.Show("Township Code is already exist!", txtTownshipCode);
                        return;
                    }
                    if (townshipNameEng > 0)
                    {
                        tooltip.SetToolTip(txtTownshipNameEng, "Error");
                        tooltip.Show("Township Name is already exist!", txtTownshipNameEng);
                        return;
                    }
                    if (townshipNameMM > 0)
                    {
                        tooltip.SetToolTip(txtTowsshipNameMM, "Error");
                        tooltip.Show("Township Name is already exist!", txtTowsshipNameMM);
                        return;
                    }
                    township.TownshipID = Guid.NewGuid().ToString();
                    township.TownshipCode = txtTownshipCode.Text;
                    township.TownshipNameInEng = txtTownshipNameEng.Text;
                    township.TownshipNameInMM = txtTowsshipNameMM.Text;
                    township.Active = true;
                    township.CreatedUserID = UserID;
                    township.CreatedDate = DateTime.Now;
                    townshipController.Save(township);
                    MessageBox.Show("Successfully registered Township! Please check it in'Township List'.", "Save Success");
                    Clear();
                    FormRefresh();
                }
            }

        }
       

        public void Clear()
        {
            txtTownshipCode.Text = string.Empty;
            txtTownshipNameEng.Text = string.Empty;
            txtTowsshipNameMM.Text = string.Empty;
        }
        public void FormRefresh()
        {
            dgvTownship.AutoGenerateColumns = false;
            dgvTownship.DataSource = (from t in mbmsEntities.Townships where t.Active == true orderby t.TownshipID descending select t).ToList();
        }

        private void dgvTownship_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvTownship.Rows)
            {
                Township township = (Township)row.DataBoundItem;
                row.Cells[0].Value = township.TownshipID;
                row.Cells[1].Value = township.TownshipCode;
                row.Cells[2].Value = township.TownshipNameInEng;
                row.Cells[3].Value = township.TownshipNameInMM;

            }
        }

        private void dgvTownship_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5)
                {
                    //DeleteForTownship
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvTownship.Rows[e.RowIndex];
                        Township townshipObj = (Township)row.DataBoundItem;
                        townshipObj = (from t in mbmsEntities.Townships where t.TownshipID == townshipObj.TownshipID select t).FirstOrDefault();
                        var quarterCount = (from t in townshipObj.Quarters where t.Active == true select t).Count();
                        var customerCount = (from t in townshipObj.Customers where t.Active == true select t).Count();
                        if (quarterCount > 0)
                        {
                            MessageBox.Show("This Township cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        if (customerCount > 0)
                        {
                            MessageBox.Show("This Township cannot be deleted! It is in used.", "Cannot Delete", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                        TownshipID = Convert.ToString(row.Cells[0].Value);                             
                            dgvTownship.DataSource = "";
                            Township township = (from t in mbmsEntities.Townships where t.TownshipID == TownshipID select t).FirstOrDefault();
                            township.Active = false;
                            township.DeletedUserID = UserID;
                            township.DeletedDate = DateTime.Now;
                            townshipController.DeletedByTownship(township);
                            dgvTownship.DataSource = (from t in mbmsEntities.Townships where t.Active == true orderby t.TownshipCode descending select t).ToList();
                            MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Clear();
                            FormRefresh();
                        
                    }

                }
                else if (e.ColumnIndex == 4)
                {
                    //EditTownship
                    DataGridViewRow row = dgvTownship.Rows[e.RowIndex];
                    TownshipID = Convert.ToString(row.Cells[0].Value);
                    txtTownshipCode.Text = Convert.ToString(row.Cells[1].Value);
                    txtTownshipNameEng.Text = Convert.ToString(row.Cells[2].Value);
                    txtTowsshipNameMM.Text = Convert.ToString(row.Cells[3].Value);
                    isEdit = true;
                    btnSave.Text = "Update";
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void txtTownshipCode_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtTownshipNameEng_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }

        private void txtTowsshipNameMM_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnSave_Click(this, new EventArgs());
            }
        }
    }
}
