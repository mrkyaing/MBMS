using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.AdvanceMoneyCustomerController {
   public interface IAdvanceMoneyCustomerServices {
        bool SaveAdvanceMoney(AdvanceMoneyCustomer advanceMoneyCustomer);
        }
    }
