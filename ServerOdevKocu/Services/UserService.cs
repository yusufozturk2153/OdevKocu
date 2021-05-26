using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Data.Repositories.Interfaces;
using ServerOdevKocu.Entities;
using ServerOdevKocu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services
{
    public class UserService : IUserService
    {

        private readonly IConfiguration _configuration;
        private readonly UserManager<AppUser> _userManager;
        private readonly IUserRepository _userRepository;
        public UserService(IConfiguration configuration, UserManager<AppUser> userManager, IUserRepository userRepository)
        {
            _configuration = configuration;
            _userManager = userManager;
            _userRepository = userRepository;
        }

        public Task Authentication(AppUser appUser)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int userId)
        {
            throw new NotImplementedException();
        }

        public  string GenerateJwtToken(AppUser appUser)
        {

            var tokenHandler = new JwtSecurityTokenHandler();
            var key =  Encoding.ASCII.GetBytes(_configuration.GetSection("AppSettings:Secret").Value);

            var tokenDescriptor =  new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, appUser.Id.ToString()),
                    new Claim(ClaimTypes.Email, appUser.Email),
                    new Claim(ClaimTypes.Role, _userManager.GetRolesAsync(appUser).ToString())
                }),
                Expires = DateTime.UtcNow.AddHours(12),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token =  tokenHandler.CreateToken(tokenDescriptor);
            return  tokenHandler.WriteToken(token);

        }

        public Task<AppUser> GetUser(int userId)
        {
            throw new NotImplementedException();
        }

        public async Task<List<AppUser>> GetUsers()
        {
             return await _userRepository.GetAll();
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
