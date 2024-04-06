using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using Redmine.Models;
using System.Collections.Generic;
using System.Linq;

namespace Redmine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {

        /*        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            // Ellenőrzés, hogy a felhasználónév és jelszó megtalálható-e a listában
            int matchCount = SampleData.Managers.Count(d => d.Email == loginRequest.Email && d.Password == loginRequest.Password);

            return Ok(new { MatchCount = matchCount });
        }   */

        // Projekt listázása
        [HttpGet]
        public IEnumerable<object> GetProjects()
        {
            return SampleData.Projects.Select(project => new { project.ProjectId, project.Name }).ToList();
        }

        // Projekt feladatok listázása
        [HttpGet("{projectId}/task")]
        public IEnumerable<object> GetProjectTasks(int projectId)
        {
            var tasks = SampleData.Tasks.Where(task => task.ProjectId == projectId);
            return tasks.Select(task => new { task.TaskId, task.Name }).ToList();
        }
    }
}
