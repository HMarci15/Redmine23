using Microsoft.EntityFrameworkCore;

namespace Redmine.data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }


        public DbSet<Manager> Managers { get; set; }
        public DbSet<Developer> Developers { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<Task> Tasks { get; set; }
        public DbSet<ProjectDeveloper> ProjectDevelopers { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Project>()
                 .HasMany(p => p.Developers)
                 .WithMany(p => p.Projects)
                 .UsingEntity<ProjectDeveloper>();



            modelBuilder.Entity<Manager>().HasData(
               new Manager { Id = 1, Name = "John Doe", Email = "john.doe@example.com", Password = "password123" },
               new Manager { Id = 2, Name = "Jane Smith", Email = "jane.smith@example.com", Password = "password456" }
           );

            modelBuilder.Entity<Developer>().HasData(
                new Developer { Id = 1, Name = "Alice Johnson", Email = "alice.johnson@example.com" },
                new Developer { Id = 2, Name = "Bob Williams", Email = "bob.williams@example.com" }
            );

            modelBuilder.Entity<ProjectType>().HasData(
                new ProjectType { Id = 1, Name = "Type A" },
                new ProjectType { Id = 2, Name = "Type B" }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "Project 1", typeId = 1, Description = "Description for Project 1" },
                new Project { Id = 2, Name = "Project 2", typeId = 2, Description = "Description for Project 2" }
            );

            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 1, Name = "Task 1", Description = "Description for Task 1", ProjectId = 1, ManagerId = 1, Deadline = DateTime.Now.AddDays(7) },
                new Task { Id = 2, Name = "Task 2", Description = "Description for Task 2", ProjectId = 2, ManagerId = 2, Deadline = DateTime.Now.AddDays(14) }
            );

            modelBuilder.Entity<ProjectDeveloper>().HasData(
                new ProjectDeveloper { DeveloperId = 1, ProjectId = 1 },
                new ProjectDeveloper { DeveloperId = 2, ProjectId = 2 }
            );
        }


    }
}
