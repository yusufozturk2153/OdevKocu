using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Entities
{
    public class StudyPlan
    {
        public int Id { get; set; }
        public int? TeacherId { get; set; }
        public int StudentId { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public List<StudyPlanTask> StudyPlanTasks { get; set; }
    }
}
