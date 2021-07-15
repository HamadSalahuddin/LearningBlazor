using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeManagementDbContext: DbContext
    {
        public EmployeeManagementDbContext(DbContextOptions<EmployeeManagementDbContext> options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // seed Department Table.

            modelBuilder.Entity<Department>().HasData(
                new Department
                {
                    DepartmentId = 1,
                    DepartmentName = "IT"
                },
                new Department
                {
                    DepartmentId = 2,
                    DepartmentName = "HR"
                },
                new Department
                {
                    DepartmentId = 3,
                    DepartmentName = "Payroll"
                },
                new Department
                {
                    DepartmentId = 4,
                    DepartmentName = "Admin"
                }
            );

            // Seed Employee data.

            modelBuilder.Entity<Employee>().HasData(
                new Employee
                {
                    EmployeeId = 1,
                    FirstName = "Hamad",
                    LastName = "Salahuddin",
                    Email = "hamadsalahuddin@gmail.com",
                    DateOfBirth = new DateTime(1980, 10, 5),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/hamad.png"
                },
                new Employee
                {
                    EmployeeId = 2,
                    FirstName = "Sohail",
                    LastName = "Khaliq",
                    Email = "sohailkhaliq@gmail.com",
                    DateOfBirth = new DateTime(1983, 10, 5),
                    Gender = Gender.Male,
                    DepartmentId = 2,
                    PhotoPath = "images/sohail.png"
                },
                new Employee
                {
                    EmployeeId = 3,
                    FirstName = "Abid",
                    LastName = "Akram",
                    Email = "abidakram@gmail.com",
                    DateOfBirth = new DateTime(1983, 10, 5),
                    Gender = Gender.Male,
                    DepartmentId = 1,
                    PhotoPath = "images/abid.jpg"
                }, new Employee
                {
                    EmployeeId = 4,
                    FirstName = "Waseem",
                    LastName = "Maroof",
                    Email = "waseemmaroof@gmail.com",
                    DateOfBirth = new DateTime(1984, 10, 5),
                    Gender = Gender.Male,
                    DepartmentId = 3,
                    PhotoPath = "images/waseem.png"
                }
            );
        }
    }
}
