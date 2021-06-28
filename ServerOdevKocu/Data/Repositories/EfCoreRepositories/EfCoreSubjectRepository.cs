using ServerOdevKocu.Entities;
using ServerOdevKocu.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreSubjectRepository : EfCoreGeneralRepository<Subject, ApplicationDbContext>, ISubjectRepository
    {
        ApplicationDbContext _context;
        public EfCoreSubjectRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task AddSubjectToBook(int bookId, int subjectId)
        {
            Book book = await _context.Books.Include(b => b.BookSubjects).ThenInclude(bs => bs.Subject)
                .FirstOrDefaultAsync(b=>b.Id==bookId);
            
            Subject subject = await _context.Subjects.FindAsync(subjectId);

            BookSubject bookSubject = new BookSubject
            {
                Book = book,
                Subject = subject
            };
            await _context.BookSubjects.AddAsync(bookSubject);
            await _context.SaveChangesAsync();

        }
    }
}
