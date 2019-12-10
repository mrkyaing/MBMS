using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.MeterController
{
    public class MeterController : IMeter
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void DeletedMeter(Meter m)
        {
            Meter meter = mBMSEntities.Meters.Where(x => x.MeterID == m.MeterID).SingleOrDefault();
            meter.Active = m.Active;
            meter.DeletedDate = DateTime.Now;
            meter.DeletedUserID = m.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(Meter m)
        {
            mBMSEntities.Meters.Add(m);
            mBMSEntities.SaveChanges();
        }

        public void UpdateMeter(Meter m)
        {
            Meter meter = mBMSEntities.Meters.Where(x => x.MeterID == m.MeterID).SingleOrDefault();
            meter.MeterNo = m.MeterNo;
            meter.MeterTypeID = m.MeterTypeID;
            meter.Model = m.Model;
            meter.InstalledDate = m.InstalledDate;
            meter.Losses = m.Losses;
            meter.Multiplier = m.Multiplier;
            meter.HP = m.HP;
            meter.iMax = m.iMax;
            meter.BasicCurrent = m.BasicCurrent;
            meter.AvailableYear = m.AvailableYear;
            meter.Class = m.Class;
            meter.Constant = m.Constant;
            meter.Phrase = m.Phrase;
            meter.Wire = m.Wire;
            meter.Voltage = m.Voltage;
            meter.AMP = m.AMP;
            meter.Standard = m.Standard;
            meter.Status = m.Status;
            meter.KVA = m.KVA;
            meter.ManufactureBy = m.ManufactureBy;
            meter.Frequency = m.Frequency;
            meter.MeterBoxID = m.MeterBoxID;
            meter.MeterBoxSequence = m.MeterBoxSequence;
            meter.UpdatedUserID = m.UpdatedUserID;
            meter.UpdatedDate = m.UpdatedDate;
            mBMSEntities.Meters.AddOrUpdate(meter); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
