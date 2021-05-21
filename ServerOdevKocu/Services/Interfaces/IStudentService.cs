using ServerOdevKocu.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
    public interface IStudentService
    {
        Task<Student> GetById(int studentId);
        Task<List<Student>> GetAll();
        Task<List<Student>> GetAllByTeacherId(int teacherId);
        Task Add(Student student);
        Task Update(Student student);
        Task Delete(Student student);

    }
}
