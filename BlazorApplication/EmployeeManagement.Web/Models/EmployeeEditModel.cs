using EmployeeManagement.Models;
using EmployeeManagement.Models.CustomValidators;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Web.Models
{
    public class EmployeeEditModel
    {
        public int EmployeeId { get; set; }

        
        [Required(ErrorMessage = "FirstName must be provided")]
        [StringLength(100, MinimumLength = 2)]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        [EmailAddress]
        [EmailDomainValidator(
            AllowDomain = "PragimTech.com",
            ErrorMessage = "Only PragimTech.com is allowed"
        )]
        public string Email { get; set; }
        [CompareProperty(
            "Email",
            ErrorMessage ="Email and Confirm Email must match"
        )]
        public string ConfirmEmail { get; set; }
        public DateTime DateOfBirth { get; set; }
        public Gender Gender { get; set; }
        [Required]
        public int DepartmentId { get; set; }
        public string PhotoPath { get; set; }
        public Department Department { get; set; }
    }
}
