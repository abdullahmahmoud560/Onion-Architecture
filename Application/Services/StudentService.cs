using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    internal  sealed class StudentService : IStudentService
    {
        private readonly IRepositoryManager _repositoryManager;
        public StudentService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
    }
}
