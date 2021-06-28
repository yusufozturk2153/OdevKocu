using ServerOdevKocu.Entities;
using ServerOdevKocu.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.Interfaces
{
    public interface IBookRepository:IRepository<Book>
    {

        Task<Book> GetBookWithSubjects(int bookId);
        Task<List<Book>> GetAllWithSubjects();
        Task AddBookToStudent(int bookId,int studentId);
       
    }
}
