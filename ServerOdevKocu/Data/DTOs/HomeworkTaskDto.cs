using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.DTOs
{
    public class HomeworkTaskDto
    {
        public int Id { get; set; }
        public int HomeworkId { get; set; }
        public int LessonId { get; set; }
        public int BookId { get; set; }
        public int SubjectId { get; set; }
        public int NumberOfQuestions { get; set; }
        public int NumberOfTests { get; set; }
        public string Extra { get; set; }
        public string ControlStatus { get; set; }
        public bool IsDone { get; set; }
    }
}
