using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
    public interface IUserService
    {
        Task<List<AppUser>> GetUsers();
        Task<AppUser> GetUser(int userId);
        Task Register(UserRegisterDto user);
        Task Authentication(AppUser appUser);
        string GenerateJwtToken(AppUser appUser);
        Task Update(AppUser appUser);
        Task Delete(int userId);

    }
}
