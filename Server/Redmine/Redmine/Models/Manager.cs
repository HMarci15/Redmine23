using System;

public class Manager
{
    public int ManagerId { get; set; }
    public string Name { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<Task> Tasks { get; set; }
}

