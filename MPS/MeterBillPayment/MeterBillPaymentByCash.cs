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

namespace MPS.MeterBillPayment {
    public partial class MeterBillPaymentByCash : Form {
        public MeterBillInvoiceVM vm { get; set; }
        IMeterBillCalculateServices _services;     
        public MeterBillPaymentByCash() {
            InitializeComponent();
            _services = new MeterBillCalculateController();
            }

        private void MeterBillPaymentByCash_Load(object sender, EventArgs e) {
            bindUpdatedData();
            }
        private void bindUpdatedData() {
            this.txtCustomerName.Text = vm.CustomerName;
            txtQuarterName.Text = vm.QuarterName;
            txtTownshipName.Text = vm.TownshipName;
            txtBillCodeNo.Text = vm.MeterBillCode;    
            txtTotalFees.Text = vm.TotalFees.ToString();
            }
        private void btnClose_Click(object sender, EventArgs e) {
            this.Close();
            }

        private void btnPaid_Click(object sender, EventArgs e) {

            }
        }
    }
