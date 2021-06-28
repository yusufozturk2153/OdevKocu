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
    public class SubjectsController : ControllerBase
    {
        private readonly ISubjectService _subjectService;
        private readonly IMapper _mapper;

        public SubjectsController(ISubjectService subjectService, IMapper mapper)
        {
            _subjectService = subjectService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result = await _subjectService.GetAll();
            return Ok(result);

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var result = await _subjectService.GetById(id);
            return Ok(result);

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(SubjectDto subjectDto)
        {
            try
            {
                await _subjectService.Add(subjectDto);
                return Ok("Konu Başarıyla Kaydedildi");
            }
            catch
            {
                return BadRequest("Konu Ekleme İşlemi Başarısız");
            }

        }
        [HttpPost("AddSubjectToBook")]
        public async Task<IActionResult> AddSubjectToBook(BookSubjectDto bookSubjectDto)
        {
            try
            {
                await _subjectService.AddSubjectToBook(bookSubjectDto);
                return Ok("Konu Kitaba Başarıyla Kaydedildi");
            }
            catch
            {
                return BadRequest("Konu Ekleme İşlemi Başarısız");
            }


        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(Subject subject)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

       
            if (subject == null) { return NotFound(); }


            try
            {
                await _subjectService.Update(subject);
                return Ok("Konu Başarıyla Güncellendi");
            }
            catch
            {
                return BadRequest("Konu Güncelleme İşlemi Başarısız");
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Subject subject = await _subjectService.GetById(id);
            if (subject == null) { return NotFound(); }

            try
            {
                await _subjectService.Delete(subject);
                return Ok("Konu Başarıyla Silindi");
            }
            catch
            {
                return BadRequest("Konu Silme İşlemi Başarısız");
            }

        }
    }
}
