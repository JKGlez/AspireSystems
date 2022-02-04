using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MWS_API_EF.Models
{
    public partial class tbl_Payments
    {
        [MetadataType(typeof(tbl_Payments.Metadata))]
        sealed class Metadata
        {

        }



    }
}