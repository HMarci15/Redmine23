using System;

public class Project
{
    public int ProjectId { get; set; }
    public string Name { get; set; }
    public int TypeId { get; set; }
    public string Description { get; set; }
    public ICollection<Task> Tasks { get; set;}
    public ICollection<ProjectDeveloper> ProjectDeveloper { get; set;  }
    public ProjectType ProjectType { get; set; }
}
