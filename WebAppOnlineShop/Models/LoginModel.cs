using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebAppOnlineShop.Models
{
    public class LoginModel
    {
        [Key]
        [Display(Name = "Username:")]
        [Required(ErrorMessage = "you have to input your account")]
        public string UserName { set; get; }

        [Required(ErrorMessage = "you have to input your password too!")]
        [Display(Name = "Your password:")]
        public string Password { set; get; }

    }
}