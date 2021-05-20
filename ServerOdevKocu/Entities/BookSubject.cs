using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Entities
{
    public class BookSubject
    {
        public int BookId { get; set; }
        public int SubjectId { get; set; }
        public Book Book { get; set; }
        public Subject Subject { get; set; }

    }
}
