using Application.Interfaces;
using AutoMapper;
using Domain.Interfaces;
using static Shared.DataTransferObjects;

namespace Application.Services
{
    internal sealed class StudentService : IStudentService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly IMapper _mapper;
        private readonly ILoggerManager _logger;
        public StudentService(IRepositoryManager repositoryManager, IMapper mapper, ILoggerManager logger)
        {
            _repositoryManager = repositoryManager;
            _mapper = mapper;
            _logger = logger;
        }

        public IEnumerable<StudentDTO> GetAllStudents()
        {
            
            var students = _repositoryManager.StudentRepositry.GetAllStudents();
            var studentDTO = students.Select(c =>
            new StudentDTO(c.Email!, c.FirstName!,  c.lastName!)).ToList();
            return studentDTO;
           
        }

        public StudentDTO GetStudent(int companyId)
        {
            var student = _repositoryManager.StudentRepositry.GetStudent(companyId);
            var studentDTO = _mapper.Map<StudentDTO>(student);
            return studentDTO!;
        }
    }
}
