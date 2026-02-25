using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CrudOperation.Migrations
{
    public partial class relationBetweenStudentAndDepartmentt : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "HOD", "Name" },
                values: new object[] { 1, "Raman", "IT" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "HOD", "Name" },
                values: new object[] { 2, "Hitesh", "Science" });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "HOD", "Name" },
                values: new object[] { 3, "Hari", "Management" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Departments",
                keyColumn: "DepartmentId",
                keyValue: 3);
        }
    }
}
