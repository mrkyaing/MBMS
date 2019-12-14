﻿using MBMS.DAL;
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
        public MeterBillInvoiceVM vm { get; set; }
        IMeterBillCalculateServices mterBillCalculateServices;
        public UpdateMeterbillInvoiceRecrod() {
            InitializeComponent();
            mterBillCalculateServices =new  MeterBillCalculateController();
            }

        private void UpdateMeterbillInvoiceRecrod_Load(object sender, EventArgs e) {
            bindUpdatedData();
            }

        private void bindUpdatedData() {
            this.txtCustomerName.Text = vm.CustomerName;
            txtQuarterName.Text = vm.QuarterName;
            txtTownshipName.Text = vm.TownshipName;
            txtBillCodeNo.Text = vm.MeterBillCode;
            txtMeterFees.Text = vm.MeterFees.ToString();
            txtServiceFees.Text = vm.ServicesFees==null?"0.0": vm.ServicesFees.ToString();
            txtStreetLightFees.Text = vm.StreetLightFees==null?"0.0": vm.StreetLightFees.ToString();
            txtHorsePowerFees.Text = vm.HorsePowerFees==null?"0.0":vm.HorsePowerFees.ToString();
            txtAdditionalFees1.Text = vm.AdditionalFees1==null?"0.0" :vm.AdditionalFees1.ToString();
            txtAdditionalFees2.Text = vm.AdditionalFees2==null?"0.0": vm.AdditionalFees2.ToString();
            txtAdditionalFees3.Text = vm.AdditionalFees3==null?"0.0": vm.AdditionalFees3.ToString();
            txtTotalFees.Text =vm.TotalFees.ToString();
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
                MeterBill mb = new MeterBill();
                mb.MeterBillID = vm.MeterBillID;
                mb.MeterBillCode = vm.MeterBillCode;
                mb.InvoiceDate = vm.InvoiceDate;
                mb.LastBillPaidDate = vm.LastBillPaidDate;
                mb.ServicesFees = Convert.ToDecimal(txtServiceFees.Text);        
                mb.MeterFees =Convert.ToDecimal(txtMeterFees.Text);
                mb.StreetLightFees = Convert.ToDecimal(txtStreetLightFees.Text);      
                mb.TotalFees = Convert.ToDecimal(txtTotalFees.Text);           
                mb.UsageUnit = vm.UsageUnit;
                mb.CurrentMonthUnit = vm.CurrentMonthUnit;
                mb.PreviousMonthUnit = vm.PreviousMonthUnit;
                mb.isPaid = vm.isPaid;
                mb.Remark = vm.Remark;
                mb.RecivedAmount = vm.RecivedAmount;
                mb.HorsePowerFees = Convert.ToDecimal(txtHorsePowerFees.Text);
                mb.AdditionalFees1 = Convert.ToDecimal(txtAdditionalFees1.Text);
                mb.AdditionalFees2 = Convert.ToDecimal(txtAdditionalFees2.Text);
                mb.AdditionalFees3 = Convert.ToDecimal(txtAdditionalFees3.Text);
                mb.MeterUnitCollectID = vm.MeterUnitCollectID;
                mb.Active =true;
                mb.CreatedDate = vm.CreatedDate;
                mb.CreatedUserID = vm.CreatedUserID;
                mterBillCalculateServices.UpdateMeterBill(mb);
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
