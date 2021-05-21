using ServerOdevKocu.Data.Entities;
using ServerOdevKocu.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreHomeworkTaskRepository 
        : EfCoreGeneralRepository<HomeworkTask, ApplicationDbContext>, IHomeworkTaskRepository
    {
        public EfCoreHomeworkTaskRepository(ApplicationDbContext context) : base(context)
        {

        }
    
    }
}
