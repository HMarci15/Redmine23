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

       private static SampleData _sampleData;

        public ProjectController()
        {
            if (_sampleData == null)
            {
                _sampleData = new SampleData();
            }
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

            foreach (var item in _sampleData.TasksList)
            {
                Console.WriteLine("task id: " + item.TaskId + " task name: " + item.Name);
            }

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
        // 4 put + get
        [HttpGet("Developers")]
        public IActionResult getDevelopers()
        {
            // Assuming UserId is a string representing developer name
            var dev = _sampleData.Developers.Select(dev => new { dev.DeveloperId,dev.Name }).ToList();

            return Ok(dev);
        }

        [HttpPost("{devId}/task")]
        public ActionResult<Tasks> CreateTask(int devId, Tasks model)
        {
            // Ellenőrizzük, hogy a projekthez tartozik-e ilyen azonosítójú projekt
            var project = _sampleData.Projects.FirstOrDefault(p => p.ProjectId == model.ProjectId);
            if (project == null)
            {
                return NotFound("Nem található ilyen azonosítójú projekt.");
            }

            // Ellenőrizzük, hogy a fejlesztő létezik-e a rendszerben
            var developer = _sampleData.Developers.FirstOrDefault(d => d.DeveloperId == devId);
            if (developer == null)
            {
                return BadRequest("Nem található ilyen nevű fejlesztő.");
            }

            // Új feladat létrehozása
            var newTask = new Tasks
            {
                TaskId = _sampleData.TasksList.Max(t => t.TaskId) + 1,
                Name = model.Name,
                Description = model.Description,
                ProjectId = model.ProjectId,
                UserId = model.UserId, // Fejlesztő azonosítója
                DeadLine = model.DeadLine
            };
            var ProjectDevelopers = new ProjectDeveloper
            {
                DeveloperId = devId,
                ProjectId = model.ProjectId
                 
            };
            _sampleData.TasksList.Add(newTask);
            _sampleData.ProjectDevelopers.Add(ProjectDevelopers);
            


            foreach (var item in _sampleData.ProjectDevelopers)
            {
                Console.WriteLine("Dev id: " + item.DeveloperId + " Project id: " + item.ProjectId);
            }
            Console.WriteLine("///");
            foreach (var item in _sampleData.TasksList)
            {
                Console.WriteLine("task id: " + item.TaskId + " task name: " + item.Name);
            }

            // Visszaadjuk az elkészült feladatot
            return Ok(newTask);

        }



        // 5

        [HttpGet("selfTask")]
        public IEnumerable<object> GetSelfTasks()
        {
            // Assuming UserId is a string representing developer name
            var currentUserTasks = _sampleData.TasksList.Where(t => t.UserId == 3);
            return currentUserTasks.Select(task => new { task.TaskId, task.Name }).ToList();
        }

        // 6
        [HttpGet("deadlineTask")]
        public IEnumerable<object> GetDeadlineTasks()
        {
            var deadlineTasks = _sampleData.TasksList.Where(t => t.DeadLine.Date == DateTime.Today);
            return deadlineTasks.Select(task => new { task.TaskId, task.Name, task.Description, task.DeadLine.Date }).ToList();
        }
    }
}

