using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Entities
{
    public class Homework
    {
        public int Id { get; set; }
        public int StudentId { get; set; }
        public int? TeacherId { get; set; }
        public DateTime AddingDate { get; set; } 
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Student Student { get; set; }
        public Teacher Teacher { get; set; }
        public List<HomeworkTask> HomeworkTasks { get; set; }


    }
}
