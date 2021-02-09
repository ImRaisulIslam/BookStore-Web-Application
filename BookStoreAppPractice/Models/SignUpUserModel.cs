using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Models
{
    public class SignUpUserModel
    {

        [Required(ErrorMessage = "Please Enter First Name")]
        public string FirstName { get; set; }
        public string LastName { get; set; }


        [Required(ErrorMessage ="Please Enter Your Email")]
        [Display(Name ="Email Address")]
        [EmailAddress(ErrorMessage ="Please Valid Email")]
        public string Email { get; set; }
        [Required(ErrorMessage = "Please Enter Your Password")]
        [Compare("ConformPassword",ErrorMessage ="Password does not match")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]

        public string Password { get; set; }


        [Required(ErrorMessage = "Please Enter COnform Password")]
        [Display(Name = "Conform Password")]
        [DataType(DataType.Password)]
        public string ConformPassword { get; set; }
    }
}
