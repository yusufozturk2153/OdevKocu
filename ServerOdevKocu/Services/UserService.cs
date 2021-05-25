using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using ServerOdevKocu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services
{
    public class UserService : IUserService
    {
        public Task Authentication(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<AppUser> GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public Task<List<AppUser>> GetUsers()
        {
            throw new NotImplementedException();
        }

        public Task Register(UserRegisterDto user)
        {
            throw new NotImplementedException();
        }

        public Task Update(AppUser appUser)
        {
            throw new NotImplementedException();
        }
    }
}
