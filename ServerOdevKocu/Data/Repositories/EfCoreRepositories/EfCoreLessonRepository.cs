using ServerOdevKocu.Data.Entities;
using ServerOdevKocu.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreLessonRepository : EfCoreGeneralRepository<Lesson, ApplicationDbContext>, ILessonRepository
    {
        public EfCoreLessonRepository(ApplicationDbContext context) : base(context)
        {

        }

    }

}
