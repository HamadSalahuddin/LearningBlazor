using EmployeeManagement.Models;
using EmployeeManagement.Web.Services;
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
        [Inject]
        public IEmployeeService EmployeeService { get; set; }
        public IEnumerable<Employee> Employees { get; set; }
        public bool ShowFooter { get; set; } = true;

        protected int SelectedEmployeeCount { get; set; } = 0;

        protected override async Task OnInitializedAsync()
        {
            Employees = (
                await EmployeeService.GetEmployees()
            )
            .ToList();
        }

        protected void EmployeeSelectionChanged(bool isSelected)
        {
            SelectedEmployeeCount = isSelected
                ? SelectedEmployeeCount + 1
                : SelectedEmployeeCount - 1;
        }

        protected async Task DeletedEmployee(int deletedEmployeeId)
        {
            Employees = (
                await EmployeeService.GetEmployees()
            )
            .ToList();
        }

    }
}
