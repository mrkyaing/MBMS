//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MBMS.DAL
{
    using System;
    using System.Collections.Generic;
    
    public partial class UserInRole
    {
        public string UserInRoleID { get; set; }
        public string RoleID { get; set; }
        public string UserID { get; set; }
        public bool Active { get; set; }
        public string CreatedUserID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string DeletedUserID { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    
        public virtual Role Role { get; set; }
        public virtual User User { get; set; }
    }
}
