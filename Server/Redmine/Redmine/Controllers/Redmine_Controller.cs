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


        // 1
        [HttpPost("login")]
        public IActionResult Login(string email, string password)
        {
            // Ellenőrzés, hogy a felhasználónév és jelszó megtalálható-e a listában
            var matchingManager = _sampleData.Managers.FirstOrDefault(d => d.Email == email && d.Password == password);

            if (matchingManager != null)
            {
                // Ha találtunk egyezést, visszaadjuk a felhasználó nevét
                return Ok(new { Name = matchingManager.Name });
            }
            else
            {
                // Ha nem találtunk egyezést, hibaüzenetet adunk vissza
                return BadRequest("Hibás Email vagy jelszó.");
            }
        }

        //2
        [HttpGet]
        public IActionResult GetProjects()
        {
            var projects = _sampleData.Projects
                .Select(project => new
                {
                    project.ProjectId,
                    project.Name,
                    project.Description,
                    ProjectTypeName = GetProjectTypeName(project.TypeId)
                })
                .ToList();

            return Ok(projects);
        }
        private string GetProjectTypeName(int projectTypeId)
        {
            var projectType = _sampleData.ProjectTypes.FirstOrDefault(pt => pt.ProjectTypeId == projectTypeId);
            return projectType != null ? projectType.Name : null;
        }

               //3
                      
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
                    ManagerName = GetManagerName(task.UserId)
                })
                .ToList();

            return Ok(tasks);
        }

        private string GetManagerName(int managerId)
        {
            var manager = _sampleData.Managers.FirstOrDefault(m => m.ManagerId == managerId);
            return manager != null ? manager.Name : null;
        }

                // 3+      
             /*
        [HttpGet("{projId}/task/{taskId}")]
        public IActionResult GetTaskDetails(int projId, int taskId)
        {
            var task = _sampleData.TasksList.FirstOrDefault(t => t.ProjectId == projId && t.TaskId == taskId);
            if (task == null)
                return NotFound();

            return Ok(new { task.TaskId, task.Name, task.Description, task.UserId, task.DeadLine });
        }
                */

         // 5
          
        [HttpGet("selfTask")]
        public IEnumerable<object> GetSelfTasks()
        {
            // Assuming UserId is a string representing developer name
            var currentUserTasks = _sampleData.TasksList.Where(t => t.UserId==3 );
            return currentUserTasks.Select(task => new { task.TaskId, task.Name }).ToList();
        }      

        // 6
        [HttpGet("deadlineTask")]
        public IEnumerable<object> GetDeadlineTasks()
        {
            var deadlineTasks = _sampleData.TasksList.Where(t => t.DeadLine.Date == DateTime.Today);
            return deadlineTasks.Select(task => new { task.TaskId, task.Name,task.Description, task.DeadLine.Date }).ToList();
        }
    }
}

