using MBMS.DAL;
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
            List<MBMS.DAL.MeterUnitCollect> dataList = getMeterUnitCollect(dtpfromDate.Value, dtpToDate.Value,this.cboTownship.SelectedValue.ToString(), cboQuarter.SelectedValue.ToString());
            if (dataList.Count == 0) {
                MessageBox.Show("There is no meter unit collection record!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
                }
            if (IsBillCalculateSuccess(dataList, dtpfromDate.Value, dtpToDate.Value)) {
                MessageBox.Show("Meter bill process is complete successfully!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }

        private bool IsBillCalculateSuccess(List<MBMS.DAL.MeterUnitCollect> dataList, DateTime fromDate,DateTime toDate) {
            List<MeterBill> meterbillList = new List<MeterBill>();
            Random random = new Random();
            try {
                foreach(MBMS.DAL.MeterUnitCollect item in dataList) {                 
                    MeterBill mb = new MeterBill();
                    mb.MeterBillID = Guid.NewGuid().ToString();
                    mb.MeterBillCode = random.Next().ToString();
                    mb.InvoiceDate = DateTime.Now;
                    mb.LastBillPaidDate = DateTime.Now;
                    mb.ServicesFees = 0;
                    mb.MeterFees =getMeterFeesAmountwith7LayerCode(item) ;
                    mb.StreetLightFees = 0;
                    mb.HorsePowerFees = 0;
                    mb.TotalFees =Convert.ToDecimal( (mb.ServicesFees+ mb.MeterFees+ mb.StreetLightFees + mb.HorsePowerFees));
                    mb.UsageUnit = item.TotalMeterUnit;
                    mb.PreviousMonthUnit = 0;
                    mb.CurrentMonthUnit = (item.TotalMeterUnit - mb.PreviousMonthUnit);
                    mb.AdvanceMoney = 0;
                    mb.CreditAmount = 0;
                    mb.isPaid = false;
                    mb.Remark = "bill data for " + item.FromDate.ToString("MMMM");           
                    mb.MeterUnitCollectID = item.MeterUnitCollectID;
                    mb.Active = true;
                    mb.CreatedDate = DateTime.Now;
                    mb.CreatedUserID = UserID;
                    meterbillList.Add(mb);
                    }//end of foreach loop after adding Meter Bill List 
                meterbillcalculateservice.MeterBillCalculate(meterbillList,fromDate,toDate);
                }catch(Exception ex) {
                MessageBox.Show("Error occur"+ex.Message, "Information", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
                }
            return true;
            }

        private decimal getMeterFeesAmountwith7LayerCode(MBMS.DAL.MeterUnitCollect meterUnitCollect) {
            decimal result = 0;
            decimal sumUnits = 0;
            BillCode7Layer billCode7Layer = meterbillcalculateservice.GetBillCode7LayerByBillCode(Convert.ToInt64(meterUnitCollect.BillCode));
            List<BillCode7LayerDetail> billCode7LayerDetailList = meterbillcalculateservice.GetBillCode7LayerDetailByBillCode7LayerID(billCode7Layer.BillCode7LayerID).OrderBy(y=>y.LowerLimit).ToList();
            foreach(BillCode7LayerDetail item in billCode7LayerDetailList) {
                if (meterUnitCollect.TotalMeterUnit > (sumUnits+item.RateUnit)) {
                    result +=(decimal)(item.RateUnit * item.AmountPerUnit);
                    sumUnits += (decimal)item.RateUnit;
                    }
                else {
                    decimal diffUnits = meterUnitCollect.TotalMeterUnit - sumUnits;
                    result += (decimal)diffUnits * item.AmountPerUnit;
                    if((diffUnits+sumUnits)== meterUnitCollect.TotalMeterUnit) {
                        return result;
                        }
                    }
                }
            return result;
            }

        private List<MBMS.DAL.MeterUnitCollect> getMeterUnitCollect(DateTime fromdate, DateTime todate,string townshipID,string QuaeterID) {
            return meterbillcalculateservice.MeterUnitCollect(fromdate,todate,townshipID,QuaeterID);
            }

        private void MeterBillCalculate_Load(object sender, EventArgs e) {
            bindTownshipData();
            bindQuarterData();
            }

        private void bindQuarterData() {
            cboQuarter.DisplayMember = "QuarterNameInMM";
            cboQuarter.ValueMember = "QuarterID";
            cboQuarter.DataSource = meterbillcalculateservice.GetQuarter();
            cboQuarter.Text = "Select One";
            }

        private void bindTownshipData() {
            cboTownship.DisplayMember = "TownshipNameInMM";
            cboTownship.ValueMember = "TownshipID";
            cboTownship.DataSource = meterbillcalculateservice.GetTownship();
            cboTownship.Text = "Select One";
            }
        }
    }
