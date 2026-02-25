using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudOperation.Migrations
{
    public partial class InitialSeed : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Course", "DepartmentId", "Email", "EndrollementDate", "Name" },
                values: new object[] { 1, "Computer Science", 1, "alice@mail.com", new DateTime(2026, 2, 25, 13, 29, 51, 206, DateTimeKind.Local).AddTicks(7720), "Alice" });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "StudentId", "Course", "DepartmentId", "Email", "EndrollementDate", "Name" },
                values: new object[] { 2, "Physics", 2, "bob@mail.com", new DateTime(2026, 2, 25, 13, 29, 51, 206, DateTimeKind.Local).AddTicks(7750), "Bob" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2);
        }
    }
}
