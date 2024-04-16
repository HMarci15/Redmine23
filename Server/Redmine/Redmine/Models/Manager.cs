using System;
using System.ComponentModel.DataAnnotations;

public class Manager
{
    
    public int Id { get; set; }

    public string Name { get; set; }

    public string Email { get; set; }

    public string Password { get; set; }

    //map
    public List<Task> Tasks { get; set; }
}


