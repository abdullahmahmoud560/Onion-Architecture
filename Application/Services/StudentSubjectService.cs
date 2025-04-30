

using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class StudentSubjectService
    {
        private readonly IStudentSubjectRepositry _studentsubjectRepositry;

        public StudentSubjectService(IStudentSubjectRepositry studentsubjectRepositry)
        {
            _studentsubjectRepositry = studentsubjectRepositry;
        }
        public async Task<List<StudentSubject>> GetAllStudentSubjectsAsync()
        {
            return (await _studentsubjectRepositry.GetAllAsync()).ToList();
        }
        public async Task<StudentSubject> GetStudentSubjectsByCondition(Func<StudentSubject, bool> func)
        {
            var result = await _studentsubjectRepositry.GetByConditionAsync(func);
            if (result != null)
            {
                return result;
            }
            throw new Exception("Subject not found");
        }

        public async Task AddStudentSubjectsAsync(StudentSubject student)
        {
            await _studentsubjectRepositry.AddAsync(student);
        }

        public async Task UpdateAsync(StudentSubject student)
        {
            await _studentsubjectRepositry.UpdateAsync(student);
        }
        public async Task DeleteSubject(Guid id)
        {
            await _studentsubjectRepositry.DeleteAsync(id);
        }
    }

}
