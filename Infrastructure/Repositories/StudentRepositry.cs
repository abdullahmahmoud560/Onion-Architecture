
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.ApplicationDbContext;

namespace Infrastructure.Repositories
{
    public sealed class StudentRepositry : RepositoryBase<Student>, IStudentRepositry
    {
        public StudentRepositry(DB db) : base(db)
        {
        }
        public IEnumerable<Student> GetAllStudents() => GetAllAsync().Result.ToList();

        public Student GetStudent(int companyId) => GetByConditionAsync(x => x.Id.Equals(companyId)).Result.ToList().FirstOrDefault()!;

    }
}
