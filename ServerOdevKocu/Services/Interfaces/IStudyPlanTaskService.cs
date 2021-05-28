using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
    public interface IStudyPlanTaskService
    {
        Task Add(StudyPlanTaskDto studyPlanTaskDto);
        Task Update(StudyPlanTask studyPlanTask);
        Task Delete(StudyPlanTask studyPlanTask);
        Task<StudyPlanTask> GetById(int studyPlanTaskId);
        Task<List<StudyPlanTask>> GetAll();
    }
}
