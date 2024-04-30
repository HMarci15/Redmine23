using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

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
               new Manager { Id = 1, Name = "Horvath Marcell", Email = "marci@asd.com", Password = "43a66ace8a1f1f19ae8808a1f0a3ebb2fb4f292b25bed512cd6d4ae1bc8c1632", Role = "Manager" },   // marci123
               new Manager { Id = 2, Name = "Kiss Csongor", Email = "csongor@asd.com", Password = "8265a0b34b15f6b779fbd02198dfd7520d28829b7e1440b39f100cefe465b526", Role = "Admin" }, // csongor123 
               new Manager { Id = 3, Name = "Biliboc Bence", Email = "bence@asd.com", Password = "50289f2d6d5c448d3c33a42beb9d45b0b847259276fe873d52c99f187d81e782", Role = "Manager" }  // bence123
           );


            modelBuilder.Entity<Developer>().HasData(
                new Developer { Id = 1, Name = "Kukk Péter", Email = "kukk@peter.com" },
                new Developer { Id = 2, Name = "Milei Örs", Email = "milei@ors.com" },
                new Developer { Id = 3, Name = "Frits Márton", Email = "frits@marton.com" },
                new Developer { Id = 4, Name = "Horváth Ádám", Email = "horvath@adam.com" }
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
                new Project { Id = 4, Name = "Social Media Integration", typeId = 4, Description = "Integrate social media login and sharing features into existing platforms." },
                 new Project { Id = 5, Name = "Redmine Kliens ", typeId = 4, Description = "Redmine kliens fejlesztés" },
                 new Project { Id = 6, Name = "Redmine Szerver ", typeId = 4, Description = "Redmine szerver fejlesztés" }

            );

            modelBuilder.Entity<Task>().HasData(
                new Task { Id = 1, Name = "Implement Payment Gateway", Description = "Integrate Stripe payment gateway for secure online transactions.", ProjectId = 1, ManagerId = 1, Deadline = DateTime.Now.AddDays(14).Date },
                new Task { Id = 2, Name = "User Authentication", Description = "Implement user authentication using JWT for the mobile app.", ProjectId = 2, ManagerId = 2, Deadline = DateTime.Now.AddDays(10).Date },
                new Task { Id = 3, Name = "Data Visualization", Description = "Create interactive charts and graphs for visualizing sales data.", ProjectId = 3, ManagerId = 1, Deadline = DateTime.Now.AddDays(21).Date },
                new Task { Id = 4, Name = "Social Media Login", Description = "Allow users to log in using their social media accounts.", ProjectId = 4, ManagerId = 2, Deadline = DateTime.Now.AddDays(7).Date }

            );


           
        }


    }
}
