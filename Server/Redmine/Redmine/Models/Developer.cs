using System;
using System.ComponentModel.DataAnnotations;

public class Developer
{
    
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }


    //map

    public List<Project> Projects { get; set; }
}
