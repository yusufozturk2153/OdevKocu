using AutoMapper;
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
            CreateMap<Teacher, TeacherDetailDto>().ReverseMap();
            CreateMap<AppUser, UserLoginDto>().ReverseMap();
            CreateMap<AppUser, UserRegisterDto>().ReverseMap();
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Homework, HomeworkDto>().ReverseMap();
            CreateMap<StudyPlan, StudyPlanDto>().ReverseMap();
            CreateMap<StudyPlanTask, StudyPlanDto>().ReverseMap();
            CreateMap<HomeworkTask, HomeworkTaskDto>().ReverseMap();
           

        }
    }
}
