//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MWS_API_EF.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.Runtime.Serialization;

    public partial class tbl_ServicesProvided
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