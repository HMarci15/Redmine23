using System;

public class Developer
{
    public int DeveloperId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public ICollection<ProjectDeveloper> ProjectDevelopers { get; set; }
}
