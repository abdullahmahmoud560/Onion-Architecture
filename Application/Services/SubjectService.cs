

using Domain.Entities;
using Domain.Interfaces;

namespace Application.Services
{
    public class SubjectService
    {
        private readonly ISubjectRepositry _subjectRepository;

        public SubjectService(ISubjectRepositry subjectRepository)
        {
            _subjectRepository = subjectRepository;
        }
        public async Task<List<Subject>> GetAllSubjectsAsync()
        {
            return (await _subjectRepository.GetAllAsync()).ToList();
        }
        public async Task<Subject> GetSubjectByCondition(Func<Subject , bool> func)
        {
            var result = await _subjectRepository.GetByConditionAsync(func);
            if (result != null)
            {
                return result;
            }
            throw new Exception("Subject not found");
        }

        public async Task AddSubjectAsync(Subject subject)
        {
            await _subjectRepository.AddAsync(subject);
        }

        public async Task UpdateAsync(Subject subject)
        {
            await _subjectRepository.UpdateAsync(subject);
        }
        public async Task DeleteSubject(Guid  id)
        {
            await _subjectRepository.DeleteAsync(id);
        }

    }
}
