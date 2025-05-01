using Domain.Entities;
using Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly IRepositoryManager _repositoryManager;

        public StudentController(IRepositoryManager repositoryManager)
        {
            _repositoryManager = repositoryManager;
        }

        [HttpGet]
        public async Task<ActionResult<IQueryable<Student>>> GetUsers()
        {
            var users = await _repositoryManager.StudentRepositry.GetAllAsync();
            return Ok(users); 
        }

        [HttpPost]
        public async Task<ActionResult> AddUser([FromBody] SubjectDTO subject)
        {
            if (subject == null)
            {
                return BadRequest("Invalid user data.");
            }
            var subjectEntity = new Subject
            {
                Id = Guid.NewGuid().ToString(), 
                course_Name = subject.course_Name,
                hours = subject.hours,
                grade = subject.grade
            };
            await _repositoryManager.SubjectRepositry.AddAsync(subjectEntity);
            _repositoryManager.Save();
            return Ok(subjectEntity);
        }

        [HttpPost("Condition")]
        public async Task<ActionResult> ByCondition([FromBody] SubjectDTO subject)
        {
           var result = await _repositoryManager.SubjectRepositry.GetByConditionAsync(x => x.course_Name == subject.course_Name);
            return Ok(result);
        }

        [HttpPost("Update")]
        public async Task<IActionResult> Update(string name, string id )
        {
            var subject = new Subject
            {
                Id= id,
                course_Name = name
            };
            await _repositoryManager.SubjectRepositry.UpdateAsync(subject);
            _repositoryManager.Save();
            return Ok(subject);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(string id)
        {
            var subject = await _repositoryManager.StudentRepositry.GetByConditionAsync(x => x.Id == int.Parse(id)); 
            if (subject == null || !subject.Any()) 
            {
                return NotFound();
            }

            var subjectToDelete = subject.FirstOrDefault(); 
            await _repositoryManager.StudentRepositry.DeleteAsync(subjectToDelete!);
            _repositoryManager.Save();
            return NoContent();  
        }

    }
}
