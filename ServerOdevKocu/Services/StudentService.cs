using ServerOdevKocu.Entities;
using ServerOdevKocu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using AutoMapper;
using ServerOdevKocu.Data.Repositories.Interfaces;

namespace ServerOdevKocu.Services
{
    public class StudentService : IStudentService
    {
        IStudentRepository _studentRepository;
        


        public StudentService(IStudentRepository studentRepository, 
            IMapper mapper)
        {
            _studentRepository = studentRepository;
            
         
        }
        public async Task Add(Student student)
        {
            await _studentRepository.Add(student);
        }

        public async Task Delete(Student student)
        {
             await _studentRepository.Delete(student);
        }

        public async Task<List<Student>>  GetAll()
        {
            return await _studentRepository.GetAll();
        }

        public async Task<List<Student>> GetAllByTeacherId(int teacherId)
        {
            return await _studentRepository.GetAll(s=>s.TeacherId==teacherId);
        }

        public async Task<Student> GetById(int studentId)
        {
            
            return await _studentRepository.Get(s => s.Id == studentId);
        }

       

        public async Task Update(Student student)
        {
             await _studentRepository.Update(student);

            
            

        }
        
        
    }
}
