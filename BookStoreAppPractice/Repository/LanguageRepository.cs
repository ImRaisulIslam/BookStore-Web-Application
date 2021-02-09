using BookStoreAppPractice.Data;
using BookStoreAppPractice.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Repository
{
    public class LanguageRepository : ILanguageRepository
    {
        private readonly BookStoreContext _bookStoreContext = null;

        public LanguageRepository(BookStoreContext context)
        {
            _bookStoreContext = context;
        }

        public async Task<List<LanguageModel>> GetAllLagnuage()
        {
            return await _bookStoreContext.Language.Select(x => new LanguageModel()
            {
                Id = x.Id,
                Name = x.Name,
                Description = x.Description,



            }).ToListAsync();
        }
    }
}
