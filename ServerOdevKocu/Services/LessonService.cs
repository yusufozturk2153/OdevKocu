using AutoMapper;
using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Data.Repositories.Interfaces;
using ServerOdevKocu.Entities;
using ServerOdevKocu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services
{
    public class LessonService : ILessonService
    {
        ILessonRepository _lessonRepository;
        IMapper _mapper;

        public LessonService(ILessonRepository lessonRepository, IMapper mapper)
        {
            _lessonRepository = lessonRepository;
            _mapper = mapper;
        }


        public async Task Add(LessonDto lessonDto)
        {
            Lesson lesson = _mapper.Map<Lesson>(lessonDto);
            await _lessonRepository.Add(lesson);
        }

        public async Task Delete(Lesson lesson)
        {
           
            await _lessonRepository.Delete(lesson);
        }

        public async Task<Lesson> GetById(int lessonId)
        {
            return await _lessonRepository.Get(l => l.Id == lessonId);
        }

        public async Task<List<Lesson>> GetLessons()
        {
            return await _lessonRepository.GetAll();
        }

        public async Task<List<Lesson>> GetLessonsByExamType(string ExamType)
        {
            return await _lessonRepository.GetAll(l => l.ExamType == ExamType);
        }

        public async Task Update(Lesson lesson)
        {
            
            await _lessonRepository.Update(lesson);
        }
    }
}
