using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MWS_MVC.Models
{
    public class tbl_Users
    {
        public int Id_User { get; set; }
        public string Name_User { get; set; }
        public string NickName_User { get; set; }
        public string Password_User { get; set; }
        public bool AdminRights_User { get; set; }
    }
}