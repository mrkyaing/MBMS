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

namespace MPS.User_Management
{
    
    public partial class UserListfrm : Form
    {
        public string UserID { get; set; }
        string deleteUserID;
        
        MBMSEntities mbsEntities = new MBMSEntities();
     private   List<User> userList = new List<User>();
        UserController userController = new UserController();
        public UserListfrm()
        {
            InitializeComponent();
        }
        
        private void UserListfrm_Load(object sender, EventArgs e)
        {
            FormRefresh();
            bindUserRole();
        }
        public void bindUserRole()
        {
            List<Role> roleList = new List<Role>();
            Role role = new Role();
            role.RoleID = Convert.ToString(0);
            role.RoleName = "Select";
            roleList.Add(role);
            roleList.AddRange(mbsEntities.Roles.Where(x => x.Active == true).ToList());
            cboRoleName.DataSource = roleList;
            cboRoleName.DisplayMember = "RoleName";
            cboRoleName.ValueMember = "RoleID";
        }
        public void FormRefresh()
        {
            dgvUserList.AutoGenerateColumns = false;
            dgvUserList.DataSource = (from u in mbsEntities.Users where u.Active == true orderby u.UserName descending select u).ToList();
        }
        public void loadData()
        {
            userList = (from u in mbsEntities.Users
                        where u.Active == true &&
                        (u.UserName ==txtUserName.Text  || u.Role.RoleName == cboRoleName.Text)
                        select u).ToList();
            foundDataBind();

        }
        public void foundDataBind()
        {

            dgvUserList.DataSource = "";

            if (userList.Count < 1)
            {
                MessageBox.Show("No data Found", "Cannot find");
                dgvUserList.DataSource = "";
                return;
            }
            else
            {
                dgvUserList.DataSource = userList;
            }
        }

        private void dgvUserList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvUserList.Rows)
            {
                User user = (User)row.DataBoundItem;
                row.Cells[0].Value = user.UserID;
                row.Cells[1].Value = user.UserName;
                row.Cells[2].Value = user.Role.RoleName;

            }
        }

        private void dgvUserList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 5)
                {
                    //DeleteForUser
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvUserList.Rows[e.RowIndex];
                        deleteUserID = Convert.ToString(row.Cells[0].Value);
                          dgvUserList.DataSource = "";
                            User user = (from u in mbsEntities.Users where u.UserID == deleteUserID select u).FirstOrDefault();
                            user.Active = false;
                            user.DeletedUserID = UserID;
                            user.DeletedDate = DateTime.Now;
                               userController.DeleteUserID(user);
                            dgvUserList.DataSource = (from u in mbsEntities.Users where u.Active == true orderby u.UserID descending select u).ToList();
                            MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            FormRefresh();
                        
                    }

                }
                else if (e.ColumnIndex == 4)
                {
                    //EditUser
                    Userfrm userForm = new Userfrm();
                    userForm.isEdit = true;
                    userForm.Text = "Edit User";
                    userForm.edituserID = Convert.ToString(dgvUserList.Rows[e.RowIndex].Cells[0].Value);
                    userForm.UserID = UserID;
                    userForm.ShowDialog();
                    this.Close();

                }
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            loadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtUserName.Text = string.Empty;
            cboRoleName.SelectedIndex = 0;
            FormRefresh();
        }
    }
}
