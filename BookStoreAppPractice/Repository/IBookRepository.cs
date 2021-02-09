using BookStoreAppPractice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Repository
{
    public interface IBookRepository
    {
        Task<int> AddNewBooks(BookModel model);
        Task<List<BookModel>> GetAllBooks();
        Task<BookModel> GetBooks(int id);
        Task<List<BookModel>> GetTopBookAsync(int count);
        List<BookModel> SearchBooks(string Book, string Author);

        string AppName();
    }
}