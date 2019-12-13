using MBMS.DAL;
using MPS.BusinessLogic.MeterBillCalculationController;
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
        public MeterBillInvoiceVM vm { get; set; }
        IMeterBillCalculateServices _services;
        IPunishmentRuleServices punishmentruleservices;
        public MeterBillPaymentByCash() {
            InitializeComponent();
            _services = new MeterBillCalculateController();
            punishmentruleservices = new PunishmentRuleController();
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
            PunishmentRule pr = punishmentruleservices.getPunishment("Pr-001");
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

            }

        private void txtReceivedAmount_KeyDown(object sender, KeyEventArgs e) {
            if (e.KeyCode == Keys.Enter) {
                txtChangeAmt.Text = (Convert.ToDecimal(txtReceivedAmount.Text) - Convert.ToDecimal(txtTotalFees.Text)).ToString();
                }
            }
        }
    }
