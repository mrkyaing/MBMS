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
            this.gvmeterbillinvoice.DataSource = _services.GetmeterBillInvoices(fromDate, toDate, TownshipID, QuarterID);
            }

        private void gvmeterbillinvoice_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                ////delete function 
                //if (e.ColumnIndex == 6)//do the delete Link action
                //{
                //    DialogResult result = MessageBox.Show(
                //        "Are you sure  want to delete?", "Delete",
                //        MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                //    if (result.Equals(DialogResult.OK)) {
                //        DataGridViewRow row = gvum.Rows[e.RowIndex];//get the selected row's data and then 
                //        UM um = (UM)row.DataBoundItem;//typeCast to UM Object 
                //        if (uMController.Delete(um)) {
                //            MessageBox.Show("Delete Success");
                //            this.BindUMList();//calling the UM data binding method to bind the record to the GridView
                //            }

                //        else
                //            MessageBox.Show("Error");
                //        }

                //    }
                //Edit function
                if (e.ColumnIndex ==20) {
                    DataGridViewRow row = gvmeterbillinvoice.Rows[e.RowIndex];
                    MeterBillInvoiceVM meterBillInvoice = (MeterBillInvoiceVM)row.DataBoundItem;//get the selected row's data 
                    UpdateMeterbillInvoiceRecrod meterbillinvoiceUI = new UpdateMeterbillInvoiceRecrod();
                    meterbillinvoiceUI._vm= meterBillInvoice;
                    meterbillinvoiceUI.Show();
                    }
                }
            }
        }
    }
