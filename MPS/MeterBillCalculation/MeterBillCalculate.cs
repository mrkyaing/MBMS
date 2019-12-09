﻿using MBMS.DAL;
using MPS.BusinessLogic.MeterBillCalculationController;
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
    public partial class MeterBillCalculate : Form {
        public String UserID { get; set; }
        IMeterBillCalculateServices meterbillcalculateservice;
        public MeterBillCalculate() {
            InitializeComponent();
            meterbillcalculateservice = new MeterBillCalculateController();
            }

        private void btnbillprocess_Click(object sender, EventArgs e) {
            List<MBMS.DAL.MeterUnitCollect> dataList = getMeterUnitCollect(dtpfromDate.Value, dtpToDate.Value);
            if (dataList.Count == 0) {
                MessageBox.Show("There is no meter unit collection record!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (IsBillCalculateSuccess(dataList)) {
                MessageBox.Show("Meter bill process is complete successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        private bool IsBillCalculateSuccess(List<MBMS.DAL.MeterUnitCollect> dataList) {
            List<MeterBill> meterbillList = new List<MeterBill>();
            Random random = new Random();
            try {
                foreach(MBMS.DAL.MeterUnitCollect item in dataList) {
                  
                    MeterBill mb = new MeterBill();
                    mb.MeterBillID = Guid.NewGuid().ToString();
                    mb.MeterBillCode = random.Next().ToString();
                    mb.InvoiceDate = DateTime.Now;
                    mb.LastBillPaidDate = DateTime.Now;
                    mb.ServicesFees = 5000;
                    mb.MeterFees =getMeterFeesAmountwith7LayerCode(item) ;
                    mb.StreetLightFees = 750;
                    mb.HorsePowerFees = 10000;
                    mb.TotalFees =Convert.ToDecimal( (mb.ServicesFees+ mb.MeterFees+ mb.StreetLightFees + mb.HorsePowerFees));
                    mb.UsageUnit = item.TotalMeterUnit;
                    mb.PreviousMonthUnit = 0;
                    mb.CurrentMonthUnit = (item.TotalMeterUnit - mb.PreviousMonthUnit);
                    mb.AdvanceMoney = 0;
                    mb.CreditAmount = 0;
                    mb.isPaid = false;
                    mb.Remark = "bill data for " + item.FromDate.ToString("MM");           
                    mb.MeterUnitCollectID = item.MeterUnitCollectID;
                    mb.Active = true;
                    mb.CreatedDate = DateTime.Now;
                    mb.CreatedUserID = UserID;
                    meterbillList.Add(mb);
                    }//end of foreach loop after adding Meter Bill List 
                meterbillcalculateservice.MeterBillCalculate(meterbillList);
                }catch(Exception ex) {
                MessageBox.Show("Error occur"+ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                }
            return true;
            }

        private decimal getMeterFeesAmountwith7LayerCode(MBMS.DAL.MeterUnitCollect item) {
            decimal result = 0;

            return result;
            }

        private List<MBMS.DAL.MeterUnitCollect> getMeterUnitCollect(DateTime fromdate, DateTime todate) {
            return meterbillcalculateservice.MeterUnitCollect(fromdate,todate);
            }
        }
    }
