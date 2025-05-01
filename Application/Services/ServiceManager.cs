using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStudentService> _studentService;
        private readonly Lazy<ISubjectService> _subjectService;
        private readonly Lazy<IStudentSubjectService> _studentSubjectService;
        public ServiceManager(IRepositoryManager repository)
        {
            _studentService = new Lazy<IStudentService>(() => new StudentService(repository));
            _subjectService = new Lazy<ISubjectService>(() => new SubjectService(repository));
            _studentSubjectService = new Lazy<IStudentSubjectService>(() => new StudentSubjectService(repository));
        }

        public IStudentService StudentService => _studentService.Value;

        public ISubjectService SubjectService => _subjectService.Value;

        public IStudentSubjectService StudentSubjectService => _studentSubjectService.Value;

    }
}
