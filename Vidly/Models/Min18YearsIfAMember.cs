using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Vidly.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;
            if (customer.MembershipTypeId == 0 || customer.MembershipTypeId == 1)
            {
                return ValidationResult.Success;
            }
            if (customer.CustomerBirthDate == null)
            {
                return new ValidationResult("Date Of Birth is Required");
            }

            var age = DateTime.Today.Year - customer.CustomerBirthDate.Value.Year;

            return (age > 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer should be atleast 18years old to go on a membership");
        }
    }
}