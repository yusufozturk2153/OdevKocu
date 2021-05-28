using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Services.Interfaces
{
    public interface IPublisherService
    {
        Task Add(PublisherDto publisherDto);
        Task Update(Publisher publisher);
        Task Delete(Publisher publisher);
        Task<Publisher> GetById(int publisherId);
        Task<List<Publisher>> GetAll();
  
    }
}
