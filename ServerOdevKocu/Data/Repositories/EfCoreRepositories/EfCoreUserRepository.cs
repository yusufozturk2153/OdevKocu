using ServerOdevKocu.Data.Repositories.Interfaces;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreUserRepository:EfCoreGeneralRepository<AppUser,ApplicationDbContext>,IUserRepository
    {
        public EfCoreUserRepository(ApplicationDbContext context) : base(context)
        {

        }

    }
}
