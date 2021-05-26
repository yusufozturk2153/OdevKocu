using ServerOdevKocu.Entities;
using ServerOdevKocu.Data.Repositories.EfCoreRepositories;
using ServerOdevKocu.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ServerOdevKocu.Data.Repositories.Interfaces;
using ServerOdevKocu.Data.DTOs;
using AutoMapper;
using Microsoft.AspNetCore.Identity;

namespace ServerOdevKocu.Services
{
    public class TeacherService : ITeacherService
    {
        ITeacherRepository _teacherRepository; 
        IMapper _mapper;
        UserManager<AppUser> _userManager;
        public TeacherService(ITeacherRepository teacherRepository, IMapper mapper, UserManager<AppUser> userManager)
        {
            _teacherRepository = teacherRepository;
            _mapper = mapper;
            _userManager = userManager;
        }

        public async Task Add(TeacherRegisterDto teacherRegisterDto)
        {
            Teacher teacher = _mapper.Map<Teacher>(teacherRegisterDto);

            teacher.SecurityStamp = Guid.NewGuid().ToString();

            await _userManager.CreateAsync(teacher, teacherRegisterDto.Password);
            await _userManager.AddToRoleAsync(teacher, "Teacher");
        }

        public async Task Delete(Teacher teacher)
        {
            await _teacherRepository.Delete(teacher);
        }

        public async Task<List<Teacher>> GetAll()
        {
            return await _teacherRepository.GetAll();
        }

        public async Task<Teacher> GetById(int teacherId)
        {
            return await _teacherRepository.Get(t => t.Id == teacherId);
        }

        public async Task Update(Teacher teacher)
        {
            await _teacherRepository.Update(teacher);
        }
    }
}
