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
    [Route("[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly string secretKey;

        public LoginController(DataContext context)
        {
            _context = context;
            secretKey = "bOblvLAvqTbsZJQy6oynX8ICePrkHlvFZxAc7DGLdhTm1HYO3U4gQiSWRMB3PuG7";
        }

        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login(string email, string password)
        {
            var foundManager =  _context.Managers.FirstOrDefault(m => m.Email == email && m.Password == password);

            if (foundManager == null)
            {
                return Unauthorized();
            }

            var token = GenerateToken(foundManager);
            return Ok(new { token,foundManager.Name, foundManager.Role });
        }

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
                    new Claim(ClaimTypes.Role, manager.Role)
                    // Ide adhatod hozzá a további szükséges adatokat
                }),
                Expires = DateTime.UtcNow.AddHours(1), // Token érvényességi ideje
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };

            var token = tokenHandler.CreateToken(tokenDescriptor);
            return tokenHandler.WriteToken(token);
        }
    }
}