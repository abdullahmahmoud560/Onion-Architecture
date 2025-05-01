using Domain.Interfaces;
using Infrastructure.ApplicationDbContext;

namespace Infrastructure.Repositories
{
    public class RepositoryManager : IRepositoryManager
    {
        private readonly DB _db;
        private readonly Lazy<IStudentRepositry> _studentRepositry;
        private readonly Lazy<ISubjectRepositry> _subjectRepositry;
        private readonly Lazy<IStudentSubjectRepositry> _studentSubjectRepositry;

        public RepositoryManager(DB db)
        {
            _db = db;
            _studentRepositry = new Lazy<IStudentRepositry>(() => new StudentRepositry(_db));
            _subjectRepositry = new Lazy<ISubjectRepositry>(() => new SubjectRepository(_db));
            _studentSubjectRepositry = new Lazy<IStudentSubjectRepositry>(() => new StudentSubjectRepository(_db));  
        }

        public IStudentRepositry StudentRepositry => _studentRepositry.Value;

        public ISubjectRepositry SubjectRepositry => _subjectRepositry.Value;

        public IStudentSubjectRepositry StudentSubjectRepositry => _studentSubjectRepositry.Value;

        public void Save() => _db.SaveChanges();
    }
}
