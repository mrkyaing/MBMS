using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity.Migrations;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Setting_Setup {
    public partial class StreetLightFeesUI : Form {
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbmsEntities = new MBMSEntities();
        public string UserID { get; set; }
        public string streetLightFeesId { get; set; }
        private ToolTip tp = new ToolTip();
        public StreetLightFeesUI() {
            InitializeComponent();
            }
        public void bindQuarter() {
            List<Quarter> quarterList = new List<Quarter>();
            Quarter quarter = new Quarter();
            quarter.QuarterID = Convert.ToString(0);
            quarter.QuarterNameInEng = "Select";
            quarterList.Add(quarter);
            quarterList.AddRange(mbmsEntities.Quarters.Where(x => x.Active == true).OrderBy(x => x.QuarterNameInEng).ToList());
            cboQuarterName.DataSource = quarterList;
            cboQuarterName.DisplayMember = "QuarterNameInEng";
            cboQuarterName.ValueMember = "QuarterID";
            }
        public void bindTownship() {
            List<Township> townshipList = new List<Township>();
            Township township = new Township();
            township.TownshipID = Convert.ToString(0);
            township.TownshipNameInEng = "Select";
            townshipList.Add(township);
            townshipList.AddRange(mbmsEntities.Townships.Where(x => x.Active == true).OrderBy(x => x.TownshipNameInEng).ToList());
            cboTownshipName.DataSource = townshipList;
            cboTownshipName.DisplayMember = "TownshipNameInEng";
            cboTownshipName.ValueMember = "TownshipID";
            }
        private void StreetLightFeesUI_Load(object sender, EventArgs e) {
            bindQuarter();
            bindTownship();
            bindStreetLightFeesGridView();
            }

        private void bindStreetLightFeesGridView() {
            gvStreetLightFees.AutoGenerateColumns = false;
            gvStreetLightFees.DataSource = mbmsEntities.StreetLightFees.Where(x => x.Active == true).OrderByDescending(y=>y.CreatedDate).ToList();
            }

        private void cboTownshipName_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboTownshipName.SelectedIndex > 0) {
                mbmsEntities = new MBMSEntities();
                string townshipID = Convert.ToString(cboTownshipName.SelectedValue);
                List<Quarter> quarterList = new List<Quarter>();
                Quarter quarter = new Quarter();
                quarter.QuarterID = Convert.ToString(0);
                quarter.QuarterNameInEng = "Select";
                quarterList.Add(quarter);
                quarterList.AddRange(mbmsEntities.Quarters.Where(x => x.Active == true && x.TownshipID == townshipID).OrderBy(x => x.QuarterNameInEng).ToList());
                cboQuarterName.DataSource = quarterList;
                cboQuarterName.DisplayMember = "QuarterNameInEng";
                cboQuarterName.ValueMember = "QuarterID";
                var towshipData = (from t in mbmsEntities.Townships where t.TownshipID == townshipID select t).FirstOrDefault();
                }
            }

        private void btnSave_Click(object sender, EventArgs e) {
            if (checkValidation()) {
                string QuarterId= cboQuarterName.SelectedValue.ToString();
                bool isdataExists = mbmsEntities.StreetLightFees.Any(x => x.Active == true && x.QuarterID == QuarterId);
                if (isdataExists) {
                    MessageBox.Show("Same Quarter data already exists!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                    }
                if (btnSave.Text.Equals("Update")) {
                    StreetLightFee streetlightfeeentity = mbmsEntities.StreetLightFees.Where(x => x.Active == true && x.StreetLightFeesID == streetLightFeesId).SingleOrDefault();
                    streetlightfeeentity.QuarterID = QuarterId;
                    streetlightfeeentity.Amount = Convert.ToDecimal(txtstreetlightfeeamt.Text);
                    streetlightfeeentity.Active = true;
                    streetlightfeeentity.UpdatedDate = DateTime.Now;
                    streetlightfeeentity.UpdatedUserID = UserID;
                    mbmsEntities.StreetLightFees.AddOrUpdate(streetlightfeeentity);
                    mbmsEntities.SaveChanges();
                    MessageBox.Show("Successfully Updated", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    btnSave.Text = "Save";
                    }
                else {
                    StreetLightFee streetlightfeeentity = new StreetLightFee();
                    streetlightfeeentity.StreetLightFeesID = Guid.NewGuid().ToString();
                    streetlightfeeentity.QuarterID = QuarterId;
                    streetlightfeeentity.Amount = Convert.ToDecimal(txtstreetlightfeeamt.Text);
                    streetlightfeeentity.Active = true;
                    streetlightfeeentity.CreatedDate = DateTime.Now;
                    streetlightfeeentity.CreatedUserID = UserID;
                    mbmsEntities.StreetLightFees.Add(streetlightfeeentity);
                    mbmsEntities.SaveChanges();
                    MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                bindStreetLightFeesGridView();
                }
            }

        private bool checkValidation() {
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            if (cboQuarterName.SelectedIndex <= 0) {
                MessageBox.Show("Select Quarter data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
                }
        else    if (string.IsNullOrEmpty(txtstreetlightfeeamt.Text)) {
                tp.SetToolTip(txtstreetlightfeeamt, "Error");
                tp.Show("Please Fill Up Street Light Fees Amount", txtstreetlightfeeamt);
                return false;
                }
            return true;
            }

        private void btnCancel_Click(object sender, EventArgs e) {
            btnSave.Text = "Save";
            cboQuarterName.SelectedIndex = cboTownshipName.SelectedIndex = 0;
            txtstreetlightfeeamt.Text = string.Empty;
            bindStreetLightFeesGridView();
            }

        private void gvStreetLightFees_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e) {
            foreach (DataGridViewRow row in gvStreetLightFees.Rows) {
                StreetLightFee streetLightFeesEntity = (StreetLightFee)row.DataBoundItem;
                row.Cells[0].Value = streetLightFeesEntity.StreetLightFeesID;
                row.Cells[1].Value = streetLightFeesEntity.Quarter.QuarterNameInEng;             
                row.Cells[3].Value = streetLightFeesEntity.Quarter.Township.TownshipNameInEng;
                row.Cells[2].Value = streetLightFeesEntity.Amount;
                }
            }

        private void gvStreetLightFees_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                if (e.ColumnIndex == 5) {
                    //Delete
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK)) {
                        DataGridViewRow row = gvStreetLightFees.Rows[e.RowIndex];
                        StreetLightFee griddata = (StreetLightFee)row.DataBoundItem;//get the selected row's data 
                        StreetLightFee streetLightFee = mbmsEntities.StreetLightFees.Where(x => x.Active == true && x.StreetLightFeesID == griddata.StreetLightFeesID).SingleOrDefault();
                        streetLightFee.Active = false;
                        streetLightFee.UpdatedDate = DateTime.Now;
                        streetLightFee.UpdatedUserID = this.UserID;
                        mbmsEntities.SaveChanges();
                        MessageBox.Show("Successfully Deleted", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        bindStreetLightFeesGridView();
                        }
                    }
                else if (e.ColumnIndex == 4) {
                    //Edit
                    DataGridViewRow row = gvStreetLightFees.Rows[e.RowIndex];
                    StreetLightFee streetLightFee = (StreetLightFee)row.DataBoundItem;//get the selected row's data 
                    streetLightFeesId = streetLightFee.StreetLightFeesID;
                    cboQuarterName.Text = streetLightFee.Quarter.QuarterNameInEng;
                    cboTownshipName.Text = streetLightFee.Quarter.Township.TownshipNameInEng;
                    txtstreetlightfeeamt.Text = streetLightFee.Amount.ToString();
                    btnSave.Text = "Update";
                    }
                }
            }
        }
    }
