﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace ServerOdevKocu.Repositories.Interfaces
{
    public interface IRepository<T> where T: class
    {
        Task<T> Get(Expression<Func<T,bool>> filter);
        Task<List<T>> GetAll(Expression<Func<T, bool>> filter = null);
        Task<T> Add(T entity);
        Task<T> Update(T entity);
        Task<T> Delete(T entity);
        
    }
}
