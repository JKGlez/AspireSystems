//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MechanicalWorkshop.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class tbl_WorkOrders
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_WorkOrders()
        {
            this.tbl_Payments = new HashSet<tbl_Payments>();
            this.tbl_ServicesProvided = new HashSet<tbl_ServicesProvided>();
        }
    
        public int Id_WorkOrder { get; set; }
        public int Client_WorkOrder { get; set; }
        public int Vehicle_WorkOrder { get; set; }
        public System.DateTime StartDate_WorkOrder { get; set; }
        public Nullable<System.DateTime> FinishDate_WorkOrder { get; set; }
        public string Observation_WorkOrder { get; set; }
        public Nullable<decimal> FinalCost_WorkOrder { get; set; }
        public Nullable<int> Status_WorkOrder { get; set; }
    
        public virtual tbl_Clients tbl_Clients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_Payments> tbl_Payments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_ServicesProvided> tbl_ServicesProvided { get; set; }
        public virtual tbl_Vehicles tbl_Vehicles { get; set; }
    }
}
