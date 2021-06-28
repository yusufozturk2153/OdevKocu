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
    public class PublishersController : ControllerBase
    {
        private readonly IPublisherService _publisherService;
        private readonly IMapper _mapper;
        public PublishersController(IPublisherService publisherService, IMapper mapper)
        {
            _publisherService = publisherService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var result = await _publisherService.GetAll();
            return Ok(result);

        }
        
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var result = await _publisherService.GetById(id);
            return Ok(result);

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(string publisherName)
        {
            try
            {
                await _publisherService.Add(publisherName);
                return Ok("Yayınevi Başarıyla Kaydedildi");
            }
            catch
            {
                return BadRequest("Yayınevi Ekleme İşlemi Başarısız");
            }


        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(PublisherDto publisherDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Publisher publisher = await _publisherService.GetById(publisherDto.Id);
            if (publisher == null) { return NotFound(); }

            _mapper.Map(publisherDto, publisher);


            try
            {
                await _publisherService.Update(publisher);
                return Ok("Yayınevi Başarıyla Güncellendi");
            }
            catch
            {
                return BadRequest("Yayınevi Güncelleme İşlemi Başarısız");
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Publisher publisher = await _publisherService.GetById(id);
            if (publisher == null) { return NotFound(); }

            try
            {
                await _publisherService.Delete(publisher);
                return Ok("Yayınevi Başarıyla Silindi");
            }
            catch
            {
                return BadRequest("Yayınevi Silme İşlemi Başarısız");
            }

        }
    }
}
