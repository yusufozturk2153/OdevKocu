using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.DTOs
{
    public class UserRegisterDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Gender { get; set; }
        public string PhoneNumber { get; set; }
    }
}
