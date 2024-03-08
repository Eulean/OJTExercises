using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace NightIV.Models
{
    public class Min18YearsIfAMember : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var customer = (Customer)validationContext.ObjectInstance;

            if (customer.MemberShipTypeId == MemberShipTypes.Unknown || 
                customer.MemberShipTypeId == MemberShipTypes.PayAsYouGo)
                return ValidationResult.Success;

            if (customer.Birthday == null)
                return new ValidationResult("Birthday is required.");

            var age = DateTime.Today.Year - customer.Birthday.Value.Year;

            return (age >= 18)
                ? ValidationResult.Success
                : new ValidationResult("Customer Should be 18 years old");

        }
    }
}