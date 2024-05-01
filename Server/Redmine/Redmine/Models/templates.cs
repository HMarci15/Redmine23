using System.ComponentModel.DataAnnotations.Schema;

namespace Redmine.Models
{
    public class TaskModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int ManagerId { get; set; }
        public int ProjectId { get; set; }
    }
    public class DeveloperDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }


      
    }
    public class ManagerDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }

        public string Role { get; set; }

       
    }
    public class ProjectDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public int typeId { get; set; }

        public string Description { get; set; }

        public string ProjectTypeName { get; set; }

    }
    public class ProjectTypeDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

       
    }
    public class PtaskDto
    {

        public int Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }


        public int ProjectId { get; set; }

        public int ManagerId { get; set; }

        public DateTime Deadline { get; set; }

        
    }
}
