using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeManagement.Models
{
    public class Department
    {
        public int DepartmentId { get; set; }
        [Column(TypeName = "Nvarchar(100)")]
        [Required]
        public string DepartmentName { get; set; }

    }
}
