using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace TestUngDung.Areas.Admin.Data
{
    public class LoginModel
    {
        [Required]
        public string Accounts { set; get; }
        public string Password { set; get; }
        public string UserType { set; get; }
        public bool RememberMe { set; get; }
    }
}