using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MWS_MVC.Models
{
    public class tbl_Vehicles
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

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual tbl_Clients tbl_Clients { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual ICollection<tbl_WorkOrders> tbl_WorkOrders { get; set; }
    }
}