using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using BookStoreAppPractice.Data;
using BookStoreAppPractice.Models;
using BookStoreAppPractice.Repository;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace BookStoreAppPractice.Controllers
{
    
    public class BookController : Controller
    {
        private  readonly IBookRepository _bookRepository = null;
        private readonly ILanguageRepository _languageRepository = null;
        private readonly IWebHostEnvironment _webHostEnvironment = null;
        public BookController( IBookRepository bookRepository , ILanguageRepository languageRepository
            
            
            , IWebHostEnvironment webHostEnvironment)
        {
            _bookRepository = bookRepository;
            _languageRepository = languageRepository;

            _webHostEnvironment = webHostEnvironment;

        }




        public IActionResult Index()
        {
            return View();
        }
        [Route("Book-List", Name ="BookListRoute")]
        public  async Task<ViewResult> GetAllBooks()
        {
           
           var data = await _bookRepository.GetAllBooks();
            return View(data);
        }

        [Route("Book-Detail/{id:int:min(1)}", Name="BookRoute")]
        public async Task<ViewResult> GetBooks(int id )
        {
            var data= await _bookRepository.GetBooks(id);
            return View(data);
        }

        public async Task<ViewResult>  AddBooks( bool isSuccess = false , int bookId = 0 )
        {

            var model = new BookModel()
            {
                //Language = "2"

            };



           // ViewBag.Language = new SelectList( await _languageRepository.GetAllLagnuage(), "Id", "Name");
            

           

            ViewBag.IsSuccess = isSuccess;
            ViewBag.BookId =   bookId;
            return   View(  model);
        }

        [HttpPost]
        public async  Task<IActionResult> AddBooks( BookModel bookModel )
        {


            if (ModelState.IsValid)
            {
                if (bookModel.CoverPhoto != null)
                {

                    string folder = "books/cover/";
                  bookModel.CoverImageUrl =  await UploadImage( folder, bookModel.CoverPhoto);

                }


                if (bookModel.GalleryImages != null)
                {
                    string folder = "books/gallery/";

                    bookModel.Gallery= new List<GalleryModel>();
                    foreach (var file in bookModel.GalleryImages)
                    {
                        var gallery = new GalleryModel()
                        {
                            Name = file.FileName,
                            Url = await UploadImage(folder, file)
                        };
                        bookModel.Gallery.Add(gallery);


                    }
                    
                    

                }


                if (bookModel.BookPdf != null)
                {

                    string folder = "books/bookpdf/";
                    bookModel.BookPdfUrl = await UploadImage(folder, bookModel.BookPdf);

                }


                int id = await _bookRepository.AddNewBooks(bookModel);


                if (id > 0)
                {
                    return RedirectToAction(nameof(AddBooks), new { isSuccess = true, bookId = id });
                }

            }

            ModelState.AddModelError("", "This is Custom message from Controller");


          //  ViewBag.Language = new SelectList(await _languageRepository.GetAllLagnuage(), "Id", "Name");

            // ViewBag.Language = new SelectList(GetLanguage(), "Id", "Text");



            //ViewBag.IsSuccess = false;
            //ViewBag.BookId = 0;



            return View();
        }

        private async Task<string> UploadImage(string folderPath, IFormFile file)
        {
            
            folderPath += Guid.NewGuid().ToString() + "_" + file.FileName;

            
            string serverFolder = Path.Combine(_webHostEnvironment.WebRootPath, folderPath);


            await file.CopyToAsync(new FileStream(serverFolder, FileMode.Create));

            return "/" + folderPath;
        }








        public List<BookModel> SearchBooks(string BookName , string AuthorName)
        {
            return _bookRepository.SearchBooks(BookName, AuthorName);
        }
    }
}