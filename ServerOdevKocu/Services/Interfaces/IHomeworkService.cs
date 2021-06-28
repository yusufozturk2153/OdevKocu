using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
     public interface IHomeworkService
    {
        Task Add(AddHomeworkDto homeworkDto);
        Task Update(Homework homework);
        Task Delete(Homework homework);
        Task<Homework> GetById(int homeworkId);
        Task<List<Homework>> GetAll();
    }
}
