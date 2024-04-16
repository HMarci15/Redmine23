using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;

using System.Collections.Generic;
using System.Linq;
using Redmine.data;
using Redmine.Models;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Redmine.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ProjectController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly JsonSerializerOptions _jsonOptions;

        public ProjectController(DataContext context)
        {
            _context = context;
            _jsonOptions = new JsonSerializerOptions
            {
                ReferenceHandler = ReferenceHandler.Preserve,
                // Egyéb beállítások, ha szükséges
            };
        }

        
        

      //2
      [HttpGet]
      public IActionResult GetProjects()
      {
          var projects = _context.Projects
              .Select(project => new
              {
                  project.Id,
                  project.Name,
                  project.Description,
                  ProjectTypeName = project.Type.Name
              })
              .ToList();

          return Ok(projects);
      }
      

      //3

      [HttpGet("/project/{projectId}/tasks")]
      public IActionResult GetProjectTasks(int projectId)
      {
          var tasks = _context.Tasks
              .Where(task => task.ProjectId == projectId)
              .Select(task => new
              {
                  task.Id,
                  task.Name,
                  task.Description,
                  task.Deadline,
                  ManagerName = task.Manager.Name
              })
              .ToList();

          

          return Ok(tasks);
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
          var dev = _context.Developers.Select(dev => new { dev.Id,dev.Name }).ToList();

          return Ok(dev);
      }


        [HttpPost("{devId}/task")]
        public ActionResult<Task> CreateTask(int devId, TaskModel model)
        {
            // Ellenőrizzük, hogy a projekthez tartozik-e ilyen azonosítójú projekt
            var project = _context.Projects.FirstOrDefault(p => p.Id == model.ProjectId);
            if (project == null)
            {
                return NotFound("Nem található ilyen azonosítójú projekt.");
            }
            

            // Ellenőrizzük, hogy a fejlesztő létezik-e a rendszerben
            var developer = _context.Developers.FirstOrDefault(d => d.Id == devId);
            if (developer == null)
            {
                return BadRequest("Nem található ilyen nevű fejlesztő.");
            }
            var isDeveloperAssigned = _context.ProjectDevelopers.Any(pd => pd.DeveloperId == devId && pd.ProjectId == model.ProjectId);
            if (isDeveloperAssigned)
            {
                return Conflict("A megadott fejlesztő már hozzá van rendelve ehhez a projekthez.");
            }

            // Új feladat létrehozása
            var newTask = new Task
            {
                Id = _context.Tasks.Max(t => t.Id) + 1,
                Name = model.Name,
                Description = model.Description,
                ProjectId = model.ProjectId,
                ManagerId = model.ManagerId, // Fejlesztő azonosítója
                Deadline = model.Deadline
            };

            var projectDeveloper = new ProjectDeveloper
            {
                ProjectId = project.Id,
                DeveloperId = developer.Id
            };
            
            // Hozzáadjuk az új feladatot a feladatokhoz
            _context.Tasks.Add(newTask);
            _context.ProjectDevelopers.Add(projectDeveloper);
            // Hozzáadjuk a ProjectDevelopers táblához az új rekordot


            // Mentjük a változásokat az adatbázisba
            _context.SaveChanges();

            var serializedTask = JsonSerializer.Serialize(newTask, _jsonOptions);
            return Content(serializedTask, "application/json");
        }



        // 5        autentikáció

        [HttpGet("selfTask")]
       public IEnumerable<object> GetSelfTasks()
       {
           // Assuming UserId is a string representing developer name
           var currentUserTasks = _context.Tasks.Where(t => t.ManagerId == 2);
           return currentUserTasks.Select(task => new { task.Id, task.Name }).ToList();
       }

       // 6  autentikáció
       [HttpGet("deadlineTask")]
       public IEnumerable<object> GetDeadlineTasks()
       {
           var deadlineTasks = _context.Tasks.Where(t => t.Deadline.Date == DateTime.Today.AddDays(10));

            if (deadlineTasks != null)
            {
                return deadlineTasks.Select(task => new { task.Id, task.Name, task.Description, task.Deadline.Date }).ToList();
            }else
            {
                return new List<object> { new { Message = "Nincs elérhető feladat ma." } };
            }
           
       }     
    }

}

