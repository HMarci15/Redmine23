using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Redmine.data;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Redmine.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string secretKey;

        public AuthController(DataContext context)
        {
            _context = context;
            secretKey = "bOblvLAvqTbsZJQy6oynX8ICePrkHlvFZxAc7DGLdhTm1HYO3U4gQiSWRMB3PuG7";
        }

        [HttpPost]
        [AllowAnonymous] // Mivel ez a bejelentkezési végpont, ne legyen rá szükség a bejelentkezésre
        [Route("Bejelentkezes")]
        public async Task<IActionResult> Login([FromBody] LoginModel model)
        {
            var foundManager = await _context.Managers.FirstOrDefaultAsync(m => m.Email == model.Email && m.Password == model.Password);

            if (foundManager == null)
            {
                return Unauthorized();
            }

            var token = GenerateToken(foundManager);
            return Ok(new { token });
        }

        public class LoginModel
        {
            public string Email { get; set; }
            public string Password { get; set; }
        }

        // JWT token generálása
        private string GenerateToken(Manager manager)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(secretKey);

            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.NameIdentifier, manager.Id.ToString()),
                    new Claim(ClaimTypes.Name, manager.Name),
                    // Ide adhatod hozzá a további szükséges adatokat
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token érvényességi ideje
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }


        //teszt
        [Authorize]
        [HttpGet("Lista")]     
        public async Task<IActionResult> GetSelfTasks()
        {
            var managerIdClaim = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            if (string.IsNullOrEmpty(managerIdClaim) || !int.TryParse(managerIdClaim, out int managerId))
            {
                return Unauthorized(new { message = "Unauthorized" });
            }

            // Felhasználóhoz tartozó feladatok lekérése
            var currentUserTasks = await _context.Tasks.Where(p => p.ManagerId == managerId).ToListAsync();
            return Ok(currentUserTasks.Select(task => new { task.Id, task.Name, task.Description, task.Deadline.Date }).ToList());
        }



    }
}
