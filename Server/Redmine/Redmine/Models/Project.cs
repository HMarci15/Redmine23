using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Project
{
    
    public int Id { get; set; }

    public string Name { get; set; }

    public int typeId { get; set; }

    public string Description { get; set; }

        //map 
    [ForeignKey("typeId")]
    public ProjectType Type { get; set; }

    public List<Developer> Developers { get; set; }

    public List<Ptask> Tasks { get; set; }
}
