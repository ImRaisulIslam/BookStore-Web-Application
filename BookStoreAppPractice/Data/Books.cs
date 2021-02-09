using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Data
{
    public class Books
    {
        public int Id { get; set; }
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string BookDescription { get; set; }
        public string Catagory { get; set; }
        public int TotalPages { get; set; }

        public int LanguageId { get; set; }

        public string CoverPhotoUrl { get; set; }
        public DateTime? CreateOn { get; set; }
        public DateTime? UpdateOn { get; set; }

        public Language Language { get; set; }
        public string BookPdfURL { get; set; }

        public ICollection<BookGallery> BookGallery { get; set; }
    }
}
