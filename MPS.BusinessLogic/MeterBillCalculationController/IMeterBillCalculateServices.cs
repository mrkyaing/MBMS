using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MPS.ViewModels;
namespace MPS.BusinessLogic.MeterBillCalculationController {
  public  interface IMeterBillCalculateServices {
        List<MeterUnitCollect> MeterUnitCollect(DateTime fromDate, DateTime toDate,string TownshipID,string QuarterID);
        void MeterBillCalculate(List<MeterBill> _meterBill,DateTime fromDate,DateTime toDate);
        List<Township> GetTownship();
        List<Quarter> GetQuarter();
        BillCode7Layer GetBillCode7LayerByBillCode(long billCodeNo);
        List<BillCode7LayerDetail> GetBillCode7LayerDetailByBillCode7LayerID(string BillCode7LayerID);
        List<MeterBillInvoiceVM> GetmeterBillInvoices(DateTime fromDate, DateTime toDate, string TownshipID, string QuarterID);
        }
    }
