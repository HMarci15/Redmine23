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
               new Manager { Id = 1, Name = "Horvath Marcell", Email = "asd@asd.com", Password = "asd123" },
               new Manager { Id = 2, Name = "Kiss Csongor", Email = "dsa@dsa.com", Password = "dsa321" }
           );


            modelBuilder.Entity<Developer>().HasData(
                new Developer { Id = 1, Name = "Alice Johnson", Email = "alice.johnson@example.com" },
                new Developer { Id = 2, Name = "Bob Williams", Email = "bob.williams@example.com" },
                new Developer { Id = 3, Name = "Charlie Brown", Email = "charlie.brown@example.com" },
                new Developer { Id = 4, Name = "David Miller", Email = "david.miller@example.com" }
            );

            modelBuilder.Entity<ProjectType>().HasData(
                new ProjectType { Id = 1, Name = "Web Development" },
                new ProjectType { Id = 2, Name = "Mobile App Development" },
                new ProjectType { Id = 3, Name = "Data Analytics" },
                new ProjectType { Id = 4, Name = "E-commerce" }
            );

            modelBuilder.Entity<Project>().HasData(
                new Project { Id = 1, Name = "E-commerce Website", typeId = 1, Description = "Develop an e-commerce website for a clothing brand." },
                new Project { Id = 2, Name = "Mobile App - Task Manager", typeId = 2, Description = "Create a mobile app to manage tasks and schedules efficiently." },
                new Project { Id = 3, Name = "Data Analysis Dashboard", typeId = 3, Description = "Build a dashboard for analyzing sales data and trends." },
                new Project { Id = 4, Name = "Social Media Integration", typeId = 4, Description = "Integrate social media login and sharing features into existing platforms." }
            );

            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 1, Name = "Implement Payment Gateway", Description = "Integrate Stripe payment gateway for secure online transactions.", ProjectId = 1, ManagerId = 1, Deadline = DateTime.Now.AddDays(14) },
                new Task { Id = 2, Name = "User Authentication", Description = "Implement user authentication using JWT for the mobile app.", ProjectId = 2, ManagerId = 2, Deadline = DateTime.Now.AddDays(10) },
                new Task { Id = 3, Name = "Data Visualization", Description = "Create interactive charts and graphs for visualizing sales data.", ProjectId = 3, ManagerId = 1, Deadline = DateTime.Now.AddDays(21) },
                new Task { Id = 4, Name = "Social Media Login", Description = "Allow users to log in using their social media accounts.", ProjectId = 4, ManagerId = 2, Deadline = DateTime.Now.AddDays(7) }
            );


            modelBuilder.Entity<ProjectDeveloper>().HasData(
                new ProjectDeveloper { DeveloperId = 1, ProjectId = 1 },
                new ProjectDeveloper { DeveloperId = 2, ProjectId = 2 }
            );
        }


    }
}
