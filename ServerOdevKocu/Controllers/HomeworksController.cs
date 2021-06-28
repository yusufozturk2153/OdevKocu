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
    public class HomeworksController : ControllerBase
    {
        private readonly IHomeworkService _homeworkService;
        private readonly IHomeworkTaskService _taskService;
        private readonly IMapper _mapper;

        public HomeworksController(IHomeworkService homeworkService,IHomeworkTaskService taskService,IMapper mapper)
        {
            _homeworkService = homeworkService;
            _taskService = taskService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result = await _homeworkService.GetAll();
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

            var result = await _homeworkService.GetById(id);
            return Ok(result);

        }
        [HttpGet("Task/{id}")]
        public async Task<IActionResult> GetTask(int id)
        {

            var result = await _taskService.GetById(id);
            return Ok(result);

        }
      

        [HttpPost("Add")]
        public async Task<IActionResult> Add(AddHomeworkDto homeworkDto)
        {
            try
            {
                await _homeworkService.Add(homeworkDto);
                return Ok("Ödev Oluşturuldu. Şimdi Ödev İçeriğini Belirleyebilirsiniz");
            }
            catch
            {
                return BadRequest("Ödev Oluşturma İşlemi Başarısız");
            }


        }
        [HttpPost("AddTasks")]
        public async Task<IActionResult> AddTasks(HomeworkTaskDto[] homeworkTasks)
        {
            try
            {
                foreach(HomeworkTaskDto taskDto in homeworkTasks)
                {
                    await _taskService.Add(taskDto);
                }
              
                return Ok("Ödev İçeriği Başarıyla Kaydedildi");
            }
            catch
            {
                return BadRequest("Ödev İçeriği Kaydetme İşlemi Başarısız");
            }


        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(HomeworkDto homeworkDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Homework homework = _mapper.Map<Homework>(homeworkDto);

            if (homework == null) { return NotFound(); }


            try
            {
                await _homeworkService.Update(homework);
                return Ok("Ödev Başarıyla Güncellendi");
            }
            catch
            {
                return BadRequest("Ödev Güncelleme İşlemi Başarısız");
            }
        }
        [HttpPut("UpdateTask")]
        public async Task<IActionResult> UpdateTask(HomeworkTaskDto homeworkTaskDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            HomeworkTask homeworkTask = _mapper.Map<HomeworkTask>(homeworkTaskDto);

            if (homeworkTask == null) { return NotFound(); }


            try
            {
                await _taskService.Update(homeworkTask);
                return Ok("Ödev İçeriği Başarıyla Güncellendi");
            }
            catch
            {
                return BadRequest("Ödev İçeriği Güncelleme İşlemi Başarısız");
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Homework homework = await _homeworkService.GetById(id);
  
            if (homework == null) { return NotFound(); }

            try
            {
                await _homeworkService.Delete(homework);
               
                return Ok("Ödev Başarıyla Silindi");
            }
            catch
            {
                return BadRequest("Ödev Silme İşlemi Başarısız");
            }
        }
        [HttpDelete("DeleteTask/{id}")]
        public async Task<IActionResult> DeleteTask(int id)
        {
            HomeworkTask task = await _taskService.GetById(id);
            if (task == null) { return NotFound(); }

            try
            {
                await _taskService.Delete(task);
                return Ok("Ödev İçeriği Başarıyla Silindi");
            }
            catch
            {
                return BadRequest("Ödev İçeriği Silme İşlemi Başarısız");
            }
        }
    }
}
