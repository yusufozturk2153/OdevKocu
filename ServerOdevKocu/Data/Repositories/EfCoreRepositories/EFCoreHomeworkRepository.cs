using ServerOdevKocu.Data.Entities;
using ServerOdevKocu.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EFCoreHomeworkRepository : EfCoreGeneralRepository<Homework, ApplicationDbContext>, IHomeworkRepository
    {
        public EFCoreHomeworkRepository(ApplicationDbContext context) : base(context)
        {

        }
    }
    
}
