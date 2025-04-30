
using Domain.Entities;
using Domain.Interfaces;
using Infrastructure.ApplicationDbContext;

namespace Infrastructure.Repositories
{
    public class SubjectRepository : RepositoryBase<Subject>, ISubjectRepositry
    {
        public SubjectRepository(DB db) : base(db)
        {
        }
    }
}
