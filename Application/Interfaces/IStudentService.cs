using static Shared.DataTransferObjects;

namespace Application.Interfaces
{
    public interface IStudentService
    {
        IEnumerable<StudentDTO> GetAllStudents();
        StudentDTO GetStudent(int companyId);

    }
}
