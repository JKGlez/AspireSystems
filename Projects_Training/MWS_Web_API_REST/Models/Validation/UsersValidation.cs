﻿using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;
using System.Web;

namespace MWS_API_EF.Models
{
    public partial class tbl_Users
    {
        [MetadataType(typeof(tbl_Users.Metadata))]
        sealed class Metadata
        {

        }



    }
}