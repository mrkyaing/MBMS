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

namespace MPS.Setting_Setup {
    public partial class RoleManagementUI : Form {
        MBMSEntities mbmsEntityies = new MBMSEntities();
        RoleController roleController = new RoleController();
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

        private void btnSave_Click(object sender, EventArgs e) {
            if (cboUserRole.SelectedIndex > 0) {
                DialogResult ok = MessageBox.Show("are you sure to save data?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (ok == DialogResult.Yes) {
                    string roleID = cboUserRole.SelectedValue.ToString();
                    //delete all of role mgt before inserting .
                    roleController.RoleManagementDeleteByRoleID(roleID);
                    //Customer function 
                    roleController.SaveRoleMgtByRoleID("Customer", "View", roleID, chkviewcustomerlist.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("Customer", "Add", roleID, chkaddcustomer.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("Customer", "Edit", roleID, chkeditdeletecustomer.Checked, UserID);
                    //Bill Unit Collect 
                    roleController.SaveRoleMgtByRoleID("BillUnitCollect", "View", roleID, chkViewBillUnit.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("BillUnitCollect", "Edit", roleID, chkcollectbillunit.Checked, UserID);
                    //Bill Process
                    roleController.SaveRoleMgtByRoleID("BillProcess", "Edit", roleID, chkbillingprocess.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("BillProcess", "View", roleID, chkviewbillinginvoice.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("BillProcess", "Edit", roleID, chkeditbillingprocessdata.Checked, UserID);
                    //
                    roleController.SaveRoleMgtByRoleID("Meter", "Edit", roleID, chkeditdeletemeter.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("Meter", "Add", roleID, chkaddmeter.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("Meter", "View", roleID, chkviewmeterlist.Checked, UserID);
                    //Bill Payment
                    roleController.SaveRoleMgtByRoleID("BillPayment", "View", roleID, chkviewbillpayment.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("BillPayment", "Edit", roleID, chkeditdeletebillpayment.Checked, UserID);
                    //ROle
                    roleController.SaveRoleMgtByRoleID("Role", "Edit", roleID, chkeditdeleterole.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("Role", "Add", roleID, chkaddrole.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("Role", "View", roleID, chkviewrole.Checked, UserID);
                    //meter box
                    roleController.SaveRoleMgtByRoleID("MeterBox", "Edit", roleID, chkeditdeletemeterbox.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("MeterBox", "Add", roleID, chkaddmeterbox.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("MeterBox", "View", roleID, chkviewmeterbox.Checked, UserID);
                    //village 
                    roleController.SaveRoleMgtByRoleID("Quarter", "Edit", roleID, chkeditdeletevillage.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("Quarter", "Add", roleID, chkaddvillage.Checked, UserID);
                    roleController.SaveRoleMgtByRoleID("Quarter", "View", roleID, chkviewvillage.Checked, UserID);
                    //Punishment
                    roleController.SaveRoleMgtByRoleID("Punishment", "Add", roleID, chkviewPunishmentRule.Checked, UserID);
                   

                    MessageBox.Show("Successfully saved ", "Infromation", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }//end of dialog yes
                }//end of index 0
            else {
                MessageBox.Show("Please select role record to save data.", "Waring", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        private void btnCancel_Click(object sender, EventArgs e) {
            chkaddcustomer.Checked = chkeditdeletecustomer.Checked = chkviewcustomerlist.Checked = false;
            }
        }
    }
