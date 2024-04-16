using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Redmine.Migrations
{
    /// <inheritdoc />
    public partial class OrmTest2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2024, 4, 30, 22, 44, 26, 953, DateTimeKind.Local).AddTicks(1968));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2024, 4, 26, 22, 44, 26, 953, DateTimeKind.Local).AddTicks(2032));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2024, 5, 7, 22, 44, 26, 953, DateTimeKind.Local).AddTicks(2034));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deadline",
                value: new DateTime(2024, 4, 23, 22, 44, 26, 953, DateTimeKind.Local).AddTicks(2036));
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 1,
                column: "Deadline",
                value: new DateTime(2024, 4, 30, 22, 37, 48, 786, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 2,
                column: "Deadline",
                value: new DateTime(2024, 4, 26, 22, 37, 48, 786, DateTimeKind.Local).AddTicks(2282));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 3,
                column: "Deadline",
                value: new DateTime(2024, 5, 7, 22, 37, 48, 786, DateTimeKind.Local).AddTicks(2284));

            migrationBuilder.UpdateData(
                table: "Tasks",
                keyColumn: "Id",
                keyValue: 4,
                column: "Deadline",
                value: new DateTime(2024, 4, 23, 22, 37, 48, 786, DateTimeKind.Local).AddTicks(2286));
        }
    }
}
