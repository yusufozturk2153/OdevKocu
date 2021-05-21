using ServerOdevKocu.Data.Entities;
using ServerOdevKocu.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreSubjectRepository : EfCoreGeneralRepository<Subject, ApplicationDbContext>, ISubjectRepository
    {
        public EfCoreSubjectRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
