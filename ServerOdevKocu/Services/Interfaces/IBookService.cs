using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
    public interface IBookService
    {
        Task Add(BookDto bookDto);
        Task Update(Book book);
        Task Delete(Book  book);
        Task<Book> GetById(int bookId);
        Task<List<Book>> GetBooks();
        Task<List<Book>> GetBooksByPublisherId(int publisherId);
       

    }
}
