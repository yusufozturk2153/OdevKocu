using ServerOdevKocu.Entities;
using ServerOdevKocu.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreStudentRepository : EfCoreGeneralRepository<Student, ApplicationDbContext>, IStudentRepository
    {
        private readonly ApplicationDbContext _context;
        public EfCoreStudentRepository(ApplicationDbContext context):base(context)
        {
            _context = context;
        }

        public async Task<List<Student>> GetAllWithBooks()
        {
            return await _context.Students
                .Include(s=>s.Homeworks)
                .Include(s=>s.StudyPlans)
                .Include(s => s.StudentBooks).ThenInclude(sb => sb.Book).ToListAsync();
        }

        public async Task<Student> GetStudentWithBooks(int studentId)
        {
            return await _context.Students
                .Include(s => s.Homeworks)
                .Include(s => s.StudyPlans)
                    .Include(s => s.StudentBooks).ThenInclude(sb => sb.Book).Where(s=>s.Id==studentId).FirstOrDefaultAsync();
        }
    }
}
