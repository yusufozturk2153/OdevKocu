using ServerOdevKocu.Entities;
using ServerOdevKocu.Data.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreBookRepository:EfCoreGeneralRepository<Book, ApplicationDbContext>,IBookRepository
    {
        ApplicationDbContext _context;
        public EfCoreBookRepository(ApplicationDbContext context) : base(context)
        {
            _context = context;
        }

        public async Task<List<Book>> GetAllWithSubjects()
        {
            return await _context.Books.Include(b => b.BookSubjects).ThenInclude(bs => bs.Subject).ToListAsync();
        }

        public async Task<Book> GetBookWithSubjects(int bookId)
        {
            return await _context.Books
                .Include(b => b.BookSubjects).ThenInclude(bs => bs.Subject).Where(b=>b.Id==bookId).FirstOrDefaultAsync();
        }
    }
}
