using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.MeterBillCalculationController {
    interface IMeterBillCalculateServices {
        void MeterBillCalculate(List<MeterBill> _meterBill);
        }
    }
