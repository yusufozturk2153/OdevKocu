using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Entities
{
    public class Student:AppUser
    {
        public string Class { get; set; }
        public string ExamType { get; set; }
        public int? TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        public List<Homework> Homeworks { get; set; }
        public List<StudyPlan> StudyPlans { get; set; }

    }
}

