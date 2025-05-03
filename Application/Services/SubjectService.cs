

using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public sealed class SubjectService : ISubjectService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _logger;

        public SubjectService(IRepositoryManager repositoryManager,ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _logger = logger;
        }
      
    }
}
