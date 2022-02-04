using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MWS_API_EF.Models
{
    public partial class tbl_Clients
    {
        [MetadataType(typeof(tbl_Clients.Metadata))]
        sealed class Metadata
        {
            //[JsonIgnore]
            //[IgnoreDataMember]
            //public ICollection<tbl_WorkOrders> tbl_WorkOrders;

            //[JsonIgnore]
            //[IgnoreDataMember]
            //public ICollection<tbl_Payments> tbl_Payments;

            //[JsonIgnore]
            //[IgnoreDataMember]
            //public ICollection<tbl_Vehicles> tbl_Vehicles;
        }



    }
}