﻿using System.ComponentModel.DataAnnotations;

namespace Flights.Models
{
    public class DateGreaterThanToday : ValidationAttribute
    {

        public DateGreaterThanToday()
        {

        }

        // Validate the date
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var currentValue = (DateTime)value;

            var comparisonValue = DateTime.Now;

            if (currentValue < comparisonValue)
            {
                return new ValidationResult(ErrorMessage = "Your Flight can't be earlier than the time now");
            }

            return ValidationResult.Success;
        }
    }
}
