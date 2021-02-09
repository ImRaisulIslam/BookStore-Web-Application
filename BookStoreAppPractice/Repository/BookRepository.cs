using BookStoreAppPractice.Data;
using BookStoreAppPractice.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Repository
{
    public class BookRepository : IBookRepository
    {

        private readonly BookStoreContext _bookStoreContext = null;
        private readonly IConfiguration _configuration;

        public BookRepository(BookStoreContext context , IConfiguration configuration)
        {
            _bookStoreContext = context;
            _configuration = configuration;
        }

        public async Task<int> AddNewBooks(BookModel model)
        {
            var NewBook = new Books()
            {
                AuthorName = model.AuthorName,
                CreateOn = DateTime.UtcNow,
                BookDescription = model.BookDescription,
                TotalPages = model.TotalPages.HasValue ? model.TotalPages.Value : 0,
                LanguageId = model.LanguageId,
                CoverPhotoUrl = model.CoverImageUrl,
                BookName = model.BookName,
                UpdateOn = DateTime.Now,
                BookPdfURL = model.BookPdfUrl

            };

            NewBook.BookGallery = new List<BookGallery>();

            foreach (var file in model.Gallery)
            {

                NewBook.BookGallery.Add(new BookGallery()
                {
                    Name = file.Name,
                    URL = file.Url
                });

            }

            await _bookStoreContext.Books.AddAsync(NewBook);
            await _bookStoreContext.SaveChangesAsync();

            return NewBook.Id;

        }



        public async Task<List<BookModel>> GetAllBooks()
        {
            return await _bookStoreContext.Books
                  .Select(book => new BookModel()
                  {
                      AuthorName = book.AuthorName,
                      Catagory = book.Catagory,
                      BookDescription = book.BookDescription,
                      Id = book.Id,
                      LanguageId = book.LanguageId,
                      Language = book.Language.Name,
                      BookName = book.BookName,
                      TotalPages = book.TotalPages,
                      CoverImageUrl = book.CoverPhotoUrl

                  }).ToListAsync();
        }


        public async Task<List<BookModel>> GetTopBookAsync(int count)
        {
            return await _bookStoreContext.Books
                  .Select(book => new BookModel()
                  {
                      AuthorName = book.AuthorName,
                      Catagory = book.Catagory,
                      BookDescription = book.BookDescription,
                      Id = book.Id,
                      LanguageId = book.LanguageId,
                      Language = book.Language.Name,
                      BookName = book.BookName,
                      TotalPages = book.TotalPages,
                      CoverImageUrl = book.CoverPhotoUrl

                  }).Take(count).ToListAsync();
        }









        public async Task<BookModel> GetBooks(int id)
        {
            return await _bookStoreContext.Books.Where(x => x.Id == id)
                 .Select(book => new BookModel()
                 {
                     AuthorName = book.AuthorName,
                     Catagory = book.Catagory,
                     Id = book.Id,
                     LanguageId = book.LanguageId,
                     Language = book.Language.Name,
                     BookName = book.BookName,
                     BookDescription = book.BookDescription,
                     TotalPages = book.TotalPages,
                     CoverImageUrl = book.CoverPhotoUrl,
                     Gallery = book.BookGallery.Select(g => new GalleryModel()
                     {
                         Id = g.Id,
                         Name = g.Name,
                         Url = g.URL



                     }).ToList(),

                     BookPdfUrl = book.BookPdfURL
                 }).FirstOrDefaultAsync();


        }
        public List<BookModel> SearchBooks(string Book, String Author)
        {
            return null;
        }


        public string AppName()
        {
            return _configuration["AppName"];
        }



    }
}
