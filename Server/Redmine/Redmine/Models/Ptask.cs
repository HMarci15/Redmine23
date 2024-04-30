using System;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

public class Ptask
{
    
    public int Id { get; set; }

    public string Name { get; set; }

    public string Description { get; set; }

   
     public  int ProjectId { get; set; }

    public int ManagerId { get; set; }
   
    public DateTime Deadline { get; set; }

    //map 
    [ForeignKey("ProjectId")]
    public Project Project { get; set; }
    [ForeignKey("ManagerId")]
    public Manager Manager { get; set; }
}
