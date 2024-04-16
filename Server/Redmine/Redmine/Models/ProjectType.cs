using System;
using System.ComponentModel.DataAnnotations;

public class ProjectType
{
 
    public int Id { get; set; }

    public string Name { get; set; }
    
    //map

    public List<Project> Projects { get; set; }
}
