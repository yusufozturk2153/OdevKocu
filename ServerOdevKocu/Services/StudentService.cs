using ServerOdevKocu.Data.Entities;
using ServerOdevKocu.Data.Repositories.EfCoreRepositories;
using ServerOdevKocu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services
{
    public class StudentService : IStudentService
    {
        EfCoreStudentRepository _efCoreStudentRepository;
        public StudentService(EfCoreStudentRepository efCoreStudentRepository)
        {
            _efCoreStudentRepository = efCoreStudentRepository;
        }
        public async Task Add(Student student)
        {
             await _efCoreStudentRepository.Add(student);
        }

        public async Task Delete(Student student)
        {
             await _efCoreStudentRepository.Delete(student);
        }

        public async Task<List<Student>>  GetAll()
        {
            return await _efCoreStudentRepository.GetAll();
        }

        public async Task<List<Student>> GetAllByTeacherId(int teacherId)
        {
            return await _efCoreStudentRepository.GetAll(s=>s.TeacherId==teacherId);
        }

        public async Task<Student> GetById(int studentId)
        {
            return await _efCoreStudentRepository.Get(s => s.Id == studentId);
        }

        public async Task Update(Student student)
        {
             await _efCoreStudentRepository.Update(student);
        }
    }
}
