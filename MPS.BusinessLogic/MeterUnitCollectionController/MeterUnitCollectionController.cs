using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;

namespace MPS.BusinessLogic.MeterUnitCollectionController {
    public class MeterUnitCollectionController : IMeterUnitCollections {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void MeterUnitCollectionProces(MeterUnitCollect meterUnitCollect) {
            mBMSEntities.MeterUnitCollects.Add(meterUnitCollect);
            mBMSEntities.SaveChanges();
            }
        }
    }
