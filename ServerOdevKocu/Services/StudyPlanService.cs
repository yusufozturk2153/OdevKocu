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
    public class StudyPlanService : IStudyPlanService
    {
        private readonly IStudyPlanRepository _studyPlanRepository;
        private readonly IMapper _mapper;

        public StudyPlanService(IStudyPlanRepository studyPlanRepository, IMapper mapper)
        {
            _studyPlanRepository = studyPlanRepository;
            _mapper = mapper;
        }
        public async Task Add(StudyPlanDto studyPlanDto)
        {
            StudyPlan studyPlan = _mapper.Map<StudyPlan>(studyPlanDto);
            await _studyPlanRepository.Add(studyPlan);
        }

        public async Task Delete(StudyPlan studyPlan)
        {
            await _studyPlanRepository.Delete(studyPlan);
        }

        public async Task<List<StudyPlan>> GetAll()
        {
            return await _studyPlanRepository.GetAll();
        }

        public async Task<StudyPlan> GetById(int studyPlanId)
        {
            return await _studyPlanRepository.Get(sp => sp.Id == studyPlanId);
        }

        public async Task Update(StudyPlan studyPlan)
        {
            await _studyPlanRepository.Update(studyPlan);
        }
    }
}
