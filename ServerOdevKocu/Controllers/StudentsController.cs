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
    public class StudentsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IStudentService _studentService;
        private readonly UserManager<AppUser> _userManager;

        public StudentsController(IMapper mapper, IStudentService studentService, UserManager<AppUser> userManager)
        {
            _mapper = mapper;
            _studentService = studentService ;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(StudentRegisterDto studentRegisterDto)
        {
            
             Student student = _mapper.Map<Student>(studentRegisterDto);

            student.SecurityStamp = Guid.NewGuid().ToString();
            student.UserName = studentRegisterDto.Email;

            var addUserResult = await _userManager.CreateAsync(student, studentRegisterDto.Password);
            var addRoleResult= await _userManager.AddToRoleAsync(student, "Student");

            if(addUserResult.Succeeded && addRoleResult.Succeeded)
            {
                return StatusCode(201);
            }
               
            return BadRequest();
            

        }
        [HttpGet]
        public async Task<IActionResult> Get()
       {
            var result =   await _studentService.GetAll();

            return Ok(result);

        }
        [HttpGet("id")]
        public async Task<IActionResult> Get(int studentId)
        {
            var result = await _studentService.GetById(studentId);

            return Ok(result);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentDetailDto studentDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var student = await _studentService.GetById(id);

            if (student == null) { return NotFound(); }

             _mapper.Map(studentDetailDto, student);

            try {
                await _studentService.Update(student);
                return Ok(student);
            }
            catch{
                return BadRequest();
            }
             
            //TODO normailized email ve username değiştirme ayarlarına bak

           
        }

    }
}
