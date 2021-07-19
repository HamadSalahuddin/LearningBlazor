﻿using EmployeeManagement.Models;
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
            this.dbContext = appDbContext;
        }

        public Department GetDepartment(int departmentId)
        {
            return dbContext.Departments
                .FirstOrDefault(d => d.DepartmentId == departmentId);
        }

        public IEnumerable<Department> GetDepartments()
        {
            return dbContext.Departments;
        }
    }
}
