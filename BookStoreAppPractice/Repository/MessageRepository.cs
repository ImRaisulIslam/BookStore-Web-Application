using BookStoreAppPractice.Models;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BookStoreAppPractice.Repository
{
    public class MessageRepository : IMessageRepository
    {
        private readonly IOptionsMonitor<BookAlertConfig> _config;

        public MessageRepository(IOptionsMonitor<BookAlertConfig> config)
        {
            _config = config;
        }

        public string getName()
        {
            return _config.CurrentValue.BookName;
        }
    }
}
