using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redmine.data;

using Microsoft.EntityFrameworkCore;

namespace Redmine.Controllers
{
   
    
        [Route("api/[controller]")]
        [ApiController]
        public class TestController : ControllerBase
        {
        private readonly DataContext _context;

        public TestController(DataContext context)
        {
            _context = context;
        }


        [HttpGet]
        public IActionResult GetProjects()
        {
            var projects = _context.ProjectDevelopers
                .Select(p => new
                {
                    projectName =p.Project.Name,
                  developerName = p.Developer.Name
                })
                .ToList();

            return Ok(projects);
        }
    }
    
}
