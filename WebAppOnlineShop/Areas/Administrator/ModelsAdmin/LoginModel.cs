using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppOnlineShop.Areas.Administrator.ModelsAdmin
{
    public class LoginModel
    {
        [Required(ErrorMessage = "Mời nhập user name")]
        public string Username { set; get; }

        [Required(ErrorMessage = "Mời nhập password")]
        public string Password { set; get; }

        public bool RememberMe { set; get; }
    }
}