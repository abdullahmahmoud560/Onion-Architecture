using Domain.Entities;

namespace Domain.Interfaces
{
    public interface IStudentRepositry
    {
        IEnumerable<Student> GetAllStudents();
        Student GetStudent(int companyId);

    }
}
