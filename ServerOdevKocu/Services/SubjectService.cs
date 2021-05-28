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
       

        public SubjectService(ISubjectRepository subjecttRepository)
        {
            _subjecttRepository = subjecttRepository;
           
        }

        public async Task Add(Subject subject)
        {
            await _subjecttRepository.Add(subject);
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
