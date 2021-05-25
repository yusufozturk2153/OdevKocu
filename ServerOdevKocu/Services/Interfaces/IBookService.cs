using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
    interface IBookService
    {
        Task<Book> GetById(int bookId);
        Task<List<Book>> GetAllBooks();
        Task<List<Book>> GetBooksByPublisherId(int publisherId);
    }
}
