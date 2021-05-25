using ServerOdevKocu.Entities;
using ServerOdevKocu.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreStudyPlanTaskRepository : EfCoreGeneralRepository<StudyPlanTask, ApplicationDbContext>, IStudyPlanTaskRepository
    {
        public EfCoreStudyPlanTaskRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
