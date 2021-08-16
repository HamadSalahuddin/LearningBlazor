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
            if (value != null)
            {
                string[] strings = value.ToString()
                .Split("@");
                if (strings.Length > 1 && strings[1].ToUpper() == AllowDomain.ToUpper())
                {
                    return ValidationResult.Success;
                }
                return new ValidationResult(
                    ErrorMessage,
                    new[] { validationContext.MemberName }
                );
            }
            return null;
        }
    }
}
