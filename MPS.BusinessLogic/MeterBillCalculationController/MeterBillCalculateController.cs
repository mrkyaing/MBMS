﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Objects;

namespace MPS.BusinessLogic.MeterBillCalculationController {
    public class MeterBillCalculateController : IMeterBillCalculateServices {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void MeterBillCalculate(List<MeterBill> meterBillList) {
           foreach(MeterBill item in meterBillList) {
                mBMSEntities.MeterBills.Add(item);
                mBMSEntities.SaveChanges();
                }
            }

        public List<MeterUnitCollect> MeterUnitCollect(DateTime fromDate, DateTime toDate) {
            return mBMSEntities.MeterUnitCollects.Where(x => EntityFunctions.TruncateTime( x.FromDate) >= fromDate.Date && EntityFunctions.TruncateTime(x.ToDate) <= toDate.Date).ToList();
            }
        }
    }
