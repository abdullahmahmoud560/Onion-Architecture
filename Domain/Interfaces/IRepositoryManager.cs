using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
