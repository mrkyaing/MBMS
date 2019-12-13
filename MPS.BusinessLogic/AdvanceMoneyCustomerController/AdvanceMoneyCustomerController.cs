using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;

namespace MPS.BusinessLogic.AdvanceMoneyCustomerController {
    public class AdvanceMoneyCustomerController : IAdvanceMoneyCustomerServices {
        MBMSEntities mBMSEntities = new MBMSEntities();

        public bool SaveAdvanceMoney(AdvanceMoneyCustomer advanceMoneyCustomer) {
            try {
                mBMSEntities.AdvanceMoneyCustomers.Add(advanceMoneyCustomer);
                mBMSEntities.SaveChanges();
                }catch(Exception ex) {
                return false;
                }
            return true;
            }
        }
    }
