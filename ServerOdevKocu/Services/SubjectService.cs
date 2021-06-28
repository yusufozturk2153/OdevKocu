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
    public class SubjectService : ISubjectService
    {
        ISubjectRepository _subjecttRepository;
        IMapper _mapper;


        public SubjectService(ISubjectRepository subjecttRepository, IMapper mapper)
        {
            _subjecttRepository = subjecttRepository;
            _mapper = mapper;
        }

        public async Task Add(SubjectDto subjectDto)
        {
            Subject subject = _mapper.Map<Subject>(subjectDto);
            await _subjecttRepository.Add(subject);
        }

        public async Task AddSubjectToBook(BookSubjectDto bookSubjectDto)
        {
            await _subjecttRepository.AddSubjectToBook(bookSubjectDto.BookId, bookSubjectDto.SubjectId);
        }

        public async Task Delete(Subject subject)
        {
            await _subjecttRepository.Delete(subject);
        }

        public async Task<List<Subject>> GetAll()
        {
            return await _subjecttRepository.GetAll();
        }

        public async Task<Subject> GetById(int subjectId)
        {
            return await _subjecttRepository.Get(s => s.Id == subjectId);
        }

        public async Task Update(Subject subject)
        {
            await _subjecttRepository.Update(subject);
        }
    }
}
