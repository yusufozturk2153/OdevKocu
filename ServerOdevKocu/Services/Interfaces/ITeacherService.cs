using ServerOdevKocu.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
    public interface ITeacherService
    {
        Task<Teacher> GetById(int teacherId);
        Task<List<Teacher>> GetAll();
        Task Add(Teacher teacher);
        Task Update(Teacher teacher);
        Task Delete(Teacher teacher);
    }
}
