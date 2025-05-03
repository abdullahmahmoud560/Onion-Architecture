

using System.Linq.Expressions;
using Domain.Interfaces;
using Infrastructure.ApplicationDbContext;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
    public abstract class RepositoryBase <T> : IRepositryBase<T> where T : class
    {
        private readonly DB _db;

        public RepositoryBase(DB db)
        {
            _db = db;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(_db.Set<T>().AsQueryable());
        }

        public async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);  
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Set<T>().Update(entity);  
        }

        public async Task<IQueryable<T>> GetByConditionAsync(Expression<Func<T, bool>> func)
        {
            return await Task.FromResult(_db.Set<T>().Where(func));
        }




        public async Task DeleteAsync(T entity)
        {
            _db.Set<T>().Remove(entity);
        }

    }
}
