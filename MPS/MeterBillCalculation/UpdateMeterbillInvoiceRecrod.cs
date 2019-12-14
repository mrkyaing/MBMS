using MBMS.DAL;
using MPS.BusinessLogic.MeterBillCalculationController;
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

namespace MPS.MeterBillCalculation {
    public partial class UpdateMeterbillInvoiceRecrod : Form {
        public MeterBillInvoiceVM _vm { get; set; }
        IMeterBillCalculateServices _services;
        public UpdateMeterbillInvoiceRecrod() {
            InitializeComponent();
            _services =new  MeterBillCalculateController();
            }

        private void UpdateMeterbillInvoiceRecrod_Load(object sender, EventArgs e) {
            bindUpdatedData();
            }

        private void bindUpdatedData() {
            this.txtCustomerName.Text = _vm.CustomerName;
            txtQuarterName.Text = _vm.QuarterName;
            txtTownshipName.Text = _vm.TownshipName;
            txtBillCodeNo.Text = _vm.MeterBillCode;
            txtMeterFees.Text = _vm.MeterFees.ToString();
            txtServiceFees.Text = _vm.ServicesFees==null?"0.0": _vm.ServicesFees.ToString();
            txtStreetLightFees.Text = _vm.StreetLightFees==null?"0.0": _vm.StreetLightFees.ToString();
            txtHorsePowerFees.Text = _vm.HorsePowerFees==null?"0.0":_vm.HorsePowerFees.ToString();
            txtAdditionalFees1.Text = _vm.AdditionalFees1==null?"0.0" :_vm.AdditionalFees1.ToString();
            txtAdditionalFees2.Text = _vm.AdditionalFees2==null?"0.0": _vm.AdditionalFees2.ToString();
            txtAdditionalFees3.Text = _vm.AdditionalFees3==null?"0.0": _vm.AdditionalFees3.ToString();
            txtTotalFees.Text =_vm.TotalFees.ToString();
            }

        private void txtServiceFees_TextChanged(object sender, EventArgs e) {
            ChangeTotalFeesAmount();
            }

        private void ChangeTotalFeesAmount() {
            txtTotalFees.Text =
                  (Convert.ToDecimal(txtMeterFees.Text) +
                  Convert.ToDecimal(txtServiceFees.Text) +
                  Convert.ToDecimal(txtStreetLightFees.Text) +
                  Convert.ToDecimal(txtHorsePowerFees.Text) +
                  Convert.ToDecimal(txtAdditionalFees1.Text) +
                   Convert.ToDecimal(txtAdditionalFees2.Text) +
                  Convert.ToDecimal(txtAdditionalFees3.Text)
                  ).ToString();
            }
        private void txtMeterFees_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                this.ChangeTotalFeesAmount();
            }

        private void txtStreetLightFees_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                this.ChangeTotalFeesAmount();
            }

        private void txtHorsePowerFees_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                this.ChangeTotalFeesAmount();
            }

        private void txtAdditionalFees1_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                this.ChangeTotalFeesAmount();
            }

        private void txtAdditionalFees2_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                this.ChangeTotalFeesAmount();
            }

        private void txtAdditionalFees3_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                this.ChangeTotalFeesAmount();
            }

        private void btnUpdate_Click(object sender, EventArgs e) {
            try {
                MeterBill _mb = new MeterBill();
                _mb.MeterBillID = _vm.MeterBillID;
                _mb.InvoiceDate = _vm.InvoiceDate;
                _mb.LastBillPaidDate = _vm.LastBillPaidDate;
                _mb.MeterBillCode = _vm.MeterBillCode;
                _mb.MeterFees =Convert.ToDecimal(txtMeterFees.Text);
                _mb.ServicesFees = Convert.ToDecimal(txtServiceFees.Text);
                _mb.TotalFees = Convert.ToDecimal(txtTotalFees.Text);
                _mb.StreetLightFees = Convert.ToDecimal(txtStreetLightFees.Text);
                _mb.UsageUnit = _vm.UsageUnit;
                _mb.CurrentMonthUnit = _vm.CurrentMonthUnit;
                _mb.PreviousMonthUnit = _vm.PreviousMonthUnit;
                _mb.isPaid = _vm.isPaid;
                _mb.Remark = _vm.Remark;
                _mb.RecivedAmount = _vm.RecivedAmount;
                _mb.HorsePowerFees = Convert.ToDecimal(txtHorsePowerFees.Text);
                _mb.AdditionalFees1 = Convert.ToDecimal(txtAdditionalFees1.Text);
                _mb.AdditionalFees2 = Convert.ToDecimal(txtAdditionalFees2.Text);
                _mb.AdditionalFees3 = Convert.ToDecimal(txtAdditionalFees3.Text);
                _mb.MeterUnitCollectID = _vm.MeterUnitCollectID;
                _mb.Active =true;
                _mb.CreatedDate = _vm.CreatedDate;
                _mb.CreatedUserID = _vm.CreatedUserID;
                _services.UpdateMeterBill(_mb);
                MessageBox.Show("Meter bill record is updated successfully.", "information", MessageBoxButtons.OK, MessageBoxIcon.Information);        
                }
            catch(Exception ex) {
                MessageBox.Show("Error occur" + ex.Message);
                }
            }

        private void btnPrint_Click(object sender, EventArgs e) {

            }

        private void txtServiceFees_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter)
                this.ChangeTotalFeesAmount();
            }

        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
            }
        }
    }
