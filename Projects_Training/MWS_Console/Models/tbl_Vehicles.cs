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
    
    public partial class tbl_Vehicles
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Vehicles()
        {
            this.tbl_WorkOrders = new HashSet<tbl_WorkOrders>();
        }
    
        public int Id_Vehicle { get; set; }
        public string Brand_Vehicle { get; set; }
        public string Model_Vehicle { get; set; }
        public string NickName_Vehicle { get; set; }
        public Nullable<int> Owner_Vehicle { get; set; }
    
        public virtual tbl_Clients tbl_Clients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<tbl_WorkOrders> tbl_WorkOrders { get; set; }
    }
}