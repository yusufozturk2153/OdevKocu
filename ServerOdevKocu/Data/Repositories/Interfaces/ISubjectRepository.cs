using ServerOdevKocu.Entities;
using ServerOdevKocu.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.Interfaces
{
    public interface ISubjectRepository : IRepository<Subject>
    {
        Task AddSubjectToBook(int BookId, int SubjectId);
    }
}
