using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.DTOs
{
    public class StudyPlanTaskDto
    {
        public int Id { get; set; }
        public int StudyPlanId { get; set; }
        public DateTime Day { get; set; }
        public string StartTime { get; set; }
        public string EndTime { get; set; }
        public int HomeworkTaskId { get; set; }
        public string Extra { get; set; }
        public int LessonId { get; set; }
        public int BookId { get; set; }
        public int SubjectId { get; set; }
        public int NumberOfQuestion { get; set; }
    }
}
