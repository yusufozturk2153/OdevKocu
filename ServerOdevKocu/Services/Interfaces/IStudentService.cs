using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
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
        Task Add(StudentRegisterDto studentRegisterDto, int? teacherId);
        Task Update(Student student);
        Task Delete(Student student);
        

    }
}
