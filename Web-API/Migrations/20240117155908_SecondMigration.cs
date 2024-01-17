using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Web_API.Migrations
{
    /// <inheritdoc />
    public partial class SecondMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "EmployeeId",
                table: "Employee",
                newName: "Id");

            migrationBuilder.RenameColumn(
                name: "DepartmentId",
                table: "Department",
                newName: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Employee",
                newName: "EmployeeId");

            migrationBuilder.RenameColumn(
                name: "Id",
                table: "Department",
                newName: "DepartmentId");
        }
    }
}
