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
    using System.Data.Entity;
    using System.Data.Entity.Infrastructure;
    
    public partial class Mechanical_WorkshopEntities1 : DbContext
    {
        public Mechanical_WorkshopEntities1()
            : base("name=Mechanical_WorkshopEntities1")
        {
        }
    
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            throw new UnintentionalCodeFirstException();
        }
    
        public virtual DbSet<tbl_Clients> tbl_Clients { get; set; }
        public virtual DbSet<tbl_Payments> tbl_Payments { get; set; }
        public virtual DbSet<tbl_ServicesProvided> tbl_ServicesProvided { get; set; }
        public virtual DbSet<tbl_Vehicles> tbl_Vehicles { get; set; }
        public virtual DbSet<tbl_WorkOrders> tbl_WorkOrders { get; set; }
    }
}
