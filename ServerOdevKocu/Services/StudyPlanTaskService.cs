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
    public class StudyPlanTaskService : IStudyPlanTaskService
    {
        private readonly IStudyPlanTaskRepository _studyPlanTaskRepository;
        private readonly IMapper _mapper;

        public StudyPlanTaskService(IStudyPlanTaskRepository studyPlanTaskRepository, IMapper mapper)
        {
            _studyPlanTaskRepository = studyPlanTaskRepository;
            _mapper = mapper;
        }
        public async Task Add(StudyPlanTaskDto studyPlanTaskDto)
        {
            StudyPlanTask studyPlanTask = _mapper.Map<StudyPlanTask>(studyPlanTaskDto);
            await _studyPlanTaskRepository.Add(studyPlanTask);
        }

        public async Task Delete(StudyPlanTask studyPlanTask)
        {
            await _studyPlanTaskRepository.Delete(studyPlanTask);
        }

        public async Task<List<StudyPlanTask>> GetAll()
        {
            return await _studyPlanTaskRepository.GetAll();
        }

        public async Task<StudyPlanTask> GetById(int studyPlanTaskId)
        {
            return await _studyPlanTaskRepository.Get(spt => spt.Id == studyPlanTaskId);
        }

        public async Task Update(StudyPlanTask studyPlanTask)
        {
             await _studyPlanTaskRepository.Update(studyPlanTask);
        }
    }
}
