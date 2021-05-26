using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
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
        Task Add(TeacherRegisterDto teacherRegisterDto);
        Task Update(Teacher teacher);
        Task Delete(Teacher teacher);
    }
}
