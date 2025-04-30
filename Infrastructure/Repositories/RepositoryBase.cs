

using Domain.Interfaces;
using Infrastructure.ApplicationDbContext;

namespace Infrastructure.Repositories
{
    public class RepositoryBase<T> : IRepositryBase<T> where T : class
    {
        private readonly DB _db;

        public RepositoryBase(DB db)
        {
            _db = db;
        }

        public async Task<IQueryable<T>> GetAllAsync()
        {
            return await Task.FromResult(_db.Set<T>().AsQueryable());  // استخدام Task.FromResult لتحويل IQueryable إلى Task
        }


        public async Task<T?> GetByConditionAsync(Func<T, bool> func)
        {
            return await Task.Run(() => _db.Set<T>().AsEnumerable().FirstOrDefault(func));  // استعلام باستخدام دالة شرطية
        }

        public async Task AddAsync(T entity)
        {
            await _db.Set<T>().AddAsync(entity);  // إضافة كائن جديد
            await _db.SaveChangesAsync();  // حفظ التغييرات في قاعدة البيانات
        }

        public async Task UpdateAsync(T entity)
        {
            _db.Set<T>().Update(entity);  // تحديث الكائن
            await _db.SaveChangesAsync();  // حفظ التغييرات
        }

        public async Task DeleteAsync(Guid id)  // تم تعديل id ليكون من نوع Guid
        {
            var entity = await _db.Set<T>().FindAsync(id);
            if (entity != null)
            {
                _db.Set<T>().Remove(entity);  // حذف الكائن
                await _db.SaveChangesAsync();  // حفظ التغييرات
            }
        }
    }
}
