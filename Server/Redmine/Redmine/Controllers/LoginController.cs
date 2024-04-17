using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Redmine.data;

namespace Redmine.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;

        public LoginController(DataContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult Login(string email, string password)
        {
            // Ellenõrzés, hogy a felhasználónév és jelszó megtalálható-e a listában
            var matchingManager = _context.Managers.FirstOrDefault(d => d.Email == email && d.Password == password);

            if (matchingManager != null)
            {
                // Ha találtunk egyezést, visszaadjuk a felhasználó nevét
                return Ok(new { id = matchingManager.Id, Name = matchingManager.Name });
            }
            else
            {
                // Ha nem találtunk egyezést, hibaüzenetet adunk vissza
                return BadRequest("Hibás Email vagy jelszó.");
            }
        }
    }
}