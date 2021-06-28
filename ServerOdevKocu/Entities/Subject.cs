using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Entities
{
    public class Subject
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int LessonId { get; set; }
        public Lesson Lesson { get; set; }
        public List<BookSubject> BookSubjects { get; set; }

    }
}
