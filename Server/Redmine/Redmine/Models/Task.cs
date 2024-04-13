using System;

public class Tasks
{
    public int TaskId { get; set; }
    public string Name { get; set; }
    public string Description { get; set; }
    public Project Project { get; set; }
    public Manager Manager { get; set; }
    public DateTime DeadLine { get; set; }
}
