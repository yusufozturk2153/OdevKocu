using ServerOdevKocu.Entities;
using ServerOdevKocu.Data.Repositories.EfCoreRepositories;
using ServerOdevKocu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerOdevKocu.Data.Repositories.Interfaces;

namespace ServerOdevKocu.Services
{
    public class TeacherService : ITeacherService
    {
        ITeacherRepository _teacherRepository;
        public TeacherService(ITeacherRepository teacherRepository)
        {
            _teacherRepository = teacherRepository;
        }

        public async Task Add(Teacher teacher)
        {
            await _teacherRepository.Add(teacher);
        }

        public async Task Delete(Teacher teacher)
        {
            await _teacherRepository.Delete(teacher);
        }

        public async Task<List<Teacher>> GetAll()
        {
            return await _teacherRepository.GetAll();
        }

        public async Task<Teacher> GetById(int teacherId)
        {
            return await _teacherRepository.Get(t => t.Id == teacherId);
        }

        public async Task Update(Teacher teacher)
        {
            await _teacherRepository.Update(teacher);
        }
    }
}
