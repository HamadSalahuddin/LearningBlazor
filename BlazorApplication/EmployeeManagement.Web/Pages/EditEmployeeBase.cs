using AutoMapper;
using EmployeeManagement.Models;
using EmployeeManagement.Web.Models;
using EmployeeManagement.Web.Services;
using Hamad.Components;
using Microsoft.AspNetCore.Components;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Pages
{
    public class EditEmployeeBase : ComponentBase
    {
        [Inject]
        public IEmployeeService EmployeeService { get; set; }

        [Inject]
        public IDepartmentService DepartmentService { get; set; }

        [Inject]
        public IMapper Mapper { get; set; }

        [Inject]
        public NavigationManager NavigationManager { get; set; }

        private Employee Employee { get; set; } = new Employee();
        protected EmployeeEditModel EmployeeEditModel = new EmployeeEditModel();
        public List<Department> Departments { get; set; } = new List<Department>();
        public string DepartmentId { get; set; }
        public string PageTitle { get; set; }
        public Confirm DeleteConfirmReference { get; set; }

        [Parameter]
        public string Id { get; set; }

        protected override async Task OnInitializedAsync()
        {
            int.TryParse(Id, out int employeeId);
            PageTitle = employeeId != 0
                ? "Edit Employee"
                : "Create Employee";

            Employee = employeeId != 0
                ? await EmployeeService.GetEmployee(employeeId)
                : new Employee
                {
                    DepartmentId = 1,
                    DateOfBirth = DateTime.Now,
                    PhotoPath = "images/nophoto.jpg",

                };
            
            Departments = (
                await DepartmentService.GetDepartments()
            ).ToList();

            Mapper.Map(Employee, EmployeeEditModel);
        }

        protected async Task HandleValidSubmit()
        {
            Mapper.Map(EmployeeEditModel, Employee);

            var employeeResult = Employee.EmployeeId != 0
                ? await EmployeeService.UpdateEmployee(Employee)
                : await EmployeeService.CreateEmployee(Employee);
            
            if(employeeResult != null)
            {
                NavigationManager.NavigateTo("/");
            }
        }

        protected void OnDeleteClick()
        {
            DeleteConfirmReference.Show();
        }

        public async Task ConfirmDelete_Click(bool deleteConfirmed)
        {
            if (deleteConfirmed)
            {
                await EmployeeService.DeleteEmployee(EmployeeEditModel.EmployeeId);
                NavigationManager.NavigateTo("/");
            }
        }
    }
}
