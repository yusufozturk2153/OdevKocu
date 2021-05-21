using ServerOdevKocu.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
    public interface IUserService
    {
        List<AppUser> GetUsers();
        AppUser GetUser(int userId);
        void SignIn(AppUser appUser);
        void Login(AppUser appUser);
        void Update(AppUser appUser);
    }
}
