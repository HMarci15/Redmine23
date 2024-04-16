namespace Redmine.Models
{
    public class TaskModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime Deadline { get; set; }
        public int ManagerId { get; set; }
        public int ProjectId { get; set; }
    }
}
