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
            this.gvmeterbillinvoice.AutoGenerateColumns = false;
            string Customerid = string.Empty;
            if (!string.IsNullOrEmpty(txtCustomerCode.Text)) {
               Customerid= mBMSEntities.Customers.Where(x => x.Active == true && x.CustomerCode == txtCustomerCode.Text).SingleOrDefault().CustomerID;
                }

            if (string.IsNullOrEmpty(txtCustomerCode.Text) && string.IsNullOrEmpty(txtCustomerName.Text) && string.IsNullOrEmpty(txtBillCodeNo.Text) && cboQuarter.SelectedIndex == 0 && cboTownship.SelectedIndex == 0) {
                this.gvmeterbillinvoice.DataSource = meterbillcalculateservice.GetmeterBillInvoices(dtpFromDate.Value, dtptoDate.Value, cboTownship.SelectedValue.ToString(), cboQuarter.SelectedValue.ToString());
                }
            else {
                this.gvmeterbillinvoice.DataSource = meterbillcalculateservice.GetmeterBillInvoices(dtpFromDate.Value, dtptoDate.Value, cboTownship.SelectedValue.ToString(), cboQuarter.SelectedValue.ToString(), Customerid, txtCustomerCode.Text);
                }           
           
            }

        private void gvmeterbillinvoice_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                //Payment function
                if (e.ColumnIndex == 20) {
                    DataGridViewRow row = gvmeterbillinvoice.Rows[e.RowIndex];
                    MeterBillInvoiceVM meterBillInvoice = (MeterBillInvoiceVM)row.DataBoundItem;//get the selected row's data 
                    MeterBillPaymentByCash paymentbycash = new MeterBillPaymentByCash();
                    paymentbycash.vm = meterBillInvoice;
                    paymentbycash.Show();
                    }//end of edit function
                }
            }
        }
    }
