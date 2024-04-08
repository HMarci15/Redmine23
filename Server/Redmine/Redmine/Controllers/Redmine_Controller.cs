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

       

        // Projekt listázása
        private readonly SampleData _sampleData;

        public ProjectController()
        {
            _sampleData = new SampleData();
        }

        [HttpPost("login")]
        public IActionResult Login([FromBody] LoginRequest loginRequest)
        {
            // Ellenőrzés, hogy a felhasználónév és jelszó megtalálható-e a listában
            var matchingManager = _sampleData.Managers.FirstOrDefault(d => d.Email == loginRequest.Email && d.Password == loginRequest.Password);

            if (matchingManager != null)
            {
                // Ha találtunk egyezést, visszaadjuk a felhasználó nevét
                return Ok(new { Name = matchingManager.Name });
            }
            else
            {
                // Ha nem találtunk egyezést, hibaüzenetet adunk vissza
                return BadRequest("Hibás felhasználónév vagy jelszó.");
            }
        }

        [HttpGet]
          public IEnumerable<object> GetProjects()
          {
              return _sampleData.Projects.Select(project => new { project.ProjectId, project.Name }).ToList();
          }

        [HttpGet("/project/{projectId}/tasks")]
        public IActionResult GetProjectTasks(int projectId)
        {
            var tasks = _sampleData.TasksList
                .Where(task => task.ProjectId == projectId)
                .Select(task => new
                {
                    task.TaskId,
                    task.Name,
                    task.Description,
                    task.DeadLine,
                    TaskTypeName = GetTaskTypeName(task.TaskId)
                })
                .ToList();

            return Ok(tasks);
        }

        private string GetTaskTypeName(int taskTypeId)
        {
            var taskType = _sampleData.ProjectTypes.FirstOrDefault(pt => pt.ProjectTypeId == taskTypeId);
            return taskType != null ? taskType.Name : null;
        }

        [HttpGet("{projId}/task/{taskId}")]
        public IActionResult GetTaskDetails(int projId, int taskId)
        {
            var task = _sampleData.TasksList.FirstOrDefault(t => t.ProjectId == projId && t.TaskId == taskId);
            if (task == null)
                return NotFound();

            return Ok(new { task.TaskId, task.Name, task.Description, task.UserId, task.DeadLine });
        }


        

        [HttpGet("{projId}/selfTask")]
        public IEnumerable<object> GetSelfTasks(int projId)
        {
            // Assuming UserId is a string representing developer name
            var currentUserTasks = _sampleData.TasksList.Where(t => t.ProjectId == projId && t.UserId == User.Identity.Name);
            return currentUserTasks.Select(task => new { task.TaskId, task.Name }).ToList();
        }

        [HttpGet("{projId}/deadlineTask")]
        public IEnumerable<object> GetDeadlineTasks(int projId)
        {
            var deadlineTasks = _sampleData.TasksList.Where(t => t.ProjectId == projId && t.DeadLine.Date == DateTime.Today);
            return deadlineTasks.Select(task => new { task.TaskId, task.Name }).ToList();
        }
    }
}

