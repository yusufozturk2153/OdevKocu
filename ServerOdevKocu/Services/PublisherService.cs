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
    public class PublisherService : IPublisherService
    {
        IPublisherRepository _publisherRepository;
        IMapper _mapper;

        public PublisherService(IPublisherRepository publisherRepository, IMapper mapper)
        {
            _publisherRepository = publisherRepository;
            _mapper = mapper;
        }

        public async Task Add(string publisherName)
        {
            Publisher publisher = new Publisher
            {
                Name = publisherName
            };
            await _publisherRepository.Add(publisher);
        }

        public async Task Delete(Publisher publisher)
        {
            await _publisherRepository.Delete(publisher);
        }

        public async Task<List<Publisher>> GetAll()
        {
            return await _publisherRepository.GetAll();
        }

        public async Task<Publisher> GetById(int publisherId)
        {
            return await _publisherRepository.Get(p => p.Id == publisherId);
        }

        public async Task Update(Publisher publisher)
        {
            await _publisherRepository.Update(publisher);
        }
    }
}
