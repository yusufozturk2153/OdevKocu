using ServerOdevKocu.Entities;
using ServerOdevKocu.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreBookRepository:EfCoreGeneralRepository<Book, ApplicationDbContext>,IBookRepository
    {
        public EfCoreBookRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
}
