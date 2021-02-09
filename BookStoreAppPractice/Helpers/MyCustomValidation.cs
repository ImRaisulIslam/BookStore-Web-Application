using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Helpers
{
    public class MyCustomValidation : ValidationAttribute
    {

       

       
        public string Text { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {

            if (value != null)
            {
                string BookName = value.ToString();
                

                if (BookName.Contains(Text))
                {
                    return ValidationResult.Success;
                }

                return new ValidationResult("use University email");

                


            }


            

            return new ValidationResult( ErrorMessage ?? "Field Empty");





        }
    }
}
