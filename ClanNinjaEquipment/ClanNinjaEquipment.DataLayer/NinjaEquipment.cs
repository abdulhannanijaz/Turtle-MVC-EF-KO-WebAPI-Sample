//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ClanNinjaEquipment.DataLayer
{
    using System;
    using System.Collections.Generic;
    
    public partial class NinjaEquipment
    {
        public long NinjaEquipmentID { get; set; }
        public Nullable<int> EquipmentID { get; set; }
        public Nullable<long> NinjaID { get; set; }
        public string Picture { get; set; }
        public Nullable<bool> IsDeleted { get; set; }
        public Nullable<bool> IsSpecial { get; set; }
        public Nullable<long> CreatedBy { get; set; }
        public Nullable<System.DateTime> CreatedOn { get; set; }
        public Nullable<System.Guid> NinjaEquipmentGUID { get; set; }
    
        public virtual Equipment Equipment { get; set; }
        public virtual Ninja Ninja { get; set; }
    }
}
