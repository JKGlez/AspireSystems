using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MWS_MVC.Models
{
    public class tbl_Clients
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public tbl_Clients()
        {
            this.tbl_Payments = new HashSet<tbl_Payments>();
            this.tbl_Vehicles = new HashSet<tbl_Vehicles>();
            this.tbl_WorkOrders = new HashSet<tbl_WorkOrders>();
        }

        public int Id_Client { get; set; }
        public string Name_Client { get; set; }
        public string NickName_Client { get; set; }
        public Nullable<System.DateTime> Pay_Day_Client { get; set; }
        public string Mobile_Phone_Client { get; set; }
        public string Email_Client { get; set; }
        public string Billing_Data_Client { get; set; }


        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<tbl_Payments> tbl_Payments { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<tbl_Vehicles> tbl_Vehicles { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<tbl_WorkOrders> tbl_WorkOrders { get; set; }
    }
}