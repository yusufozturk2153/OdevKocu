using ServerOdevKocu.Data.Entities;
using ServerOdevKocu.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreStudyPlanRepository : EfCoreGeneralRepository<StudyPlan, ApplicationDbContext>, IStudyPlanRepository
    {
        public EfCoreStudyPlanRepository(ApplicationDbContext context) : base(context)
        {

        }

    }

}
