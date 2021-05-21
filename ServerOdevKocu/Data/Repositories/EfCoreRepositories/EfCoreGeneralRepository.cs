using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using ServerOdevKocu.Repositories.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerOdevKocu.Data.Repositories.EfCoreRepositories
{
    public class EfCoreGeneralRepository<TEntity, TContext> : IRepository<TEntity> 
        where TEntity : class
        where TContext : DbContext
    {

        private readonly TContext _context;
        public EfCoreGeneralRepository(TContext context)
        {
            _context = context;
        }
        public async Task<TEntity> Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return entity;
            
        }

        public async Task<TEntity> Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;

        }

        public async Task<TEntity> Get(Expression<Func<TEntity, bool>> filter)
        {
            return await _context.Set<TEntity>().FindAsync(filter);
        }

        public async Task<List<TEntity>> GetAll(Expression<Func<TEntity, bool>> filter=null)
        {
           
              var entityList = filter==null ? _context.Set<TEntity>().ToListAsync()
                : _context.Set<TEntity>().Where(filter).ToListAsync(); ;

              return await entityList;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
