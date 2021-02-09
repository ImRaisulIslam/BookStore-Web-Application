using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Models
{
    public class SignInModel
    {
        [Required(ErrorMessage ="Enter Your Email")]
        [Display(Name ="Email Address")]
        public string EmailAddress { get; set; }


        [Required(ErrorMessage = "Enter Your Password")]
        [Display(Name = "Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Display(Name ="Remember me")]
        public bool RememberMe { get; set; }
    }
}
