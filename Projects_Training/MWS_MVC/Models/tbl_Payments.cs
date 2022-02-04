using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MWS_MVC.Models
{
    public class tbl_Payments
    {
        public int Id_Payment { get; set; }
        public int Id_Client_Payment { get; set; }
        public int Id_WorkOrder_Payment { get; set; }
        public System.DateTime Date_Payment { get; set; }
        public decimal Amount_Payment { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual tbl_Clients tbl_Clients { get; set; }
        [JsonIgnore]
        [IgnoreDataMember]
        public virtual tbl_WorkOrders tbl_WorkOrders { get; set; }
    }
}