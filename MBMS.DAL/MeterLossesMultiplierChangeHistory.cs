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
    
    public partial class MeterLossesMultiplierChangeHistory
    {
        public string MeterLossesMultiplierChangeHistoryID { get; set; }
        public string MeterID { get; set; }
        public decimal Losses { get; set; }
        public decimal Multiplier { get; set; }
        public System.DateTime UpdatedDate { get; set; }
        public string UpdatedUserID { get; set; }
        public decimal OldLosses { get; set; }
        public decimal OldMultiplier { get; set; }
    
        public virtual Meter Meter { get; set; }
    }
}
