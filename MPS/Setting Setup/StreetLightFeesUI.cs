using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Setting_Setup {
    public partial class StreetLightFeesUI : Form {
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String UserID { get; set; }
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
                StreetLightFee streetlightfeeentity = new StreetLightFee();
                streetlightfeeentity.StreetLightFeesID = Guid.NewGuid().ToString();
                streetlightfeeentity.QuarterID = cboQuarterName.SelectedValue.ToString();
                streetlightfeeentity.Amount =Convert.ToDecimal( txtstreetlightfeeamt.Text);
                streetlightfeeentity.Active = true;
                streetlightfeeentity.CreatedDate = DateTime.Now;
                streetlightfeeentity.CreatedUserID = Guid.NewGuid().ToString();
                mbmsEntities.StreetLightFees.Add(streetlightfeeentity);
                mbmsEntities.SaveChanges();
                MessageBox.Show("Successfully Saved", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        else    if (txtstreetlightfeeamt.Text.Trim() == string.Empty || Convert.ToInt32(txtstreetlightfeeamt.Text) == 0) {
                tp.SetToolTip(txtstreetlightfeeamt, "Error");
                tp.Show("Please Fill Up Street Light Fees Amount", txtstreetlightfeeamt);
                return false;
                }
            return true;
            }
        }
    }
