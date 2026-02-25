using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudOperation.Migrations
{
    public partial class DepartmentFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "EndrollementDate",
                value: new DateTime(2026, 2, 25, 14, 55, 46, 700, DateTimeKind.Local).AddTicks(6750));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "EndrollementDate",
                value: new DateTime(2026, 2, 25, 14, 55, 46, 700, DateTimeKind.Local).AddTicks(6780));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 1,
                column: "EndrollementDate",
                value: new DateTime(2026, 2, 25, 13, 30, 13, 539, DateTimeKind.Local).AddTicks(7540));

            migrationBuilder.UpdateData(
                table: "Students",
                keyColumn: "StudentId",
                keyValue: 2,
                column: "EndrollementDate",
                value: new DateTime(2026, 2, 25, 13, 30, 13, 539, DateTimeKind.Local).AddTicks(7570));
        }
    }
}
