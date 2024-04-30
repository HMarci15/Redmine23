using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Redmine.data;
using Redmine.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Data.Entity;
using System.Reflection;

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
        [Authorize]
        public IActionResult GetProjects()
        {
            var managerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(managerIdClaim) || !int.TryParse(managerIdClaim, out int managerId))
            {
                return Unauthorized(new { message = "Unauthorized" });
            }

            var projects = _context.Projects
                .Select(project => new
                {
                    project.Id,
                    project.Name,
                    project.Description,
                    ProjectTypeName = project.Type.Name
                })
                .ToList();

            if (projects.Any())
            {
                return Ok(projects);
            }
            else
            {
                return NotFound(new { Message = "Nincs elérhető projekt." });
            }
        }


        //3

        [HttpGet("/project/{projectId}/tasks")]
        [Authorize]
        public IActionResult GetProjectTasks(int projectId)
        {
            var managerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(managerIdClaim) || !int.TryParse(managerIdClaim, out int managerId))
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
            var tasks =  _context.Tasks
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
        [Authorize]
      public IActionResult getDevelopers()
        {
            var managerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(managerIdClaim) || !int.TryParse(managerIdClaim, out int managerId))
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
            // Assuming UserId is a string representing developer name
            var dev =  _context.Developers.Select(dev => new { dev.Id,dev.Name }).ToList();

          return Ok(dev);
      }


        [HttpPost("{devId}/task")]
        [Authorize]
        public ActionResult<Task> CreateTask(int devId, TaskModel model)
        {
            var managerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(managerIdClaim) || !int.TryParse(managerIdClaim, out int managerId))
            {
                return Unauthorized(new { message = "Unauthorized" });
            }

            // Ellenőrizzük, hogy a projekthez tartozik-e ilyen azonosítójú projekt
            var project =  _context.Projects.FirstOrDefault(p => p.Id == model.ProjectId);
            if (project == null)
            {
                return NotFound("Nem található ilyen azonosítójú projekt.");
            }

            // Ellenőrizzük, hogy a fejlesztő létezik-e a rendszerben
            var developer =  _context.Developers.FirstOrDefault(d => d.Id == devId);
            if (developer == null)
            {
                return BadRequest("Nem található ilyen nevű fejlesztő.");
            }
            var isDeveloperAssigned =  _context.ProjectDevelopers.Any(pd => pd.DeveloperId == devId && pd.ProjectId == model.ProjectId);
            
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
                ManagerId = managerId, // Fejlesztő azonosítója
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

            // Mentjük a változásokat az adatbázisba
             _context.SaveChanges();

            var serializedTask = JsonSerializer.Serialize(newTask, _jsonOptions);
            return Content(serializedTask, "application/json");
        }



        // 5        autentikáció

        [HttpGet("selfTask")]
        [Authorize]
        public ActionResult GetSelfTasks()
        {
            var managerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(managerIdClaim) || !int.TryParse(managerIdClaim, out int managerId))
            {
                return Unauthorized(new { message = "Unauthorized" });
            }else if(ClaimTypes.Role == "Admin")
            {
                var adminAllTasks = _context.Tasks.Select(tasks => new { tasks.Id, tasks.Name, tasks.Description, tasks.Deadline.Date }).ToList();
                return Ok(adminAllTasks);
            }else if(ClaimTypes.Role =="Manager")
            {
                     var currentUserTasks =  _context.Tasks.Where(t => t.ManagerId == managerId).Select(task => new { task.Id, task.Name, task.Description, task.Deadline.Date }).ToList();
            return Ok(currentUserTasks);
            }

            return BadRequest("Hibás valami !");
           
           

        }       

       // 6  autentikáció
       [HttpGet("deadlineTask")]
        public ActionResult GetDeadLineTasks()
        {
            var managerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(managerIdClaim) || !int.TryParse(managerIdClaim, out int managerId))
            {
                return Unauthorized(new { message = "Unauthorized" });
            }
            var deadlineTasks =  _context.Tasks
                .Where(t => t.Deadline.Date < DateTime.Today.AddDays(3)&& t.ManagerId == managerId )
                .Select(task => new { task.Id, task.Name, task.Description, date = task.Deadline.Date })
                .ToList();

            if (deadlineTasks.Any())
            {
                return Ok(deadlineTasks);
            }
            else
            {
                return NotFound(new { Message = "Nincs elérhető feladat ma." });
            }
        }
    }

}

