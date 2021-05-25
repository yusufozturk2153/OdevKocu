﻿using AutoMapper;
using ServerOdevKocu.Data.DTOs;
using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Automapper
{
    public class MapperProfiles:Profile
    {
        public MapperProfiles()
        {
            CreateMap<Student, StudentRegisterDto>().ReverseMap();
            CreateMap<Teacher, TeacherRegisterDto>().ReverseMap();
            CreateMap<Student, StudentDetailDto>().ReverseMap();
        }
    }
}