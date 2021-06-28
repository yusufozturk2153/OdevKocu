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
    public class HomeworkTaskService : IHomeworkTaskService
    {
        private readonly IHomeworkTaskRepository _homeworkTaskRepository;
        private readonly IMapper _mapper;

        public HomeworkTaskService(IHomeworkTaskRepository homeworkTaskRepository, IMapper mapper)
        {
            _homeworkTaskRepository = homeworkTaskRepository;
            _mapper = mapper;
        }
        public async Task Add(HomeworkTaskDto homeworkTaskDto)
        {
            HomeworkTask homeworkTask = _mapper.Map<HomeworkTask>(homeworkTaskDto);
            await _homeworkTaskRepository.Add(homeworkTask);
        }

        public async Task Delete(HomeworkTask homeworkTask)
        {
            await _homeworkTaskRepository.Delete(homeworkTask);
        }

        public async Task<List<HomeworkTask>> GetAll()
        {
            return await _homeworkTaskRepository.GetAll();
        }

        public async Task<HomeworkTask> GetById(int homeworkTaskId)
        {
            return await _homeworkTaskRepository.Get(ht => ht.Id == homeworkTaskId);
        }

        public async Task<List<HomeworkTask>> GetTasksByHomeworkId(int homeworkId)
        {
            return await _homeworkTaskRepository.GetAll(ht=>ht.HomeworkId==homeworkId);
        }

        public async Task Update(HomeworkTask homeworkTask)
        {
            await _homeworkTaskRepository.Update(homeworkTask);
        }
    }
}
