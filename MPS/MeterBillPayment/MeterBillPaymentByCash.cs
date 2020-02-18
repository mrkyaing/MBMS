using MBMS.DAL;
using MPS.BusinessLogic.AdvanceMoneyCustomerController;
using MPS.BusinessLogic.MeterBillCalculationController;
using MPS.BusinessLogic.PunishmentCustomerController;
using MPS.BusinessLogic.PunishmentRuleController;
using MPS.ViewModels;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace MPS.MeterBillPayment {
    public partial class MeterBillPaymentByCash : Form {
      public string UserID { get; set; }
        public MeterBillInvoiceVM vm { get; set; }
        IMeterBillCalculateServices meterBillCalculateservices;
        IPunishmentRuleServices punishmentruleservices;
        IPunishmentCustomerServices punishmentCutomerServices;
        IAdvanceMoneyCustomerServices advanceMoneyCustomerServices;
        List<PunishmentRule> punishmentRuleList;
        public string punishmentruleID { get; set; }
        public MeterBillPaymentByCash() {
            InitializeComponent();
            meterBillCalculateservices = new MeterBillCalculateController();
            punishmentruleservices = new PunishmentRuleController();
            advanceMoneyCustomerServices = new AdvanceMoneyCustomerController();
            punishmentCutomerServices = new PunishmentCustomerController();
            punishmentRuleList = new List<PunishmentRule>();
            }

        private void MeterBillPaymentByCash_Load(object sender, EventArgs e) {
            bindData();
            }
        private void bindData() {
            txtCustomerName.Text = vm.CustomerName;
            txtQuarterName.Text = vm.QuarterName;
            txtTownshipName.Text = vm.TownshipName;
            txtBillCodeNo.Text = vm.MeterBillCode;    
            txtTotalFees.Text = vm.TotalFees.ToString();
            punishmentRuleList = punishmentruleservices.getPunishmentList();
            int datediff = 0;
            if (punishmentRuleList.Count>0) {
                datediff = (DateTime.Now.Date - vm.InvoiceDate.Date).Days / 30;
                }
            decimal totalPunishmentRuleAmount = 0;
            foreach(PunishmentRule rule in punishmentRuleList) {
                if (rule.ExceedMonth<=datediff) {
                    totalPunishmentRuleAmount += rule.Amount;
                    punishmentruleID = rule.PunishmentRuleID;
                }
            }
          
            txtpunishment.Text = totalPunishmentRuleAmount.ToString();

            txtAdvanceMoney.Text = vm.AdvanceMoney.ToString();
            txtFinalTotalFees.Text = (Convert.ToDecimal(vm.TotalFees) + Convert.ToDecimal(txtpunishment.Text)).ToString();
            }
        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
            }

        private void btnPaid_Click(object sender, EventArgs e) {
            MeterBill mb = new MeterBill();
            BindMeterBillEntity(mb);        
            if (meterBillCalculateservices.UpdateMeterBill(mb)) {
                if (rdoadvancemoney.Checked) {
                    AdvanceMoneyCustomer amc = new AdvanceMoneyCustomer();
                    BindAdvanceMoneyCustomerEntity(amc);
                    if (advanceMoneyCustomerServices.SaveAdvanceMoney(amc)) {
                        }
                    }//end of Advance Money save
                if (Convert.ToDecimal(txtpunishment.Text)>0) {
                    PunishmentCustomer pc = new PunishmentCustomer();
                    BindPunishmentCustomerEntity(pc);
                    if (punishmentCutomerServices.Save(pc)){
                        }//end of Punishment Customer function save
                    }
                MessageBox.Show("Payment is Complete Successfully", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }//end of meter bill payment paid 
            }

        private void BindPunishmentCustomerEntity(PunishmentCustomer pc) {
            pc.PunishmentCustomerID = Guid.NewGuid().ToString();
            pc.Active = true;
            pc.CreatedDate = DateTime.Now;
            pc.CreatedUserID = UserID;
            pc.MeterBillID = vm.MeterBillID;
            pc.PunishmentRuleID = punishmentruleID;
            pc.PunishmentAmount = Convert.ToDecimal(txtpunishment.Text);
            pc.ForMonth = vm.InvoiceDate;
            }

        private void BindAdvanceMoneyCustomerEntity(AdvanceMoneyCustomer amc) {
            amc.AdvanceMoneyCustomerID = Guid.NewGuid().ToString();
            amc.MeterBillID = vm.MeterBillID;
            amc.ForMonth = vm.InvoiceDate;
            amc.AdvanceMonthAmount =Convert.ToDecimal(txtChangeAmt.Text);
            amc.Active = true;
            amc.CreatedDate = DateTime.Now;
            amc.CreatedUserID = UserID;
            }

        private void BindMeterBillEntity(MeterBill mb) {
            mb.MeterBillID = vm.MeterBillID;
            mb.MeterBillCode = vm.MeterBillCode;
            mb.InvoiceDate = vm.InvoiceDate;
            mb.LastBillPaidDate = vm.LastBillPaidDate;
            mb.ServicesFees = vm.ServicesFees;        
            mb.MeterFees = vm.MeterFees;
            mb.TotalFees = Convert.ToDecimal(txtFinalTotalFees.Text); //vm.TotalFees;
            mb.StreetLightFees = vm.StreetLightFees;
            mb.UsageUnit = vm.UsageUnit;
            mb.CurrentMonthUnit = vm.CurrentMonthUnit;
            mb.PreviousMonthUnit = vm.PreviousMonthUnit;        
            mb.AdvanceMoney = Convert.ToDecimal(txtAdvanceMoney.Text);
            mb.isPaid = true;
            mb.Remark = vm.Remark;
            mb.RecivedAmount = Convert.ToDecimal(txtReceivedAmount.Text);
            mb.HorsePowerFees = vm.HorsePowerFees;
            mb.AdditionalFees1 = vm.AdditionalFees1;
            mb.AdditionalFees2 = vm.AdditionalFees2;
            mb.AdditionalFees3 = vm.AdditionalFees3;
            mb.MeterUnitCollectID = vm.MeterUnitCollectID;
            mb.Active = true;
            mb.CreatedDate = vm.CreatedDate;
            mb.CreatedUserID = vm.CreatedUserID;
            }

        private void txtReceivedAmount_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                txtChangeAmt.Text = (Convert.ToDecimal(txtReceivedAmount.Text) - Convert.ToDecimal(txtFinalTotalFees.Text)).ToString();
                }
            }
        private void OnlyAllowforNumericKey_KeyPress(object sender, KeyPressEventArgs e) {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.')) {
                e.Handled = true;
                txtChangeAmt.Text =(Convert.ToDecimal(txtReceivedAmount.Text) - Convert.ToDecimal(txtFinalTotalFees.Text)).ToString();
            }
            // only allow one decimal point
            if ((e.KeyChar == '.') && ((sender as TextBox).Text.IndexOf('.') > -1)) {
                e.Handled = true;
                }       
        }         
    }
    }
