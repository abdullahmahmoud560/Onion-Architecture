

using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public sealed class SubjectService : ISubjectService
    {
        private readonly IRepositoryManager _repositoryManager;

        public SubjectService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
      
    }
}
