

using System.Linq.Expressions;

namespace Domain.Interfaces
{
    public interface IRepositryBase<T>
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<IQueryable<T>> GetByConditionAsync(Expression<Func<T,bool>> func);
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }

}
