using ServerOdevKocu.Entities;
using ServerOdevKocu.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreStudentRepository : EfCoreGeneralRepository<Student, ApplicationDbContext>, IStudentRepository
    {
        public EfCoreStudentRepository(ApplicationDbContext context):base(context)
        {

        }
    }
}
