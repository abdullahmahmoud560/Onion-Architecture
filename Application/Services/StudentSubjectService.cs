

using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public sealed class StudentSubjectService : IStudentSubjectService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public StudentSubjectService(IRepositoryManager repositoryManager,ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }
       
    }

}
