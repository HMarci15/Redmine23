using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redmine.Services;

namespace Redmine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        private readonly Iproject _Iproject;

        public ValuesController(Iproject cartService)
        {
            _Iproject = cartService;
        }

        [HttpGet]
        public async Task<IActionResult> GetProjects()
        {
           var project = await _Iproject.GetProjects();
            return Ok(project);

        }
    }
}
