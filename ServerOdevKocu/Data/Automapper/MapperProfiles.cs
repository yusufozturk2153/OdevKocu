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
            CreateMap<Student, StudentDto>().ReverseMap();
            CreateMap<Teacher, TeacherDto>().ReverseMap();
            CreateMap<Student, StudentRegisterDto>().ReverseMap();
            CreateMap<Teacher, TeacherRegisterDto>().ReverseMap();
            CreateMap<Student, StudentUpdateDto>().ReverseMap();
            CreateMap<Teacher, TeacherUpdateDto>().ReverseMap();
            CreateMap<AppUser, UserLoginDto>().ReverseMap();
            CreateMap<AppUser, UserRegisterDto>().ReverseMap();
            CreateMap<Lesson, LessonDto>().ReverseMap();
            CreateMap<Book, BookDto>().ReverseMap();
            CreateMap<Publisher, PublisherDto>().ReverseMap();
            CreateMap<Homework, HomeworkDto>().ReverseMap();
            CreateMap<Homework, AddHomeworkDto>().ReverseMap();
            CreateMap<StudyPlan, StudyPlanDto>().ReverseMap();
            CreateMap<StudyPlan, AddStudyPlanDto>().ReverseMap();
            CreateMap<StudyPlanTask, StudyPlanTaskDto>().ReverseMap();
            CreateMap<HomeworkTask, HomeworkTaskDto>().ReverseMap();
            CreateMap<Subject, SubjectDto>().ReverseMap();
            CreateMap<StudentBook, StudentBookDto>().ReverseMap();
           

        }
    }
}
