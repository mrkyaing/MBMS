//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MPS.DAO
{
    using System;
    using System.Collections.Generic;
    
    public partial class Township
    {
        public string TownshipID { get; set; }
        public string TownshipCode { get; set; }
        public string TownshipNameInEng { get; set; }
        public string TownshipNameInMM { get; set; }
        public string Address { get; set; }
        public bool Active { get; set; }
        public string CreatedUserID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string DeletedUserID { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
    }
}
