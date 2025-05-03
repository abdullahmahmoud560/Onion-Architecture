using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;

namespace Application.Services
{
    public sealed class ServiceManager : IServiceManager
    {
        private readonly Lazy<IStudentService> _studentService;
        private readonly Lazy<ISubjectService> _subjectService;
        private readonly Lazy<IStudentSubjectService> _studentSubjectService;
        public ServiceManager(IRepositoryManager repository, ILoggerManager logger, IMapper mapper)
        {
            _studentService = new Lazy<IStudentService>(() => new StudentService(repository ,mapper, logger));
            _subjectService = new Lazy<ISubjectService>(() => new SubjectService(repository,logger));
            _studentSubjectService = new Lazy<IStudentSubjectService>(() => new StudentSubjectService(repository, logger));
        }

        public IStudentService StudentService => _studentService.Value;

        public ISubjectService SubjectService => _subjectService.Value;

        public IStudentSubjectService StudentSubjectService => _studentSubjectService.Value;

    }
}
