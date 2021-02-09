using BookStoreAppPractice.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Repository
{
    public interface ILanguageRepository
    {
        Task<List<LanguageModel>> GetAllLagnuage();
    }
}