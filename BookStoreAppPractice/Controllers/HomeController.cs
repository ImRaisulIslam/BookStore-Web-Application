using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Dynamic;
using BookStoreAppPractice.Models;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using BookStoreAppPractice.Repository;

namespace BookStoreAppPractice.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly BookAlertConfig _newBookAlertConfiguration;
        private readonly BookAlertConfig _thirdPartyBooks;
        private readonly IMessageRepository _mConfiguration;

        public HomeController(IOptionsSnapshot<BookAlertConfig> newBookAlertConfiguration, IMessageRepository messageRepositoryconfig )
        {
            _newBookAlertConfiguration = newBookAlertConfiguration.Get("InternalBook");
            _thirdPartyBooks = newBookAlertConfiguration.Get("ThirdPartyBook");


            _mConfiguration = messageRepositoryconfig;
        }


        public ActionResult Index()
        {





            bool isDisplayBook = _newBookAlertConfiguration.BookAlert;


            bool isDisplayBook1 = _thirdPartyBooks.BookAlert;

            // var data = _mConfiguration.getName();

            //var booksection = _configuration.GetSection("AddNewBook");
            //var alart = booksection.GetValue<bool>("BookAlart");
            //var bookName = booksection.GetValue<string>("BookName");

            //var alart = _configuration.GetValue<bool>("test:bookAlart");
            //var bookName = _configuration.GetValue<string>("test:bookName");

            //var key1 = _configuration["INofObj:key1"];
            //var key2 = _configuration["INofObj:key2"];
            //var key3 = _configuration["INofObj:key3:key12"];

            return View();
        }

        //[Route("about/test/{id:int}")]
        public ActionResult About()
        {
            return View();
        }


       

        
      

         //[Route("abouts/test/{id:float}")]
        public ActionResult ContractUs()
        {

            return View();
        }
       // [Route("test/{a:string}")]
       //public string test(string a)
       // {
       //     return a;
       // }
    }
}
