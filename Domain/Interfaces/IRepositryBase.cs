

namespace Domain.Interfaces
{
    public interface IRepositryBase<T> where T : class
    {
        Task<IQueryable<T>> GetAllAsync();
        Task<T?> GetByConditionAsync(Func<T,bool> func);
        Task AddAsync(T product);
        Task UpdateAsync(T product);
        Task DeleteAsync(Guid id);
    }

}
