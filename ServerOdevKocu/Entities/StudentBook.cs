using ServerOdevKocu.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Entities
{
    public class StudentBook
    {
        public int StudentBookId { get; set; }
        public int StudentId { get; set; }
        public int BookId { get; set; }
        public Student Student { get; set; }
        public Book Book { get; set; }
    }
}
