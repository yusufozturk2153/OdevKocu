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
    public class LessonsController : ControllerBase
    {
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;

        public LessonsController(ILessonService lessonService, IMapper mapper)
        {
            _lessonService = lessonService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var lessons =  await _lessonService.GetLessons();
            List<LessonDto> lessonDtos = _mapper.Map<List<LessonDto>>(lessons);

            return Ok(lessonDtos);

        }
        [HttpGet("LessonsByExamType")]
        public async Task<IActionResult> GetLessonsByExamType(string examType)
        {

            var lessons = await _lessonService.GetLessonsByExamType(examType);
            List<LessonDto> lessonDtos = _mapper.Map<List<LessonDto>>(lessons);
          
            
            return Ok(lessonDtos);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            
            var lesson = await _lessonService.GetById(id);
            var result = _mapper.Map<Lesson, LessonDto>(lesson);

            return Ok(result);

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(LessonDto lessonDto) 
        {
            try
            {
                await _lessonService.Add(lessonDto);
                return Ok("Ders Başarıyla Kaydedildi");
            }
            catch
            {
                return BadRequest("Ders Ekleme İşlemi Başarısız");
            }
            
            
        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(LessonDto lessonDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Lesson lesson = await _lessonService.GetById(lessonDto.Id);
            if (lesson == null) { return NotFound(); }

            _mapper.Map(lessonDto, lesson);


            try
            {
                await _lessonService.Update(lesson);
                return Ok("Ders Başarıyla Güncellendi");
            }
            catch
            {
                return BadRequest("Ders Güncelleme İşlemi Başarısız");
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Lesson lesson = await _lessonService.GetById(id);
            if (lesson == null) { return NotFound(); }

            try
            {
                await _lessonService.Delete(lesson);
                return Ok("Ders Başarıyla Silindi");
            }
            catch
            {
                return BadRequest("Ders Silme İşlemi Başarısız");
            }

        }
    }
}
