using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Redmine.Migrations
{
    /// <inheritdoc />
    public partial class hash_update : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "43a66ace8a1f1f19ae8808a1f0a3ebb2fb4f292b25bed512cd6d4ae1bc8c1632");

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "8265a0b34b15f6b779fbd02198dfd7520d28829b7e1440b39f100cefe465b526");

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "50289f2d6d5c448d3c33a42beb9d45b0b847259276fe873d52c99f187d81e782");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 1,
                column: "Password",
                value: "marci123");

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 2,
                column: "Password",
                value: "csongor123");

            migrationBuilder.UpdateData(
                table: "Managers",
                keyColumn: "Id",
                keyValue: 3,
                column: "Password",
                value: "bence123");
        }
    }
}
