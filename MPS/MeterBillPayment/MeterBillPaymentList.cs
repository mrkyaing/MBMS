using MBMS.DAL;
using MPS.BusinessLogic.MeterBillCalculationController;
using MPS.MeterBillCalculation;
using MPS.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MPS.MeterBillPayment {
    public partial class MeterBillPaymentList : Form {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public String UserID { get; set; }
        IMeterBillCalculateServices meterbillcalculateservice;
        List<MeterBillInvoiceVM> data = null;
        public MeterBillPaymentList() {
            InitializeComponent();
            meterbillcalculateservice = new MeterBillCalculateController();
            }

        private void MeterBillPaymentUI_Load(object sender, EventArgs e) {
            bindTownshipData();
            bindQuarterData();
            }
        private void bindQuarterData() {
        
            cboQuarter.DisplayMember = "QuarterNameInMM";
            cboQuarter.ValueMember = "QuarterID";
            cboQuarter.DataSource = meterbillcalculateservice.GetQuarter();
            cboQuarter.Text = "Select One";
            }

        private void bindTownshipData() {
          
            cboTownship.DisplayMember = "TownshipNameInMM";
            cboTownship.ValueMember = "TownshipID";
            cboTownship.DataSource = meterbillcalculateservice.GetTownship();
            cboTownship.Text = "Select One";
            }

        private void btnSearch_Click(object sender, EventArgs e) {
            data = new List<MeterBillInvoiceVM>();
            this.gvmeterbillinvoice.DataSource=null;
            this.gvmeterbillinvoice.AutoGenerateColumns = false;
            string Customerid = string.Empty;
            string quarterid = string.Empty;
            string townshipid = string.Empty;
            if (cboQuarter.Text!= "Select One") quarterid = cboQuarter.SelectedValue.ToString();
            if (cboTownship.Text!= "Select One") townshipid = cboTownship.SelectedValue.ToString();
            if (!string.IsNullOrEmpty(txtCustomerName.Text)) {
               Customer c= mBMSEntities.Customers.Where(x => x.Active == true && x.CustomerNameInEng.Equals(txtCustomerName.Text)).SingleOrDefault();
                if (c == null) {
                    MessageBox.Show("There is no data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                    }else Customerid = c.CustomerID;
                }
        else if (!string.IsNullOrEmpty(txtCustomerCode.Text)) {
                Customer c = mBMSEntities.Customers.Where(x => x.Active == true && x.CustomerCode == txtCustomerCode.Text).SingleOrDefault();
                if (c == null) {
                    MessageBox.Show("There is no data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                    }
                else Customerid = c.CustomerID;
                }
            data = meterbillcalculateservice.GetmeterBillInvoices(dtpFromDate.Value,
                    dtptoDate.Value,
                   townshipid,
                  quarterid,
                    Customerid, 
                    txtBillCodeNo.Text);
                if (data.Count == 0) {
                    MessageBox.Show("There is no data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                    }
                this.gvmeterbillinvoice.DataSource = data;                                
            }

        private void gvmeterbillinvoice_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                //Payment function
                if (e.ColumnIndex == 20) {
                    DataGridViewRow row = gvmeterbillinvoice.Rows[e.RowIndex];
                    MeterBillInvoiceVM meterBillInvoice = (MeterBillInvoiceVM)row.DataBoundItem;//get the selected row's data 
                    MeterBillPaymentByCash paymentbycash = new MeterBillPaymentByCash();
                    paymentbycash.UserID = this.UserID;
                    paymentbycash.vm = meterBillInvoice;
                    paymentbycash.Show();
                    }//end of edit function
                }
            }

        private void btnCancel_Click(object sender, EventArgs e) {
            ClearControl();
            }

        private void ClearControl() {
            dtpFromDate.Value =dtptoDate.Value= DateTime.Now;
            cboTownship.Text =cboQuarter.Text= "Select One";
            txtBillCodeNo.Text = txtCustomerCode.Text = txtCustomerName.Text = string.Empty;
            gvmeterbillinvoice.DataSource = null;
            }
        }
    }
