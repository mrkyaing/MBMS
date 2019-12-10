using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MeterBillCalculationController {
  public  interface IMeterBillCalculateServices {
        List<MeterUnitCollect> MeterUnitCollect(DateTime fromDate, DateTime toDate,string TownshipID,string QuarterID);
        void MeterBillCalculate(List<MeterBill> _meterBill);
        List<Township> GetTownship();
        List<Quarter> GetQuarter();
        }
    }
