using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MBMS.DAL;
using MPS.BusinessLogic.MasterSetUpController;
using MPS.User_Management;

namespace MPS
{
    public partial class Userfrm : Form
    {
        private ToolTip tooltip = new ToolTip();
        MBMSEntities mbmsEntityies = new MBMSEntities();
        public Boolean isEdit { get; set; }
        public String edituserID { get; set; }
        public String UserID { get; set; }
     
        UserController userController = new UserController();
        public Userfrm()
        {
            InitializeComponent();
        }

        private void Userfrm_Load(object sender, EventArgs e)
        {
            bindUserRole();
            if (isEdit)
            {
                User user = (from u in mbmsEntityies.Users where u.UserID == edituserID select u).FirstOrDefault();
                txtUserName.Text = user.UserName;
                txtSecurityAnswer.Text = user.SecurityAnswer;
                txtSecurityQuestion.Text = user.SecurityQuestion;
                cboUserRole.Text = user.Role.RoleName;
                txtFullName.Text = user.FullName;
                            }
        }
        public void bindUserRole()
        {
            List<Role> roleList = new List<Role>();
            Role role = new Role();
            role.RoleID =Convert.ToString( 0);
            role.RoleName = "Select";
            roleList.Add(role);
            roleList.AddRange(mbmsEntityies.Roles.Where(x => x.Active == true).ToList());
            cboUserRole.DataSource = roleList;
            cboUserRole.DisplayMember = "RoleName";
            cboUserRole.ValueMember = "RoleID";
        }
        public bool checkValidation()
        {
            bool hasError = true;

            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.ToolTipTitle = "Error";

            if (txtUserName.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtUserName, "Error");
                tooltip.Show("Please fill up User name!", txtUserName);
                txtUserName.Focus();
                hasError = false;
            }
            else if (txtFullName.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtFullName, "Error");
                tooltip.Show("Please fill up Full Name", txtFullName);
                txtFullName.Focus();
                hasError = false;
            }
            else if (txtPassword.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtPassword, "Error");
                tooltip.Show("Please fill up Password", txtPassword);
                txtPassword.Focus();
                hasError = false;
            }           
            
            else if (txtConfirmPassword.Text.Trim() == string.Empty || txtConfirmPassword.Text != txtPassword.Text)
            {
                tooltip.SetToolTip(txtConfirmPassword, "Error");
                tooltip.Show("Do not match password or fill up password", txtConfirmPassword);
                txtConfirmPassword.Focus();
                hasError = false;
            }
            else if (cboUserRole.SelectedIndex == 0)
            {
                tooltip.SetToolTip(cboUserRole, "Error");
                tooltip.Show("Please choose User role", cboUserRole);
                cboUserRole.Focus();
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
                    User updateUser = (from u in mbmsEntityies.Users where u.UserID == edituserID select u).FirstOrDefault();
                    updateUser.UserName = txtUserName.Text;
                    updateUser.SecurityQuestion = txtSecurityQuestion.Text;
                    updateUser.SecurityAnswer = txtSecurityAnswer.Text;
                    updateUser.RoleID = cboUserRole.SelectedValue.ToString();
                    updateUser.FullName = txtFullName.Text;
                    updateUser.Password = Utility.EncryptString(txtPassword.Text, "scadmin@123");
                    updateUser.UpdatedUserID = UserID;
                    updateUser.LastLoginDate = DateTime.Now;
                    updateUser.UpdatedDate = DateTime.Now;
                    userController.UpdateUserID(updateUser);
                    MessageBox.Show("Successfully updated User!", "Update");
                    Clear();
                    UserListfrm userListForm = new UserListfrm();
                    userListForm.Show();
                    this.Close();
                }
                else
                {
                    bool usercheck = mbmsEntityies.Users.Any(x => x.Active == true && x.UserName == txtUserName.Text);
                    if (usercheck) {
                        MessageBox.Show("User already exists!", "Information",MessageBoxButtons.OK,MessageBoxIcon.Warning);
                        return;
                    }
                    User user = new User();
                    user.UserID = Guid.NewGuid().ToString();
                    user.UserName = txtUserName.Text;
                    user.Password =Utility.EncryptString( txtPassword.Text,"scadmin@123");
                    user.SecurityQuestion = txtSecurityQuestion.Text;
                    user.SecurityAnswer = txtSecurityAnswer.Text;
                    user.RoleID = cboUserRole.SelectedValue.ToString();
                    user.FullName = txtFullName.Text;
                    user.Active = true;
                    user.CreatedUserID = UserID;
                    user.CreatedDate = DateTime.Now;
                    userController.Save(user);
                    MessageBox.Show("Successfully registered user! Please check it in 'User list' ", "Save Success");
                    Clear();
                }
            }
        }

        public void Clear()
        {
            txtUserName.Text = string.Empty;
            txtSecurityQuestion.Text = string.Empty;
            txtConfirmPassword.Text = string.Empty;
            txtPassword.Text = string.Empty;
            txtSecurityAnswer.Text = string.Empty;
            txtFullName.Text = string.Empty;
            cboUserRole.SelectedIndex = 0;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void Userfrm_MouseMove(object sender, MouseEventArgs e)
        {
            tooltip.Hide(txtUserName);
            tooltip.Hide(txtFullName);
            tooltip.Hide(txtPassword);
            tooltip.Hide(txtConfirmPassword);
            tooltip.Hide(cboUserRole);
        }
    }
}
