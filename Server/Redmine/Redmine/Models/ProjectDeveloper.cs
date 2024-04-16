using System;
using System.ComponentModel.DataAnnotations.Schema;


public class ProjectDeveloper
{

    public int DeveloperId { get; set; }
    public int ProjectId { get; set; }

    [ForeignKey("DeveloperId")]
    public Developer Developer { get; set; }
    [ForeignKey("ProjectId")]
    public Project Project { get; set; }
}

