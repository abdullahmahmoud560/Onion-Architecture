

using Application.Interfaces;
using Domain.Interfaces;

namespace Application.Services
{
    public sealed class StudentSubjectService : IStudentSubjectService
    {
        private readonly IRepositoryManager _repositoryManager;

        public StudentSubjectService(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }
       
    }

}
