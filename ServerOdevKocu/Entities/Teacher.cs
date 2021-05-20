using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Entities
{
    public class Teacher:AppUser 
    {
        public List<Student> Students { get; set; }
        public List<Homework> Homeworks { get; set; }
        public List<StudyPlan> StudyPlans { get; set; }
    }
}
