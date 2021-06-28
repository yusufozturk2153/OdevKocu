using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
    public interface IHomeworkTaskService
    {
        Task Add(HomeworkTaskDto homeworkTaskDto);
        Task Update(HomeworkTask homeworkTask);
        Task Delete(HomeworkTask homeworkTask);
        Task<HomeworkTask> GetById(int homeworkTaskId);
        Task<List<HomeworkTask>> GetAll();
        Task<List<HomeworkTask>> GetTasksByHomeworkId(int homeworkId);

    }
}
