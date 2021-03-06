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
    public partial class ViewMeterBillInvoice : Form {
        public bool isPassedByCalculateForm { get; set; }
        public string UserID { get; set; }
        MBMSEntities mbmsEntities = new MBMSEntities();
        IMeterBillCalculateServices meterbillcalculateservice;
        public DateTime fromDate { get; set; }
        public DateTime toDate { get; set; }
        public string QuarterID { get; set; }
        public string TransformerID { get; set; }
        IMeterBillCalculateServices meterBillCalculateServices;
        public ViewMeterBillInvoice() {
            InitializeComponent();
            meterBillCalculateServices = new MeterBillCalculateController();
            meterbillcalculateservice = new MeterBillCalculateController();
            }

        private void ViewMeterBillInvoice_Load(object sender, EventArgs e) {
            gvmeterbillinvoice.AutoGenerateColumns = false;
            if (isPassedByCalculateForm) {
                dtpFromDate.Value = fromDate;
                dtptoDate.Value = toDate;
                this.bindQuarterData();
                this.bindTransformerData();
                cbotransformer.SelectedValue = TransformerID;
                cboQuarter.SelectedValue = QuarterID;
                gvmeterbillinvoice.DataSource = meterBillCalculateServices.GetmeterBillInvoices(fromDate, toDate, TransformerID, QuarterID, string.Empty, string.Empty);
            }
            BidnigData();
        }

        private void gvmeterbillinvoice_CellClick(object sender, DataGridViewCellEventArgs e) {
            if (e.RowIndex >= 0) {
                //Edit function
                if (e.ColumnIndex ==20) {
                    if (!CheckingRoleManagementFeature()) {
                        MessageBox.Show("Access Deined for this function.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                        }
                    DataGridViewRow row = gvmeterbillinvoice.Rows[e.RowIndex];
                    MeterBillInvoiceVM meterBillInvoice = (MeterBillInvoiceVM)row.DataBoundItem;//get the selected row's data 
                    UpdateMeterbillInvoiceRecrod meterbillinvoiceUI = new UpdateMeterbillInvoiceRecrod();
                    meterbillinvoiceUI.vm= meterBillInvoice;
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

        private bool CheckingRoleManagementFeature() {
            bool IsAllowed=false;
            string roleID = mbmsEntities.Users.Where(x => x.Active == true && x.UserID==UserID).SingleOrDefault().RoleID;
            List<RoleManagement> rolemgtList = mbmsEntities.RoleManagements.Where(x => x.Active == true && x.RoleID == roleID).ToList();
            foreach (RoleManagement item in rolemgtList) {
                //bill payment Menu Permission 
                if (item.RoleFeatureName.Equals("BillProcessEditOrDelete") && item.IsAllowed) IsAllowed=item.IsAllowed;
                }
            return IsAllowed;
                }

        private void btnSearch_Click(object sender, EventArgs e) {
            string tid = string.Empty; string qid = string.Empty;
            if (cboQuarter.SelectedIndex > 0) {
                qid = cboQuarter.SelectedValue.ToString();
            }
            if (cbotransformer.SelectedIndex >0) {
                tid = cbotransformer.SelectedValue.ToString();
            }
            List<MeterBillInvoiceVM>   data=meterBillCalculateServices.GetmeterBillInvoices(dtpFromDate.Value, dtptoDate.Value,tid,qid, string.Empty,string.Empty);
            if (data.Count == 0) {
                MessageBox.Show("There is no data.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            gvmeterbillinvoice.DataSource = data;
            }

        private void btnCancel_Click(object sender, EventArgs e) {
            BidnigData();
            }

        private void BidnigData() {
            this.bindQuarterData();
            this.bindTransformerData();
            dtpFromDate.Value = dtptoDate.Value = DateTime.Now;
            this.gvmeterbillinvoice.DataSource = null;
        }

        private void bindQuarterData() {
            cboQuarter.DisplayMember = "QuarterNameInMM";
            cboQuarter.ValueMember = "QuarterID";
            cboQuarter.DataSource = meterbillcalculateservice.GetQuarter();
            cboQuarter.Text = "Select One";
            cboQuarter.SelectedIndex = 0;
        }

        private void bindTransformerData() {
            cbotransformer.DisplayMember = "TransformerName";
            cbotransformer.ValueMember = "TransformerID";
            cbotransformer.DataSource = meterbillcalculateservice.GetTransformer();
            cbotransformer.Text = "Select One";
            cbotransformer.SelectedIndex = 0;
            }

        private void cboQuarter_SelectedIndexChanged(object sender, EventArgs e) {
            if (cboQuarter.SelectedIndex != -1) {
                cbotransformer.DisplayMember = "TransformerName";
                cbotransformer.ValueMember = "TransformerID";
                List<Transformer> data = meterbillcalculateservice.GetTransformerByQuarterID(cboQuarter.SelectedValue.ToString());
                if (data.Count != 0)
                    cbotransformer.DataSource = data;
                else {
                    MessageBox.Show("There is no transformar data!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.bindTransformerData();
                    }
                }

            }
        }
    }
