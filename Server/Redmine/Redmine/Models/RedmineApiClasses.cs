using System;
using System.Collections.Generic;

namespace Redmine.Models
{
    class Manager
    {
        public int ManagerId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }

    class Developer
    {
        public int DeveloperId { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
    }

    class Taskx
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public string UserId { get; set; }
        public DateTime DeadLine { get; set; }
    }

    class Project
    {
        public int ProjectId { get; set; }
        public string Name { get; set; }
        public int TypeId { get; set; }
        public string Description { get; set; }
    }

    class ProjectType
    {
        public int ProjectTypeId { get; set; }
        public string Name { get; set; }
    }

    class ProjectTypeDevelopers
    {
        public int DeveloperId { get; set; }
        public int ProjectId { get; set; }
    }

    static class SampleData
    {
        
        public static List<Manager> Managers { get; } = new List<Manager>
        {
            new Manager { ManagerId = 1, Name = "John Doe", Email = "john.doe@example.com", Password = "password123" },
            new Manager { ManagerId = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "securepassword" }
        };

        public static List<Developer> Developers { get; } = new List<Developer>
        {
            new Developer { DeveloperId = 1, Name = "Alice", Email = "alice@example.com" },
            new Developer { DeveloperId = 2, Name = "Bob", Email = "bob@example.com" }
        };

        public static List<Taskx> Tasks { get; } = new List<Taskx>
        {
            new Taskx { TaskId = 1, Name = "Task 1", Description = "Description for Task 1", ProjectId = 1, UserId = "Alice", DeadLine = DateTime.Now.AddDays(7) },
            new Taskx { TaskId = 2, Name = "Task 2", Description = "Description for Task 2", ProjectId = 1, UserId = "Bob", DeadLine = DateTime.Now.AddDays(14) },
            new Taskx { TaskId = 3, Name = "Task 3", Description = "Description for Task 3", ProjectId = 2, UserId = "Alice", DeadLine = DateTime.Now.AddDays(10) }
        };

        public static List<Project> Projects { get; } = new List<Project>
        {
            new Project { ProjectId = 1, Name = "Project A", TypeId = 1, Description = "Description for Project A" },
            new Project { ProjectId = 2, Name = "Project B", TypeId = 2, Description = "Description for Project B" }
        };

        public static List<ProjectType> ProjectTypes { get; } = new List<ProjectType>
        {
            new ProjectType { ProjectTypeId = 1, Name = "Type A" },
            new ProjectType { ProjectTypeId = 2, Name = "Type B" }
        };

        public static List<ProjectTypeDevelopers> ProjectTypeDevelopers { get; } = new List<ProjectTypeDevelopers>
        {
            new ProjectTypeDevelopers { DeveloperId = 1, ProjectId = 1 },
            new ProjectTypeDevelopers { DeveloperId = 2, ProjectId = 1 },
            new ProjectTypeDevelopers { DeveloperId = 1, ProjectId = 2 }
        };
    }
}
