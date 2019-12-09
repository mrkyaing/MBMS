using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;

namespace MPS.BusinessLogic.MeterBillCalculationController {
    public class MeterBillCalculateController : IMeterBillCalculateServices {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void MeterBillCalculate(List<MeterBill> meterBillList) {
           foreach(MeterBill item in meterBillList) {
                mBMSEntities.MeterBills.Add(item);
                mBMSEntities.SaveChanges();
                }
            }
        }
    }
