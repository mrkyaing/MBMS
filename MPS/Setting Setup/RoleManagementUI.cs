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
    public partial class RoleManagementUI : Form {
        MBMSEntities mbmsEntityies = new MBMSEntities();
        public String UserID { get; set; }
        public RoleManagementUI() {
            InitializeComponent();
            }

        private void RoleManagementUI_Load(object sender, EventArgs e) {
            bindUserRole();
            }
        public void bindUserRole() {
            List<Role> roleList = new List<Role>();
            Role role = new Role();
            role.RoleID = Convert.ToString(0);
            role.RoleName = "Select";
            roleList.Add(role);
            roleList.AddRange(mbmsEntityies.Roles.Where(x => x.Active == true).ToList());
            cboUserRole.DataSource = roleList;
            cboUserRole.DisplayMember = "RoleName";
            cboUserRole.ValueMember = "RoleID";
            }
        }
    }
