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

        public async Task<Employee> DeleteEmployee(int employeeId)
        {
            var employee = await dbContext.Employees
                .FirstOrDefaultAsync(employee => employee.EmployeeId == employeeId);

            if (employee != null)
            {
                dbContext.Employees.Remove(employee);
                await dbContext.SaveChangesAsync();
            }
            return employee;
        }

        public async Task<Employee> GetEmployee(int employeeId)
        {
            return await dbContext.Employees
                .Include(employee => employee.Department)
                .FirstOrDefaultAsync(employee => employee.EmployeeId == employeeId);
        }

        public async Task<Employee> GetEmployeeByEmail(string email)
        {
            return await dbContext.Employees
                .FirstOrDefaultAsync(employee => employee.Email == email);
        }

        public async Task<IEnumerable<Employee>> GetEmployees()
        {
            return await dbContext.Employees
                .ToListAsync();
        }

        public async Task<IEnumerable<Employee>> SearchEmployees(string name, Gender? gender)
        {
            IQueryable<Employee> employeesQueryable = dbContext.Employees;
            if (!string.IsNullOrEmpty(name))
            {
                employeesQueryable = employeesQueryable
                    .Where(employee => employee.FirstName.ToLower().Contains(name.ToLower())
                        || employee.LastName.ToLower().Contains(name.ToLower())
                    );
            }

            if (gender != null)
            {
                employeesQueryable = employeesQueryable
                    .Where(employee => employee.Gender == gender);
            }

            return await employeesQueryable
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
