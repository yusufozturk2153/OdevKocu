using ServerOdevKocu.Entities;
using ServerOdevKocu.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.Interfaces
{
    public interface IStudentRepository : IRepository<Student>
    {
        Task<List<Student>> GetAllWithBooks();
        Task<Student> GetStudentWithBooks(int studentId);
    }
}
