using MBMS.DAL;
using MPS.BusinessLogic.CustomerController;
using MPS.SQLiteHelper;
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
    public partial class CustomerList2HHUDB : Form
    {
        MBMSEntities mbsEntities = new MBMSEntities();
        CustomerController customerController = new CustomerController();
        private List<Customer> customerList = new List<Customer>();
        private List<Pole> poleList = new List<Pole>();
        public string UserID { get; set; }
        public CustomerList2HHUDB()
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
            if (e.RowIndex >= 0) {                       
                 if (e.ColumnIndex == 11) {
                    DetailCustomerfrm detailCustomerForm = new DetailCustomerfrm();
                    detailCustomerForm.customerID = Convert.ToString(dgvCustomerList.Rows[e.RowIndex].Cells[0].Value);
                    detailCustomerForm.ShowDialog();

                    }
                }
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
            Customerfrm customerForm = new Customerfrm();
            customerForm.Show();
        }

        private void btnSave2HHUDB_Click(object sender, EventArgs e) {

            if (poleList.Count == 0) {
                MessageBox.Show("There is no Customers data to save HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
            DialogResult ok = MessageBox.Show("are you sure to save data?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok == DialogResult.Yes) {
                PoleServices sqlitepoleservices = new PoleServices();
                List<MPS.SQLiteHelper.Poles> sqlpoleList = new List<MPS.SQLiteHelper.Poles>();
                string sqlCommand = string.Format("SELECT * FROM Customers");
                var data = sqlitepoleservices.GetAll(sqlCommand);
                foreach (var v in data) {
                    foreach (Pole p in poleList) {
                        if (p.PoleNo == v.pol_id) {
                            MessageBox.Show("(" + p.PoleNo + ") Customer code already exists in HHU db file.", "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                            }
                        }
                    }
                foreach (Pole p in poleList) {
                    MPS.SQLiteHelper.Poles pole = new MPS.SQLiteHelper.Poles();
                    pole.pol_id = p.PoleNo;
                    pole.pol_gps_x = p.GPSX.ToString();
                    pole.pol_gps_y = p.GPSY.ToString();
                    pole.pol_etc1 = p.PoleNo;
                    sqlpoleList.Add(pole);
                    }
                try {
                    sqlitepoleservices.AddRange(sqlpoleList);
                    MessageBox.Show("Customers data to HHU db file is successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                catch (Exception ex) {
                    MessageBox.Show("Error occur when saving Customers to HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
}
