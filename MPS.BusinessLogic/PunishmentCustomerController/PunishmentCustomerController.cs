using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;

namespace MPS.BusinessLogic.PunishmentCustomerController {
    public class PunishmentCustomerController : IPunishmentCustomerServices {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public bool Save(PunishmentCustomer punishmentcustomer) {
            try {
                mBMSEntities.PunishmentCustomers.Add(punishmentcustomer);
                mBMSEntities.SaveChanges();
                }catch(Exception ex) {
                return false;
                }
            return true;
            }
        }
    }
