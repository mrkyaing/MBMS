using MBMS.DAL;
using MPS.BusinessLogic.CompanyProfileController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.CompanyProfileSetup
{
    public partial class CompanyProfilefrm : Form
    {
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbmsEntities = new MBMSEntities();
        public String UserID { get; set; }
        string companyProfileID;
        private String FilePath;
        public Boolean isEdit { get; set; }
        CompanyProfile companyProfile = new CompanyProfile();
        CompanyProfileController companyProfileController = new CompanyProfileController();
        public CompanyProfilefrm()
        {
            InitializeComponent();
        }

        private void CompanyProfilefrm_Load(object sender, EventArgs e)
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

            if (txtCompanyName.Text == string.Empty)
            {
                tooltip.SetToolTip(txtCompanyName, "Error");
                tooltip.Show("Please fill up Company Name!", txtCompanyName);
                hasError = false;
            }
            else if (txtPhoneNumber.Text == string.Empty)
            {
                tooltip.SetToolTip(txtPhoneNumber, "Error");
                tooltip.Show("Please fill up Phone Number!", txtPhoneNumber);
                hasError = false;
            }
            else if (txtAddressEng.Text == string.Empty)
            {
                tooltip.SetToolTip(txtAddressEng, "Error");
                tooltip.Show("Please fill up Address (Eng)!", txtAddressEng);
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

                    CompanyProfile updateCompanyProfile = (from cp in mbmsEntities.CompanyProfiles where cp.CompanyProfileID == companyProfileID select cp).FirstOrDefault();                   

                    updateCompanyProfile.CompanyName = txtCompanyName.Text;
                    updateCompanyProfile.PhoneNumber = txtPhoneNumber.Text;
                    updateCompanyProfile.AddressEng = txtAddressEng.Text;
                    updateCompanyProfile.AddressMM = txtAddressMM.Text;
                    updateCompanyProfile.CompanyEmail = txtCompanyEmail.Text;
                    updateCompanyProfile.CompanyWebsite = txtCompanyWebsite.Text;
                    //CompanyProfilePhoto
                    if (!(string.IsNullOrEmpty(this.txtphotoPath.Text.Trim())))
                    {
                        try
                        {
                            File.Copy(txtphotoPath.Text, Application.StartupPath + "\\Images\\" + FilePath);

                            updateCompanyProfile.LogoURL = "~\\Images\\" + FilePath;
                        }
                        catch
                        {
                            updateCompanyProfile.LogoURL = "~\\Images\\" + FilePath;
                        }
                    }
                    else
                    {
                        updateCompanyProfile.LogoURL = string.Empty;
                    }
                    updateCompanyProfile.UpdatedUserID = UserID;
                    updateCompanyProfile.UpdatedDate = DateTime.Now;
                    companyProfileController.UpdateCompanyProfile(updateCompanyProfile);
                    MessageBox.Show("Successfully updated Company Profile!", "Update");
                    Clear();
                    FormRefresh();
                }
                else
                {
                    companyProfile.CompanyProfileID = Guid.NewGuid().ToString();
                    companyProfile.CompanyName = txtCompanyName.Text;
                    companyProfile.CompanyWebsite = txtCompanyWebsite.Text;
                    companyProfile.CompanyEmail = txtCompanyEmail.Text;
                    companyProfile.PhoneNumber = txtPhoneNumber.Text;
                    companyProfile.AddressEng = txtAddressEng.Text;
                    companyProfile.AddressMM = txtAddressMM.Text;
                    //CompanyProfilePhoto
                    if (!(string.IsNullOrEmpty(this.txtphotoPath.Text.Trim())))
                    {
                        try
                        {
                            File.Copy(txtphotoPath.Text, Application.StartupPath + "\\Images\\" + FilePath);

                            companyProfile.LogoURL = "~\\Images\\" + FilePath;
                        }
                        catch
                        {
                            companyProfile.LogoURL = "~\\Images\\" + FilePath;
                        }
                    }
                    else
                    {
                        companyProfile.LogoURL = string.Empty;
                    }
                    companyProfile.Active = true;
                    companyProfile.CreatedUserID = UserID;
                    companyProfile.CreatedDate = DateTime.Now;
                    companyProfileController.Save(companyProfile);
                    MessageBox.Show("Successfully registered Company Profile! Please check it in 'Company Profile List'.", "Save Success");
                    Clear();
                    FormRefresh();
                }
            }
        }
        public void Clear()
        {
            txtphotoPath.Text = string.Empty;
            txtPhoneNumber.Text = string.Empty;
            txtCompanyName.Text = string.Empty;
            txtAddressMM.Text = string.Empty;
            txtAddressEng.Text = string.Empty;
            txtCompanyEmail.Text = string.Empty;
            txtCompanyWebsite.Text = string.Empty;
            pbCompanyPhoto.Image = null;
        }
        public void FormRefresh()
        {
            dgvCompanyList.AutoGenerateColumns = false;
            dgvCompanyList.DataSource = (from cp in mbmsEntities.CompanyProfiles where cp.Active == true orderby cp.CompanyName descending select cp).ToList();
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Title = "Open Picture";
            dlg.Filter = "JPEGs (*.jpg;*.jpeg;*.jpe) |*.jpg;*.jpeg;*.jpe |GIFs (*.gif)|*.gif|PNGs (*.png)|*.png";

            try
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    txtphotoPath.Text = dlg.FileName;
                    pbCompanyPhoto.SizeMode = PictureBoxSizeMode.StretchImage;
                    pbCompanyPhoto.ImageLocation = txtphotoPath.Text;
                    FilePath = System.IO.Path.GetFileName(dlg.FileName);

                }

            }
            catch (Exception ex)
            {
                //MessageBox.ShowMessage(Globalizer.MessageType.Warning, "You have to select Picture.\n Try again!!!");
                MessageBox.Show("You have to select Picture.\n Try again!!!");
                throw ex;
            }

        }

        private void dgvCompanyList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCompanyList.Rows)
            {
                CompanyProfile companyProfile = (CompanyProfile)row.DataBoundItem;
                row.Cells[0].Value = companyProfile.CompanyProfileID;
                row.Cells[1].Value = companyProfile.CompanyName;
                row.Cells[2].Value = companyProfile.PhoneNumber;
                row.Cells[3].Value = companyProfile.CompanyEmail;
                row.Cells[4].Value = companyProfile.CompanyWebsite;
                row.Cells[5].Value = companyProfile.AddressEng;
                row.Cells[6].Value = companyProfile.AddressMM;
                row.Cells[7].Value = companyProfile.LogoURL;
            }
        }

        private void dgvCompanyList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 9)
                {
                    //DeleteForCompany
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {

                        DataGridViewRow row = dgvCompanyList.Rows[e.RowIndex];
                        companyProfileID = Convert.ToString(row.Cells[0].Value);
                        dgvCompanyList.DataSource = "";
                        CompanyProfile companyProfile = (from cp in mbmsEntities.CompanyProfiles where cp.CompanyProfileID == companyProfileID select cp).FirstOrDefault();
                        companyProfile.Active = false;
                        companyProfile.DeletedUserID = UserID;
                        companyProfile.DeletedDate = DateTime.Now;
                        companyProfileController.DeleteCompanyProfile(companyProfile);
                        dgvCompanyList.DataSource = (from cp in mbmsEntities.CompanyProfiles where cp.Active == true orderby cp.CompanyName descending select cp).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Clear();
                        FormRefresh();

                    }

                }
                else if (e.ColumnIndex == 8)
                {
                    //EditCompany
                    DataGridViewRow row = dgvCompanyList.Rows[e.RowIndex];
                    companyProfileID = Convert.ToString(row.Cells[0].Value);
                    txtCompanyName.Text = Convert.ToString(row.Cells[1].Value);
                    txtPhoneNumber.Text = Convert.ToString(row.Cells[2].Value);
                    txtCompanyEmail.Text = Convert.ToString(row.Cells[3].Value);
                    txtCompanyWebsite.Text = Convert.ToString(row.Cells[4].Value);
                    txtAddressEng.Text = Convert.ToString(row.Cells[5].Value);
                    txtAddressMM.Text = Convert.ToString(row.Cells[6].Value);
                  

                    CompanyProfile updateCompanyProfile = (from cp in mbmsEntities.CompanyProfiles where cp.CompanyProfileID == companyProfileID select cp).FirstOrDefault();
                    if (updateCompanyProfile.LogoURL != null && updateCompanyProfile.LogoURL != "")
                    {
                        this.txtphotoPath.Text = updateCompanyProfile.LogoURL.ToString();
                        string FileNmae = txtphotoPath.Text.Substring(9);
                        this.pbCompanyPhoto.ImageLocation = Application.StartupPath + "\\Images\\" + FileNmae;
                        this.pbCompanyPhoto.SizeMode = PictureBoxSizeMode.Zoom;
                    }
                    else
                    {
                        pbCompanyPhoto.Image = null;
                    }
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
