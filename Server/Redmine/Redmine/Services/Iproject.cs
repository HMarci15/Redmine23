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

using System.Reflection;

namespace Redmine.Services
{
    public interface Iproject
    {
        Task <List<ProjectDto>>GetProjects();
    }
    public class ProjectService : Iproject
    {
        private readonly DataContext _context;
        public ProjectService(DataContext context)
        {
            _context = context;
        }


        public async Task<List<ProjectDto>> GetProjects()
        {
            var projects = await _context.Projects
                .Select(project => new ProjectDto
                {
                    Id = project.Id,
                    Name = project.Name,
                    Description = project.Description,
                    ProjectTypeName = project.Type.Name
                })
                .ToListAsync();

            return projects;
        }

    }
}
