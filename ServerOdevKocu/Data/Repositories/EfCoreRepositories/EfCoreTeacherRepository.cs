using ServerOdevKocu.Entities;
using ServerOdevKocu.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreTeacherRepository : EfCoreGeneralRepository<Teacher, ApplicationDbContext>, ITeacherRepository
    {
        public EfCoreTeacherRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
