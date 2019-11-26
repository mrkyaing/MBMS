using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MeterController
{
 public   interface IMeter
    {
        void Save(Meter m);
        void UpdateMeter(Meter m);
        void DeletedMeter(Meter m);
    }
}
