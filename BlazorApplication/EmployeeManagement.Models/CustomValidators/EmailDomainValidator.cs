using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace EmployeeManagement.Models.CustomValidators
{
    public class EmailDomainValidator: ValidationAttribute
    {
        public string AllowDomain { get; set; }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            
            string[] strings = value.ToString()
                .Split("@");
            if(strings[1].ToUpper() == AllowDomain.ToUpper())
            {
                return null;
            }
            return new ValidationResult(
                $"Domain must be {AllowDomain}",
                new[] { validationContext.MemberName }
            );
        }
    }
}
