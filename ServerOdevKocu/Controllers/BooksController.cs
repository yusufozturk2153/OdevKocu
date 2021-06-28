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
    [Route("api/Books")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private readonly IBookService _bookService;
        private readonly ILessonService _lessonService;
        private readonly IMapper _mapper;
        public BooksController(IBookService bookService, IMapper mapper, ILessonService lessonService)
        {
            _bookService = bookService;
            _lessonService = lessonService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {

            var books = await _bookService.GetBooks();
            var result= _mapper.Map<List<BookDto>>(books);
            return Ok(result);

        }
        [HttpGet("GetByExamType")]
        public async Task<IActionResult> GetByExamType(string examType)
        {

            var books = await _bookService.GetBooksByExamType(examType);
            var result = _mapper.Map<List<BookDto>>(books);
            return Ok(result);

        }
        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {

            var book = await _bookService.GetById(id);
            var bookDto = _mapper.Map<Book, BookDto>(book);
            return Ok(bookDto);

        }

        [HttpPost("Add")]
        public async Task<IActionResult> Add(BookDto bookDto)
        {
            Lesson lesson = await _lessonService.GetById(bookDto.LessonId);
            bookDto.ExamType = lesson.ExamType;
            try
            {
                await _bookService.Add(bookDto);
                return Ok("Kitap Başarıyla Kaydedildi");
            }
            catch
            {
                return BadRequest("Kitap Ekleme İşlemi Başarısız");
            }
            
        }

        [HttpPost("AddBookToStudent")]
        public async Task<IActionResult> AddBookToStudent(StudentBookDto studentBookDto)
        {
            try
            {
                await _bookService.AddBookToStudent(studentBookDto);
                return Ok("Kitap Kitaplığa Başarıyla Kaydedildi");
            }
            catch
            {
                return BadRequest("Kitap Ekleme İşlemi Başarısız");
            }

        }

        [HttpPut("Update")]
        public async Task<IActionResult> Update(BookDto bookDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Book book = _mapper.Map<Book>(bookDto);

            if (book == null) { return NotFound(); }


            try
            {
                await _bookService.Update(book);
                return Ok("Kitap Başarıyla Güncellendi");
            }
            catch
            {
                return BadRequest("Kitap Güncelleme İşlemi Başarısız");
            }
        }
        [HttpDelete("Delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            Book book = await _bookService.GetById(id);
            if (book == null) { return NotFound(); }

            try
            {
                await _bookService.Delete(book);
                return Ok("Kitap Başarıyla Silindi");
            }
            catch
            {
                return BadRequest("Kitap Silme İşlemi Başarısız");
            }
        }
    }
}
