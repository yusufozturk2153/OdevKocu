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
    public class HomeworkService : IHomeworkService
    {
        private readonly IHomeworkRepository _homeworkRepository;
        private readonly IMapper _mapper;

        public HomeworkService(IHomeworkRepository homeworkRepository, IMapper mapper)
        {
            _homeworkRepository = homeworkRepository;
            _mapper = mapper;
        }
        public async Task Add(HomeworkDto homeworkDto)
        {
            Homework homework = _mapper.Map<Homework>(homeworkDto);
            await _homeworkRepository.Add(homework);
        }

        public async Task Delete(Homework homework)
        {
            await _homeworkRepository.Delete(homework);
        }

        public async Task<List<Homework>> GetAll()
        {
            return await _homeworkRepository.GetAll();
        }

        public async Task<Homework> GetById(int homeworkId)
        {
            return await _homeworkRepository.Get(h => h.Id == homeworkId);
        }

        public async Task Update(Homework homework)
        {
            await _homeworkRepository.Update(homework);
        }
    }
}
