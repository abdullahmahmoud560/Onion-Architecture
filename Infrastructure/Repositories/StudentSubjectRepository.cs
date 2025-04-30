
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.ApplicationDbContext;

namespace Infrastructure.Repositories
{
    public class StudentSubjectRepository : RepositoryBase<StudentSubject>, IStudentSubjectRepositry
    {
        public StudentSubjectRepository(DB db) : base(db)
        {
        }
    }
}
