using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class EmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeManagementDbContext dbContext;

        public EmployeeRepository(EmployeeManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Employee> AddEmployee(Employee employee)
        {
            dbContext.Employees.Add(employee);
            await dbContext.SaveChangesAsync();
            return employee;
        }

        public async void DeleteEmployee(int employeeId)
        {
            var employee = dbContext.Employees
                .FirstOrDefault(employee => employee.EmployeeId == employeeId);

            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();
            }

        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await dbContext.Employees
                .FirstOrDefaultAsync(employee => employee.EmployeeId == employeeId);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await dbContext.Employees
                .ToListAsync();
        }

        public async Task<Employee> UpdateEmployee(Employee employeeToUpdate)
        {
            var employeeInDb = await dbContext.Employees
                .FirstOrDefaultAsync(employee => employee.EmployeeId == employeeToUpdate.EmployeeId);

            if (employeeInDb != null)
            {
                employeeInDb.FirstName = employeeToUpdate.FirstName;
                employeeInDb.LastName = employeeToUpdate.LastName;
                employeeInDb.Email = employeeToUpdate.Email;
                employeeInDb.DateOfBirth = employeeToUpdate.DateOfBirth;
                employeeInDb.Gender = employeeToUpdate.Gender;
                employeeInDb.DepartmentId = employeeToUpdate.DepartmentId;
                employeeInDb.PhotoPath = employeeToUpdate.PhotoPath;
                await dbContext.SaveChangesAsync();
                return employeeInDb;
            }
            return null;

        }
    }
}
