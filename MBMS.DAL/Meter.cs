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
    
    public partial class Meter
    {
        public Meter()
        {
            this.Customers = new HashSet<Customer>();
            this.MeterLossesMultiplierChangeHistories = new HashSet<MeterLossesMultiplierChangeHistory>();
            this.MeterUnitCollects = new HashSet<MeterUnitCollect>();
        }
    
        public string MeterID { get; set; }
        public string MeterNo { get; set; }
        public string MeterTypeID { get; set; }
        public string Model { get; set; }
        public Nullable<System.DateTime> InstalledDate { get; set; }
        public int Losses { get; set; }
        public Nullable<int> Multiplier { get; set; }
        public Nullable<int> HP { get; set; }
        public Nullable<int> Voltage { get; set; }
        public string AMP { get; set; }
        public Nullable<int> Standard { get; set; }
        public Nullable<int> iMax { get; set; }
        public Nullable<int> KVA { get; set; }
        public string ManufactureBy { get; set; }
        public Nullable<int> Frequency { get; set; }
        public string Status { get; set; }
        public string MeterBoxID { get; set; }
        public string MeterBoxSequence { get; set; }
        public bool Active { get; set; }
        public string CreatedUserID { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public string UpdatedUserID { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public string DeletedUserID { get; set; }
        public Nullable<System.DateTime> DeletedDate { get; set; }
        public string Phrase { get; set; }
        public string Wire { get; set; }
        public string BasicCurrent { get; set; }
        public string Constant { get; set; }
        public string Class { get; set; }
        public Nullable<int> AvailableYear { get; set; }
    
        public virtual ICollection<Customer> Customers { get; set; }
        public virtual MeterBox MeterBox { get; set; }
        public virtual MeterType MeterType { get; set; }
        public virtual ICollection<MeterLossesMultiplierChangeHistory> MeterLossesMultiplierChangeHistories { get; set; }
        public virtual ICollection<MeterUnitCollect> MeterUnitCollects { get; set; }
    }
}
