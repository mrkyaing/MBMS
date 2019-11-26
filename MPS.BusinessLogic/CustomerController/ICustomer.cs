using MBMS.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MPS.BusinessLogic.CustomerController
{
 public   interface ICustomer
    {
        void Save(Customer c);
        void UpdateCustomer(Customer c);
        void DeleteCustomer(Customer c);
    }
}
