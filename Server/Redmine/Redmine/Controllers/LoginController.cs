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
            // Ellen�rz�s, hogy a felhaszn�l�n�v �s jelsz� megtal�lhat�-e a list�ban
            var matchingManager = _context.Managers.FirstOrDefault(d => d.Email == email && d.Password == password);

            if (matchingManager != null)
            {
                // Ha tal�ltunk egyez�st, visszaadjuk a felhaszn�l� nev�t
                return Ok(new { id = matchingManager.Id, Name = matchingManager.Name });
            }
            else
            {
                // Ha nem tal�ltunk egyez�st, hiba�zenetet adunk vissza
                return BadRequest("Hib�s Email vagy jelsz�.");
            }
        }
    }
}