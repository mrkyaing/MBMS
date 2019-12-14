using MBMS.DAL;
using MPS.BusinessLogic.AdvanceMoneyCustomerController;
using MPS.BusinessLogic.MeterBillCalculationController;
using MPS.BusinessLogic.PunishmentCustomerController;
using MPS.BusinessLogic.PunishmentRuleController;
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
    public partial class MeterBillPaymentByCash : Form {
         string UserID { get; set; }
        public MeterBillInvoiceVM vm { get; set; }
        IMeterBillCalculateServices meterBillCalculateservices;
        IPunishmentRuleServices punishmentruleservices;
        IPunishmentCustomerServices punishmentCutomerServices;
        IAdvanceMoneyCustomerServices advanceMoneyCustomerServices;
        PunishmentRule pr;
        public MeterBillPaymentByCash() {
            InitializeComponent();
            meterBillCalculateservices = new MeterBillCalculateController();
            punishmentruleservices = new PunishmentRuleController();
            advanceMoneyCustomerServices = new AdvanceMoneyCustomerController();
            pr = new PunishmentRule();
            punishmentCutomerServices = new PunishmentCustomerController();
            }

        private void MeterBillPaymentByCash_Load(object sender, EventArgs e) {
            bindData();
            }
        private void bindData() {
            this.txtCustomerName.Text = vm.CustomerName;
            txtQuarterName.Text = vm.QuarterName;
            txtTownshipName.Text = vm.TownshipName;
            txtBillCodeNo.Text = vm.MeterBillCode;    
            txtTotalFees.Text = vm.TotalFees.ToString();
            pr= punishmentruleservices.getPunishment("Pr-001");
            int datediff =(vm.InvoiceDate.Date - DateTime.Now.Date).Days;
            if(datediff>=pr.FromDays && datediff <= pr.ToDays) {
                txtpunishment.Text = pr.Amount.ToString();
                }else {
                txtpunishment.Text = "0.0";
                }
            txtAdvanceMoney.Text = "0.0";
            
            }
        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
            }

        private void btnPaid_Click(object sender, EventArgs e) {
            MeterBill mb = new MeterBill();
            BindMeterBillEntity(mb);        
            if (meterBillCalculateservices.UpdateMeterBill(mb)) {
                if (Convert.ToDecimal(txtAdvanceMoney.Text)>0) {
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
            pc.PunishmentRuleID = pr.PunishmentRuleID;
            pc.PunishmentAmount = Convert.ToDecimal(txtpunishment.Text);
            }

        private void BindAdvanceMoneyCustomerEntity(AdvanceMoneyCustomer amc) {
            amc.AdvanceMoneyCustomerID = Guid.NewGuid().ToString();
            amc.MeterBillID = vm.MeterBillID;
            amc.ForMonth = vm.InvoiceDate;
            amc.Active = true;
            amc.CreatedDate = DateTime.Now;
            amc.CreatedUserID = UserID;
            }

        private void BindMeterBillEntity(MeterBill mb) {
            mb.MeterBillID = vm.MeterBillID;
            mb.InvoiceDate = vm.InvoiceDate;
            mb.LastBillPaidDate = vm.LastBillPaidDate;
            mb.MeterBillCode = vm.MeterBillCode;
            mb.MeterFees = vm.MeterFees;
            mb.ServicesFees = vm.ServicesFees;
            mb.TotalFees = vm.TotalFees;
            mb.StreetLightFees = vm.StreetLightFees;
            mb.UsageUnit = vm.UsageUnit;
            mb.CurrentMonthUnit = vm.CurrentMonthUnit;
            mb.PreviousMonthUnit = vm.PreviousMonthUnit;
            mb.isPaid = true;
            mb.AdvanceMoney = Convert.ToDecimal(txtAdvanceMoney.Text);
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
                txtChangeAmt.Text = (Convert.ToDecimal(txtReceivedAmount.Text) - Convert.ToDecimal(txtTotalFees.Text)).ToString();
                }
            }
        }
    }
