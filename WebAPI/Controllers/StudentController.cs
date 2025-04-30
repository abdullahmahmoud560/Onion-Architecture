using Application.Services;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using WebAPI.Models;

namespace WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly SubjectService _subjectService;

        public StudentController(SubjectService subjectService)
        {
            _subjectService = subjectService;
        }

        [HttpGet]
        public async Task<ActionResult<IQueryable<Subject>>> GetUsers()
        {
            var users = await _subjectService.GetAllSubjectsAsync();
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
            await _subjectService.AddSubjectAsync(subjectEntity);
            return Ok(subjectEntity);
        }

        [HttpPost("Update")]
        public async Task<ActionResult> ByCondition([FromBody] SubjectDTO subject)
        {
           var result = await _subjectService.GetSubjectByCondition(x => x.course_Name == subject.course_Name);
           
            return Ok(result);
        }
    }
}
