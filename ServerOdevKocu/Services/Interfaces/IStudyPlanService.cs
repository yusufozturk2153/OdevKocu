using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
    public interface IStudyPlanService
    {
        Task Add(StudyPlanDto studyPlanDto);
        Task Update(StudyPlan studyPlan);
        Task Delete(StudyPlan studyPlan);
        Task<StudyPlan> GetById(int studyPlanId);
        Task<List<StudyPlan>> GetAll();
    }
}
