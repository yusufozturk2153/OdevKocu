using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
    public interface ILessonService
    {
        Task Add(LessonDto lessonDto);
        Task Update(Lesson lesson);
        Task Delete(Lesson lesson);
        Task<Lesson> GetById(int lessonId);
        Task<List<Lesson>> GetLessons();
        Task<List<Lesson>> GetLessonsByExamType(string ExamType);
        
    }
}
