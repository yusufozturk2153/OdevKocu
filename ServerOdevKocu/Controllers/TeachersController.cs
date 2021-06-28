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
    public class TeachersController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly ITeacherService _teacherService;
        private readonly IStudentService _studentService;
        private readonly UserManager<AppUser> _userManager;

        public TeachersController(IMapper mapper, UserManager<AppUser> userManager, 
            ITeacherService teacherService,IStudentService studentService)
        {
            _mapper = mapper;
            _teacherService = teacherService;
            _studentService = studentService;
            _userManager = userManager;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(TeacherRegisterDto teacherRegisterDto)
        {

            Teacher teacher = _mapper.Map<Teacher>(teacherRegisterDto);

            teacher.SecurityStamp = Guid.NewGuid().ToString();
            teacher.UserName = teacherRegisterDto.Email;

            var addUserResult = await _userManager.CreateAsync(teacher, teacherRegisterDto.Password);
            var addRoleResult = await _userManager.AddToRoleAsync(teacher, "Teacher");

            if (addUserResult.Succeeded && addRoleResult.Succeeded)
            {
                return StatusCode(201);
            }

            return BadRequest();


        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var teachers = await _teacherService.GetAll();
            var result = _mapper.Map<List<TeacherDto>>(teachers);
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            var teacher = await _teacherService.GetById(id);
            var result = _mapper.Map<TeacherDto>(teacher);
            return Ok(result);

        }

        [HttpGet("students")]
        public async Task<IActionResult> GetStudentsOfTeacher(int id)
        {
            var students = await _studentService.GetAllByTeacherId(id);
            var result = _mapper.Map<List<StudentDto>>(students);
            return Ok(result);

        }

        [HttpPost("addStudent/{id}")]
        public async Task<IActionResult> AddStudentToTeacher(StudentRegisterDto studentRegisterDto,int id)
        {
            try
            {
                await _studentService.Add(studentRegisterDto, id);
                return Ok("Öğrenci Başarıyla Kaydedildi");
            }
            catch
            {
                return BadRequest("Öğrenci Eklenemedi");
            }
            
        }

        [HttpPut("update/{id}")]
        public async Task<IActionResult> Update(int id, TeacherUpdateDto teacherDetailDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = await _teacherService.GetById(id);

            if (teacher == null) { return NotFound(); }

            _mapper.Map(teacherDetailDto, teacher);

            teacher.UserName = teacherDetailDto.Email;

            teacher.NormalizedEmail = teacherDetailDto.Email.ToUpper();
            teacher.NormalizedUserName = teacherDetailDto.Email.ToUpper();

            try
            {
                await _teacherService.Update(teacher);
                return Ok(teacher);
            }
            catch
            {
                return BadRequest();
            }


        }

        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var teacher = await _teacherService.GetById(id);


            if (teacher == null) { return NotFound(); }

            try
            {
                await _teacherService.Delete(teacher);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }

        }
    }
}
