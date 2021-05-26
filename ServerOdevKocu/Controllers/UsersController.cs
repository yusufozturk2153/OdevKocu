using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using ServerOdevKocu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IUserService _userService;
        
        public UsersController(IMapper mapper, UserManager<AppUser> userManager, 
            SignInManager<AppUser> signInManager,IUserService userService)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _userService = userService;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _userService.GetUsers();

            return Ok(result);

        }
        [HttpPost("login")]
        public async Task<IActionResult> Login(UserLoginDto userLoginDto)
        {
            var user = await _userManager.FindByEmailAsync(userLoginDto.Email);

            if (user == null) 
                { 
                    return BadRequest(new { message = "Hatalı E-Mail" });
                }
            var result = await _signInManager.CheckPasswordSignInAsync(user, userLoginDto.Password,false);
           

            if (result.Succeeded)
            {
                return Ok(new
                {

                    token = _userService.GenerateJwtToken(user),
                

                }); ;
            }
            return Unauthorized();
        } 
       
    }
}
