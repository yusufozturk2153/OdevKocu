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
    public class BookService : IBookService
    {
        IBookRepository _bookRepository;
        IMapper _mapper;


        public BookService(IBookRepository bookRepository, IMapper mapper)
        {
            _bookRepository = bookRepository;
            _mapper = mapper;
        }

        public async Task Add(BookDto bookDto)
        {

            Book book = _mapper.Map<Book>(bookDto);
            await _bookRepository.Add(book);

        }

        public async Task Delete(Book book)
        {
            await _bookRepository.Delete(book);
        }

        public async Task<List<Book>> GetBooks()
        {
            return await _bookRepository.GetAllWithSubjects();   
        }

        public async Task<List<Book>> GetBooksByPublisherId(int publisherId)
        {
            return await _bookRepository.GetAll(b=>b.PublisherId==publisherId);
        }

        public async Task<Book> GetById(int bookId)
        {
            return await _bookRepository.GetBookWithSubjects(bookId);
        }

        public async Task Update(Book book)
        {
            await _bookRepository.Update(book);
        }
    }
}
