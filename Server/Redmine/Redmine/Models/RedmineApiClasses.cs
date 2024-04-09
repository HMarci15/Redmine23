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

    class Tasks
    {
        public int TaskId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public int ProjectId { get; set; }
        public int UserId { get; set; }
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

     class SampleData
    {
        
        public  List<Manager> Managers { get; } = new List<Manager>
        {
            new Manager { ManagerId = 1, Name = "John Doe", Email = "john.doe@example.com", Password = "password123" },
            new Manager { ManagerId = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "securepassword" },
             new Manager { ManagerId = 3, Name = "Matyi marci", Email = "string", Password = "string" }
        };

        public  List<Developer> Developers { get; } = new List<Developer>
        {
            new Developer { DeveloperId = 1, Name = "Alice", Email = "alice@example.com" },
            new Developer { DeveloperId = 2, Name = "Bob", Email = "bob@example.com" }
        };

        public  List<Tasks> TasksList { get; } = new List<Tasks>
{
    new Tasks { TaskId = 1, Name = "Task 1", Description = "Description for Task 1", ProjectId = 1, UserId = 1, DeadLine = DateTime.Now },
    new Tasks { TaskId = 2, Name = "Task 2", Description = "Description for Task 2", ProjectId = 1, UserId = 2, DeadLine = DateTime.Now },
    new Tasks { TaskId = 3, Name = "Task 3", Description = "Description for Task 3", ProjectId = 2, UserId = 3, DeadLine = DateTime.Now }
};

        public  List<Project> Projects { get; } = new List<Project>
        {
            new Project { ProjectId = 1, Name = "Project A", TypeId = 1, Description = "Description for Project A" },
            new Project { ProjectId = 2, Name = "Project B", TypeId = 2, Description = "Description for Project B" }
        };

        public  List<ProjectType> ProjectTypes { get; } = new List<ProjectType>
        {
            new ProjectType { ProjectTypeId = 1, Name = "Type A" },
            new ProjectType { ProjectTypeId = 2, Name = "Type B" }
        };

        public  List<ProjectTypeDevelopers> ProjectTypeDevelopers { get; } = new List<ProjectTypeDevelopers>
        {
            new ProjectTypeDevelopers { DeveloperId = 1, ProjectId = 1 },
            new ProjectTypeDevelopers { DeveloperId = 2, ProjectId = 1 },
            new ProjectTypeDevelopers { DeveloperId = 1, ProjectId = 2 }
        };
    }
}
