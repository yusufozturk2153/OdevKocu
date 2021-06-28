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
    [Route("api/[controller]")]
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

        [HttpPost("Register")]
        public async Task<IActionResult> Register(StudentRegisterDto studentRegisterDto)
        {
            try
            {
                await _studentService.Add(studentRegisterDto,null);
                return StatusCode(201);
            }

            catch
            {
                return BadRequest();
            }

             
        }

        [HttpGet]
        public async Task<IActionResult> Get()
       {
            var students =   await _studentService.GetAll();
            var result = _mapper.Map<List<StudentDto>>(students);

            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var student = await _studentService.GetById(id);
            var result = _mapper.Map<Student, StudentDto>(student);
            return Ok(result);

        }
        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, StudentUpdateDto studentDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            
            var student = await _studentService.GetById(id);

            if (student == null) { return NotFound(); }

             _mapper.Map(studentDetailDto, student);

            student.UserName = studentDetailDto.Email;

            student.NormalizedEmail= studentDetailDto.Email.ToUpper();
            student.NormalizedUserName = studentDetailDto.Email.ToUpper();

            try {
                await _studentService.Update(student);
                return Ok(student);
            }
            catch{
                return BadRequest();
            }
             
            //TODO normailized email ve username değiştirme ayarlarına bak

           
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var student = await _studentService.GetById(id);

            
            if (student == null) { return NotFound(); }

            try
            {
                await _studentService.Delete(student);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
            
        }

    }
}
