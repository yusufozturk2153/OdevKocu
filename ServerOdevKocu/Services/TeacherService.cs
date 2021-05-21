using ServerOdevKocu.Data.Entities;
using ServerOdevKocu.Data.Repositories.EfCoreRepositories;
using ServerOdevKocu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services
{
    public class TeacherService : ITeacherService
    {
        EfCoreTeacherRepository _efCoreTeacherRepository;
        public TeacherService(EfCoreTeacherRepository efCoreTeacherRepository)
        {
            _efCoreTeacherRepository = efCoreTeacherRepository;
        }

        public async Task Add(Teacher teacher)
        {
            await _efCoreTeacherRepository.Add(teacher);
        }

        public async Task Delete(Teacher teacher)
        {
            await _efCoreTeacherRepository.Delete(teacher);
        }

        public async Task<List<Teacher>> GetAll()
        {
            return await _efCoreTeacherRepository.GetAll();
        }

        public async Task<Teacher> GetById(int teacherId)
        {
            return await _efCoreTeacherRepository.Get(t => t.Id == teacherId);
        }

        public async Task Update(Teacher teacher)
        {
            await _efCoreTeacherRepository.Update(teacher);
        }
    }
}
