using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class StudentService
    {
        private readonly IStudentRepositry _studentRepositry;

        public StudentService(IStudentRepositry studentRepository)
        {
            _studentRepositry = studentRepository;
        }
        public async Task<List<Student>> GetAllStudentsAsync()
        {
            return (await _studentRepositry.GetAllAsync()).ToList();
        }
        public async Task<Student> GetStudentByCondition(Func<Student, bool> func)
        {
            var result = await _studentRepositry.GetByConditionAsync(func);
            if (result != null)
            {
                return result;
            }
            throw new Exception("Subject not found");
        }

        public async Task AddStudentAsync(Student student)
        {
            await _studentRepositry.AddAsync(student);
        }

        public async Task UpdateAsync(Student student)
        {
            await _studentRepositry.UpdateAsync(student);
        }
        public async Task DeleteSubject(Guid id)
        {
            await _studentRepositry.DeleteAsync(id);
        }
    }
}
