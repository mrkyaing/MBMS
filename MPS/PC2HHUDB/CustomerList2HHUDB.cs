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
        public string UserID { get; set; }
        public CustomerList2HHUDB()
        {
            InitializeComponent();
            BuildSQLiteConnection();
            }
        private void BuildSQLiteConnection() {
            if (String.IsNullOrEmpty(Storage.ConnectionString)) {
                Storage.ConnectionString = string.Format("Data Source={0};Version=3;", System.IO.Path.GetDirectoryName(
                System.Reflection.Assembly.GetEntryAssembly().Location).Replace(@"\bin\Debug", System.Configuration.ConfigurationManager.AppSettings["DatabaseFile"]));
                }
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
            customerList = (from c in mbsEntities.Customers where c.Active == true orderby c.CustomerCode descending select c).ToList();
            dgvCustomerList.AutoGenerateColumns = false;
            dgvCustomerList.DataSource = customerList;
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

            if (this.customerList.Count == 0) {
                MessageBox.Show("There is no Customers data to save HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
                }
            DialogResult ok = MessageBox.Show("are you sure to save data?", "information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (ok == DialogResult.Yes) {
                ConsumerMasterServices sqlitecustomerservices = new ConsumerMasterServices();
                List<ConsumerMaster> sqlConsumerMasterList = new List<ConsumerMaster>();
                string sqlCommand = string.Format("SELECT * FROM ConsumerMaster");
                var data = sqlitecustomerservices.GetAll(sqlCommand);
                foreach (var v in data) {
                    foreach (Customer c in customerList) {
                        if (c.CustomerCode == v.csm_id) {
                            MessageBox.Show("(" + c.CustomerCode + ") Customer code already exists in HHU db file.", "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            return;
                            }
                        }
                    }
                foreach (Customer c in customerList) {
                    ConsumerMaster consumer = new ConsumerMaster();
                    consumer.csm_id = c.CustomerCode;
                    consumer.csm_name = c.CustomerNameInEng;
                    consumer.csm_village_code = c.Quarter.QuarterCode;
                    consumer.csm_village_name = c.Quarter.QuarterNameInEng;
                    consumer.csm_meter_id = c.Meter.MeterNo;
                    consumer.csm_address_name = c.CustomerAddressInEng;
                    Pole p = mbsEntities.Poles.Where(x => x.Transformer.QuarterID == c.QuarterID).SingleOrDefault();
                    if (p == null) {
                        MessageBox.Show("set Pole data for>" + c.CustomerCode, "information", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        return;
                        }
                    //consumer.csm_gps_h = p.GPSX.ToString();
                    //consumer.csm_gps_l = p.GPSY.ToString();
                    consumer.csm_gps_h =c.Quarter.Township.Quarters.Where(x=>x.QuarterID==c.QuarterID).Where(y=>y.p).
                    consumer.csm_gps_l = p.GPSY.ToString();
                    sqlConsumerMasterList.Add(consumer);
                    }
                try {
                    sqlitecustomerservices.AddRange(sqlConsumerMasterList);
                    MessageBox.Show("Customers data to HHU db file is successfully saved.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                catch (Exception ex) {
                    MessageBox.Show("Error occur when saving Customers to HHU db file.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }
}
