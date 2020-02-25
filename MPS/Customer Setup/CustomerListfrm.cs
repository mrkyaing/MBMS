using MBMS.DAL;
using MPS.BusinessLogic.CustomerController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Customer_Setup
{
    public partial class CustomerListfrm : Form
    {
        MBMSEntities mbsEntities = new MBMSEntities();
        CustomerController customerController = new CustomerController();
        private List<Customer> customerList = new List<Customer>();
        string customerID;
        public string UserID { get; set; }
        public CustomerListfrm()
        {
            InitializeComponent();
        }

        private void dgvCustomerList_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in dgvCustomerList.Rows)
            {
                 Customer customer = (Customer)row.DataBoundItem;
                row.Cells[0].Value = customer.CustomerID;
                row.Cells[1].Value = customer.CustomerCode;
                row.Cells[2].Value = customer.CustomerNameInEng;
                row.Cells[3].Value = customer.CustomerNameInMM;
                row.Cells[4].Value = customer.NRC;
                row.Cells[5].Value = customer.PhoneNo;
                row.Cells[6].Value = customer.Township.TownshipNameInEng;
                row.Cells[7].Value = customer.Quarter.QuarterNameInEng;
                row.Cells[8].Value = customer.Meter.MeterNo;
                row.Cells[9].Value = customer.Ledger.BookCode;
                row.Cells[10].Value = customer.BillCode7Layer.BillCode7LayerNo;
                row.Cells[14].Value = customer.SMDNo;
                }
        }
        public void FormRefresh()
        {
            dgvCustomerList.AutoGenerateColumns = false;
            dgvCustomerList.DataSource = (from c in mbsEntities.Customers where c.Active == true orderby c.CustomerCode descending select c).ToList();
        }

        private void CustomerListfrm_Load(object sender, EventArgs e)
        {
            FormRefresh();
            bindTownship();
        }
        
        public void bindTownship()
        {
            List<Township> townshipList = new List<Township>();
            Township township = new Township();
            township.TownshipID = Convert.ToString(0);
            township.TownshipNameInEng = "Select";
            townshipList.Add(township);
            townshipList.AddRange(mbsEntities.Townships.Where(x => x.Active == true).ToList());
            cboTownshipName.DataSource = townshipList;
            cboTownshipName.DisplayMember = "TownshipNameInEng";
            cboTownshipName.ValueMember = "TownshipID";
        }
        public void LoadData()
        {
            customerList = (from c in mbsEntities.Customers
                         where c.Active == true &&
                         c.CustomerCode == txtCustomerCode.Text || c.CustomerNameInEng == txtCustomerName.Text
                         ||  c.Township.TownshipNameInEng == cboTownshipName.Text
                         select c).ToList();
            foundDataBind();
        }
        public void foundDataBind()
        {
            dgvCustomerList.DataSource = "";

            if (customerList.Count < 1)
            {
                MessageBox.Show("No data Found", "Cannot find");
                dgvCustomerList.DataSource = "";
                return;
            }
            else
            {
                dgvCustomerList.DataSource = customerList;
            }
        }

        private void dgvCustomerList_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (e.ColumnIndex == 13)
                {
                    //DeleteForCustomer
                    if (!CheckingRoleManagementFeature("CustomerEditOrDelete")) {
                        MessageBox.Show("Access Denied for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        }
                    DialogResult result = MessageBox.Show(this, "Are you sure you want to delete?", "Delete", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK))
                    {
                        DataGridViewRow row = dgvCustomerList.Rows[e.RowIndex];
                        customerID = Convert.ToString(row.Cells[0].Value);

                        dgvCustomerList.DataSource = "";
                        Customer customer = (from c in mbsEntities.Customers where c.CustomerID == customerID select c).FirstOrDefault();
                        customer.Active = false;
                        customer.DeletedUserID = UserID;
                        customer.DeletedDate = DateTime.Now;
                        customerController.DeleteCustomer(customer);
                        dgvCustomerList.DataSource = (from c in mbsEntities.Customers where c.Active == true orderby c.CustomerCode descending select c).ToList();
                        MessageBox.Show(this, "Successfully Deleted!", "Delete Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        FormRefresh();

                    }

                }
                else if (e.ColumnIndex == 11)
                {
                    if (!CheckingRoleManagementFeature("CustomerView")) {
                        MessageBox.Show("Access Denied for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        }
                    DetailCustomerfrm  detailCustomerForm = new DetailCustomerfrm();
                    detailCustomerForm.customerID = Convert.ToString(dgvCustomerList.Rows[e.RowIndex].Cells[0].Value);
                    detailCustomerForm.ShowDialog();

                }
                else if (e.ColumnIndex == 12)
                {
                    //EditCustomer
                    if (!CheckingRoleManagementFeature("CustomerEditOrDelete")) {
                        MessageBox.Show("Access Denied for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        }
                    Customerfrm customerForm = new Customerfrm();
                    customerForm.isEdit = true;
                    customerForm.Text = "Edit Customer";
                    customerForm.customerID = Convert.ToString(dgvCustomerList.Rows[e.RowIndex].Cells[0].Value);
                    customerForm.UserID = UserID;
                    customerForm.ShowDialog();
                    this.Close();

                }
            }
        }
        private bool CheckingRoleManagementFeature(string ProgramName) {
            bool IsAllowed = false;
            string roleID = mbsEntities.Users.Where(x => x.Active == true && x.UserID == UserID).SingleOrDefault().RoleID;
            List<RoleManagement> rolemgtList = mbsEntities.RoleManagements.Where(x => x.Active == true && x.RoleID == roleID).ToList();
            foreach (RoleManagement item in rolemgtList) {
                //bill payment Menu Permission CustomerView
                if (item.RoleFeatureName.Equals(ProgramName) && item.IsAllowed) IsAllowed = item.IsAllowed;
                }
            return IsAllowed;
            }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadData();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtCustomerCode.Text = string.Empty;
            txtCustomerName.Text = string.Empty;
            cboTownshipName.SelectedIndex = 0;
            FormRefresh();
        }

        private void btnAddNewCustomer_Click(object sender, EventArgs e)
        {
            if (!CheckingRoleManagementFeature("CustomerAdd")) {
                MessageBox.Show("Access Denied for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            Customerfrm customerForm = new Customerfrm();
            customerForm.Show();
        }

        private void txtCustomerCode_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.btnSearch_Click(sender, e);
            }
        }

        private void txtCustomerName_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                this.btnSearch_Click(sender, e);
            }
        }
    }
}
