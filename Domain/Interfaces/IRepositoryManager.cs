namespace Domain.Interfaces
{
    public interface IRepositoryManager
    {
        IStudentRepositry StudentRepositry { get; }
        ISubjectRepositry SubjectRepositry { get; }
        IStudentSubjectRepositry StudentSubjectRepositry { get; }

        void Save();
    }
}
