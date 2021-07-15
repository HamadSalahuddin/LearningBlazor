﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace EmployeeManagement.Models
{
    public class Employee
    {
        public int EmployeeId { get; set; }

        [Column(TypeName = "Nvarchar(100)")]
        public string FirstName { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string LastName { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string Email { get; set; }

        [Column(TypeName = "DateTime2")]
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        public int DepartmentId { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        public string PhotoPath { get; set; }

    }
}
