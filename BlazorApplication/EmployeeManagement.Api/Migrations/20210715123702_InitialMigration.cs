using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace EmployeeManagement.Api.Migrations
{
    public partial class InitialMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DepartmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentName = table.Column<string>(type: "Nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DepartmentId);
                });

            migrationBuilder.CreateTable(
                name: "Employees",
                columns: table => new
                {
                    EmployeeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    LastName = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    Email = table.Column<string>(type: "Nvarchar(100)", nullable: true),
                    DateOfBirth = table.Column<DateTime>(type: "DateTime2", nullable: false),
                    Gender = table.Column<int>(type: "int", nullable: false),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    PhotoPath = table.Column<string>(type: "Nvarchar(100)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeId);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DepartmentId", "DepartmentName" },
                values: new object[,]
                {
                    { 1, "IT" },
                    { 2, "HR" },
                    { 3, "Payroll" },
                    { 4, "Admin" }
                });

            migrationBuilder.InsertData(
                table: "Employees",
                columns: new[] { "EmployeeId", "DateOfBirth", "DepartmentId", "Email", "FirstName", "Gender", "LastName", "PhotoPath" },
                values: new object[,]
                {
                    { 1, new DateTime(1980, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "hamadsalahuddin@gmail.com", "Hamad", 0, "Salahuddin", "images/hamad.png" },
                    { 2, new DateTime(1983, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 2, "sohailkhaliq@gmail.com", "Sohail", 0, "Khaliq", "images/sohail.png" },
                    { 3, new DateTime(1983, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 1, "abidakram@gmail.com", "Abid", 0, "Akram", "images/abid.jpg" },
                    { 4, new DateTime(1984, 10, 5, 0, 0, 0, 0, DateTimeKind.Unspecified), 3, "waseemmaroof@gmail.com", "Waseem", 0, "Maroof", "images/waseem.png" }
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Departments");

            migrationBuilder.DropTable(
                name: "Employees");
        }
    }
}
