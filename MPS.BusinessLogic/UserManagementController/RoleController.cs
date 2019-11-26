using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MBMS.DAL;
using System.Data.Entity.Migrations;

namespace MPS.BusinessLogic.MasterSetUpController
{
    public class RoleController : IRole
    {
        MBMSEntities mBMSEntities = new MBMSEntities();

        public void DeletedByRoleID(Role r)
        {
            Role role = mBMSEntities.Roles.Where(x => x.RoleID == r.RoleID).SingleOrDefault();
            role.Active = r.Active;
            role.DeletedDate = DateTime.Now;
            role.DeletedUserID = r.DeletedUserID;
            mBMSEntities.SaveChanges();

        }

        public void Save(Role r)
        {
            mBMSEntities.Roles.Add(r);
            mBMSEntities.SaveChanges();
        }

        public void UpdateByRoleID(Role r)
        {
            Role role = mBMSEntities.Roles.Where(x => x.RoleID == r.RoleID).SingleOrDefault();
            role.RoleName = r.RoleName;
            role.RoleLevel = r.RoleLevel;
            role.UpdatedDate = DateTime.Now;
            role.UpdatedUserID = r.UpdatedUserID;
            mBMSEntities.Roles.AddOrUpdate(role); //requires using System.Data.Entity.Migrations;
            mBMSEntities.SaveChanges();
        }
    }
}
