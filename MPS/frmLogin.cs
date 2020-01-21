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

namespace MPS
{
    public partial class frmLogin : Form
    {
        MBMSEntities mbsEntities = new MBMSEntities();
         ToolTip tooltip = new ToolTip();
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Boolean hasError = false;
            tooltip.RemoveAll();
            tooltip.IsBalloon = true;
            tooltip.ToolTipIcon = ToolTipIcon.Error;
            tooltip.ToolTipTitle = "Error";
            //Validation
            if (txtUserName.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtUserName, "Error");
                tooltip.Show("Please fill up User name!", txtUserName);
                hasError = true;
            }else if(txtPassword.Text.Trim() == string.Empty)
            {
                tooltip.SetToolTip(txtPassword, "Error");
                tooltip.Show("Please fill up Password!", txtPassword);
                hasError = true;

            }
            if (!hasError) {
                User user = new User();
                user = (from u in mbsEntities.Users where u.UserName == txtUserName.Text  && u.Active == true select u).FirstOrDefault<User>();
                if (user != null && Utility.DecryptString(user.Password, "scadmin@123") ==txtPassword.Text){
                   
                    string UserID = user.UserID;
                    string UserName = user.UserName;
                    this.Hide();     
                    MainMDI mainForm = new MainMDI();
                    mainForm.UserID = UserID;
                    mainForm.UserName = UserName;
                    mainForm.Show();
                }
                else
                {
                    MessageBox.Show(this, "Incorrect Username and Password! Please try again", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
            txtPassword.Text = string.Empty;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void txtUserName_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }

        private void txtPassword_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin_Click(this, new EventArgs());
            }
        }
    }
}
