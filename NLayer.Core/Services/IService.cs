﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace NLayer.Core.Services
{
    public interface IService<T> where T : class
    {
        Task<T> GetByIdAsync<T>(int id);
        Task<IEnumerable<T>> GetAllAsync();
        IQueryable<T> Where(Expression<Func<T, bool>> expression);
        Task<bool> AnyAsync(Expression<Func<T, bool>> expression);
        Task AddAsnyc(T entity);
        Task AddRangeAsync(IEnumerable<T> entities);
        Task UpdateAsnyc(T entity);
        Task RemoveAsnyc(T entity);
        Task RemoveRangeAsync(IEnumerable<T> entities);

    }
}
