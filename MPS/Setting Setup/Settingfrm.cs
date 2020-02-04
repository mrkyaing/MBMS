using MBMS.DAL;

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static MPS.Utility;

namespace MPS.Setting_Setup
{
    public partial class Settingfrm : Form
    {
        MBMSEntities mbmsEntities = new MBMSEntities();
       
        private ToolTip tp = new ToolTip();
        public string  UserID { get; set; }
        public Settingfrm()
        {
            InitializeComponent();
        }

        private void Settingfrm_Load(object sender, EventArgs e)
        {
            CompanyProfile companyProfile = new CompanyProfile();
            companyProfile = mbmsEntities.CompanyProfiles.Where(X => X.Active == true).SingleOrDefault();
            lblCompanyName.Text = SettingController.defaultCompanyProfile.CompanyName;
            lblAddress.Text = companyProfile.AddressEng;
            lblEmail.Text = companyProfile.CompanyEmail;
            lblPhoneNumber.Text = companyProfile.PhoneNumber;
            lblWebsite.Text = companyProfile.CompanyWebsite;

            foreach (string printerName in PrinterSettings.InstalledPrinters)
            {
                cboPrinter.Items.Add(printerName);                
            }
            if (DefaultPrinter.A4Printer != null)
            {
                cboPrinter.Text = DefaultPrinter.A4Printer;
            }
            txtNoCopy.Text = SettingController.DefaultNoOfCopies.ToString();
            txtStreetLightFees.Text = SettingController.StreetLightFees.ToString();
            dtExpireDate.Value =Convert.ToDateTime( SettingController.ExpireDate);
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            Boolean hasError = false;
            tp.RemoveAll();
            tp.IsBalloon = true;
            tp.ToolTipIcon = ToolTipIcon.Error;
            tp.ToolTipTitle = "Error";
            if (txtNoCopy.Text.Trim() == string.Empty || Convert.ToInt32(txtNoCopy.Text) == 0)
            {                
                tp.SetToolTip(txtNoCopy, "Error");
                tp.Show("Please number of Copy!", txtNoCopy);
                hasError = true;
            }
            if (!hasError)
            {
                DefaultPrinter.A4Printer = cboPrinter.Text;
                SettingController.CompanyName = lblCompanyName.Text;
                SettingController.CompanyEmail = lblEmail.Text;
                SettingController.PhoneNo = lblPhoneNumber.Text;
                SettingController.CompanyWebsite = lblWebsite.Text;
                SettingController.CompanyAddress = lblAddress.Text;
                SettingController.DefaultNoOfCopies =Convert.ToInt32( txtNoCopy.Text);
                SettingController.ExpireDate = dtExpireDate.Value.ToString();
                SettingController.StreetLightFees =Convert.ToInt32( txtStreetLightFees.Text);
                mbmsEntities.SaveChanges();
                MessageBox.Show("Successfully save Setting!");
                }
        }

        private void lblstreetlightfeescustom_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
            StreetLightFeesUI slfui = new StreetLightFeesUI();
            slfui.UserID = this.UserID;
            slfui.Show();
            }
        }
}
