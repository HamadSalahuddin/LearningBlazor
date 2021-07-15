using EmployeeManagement.Models;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EmployeeListBase : ComponentBase
    {
        public IEnumerable<Employee> Employees { get; set; }

        protected override async Task OnInitializedAsync()
        {
            await Task.Run(LoadEmployees);
        }

        private void LoadEmployees()
        {
            Thread.Sleep(3000);
            Employees = new List<Employee>
            {
                new Employee
                {
                    EmployeeId =1,
                    FirstName ="Hamad",
                    LastName = "Salahuddin",
                    Email= "hamadsalahuddin@gmail.com",
                    DateOfBirth = new DateTime(1980, 10, 5),
                    Gender = Gender.Male,
                    Department = new Department
                    {
                        DepartmentId =1,
                        DepartmentName = "IT"
                    },
                    PhotoPath = "images/hamad.png"
                },
                new Employee
                {
                    EmployeeId =2,
                    FirstName ="Sohail",
                    LastName = "Khaliq",
                    Email= "sohailkhaliq@gmail.com",
                    DateOfBirth = new DateTime(1983, 10, 5),
                    Gender = Gender.Male,
                    Department = new Department
                    {
                        DepartmentId =1,
                        DepartmentName = "HR"
                    },
                    PhotoPath = "images/sohail.png"
                },
                new Employee
                {
                    EmployeeId =3,
                    FirstName ="Abid",
                    LastName = "Akram",
                    Email= "abidakram@gmail.com",
                    DateOfBirth = new DateTime(1983, 10, 5),
                    Gender = Gender.Male,
                    Department = new Department
                    {
                        DepartmentId =1,
                        DepartmentName = "QA"
                    },
                    PhotoPath = "images/abid.jpg"
                },new Employee
                {
                    EmployeeId =4,
                    FirstName ="Waseem",
                    LastName = "Maroof",
                    Email= "waseemmaroof@gmail.com",
                    DateOfBirth = new DateTime(1984, 10, 5),
                    Gender = Gender.Male,
                    Department = new Department
                    {
                        DepartmentId =1,
                        DepartmentName = "IT"
                    },
                    PhotoPath = "images/waseem.png"
                },
            };
        }
    }
}
