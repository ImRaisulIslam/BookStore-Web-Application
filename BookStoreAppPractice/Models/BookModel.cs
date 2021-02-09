using BookStoreAppPractice.Helpers;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Models
{
    public class BookModel
    {
        
        public int Id { get; set; }

        //[StringLength(20, MinimumLength =3, ErrorMessage ="Minimum Length = 3 maximum Length = 20")]

        //[Required (ErrorMessage ="Please Enter The Name of The Book")]
        //[MyCustomValidation(Text = "mvc")]
        public string  BookName { get; set; }

       


        public string  AuthorName { get; set; }

        
        public string BookDescription { get; set; }
        public string Catagory { get; set; }
        
        [Required(ErrorMessage = "Please Enter Total Pages")]
        public int? TotalPages { get; set; }

        [Display(Name = "Please Choose The Cover Photo ")]
 
        public IFormFile CoverPhoto { get; set; }


        [Display(Name = "Please Choose Multiple Gallery Photo ")]
       
        public IFormFileCollection GalleryImages { get; set; }

        public string CoverImageUrl { get; set; }

        public int LanguageId { get; set; }

        public string Language { get; set; }

        [Display(Name = "Upload Book In Pdf ")]
        public IFormFile BookPdf { get; set; }
        public string BookPdfUrl { get; set; }

        public List<GalleryModel> Gallery { get; set; }



    }
}
