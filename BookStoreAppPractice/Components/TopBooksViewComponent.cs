using BookStoreAppPractice.Data;
using BookStoreAppPractice.Repository;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Components
{
    public class TopBooksViewComponent : ViewComponent
    {
       
        private readonly IBookRepository _bookRepository;

        public TopBooksViewComponent( IBookRepository bookRepository)
        {
          
            _bookRepository = bookRepository;
        }

       

        public async Task<IViewComponentResult> InvokeAsync( int count)
        {
            var data = await _bookRepository.GetTopBookAsync(count);
            return View(data);
        }
    }
}
