using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.DTOs
{
    public class AddStudyPlanDto
    {
        public int StudentId { get; set; }
        public int TeacherId { get; set; }
        public DateTime AddingDate { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
