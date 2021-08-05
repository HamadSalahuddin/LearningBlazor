using EmployeeManagement.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Api.Models
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly EmployeeManagementDbContext dbContext;

        public DepartmentRepository(EmployeeManagementDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public async Task<Department> GetDepartment(int departmentId)
        {
            return await dbContext.Departments
                .FirstOrDefaultAsync(d => d.DepartmentId == departmentId);
        }

        public async Task<IEnumerable<Department>> GetDepartments()
        {
            return await dbContext.Departments
                .ToListAsync();
        }
    }
}
