﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Objects;
using MPS.ViewModels;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.MeterBillCalculationController {
    public class MeterBillCalculateController : IMeterBillCalculateServices {
        MBMSEntities mBMSEntities = new MBMSEntities();

        public BillCode7Layer GetBillCode7LayerByBillCode(long billCodeNo) {
            BillCode7Layer _billCode7Layer = mBMSEntities.BillCode7Layer.Where(x => x.BillCode7LayerNo == billCodeNo && x.Active==true).SingleOrDefault();
            return _billCode7Layer;
            }

        public List<BillCode7LayerDetail> GetBillCode7LayerDetailByBillCode7LayerID(string BillCode7LayerID) {
            List<BillCode7LayerDetail> _billcode7LayerDetialList = mBMSEntities.BillCode7LayerDetail.Where(x => x.BillCode7LayerID == BillCode7LayerID && x.Active==true).ToList();
            return _billcode7LayerDetialList;
            }

        public List<MeterBillInvoiceVM> GetmeterBillInvoices(DateTime fromDate, DateTime toDate, string TownshipID, string QuarterID) {
            List<MeterBillInvoiceVM> data=mBMSEntities.MeterBills.Where(x => x.InvoiceDate >= fromDate && 
            x.InvoiceDate <= toDate).Select(y=>new MeterBillInvoiceVM {
                MeterBillID=y.MeterBillID,
                CustomerName=y.MeterUnitCollect.Customer.CustomerNameInEng,
                QuarterName=y.MeterUnitCollect.Customer.Quarter.QuarterNameInEng,
                TownshipName=y.MeterUnitCollect.Customer.Township.TownshipNameInEng,
                MeterBillCode=y.MeterBillCode,
                InvoiceDate=y.InvoiceDate,
                LastBillPaidDate=y.LastBillPaidDate,
                ServicesFees=y.ServicesFees,
                MeterFees=y.MeterFees,
                StreetLightFees=y.StreetLightFees,
                TotalFees=y.TotalFees,
                UsageUnit=y.UsageUnit,
                CurrentMonthUnit=y.CurrentMonthUnit,
                PreviousMonthUnit=y.PreviousMonthUnit,
                AdvanceMoney=y.AdvanceMoney,
                CreditAmount=y.CreditAmount,
                Remark=y.Remark,
                isPaid=y.isPaid,
                RecivedAmount=y.RecivedAmount,
                HorsePowerFees=y.HorsePowerFees,
                AdditionalFees1=y.AdditionalFees1,
                AdditionalFees2=y.AdditionalFees2,
                AdditionalFees3=y.AdditionalFees3,
                MeterUnitCollectID=y.MeterUnitCollectID,
                Active=y.Active,
                CreatedUserID=y.CreatedUserID,
                CreatedDate=y.CreatedDate
                }
            ).ToList();
            return data;
            }

        public List<Quarter> GetQuarter() {
            return mBMSEntities.Quarters.Where(x => x.Active == true).ToList();
            }

        public List<Township> GetTownship() {
            return mBMSEntities.Townships.Where(x => x.Active == true).ToList();
            }

        public void MeterBillCalculate(List<MeterBill> meterBillList, DateTime fromDate, DateTime toDate) {
           foreach(MeterBill item in meterBillList) {
                mBMSEntities.MeterBill_DeleteByFromDateToDate(fromDate,toDate);
                mBMSEntities.MeterBills.Add(item);
                mBMSEntities.SaveChanges();
                }
            }

        public List<MeterUnitCollect> MeterUnitCollect(DateTime fromDate, DateTime toDate,string TownshipID,string QuarterID) {
          //  List<Transformer> transformerList = mBMSEntities.Transformers.Where(x => x.QuarterID == QuarterID).ToList();
            return mBMSEntities.MeterUnitCollects.Where(x => EntityFunctions.TruncateTime( x.FromDate) >= fromDate.Date && EntityFunctions.TruncateTime(x.ToDate) <= toDate.Date).ToList();// || x.TransformerID.Contains(x.TransformerID)
            }

        public void UpdateMeterBill(MeterBill _meterbill) {
            mBMSEntities.MeterBills.AddOrUpdate(_meterbill);
            mBMSEntities.SaveChanges();
            }
        }
    }
