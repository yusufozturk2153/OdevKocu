using ServerOdevKocu.Entities;
using ServerOdevKocu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using ServerOdevKocu.Data.Repositories.Interfaces;
using ServerOdevKocu.Data.DTOs;

namespace ServerOdevKocu.Services
{
    public class StudentService : IStudentService
    {
        IStudentRepository _studentRepository;
        ITeacherService _teacherService;
        UserManager<AppUser> _userManager ;
        IMapper _mapper;
        


        public StudentService(IStudentRepository studentRepository, ITeacherService teacherService,
            IMapper mapper,UserManager<AppUser> userManager)
        {
            _studentRepository = studentRepository;
            _teacherService = teacherService;
            _userManager = userManager;
            _mapper = mapper;

        }
        public async Task Add(StudentRegisterDto studentRegisterDto,int? teacherId)
        {

            Student student = _mapper.Map<Student>(studentRegisterDto);
            student.SecurityStamp = Guid.NewGuid().ToString();
            student.UserName = studentRegisterDto.Email;

            if(teacherId != null)
            {
                Teacher teacher = await _teacherService.GetById(Convert.ToInt32(teacherId));
                student.Teacher = teacher;

            }
            

             await _userManager.CreateAsync(student, studentRegisterDto.Password);
             await _userManager.AddToRoleAsync(student, "Student");

        }

        public async Task Delete(Student student)
        {
             await _studentRepository.Delete(student);
        }

        public async Task<List<Student>>  GetAll()
        {
            return await _studentRepository.GetAllWithBooks();
        }

        public async Task<List<Student>> GetAllByTeacherId(int teacherId)
        {
            return await _studentRepository.GetAll(s=>s.TeacherId==teacherId);
        }

        public async Task<Student> GetById(int studentId)
        {
            
            return await _studentRepository.GetStudentWithBooks(studentId);
        }

       

        public async Task Update(Student student)
        {
             await _studentRepository.Update(student);
            
            

        }
        
        
    }
}
