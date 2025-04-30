
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.ApplicationDbContext;

namespace Infrastructure.Repositories
{
    public class StudentRepositry : RepositoryBase<Student>, IStudentRepositry
    {
        public StudentRepositry(DB db) : base(db)
        {
        }
    }
}
