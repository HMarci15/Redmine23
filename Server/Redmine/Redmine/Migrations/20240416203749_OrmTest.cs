using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Redmine.Migrations
{
    /// <inheritdoc />
    public partial class OrmTest : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Developers",
                columns: new[] { "Id", "Email", "Name" },
                values: new object[,]
                {
                    { 3, "charlie.brown@example.com", "Charlie Brown" },
                    { 4, "david.miller@example.com", "David Miller" }
                });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "Password" },
                values: new object[] { "asd@asd.com", "Horvath Marcell", "asd123" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name", "Password" },
                values: new object[] { "dsa@dsa.com", "Kiss Csongor", "dsa321" });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Web Development");

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Mobile App Development");

            migrationBuilder.InsertData(
                table: "ProjectTypes",
                columns: new[] { "Id", "Name" },
                values: new object[,]
                {
                    { 3, "Data Analytics" },
                    { 4, "E-commerce" }
                });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Develop an e-commerce website for a clothing brand.", "E-commerce Website" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Create a mobile app to manage tasks and schedules efficiently.", "Mobile App - Task Manager" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Deadline", "Description", "Name" },
                values: new object[] { new DateTime(2024, 4, 30, 22, 37, 48, 786, DateTimeKind.Local).AddTicks(2214), "Integrate Stripe payment gateway for secure online transactions.", "Implement Payment Gateway" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Deadline", "Description", "Name" },
                values: new object[] { new DateTime(2024, 4, 26, 22, 37, 48, 786, DateTimeKind.Local).AddTicks(2282), "Implement user authentication using JWT for the mobile app.", "User Authentication" });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "Id", "Description", "Name", "typeId" },
                values: new object[,]
                {
                    { 3, "Build a dashboard for analyzing sales data and trends.", "Data Analysis Dashboard", 3 },
                    { 4, "Integrate social media login and sharing features into existing platforms.", "Social Media Integration", 4 }
                });

            migrationBuilder.InsertData(
                table: "Tasks",
                columns: new[] { "Id", "Deadline", "Description", "ManagerId", "Name", "ProjectId" },
                values: new object[,]
                {
                    { 3, new DateTime(2024, 5, 7, 22, 37, 48, 786, DateTimeKind.Local).AddTicks(2284), "Create interactive charts and graphs for visualizing sales data.", 1, "Data Visualization", 3 },
                    { 4, new DateTime(2024, 4, 23, 22, 37, 48, 786, DateTimeKind.Local).AddTicks(2286), "Allow users to log in using their social media accounts.", 2, "Social Media Login", 4 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Developers",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Email", "Name", "Password" },
                values: new object[] { "john.doe@example.com", "John Doe", "password123" });

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Email", "Name", "Password" },
                values: new object[] { "jane.smith@example.com", "Jane Smith", "password456" });

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: 1,
                column: "Name",
                value: "Type A");

            migrationBuilder.UpdateData(
                table: "ProjectTypes",
                keyColumn: "Id",
                keyValue: 2,
                column: "Name",
                value: "Type B");

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Description for Project 1", "Project 1" });

            migrationBuilder.UpdateData(
                table: "Projects",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Description", "Name" },
                values: new object[] { "Description for Project 2", "Project 2" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                columns: new[] { "Deadline", "Description", "Name" },
                values: new object[] { new DateTime(2024, 4, 23, 16, 8, 21, 984, DateTimeKind.Local).AddTicks(2254), "Description for Task 1", "Task 1" });

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                columns: new[] { "Deadline", "Description", "Name" },
                values: new object[] { new DateTime(2024, 4, 30, 16, 8, 21, 984, DateTimeKind.Local).AddTicks(2322), "Description for Task 2", "Task 2" });
        }
    }
}
