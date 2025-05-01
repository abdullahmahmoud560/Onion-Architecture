namespace Application.Interfaces
{
    public interface IServiceManager
    {
        public IStudentService StudentService { get; }
        public ISubjectService SubjectService { get; }
        public IStudentSubjectService StudentSubjectService { get; }
    }
}
