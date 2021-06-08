using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebShopDienTu.Models
{
    public class RegisterModel
    {
        [Key]
        public long ID { set; get; }

        [Display(Name = "UserName")]
        [Required(ErrorMessage = "Required UserName")]

        public string UserName { set; get; }

        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        [StringLength(20, MinimumLength = 6, ErrorMessage = "Min length of the password must be 6")]
        [Required(ErrorMessage = "Required Password")]
        public string Password { set; get; }

        [Display(Name = "Confirm Password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "Confrim Password not khop")]
        public string ConfirmPassword { set; get; }

        [Display(Name = "Name")]
        [Required(ErrorMessage = "Required Name")]
        public string Name { set; get; }

        [Display(Name = "Required Address")]
        public string Address { set; get; }

        [Required(ErrorMessage = "Required email")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { set; get; }

        [Required(ErrorMessage = "Required phone")]
        [Display(Name = "Phone")]
        public string Phone { set; get; }
    }
}