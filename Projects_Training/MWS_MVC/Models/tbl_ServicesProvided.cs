using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MWS_MVC.Models
{
    public class tbl_ServicesProvided
    {
        public int Id_Service { get; set; }
        public int Id_WorkOrder_Service { get; set; }
        public string Description_Service { get; set; }
        public string Observation_Service { get; set; }
        public decimal EstimatedCost_Service { get; set; }
        public Nullable<decimal> ExtraExpenses_Service { get; set; }
        public string ExtraExpensesDescription_Service { get; set; }
        public decimal FinalCost_Service { get; set; }

        [JsonIgnore]
        [IgnoreDataMember]
        public virtual tbl_WorkOrders tbl_WorkOrders { get; set; }
    }
}