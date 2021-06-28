using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.DTOs
{
    public class SubjectDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LessonId { get; set; }
    }
}
