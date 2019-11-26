using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.CustomerController
{
    
    public class CustomerController : ICustomer
    {
        MBMSEntities mBMSEntities = new MBMSEntities();
        public void DeleteCustomer(Customer c)
        {
            Customer customer = mBMSEntities.Customers.Where(x => x.CustomerID == c.CustomerID).SingleOrDefault();
            customer.Active = c.Active;
            customer.DeletedDate = DateTime.Now;
            customer.DeletedUserID = c.DeletedUserID;
            mBMSEntities.SaveChanges();
        }

        public void Save(Customer c)
        {
            mBMSEntities.Customers.Add(c);
            mBMSEntities.SaveChanges();
        }

        public void UpdateCustomer(Customer c)
        {
            Customer customer = mBMSEntities.Customers.Where(x => x.CustomerID == c.CustomerID).SingleOrDefault();
            customer.CustomerCode = c.CustomerCode;
            customer.CustomerNameInEng = c.CustomerNameInEng;
            customer.CustomerNameInMM = c.CustomerNameInMM;
            customer.CustomerAddressInMM = c.CustomerAddressInMM;
            customer.CustomerAddressInEng = c.CustomerAddressInEng;
            customer.BillCode7LayerID = c.BillCode7LayerID;
            customer.LineNo = c.LineNo;
            customer.PageNo = c.PageNo;
            customer.PhoneNo = c.PhoneNo;
            customer.NRC = c.NRC;
            customer.Post = c.Post;
            customer.QuarterID = c.QuarterID;
            customer.MeterID = c.MeterID;
            customer.TownshipID = c.TownshipID;
            customer.LedgerID = c.LedgerID;            
            customer.UpdatedUserID = c.UpdatedUserID;
            customer.UpdatedDate = c.UpdatedDate;
            mBMSEntities.Customers.AddOrUpdate(customer); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
