using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using ServerOdevKocu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StudyPlansController : ControllerBase
    {
        private readonly IStudyPlanService _studyPlanService;
        private readonly IStudyPlanTaskService _taskService;
        private readonly IMapper _mapper;
        public StudyPlansController(IStudyPlanService studyPlanService, IStudyPlanTaskService studyPlanTaskService,
            IMapper mapper)
        {
            _studyPlanService = studyPlanService;
            _taskService = studyPlanTaskService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result = await _studyPlanService.GetAll();
            return Ok(result);

        }

        [HttpGet("Tasks")]
        public async Task<IActionResult> GetTasks()
        {

            var result = await _taskService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var result = await _studyPlanService.GetById(id);
            return Ok(result);

        }
        [HttpGet("Task/{id}")]
        public async Task<IActionResult> GetTask(int id)
        {

            var result = await _taskService.GetById(id);
            return Ok(result);

        }


        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddStudyPlanDto studyPlanDto)
        {
            try
            {
                await _studyPlanService.Add(studyPlanDto);
                return Ok("Plan Oluşturuldu. Şimdi Plan İçeriğini Belirleyebilirsiniz");
            }
            catch
            {
                return BadRequest("Plan Oluşturma İşlemi Başarısız");
            }


        }
        [HttpPost("AddTasks")]
        public async Task<IActionResult> AddTasks(StudyPlanTaskDto[] studyPlanTasks)
        {
            try
            {
                foreach (StudyPlanTaskDto taskDto in studyPlanTasks)
                {
                    await _taskService.Add(taskDto);
                }

                return Ok("Plan İçeriği Başarıyla Kaydedildi");
            }
            catch
            {
                return BadRequest("Plan İçeriği Kaydetme İşlemi Başarısız");
            }


        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(StudyPlanDto studyPlanDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StudyPlan studyPlan = _mapper.Map<StudyPlan>(studyPlanDto);

            if (studyPlan == null) { return NotFound(); }


            try
            {
                await _studyPlanService.Update(studyPlan);
                return Ok("Plan Başarıyla Güncellendi");
            }
            catch
            {
                return BadRequest("Plan Güncelleme İşlemi Başarısız");
            }
        }
        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(StudyPlanTaskDto studyPlanTaskDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            StudyPlanTask studyPlanTask = _mapper.Map<StudyPlanTask>(studyPlanTaskDto);

            if (studyPlanTask == null) { return NotFound(); }


            try
            {
                await _taskService.Update(studyPlanTask);
                return Ok("Plan İçeriği Başarıyla Güncellendi");
            }
            catch
            {
                return BadRequest("Plan İçeriği Güncelleme İşlemi Başarısız");
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            StudyPlan studyPlan = await _studyPlanService.GetById(id);

            if (studyPlan == null) { return NotFound(); }

            try
            {
                await _studyPlanService.Delete(studyPlan);

                return Ok("Plan Başarıyla Silindi");
            }
            catch
            {
                return BadRequest("Plan Silme İşlemi Başarısız");
            }
        }
        [HttpDelete("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            StudyPlanTask task = await _taskService.GetById(id);
            if (task == null) { return NotFound(); }

            try
            {
                await _taskService.Delete(task);
                return Ok("Plan İçeriği Başarıyla Silindi");
            }
            catch
            {
                return BadRequest("Plan İçeriği Silme İşlemi Başarısız");
            }
        }
    }
}
