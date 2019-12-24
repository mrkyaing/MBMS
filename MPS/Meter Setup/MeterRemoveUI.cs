using MBMS.DAL;
using MPS.BusinessLogic.MeterController;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.Meter_Setup {
    public partial class MeterRemoveUI : Form {
        IMeter meterservice;
        public Meter meter { get; set; }
        MBMSEntities mbmsEntities = new MBMSEntities();
        public MeterRemoveUI() {
            InitializeComponent();
            meterservice = new MeterController();
            }

        private void MeterRemoveUI_Load(object sender, EventArgs e) {
            LoadMeterInfo();
            }

        private void LoadMeterInfo() {
            lblmeterNo.Text = meter.MeterNo;
            Customer customer = mbmsEntities.Customers.Where(x => x.MeterID == meter.MeterID).SingleOrDefault();
            lblcustomername.Text = customer.CustomerNameInEng;
            lblinstallationdate.Text = meter.InstalledDate.Value.ToShortDateString();
            }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
            }

        private void btnremove_Click(object sender, EventArgs e) {
            DialogResult confirm = MessageBox.Show("Are you sure to remove it?", "Information", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm == DialogResult.Yes) {
                try {
                    Customer customer = mbmsEntities.Customers.Where(x => x.MeterID == meter.MeterID).SingleOrDefault();
                    MeterHistory meterhistory = new MeterHistory();
                    meterhistory.MeterHistoryID = Guid.NewGuid().ToString();
                    meterhistory.OldMeterID = meter.MeterID;
                    meterhistory.CustomerID = customer.CustomerID;
                    meterhistory.Remark = txtRemark.Text;
                    meterhistory.RemovedDate = dtpremoveddate.Value;
                    meterhistory.Active = true;
                    meterhistory.CreatedDate = DateTime.Now;
                    meterhistory.CreatedUserID = meter.CreatedUserID;
                    meterservice.RemoveMeter(meterhistory);
                    meterservice.DeletedMeter(meter);
                    MessageBox.Show("Successfully removed Meter record'.", "Remove Success");
                    //EditCustomer
                    Customerfrm customerForm = new Customerfrm();
                    customerForm.isEdit = true;
                    customerForm.Text = "Edit Customer";
                    customerForm.MeterHistoryID = meterhistory.MeterHistoryID;
                    customerForm.customerID = customer.CustomerID;
                    customerForm.UserID = meter.CreatedUserID;
                    customerForm.ShowDialog();
                    }
                catch (Exception ex) {
                    MessageBox.Show("Error Occur");
                    }
                }
            }
        }
    }
