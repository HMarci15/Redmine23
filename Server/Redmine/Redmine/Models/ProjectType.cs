using System;

public class ProjectType
{
    public int ProjectTypeId { get; set; }
    public string Name { get; set; }

    public ICollection<Project> Project { get; set;}
}
