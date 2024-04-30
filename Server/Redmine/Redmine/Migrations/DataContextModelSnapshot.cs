﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Redmine.data;

#nullable disable

namespace Redmine.Migrations
{
    [DbContext(typeof(DataContext))]
    partial class DataContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "8.0.4");

            modelBuilder.Entity("Developer", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Developers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "kukk@peter.com",
                            Name = "Kukk Péter"
                        },
                        new
                        {
                            Id = 2,
                            Email = "milei@ors.com",
                            Name = "Milei Örs"
                        },
                        new
                        {
                            Id = 3,
                            Email = "frits@marton.com",
                            Name = "Frits Márton"
                        },
                        new
                        {
                            Id = 4,
                            Email = "horvath@adam.com",
                            Name = "Horváth Ádám"
                        });
                });

            modelBuilder.Entity("Manager", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Password")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Role")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("Managers");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Email = "marci@asd.com",
                            Name = "Horvath Marcell",
                            Password = "43a66ace8a1f1f19ae8808a1f0a3ebb2fb4f292b25bed512cd6d4ae1bc8c1632",
                            Role = "Manager"
                        },
                        new
                        {
                            Id = 2,
                            Email = "csongor@asd.com",
                            Name = "Kiss Csongor",
                            Password = "8265a0b34b15f6b779fbd02198dfd7520d28829b7e1440b39f100cefe465b526",
                            Role = "Admin"
                        },
                        new
                        {
                            Id = 3,
                            Email = "bence@asd.com",
                            Name = "Biliboc Bence",
                            Password = "50289f2d6d5c448d3c33a42beb9d45b0b847259276fe873d52c99f187d81e782",
                            Role = "Manager"
                        });
                });

            modelBuilder.Entity("Project", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("typeId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("typeId");

                    b.ToTable("Projects");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Description = "Develop an e-commerce website for a clothing brand.",
                            Name = "E-commerce Website",
                            typeId = 1
                        },
                        new
                        {
                            Id = 2,
                            Description = "Create a mobile app to manage tasks and schedules efficiently.",
                            Name = "Mobile App - Task Manager",
                            typeId = 2
                        },
                        new
                        {
                            Id = 3,
                            Description = "Build a dashboard for analyzing sales data and trends.",
                            Name = "Data Analysis Dashboard",
                            typeId = 3
                        },
                        new
                        {
                            Id = 4,
                            Description = "Integrate social media login and sharing features into existing platforms.",
                            Name = "Social Media Integration",
                            typeId = 4
                        },
                        new
                        {
                            Id = 5,
                            Description = "Redmine kliens fejlesztés",
                            Name = "Redmine Kliens ",
                            typeId = 4
                        },
                        new
                        {
                            Id = 6,
                            Description = "Redmine szerver fejlesztés",
                            Name = "Redmine Szerver ",
                            typeId = 4
                        });
                });

            modelBuilder.Entity("ProjectDeveloper", b =>
                {
                    b.Property<int>("DeveloperId")
                        .HasColumnType("INTEGER");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("DeveloperId", "ProjectId");

                    b.HasIndex("ProjectId");

                    b.ToTable("ProjectDevelopers");
                });

            modelBuilder.Entity("ProjectType", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("ProjectTypes");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Name = "Web Development"
                        },
                        new
                        {
                            Id = 2,
                            Name = "Mobile App Development"
                        },
                        new
                        {
                            Id = 3,
                            Name = "Data Analytics"
                        },
                        new
                        {
                            Id = 4,
                            Name = "E-commerce"
                        });
                });

            modelBuilder.Entity("Ptask", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd()
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("Deadline")
                        .HasColumnType("TEXT");

                    b.Property<string>("Description")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ManagerId")
                        .HasColumnType("INTEGER");

                    b.Property<string>("Name")
                        .IsRequired()
                        .HasColumnType("TEXT");

                    b.Property<int>("ProjectId")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("ManagerId");

                    b.HasIndex("ProjectId");

                    b.ToTable("Tasks");

                    b.HasData(
                        new
                        {
                            Id = 1,
                            Deadline = new DateTime(2024, 5, 14, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Integrate Stripe payment gateway for secure online transactions.",
                            ManagerId = 1,
                            Name = "Implement Payment Gateway",
                            ProjectId = 1
                        },
                        new
                        {
                            Id = 2,
                            Deadline = new DateTime(2024, 5, 10, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Implement user authentication using JWT for the mobile app.",
                            ManagerId = 2,
                            Name = "User Authentication",
                            ProjectId = 2
                        },
                        new
                        {
                            Id = 3,
                            Deadline = new DateTime(2024, 5, 21, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Create interactive charts and graphs for visualizing sales data.",
                            ManagerId = 1,
                            Name = "Data Visualization",
                            ProjectId = 3
                        },
                        new
                        {
                            Id = 4,
                            Deadline = new DateTime(2024, 5, 7, 0, 0, 0, 0, DateTimeKind.Local),
                            Description = "Allow users to log in using their social media accounts.",
                            ManagerId = 2,
                            Name = "Social Media Login",
                            ProjectId = 4
                        });
                });

            modelBuilder.Entity("Project", b =>
                {
                    b.HasOne("ProjectType", "Type")
                        .WithMany("Projects")
                        .HasForeignKey("typeId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Type");
                });

            modelBuilder.Entity("ProjectDeveloper", b =>
                {
                    b.HasOne("Developer", "Developer")
                        .WithMany()
                        .HasForeignKey("DeveloperId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project", "Project")
                        .WithMany()
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Developer");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Ptask", b =>
                {
                    b.HasOne("Manager", "Manager")
                        .WithMany("Tasks")
                        .HasForeignKey("ManagerId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.HasOne("Project", "Project")
                        .WithMany("Tasks")
                        .HasForeignKey("ProjectId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();

                    b.Navigation("Manager");

                    b.Navigation("Project");
                });

            modelBuilder.Entity("Manager", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("Project", b =>
                {
                    b.Navigation("Tasks");
                });

            modelBuilder.Entity("ProjectType", b =>
                {
                    b.Navigation("Projects");
                });
#pragma warning restore 612, 618
        }
    }
}
