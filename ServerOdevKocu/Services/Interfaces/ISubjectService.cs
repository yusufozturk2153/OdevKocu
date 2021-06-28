using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
    public interface ISubjectService
    {
        Task Add(SubjectDto subjectDto);
        Task AddSubjectToBook(BookSubjectDto bookSubjectDto);
        Task Update(Subject subject);
        Task Delete(Subject subject);
        Task<Subject> GetById(int subjectId);
        Task<List<Subject>> GetAll();
        

    }
}
