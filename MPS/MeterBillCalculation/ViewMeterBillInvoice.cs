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
    public partial class ViewMeterBillInvoice : Form {
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string QuarterID { get; set; }
        public string TownshipID { get; set; }
        IMeterBillCalculateServices _services;
        public ViewMeterBillInvoice() {
            InitializeComponent();
            _services = new MeterBillCalculateController();
            }

        private void ViewMeterBillInvoice_Load(object sender, EventArgs e) {
            this.gvmeterbillinvoice.AutoGenerateColumns = false;
            dtpFromDate.Value = fromDate;
            dtptoDate.Value = toDate;
            this.gvmeterbillinvoice.DataSource = _services.GetmeterBillInvoices(fromDate, toDate, TownshipID, QuarterID);
            }

        private void gvmeterbillinvoice_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                //Edit function
                if (e.ColumnIndex ==20) {
                    DataGridViewRow row = gvmeterbillinvoice.Rows[e.RowIndex];
                    MeterBillInvoiceVM meterBillInvoice = (MeterBillInvoiceVM)row.DataBoundItem;//get the selected row's data 
                    UpdateMeterbillInvoiceRecrod meterbillinvoiceUI = new UpdateMeterbillInvoiceRecrod();
                    meterbillinvoiceUI._vm= meterBillInvoice;
                    meterbillinvoiceUI.Show();
                    }//end of edit function
                
                //print function 
                if (e.ColumnIndex ==21)//do the print Link action
                {
                    DialogResult result = MessageBox.Show(
                        "Are you sure  want to print?", "printing",
                        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                    if (result.Equals(DialogResult.OK)) {
                        DataGridViewRow row = gvmeterbillinvoice.Rows[e.RowIndex];//get the selected row's data and then 
                        MeterBillInvoiceVM meterBillInvoice = (MeterBillInvoiceVM)row.DataBoundItem;//get the selected row's data 
                        }
                    }
                }
            }

        private void btnSearch_Click(object sender, EventArgs e) {
            this.gvmeterbillinvoice.DataSource = _services.GetmeterBillInvoices(dtpFromDate.Value, dtptoDate.Value, TownshipID, QuarterID);
            }
        }
    }
