using Entities.Dtos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.ValidationAttributes
{
    public class DesiCostValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var carrier = (BaseCarrierConfigurationDto)validationContext.ObjectInstance;

            if (carrier.CarrierMaxDesi <= carrier.CarrierMinDesi)
            {
                return new ValidationResult(ErrorMessage ?? "CarrierMaxDesi must be greater than CarrierMinDesi.");
            }

            if (carrier.CarrierMinDesi >= carrier.CarrierMaxDesi)
            {
                return new ValidationResult(ErrorMessage ?? "CarrierMinDesi must be less than CarrierMaxDesi.");
            }

            return ValidationResult.Success;
        }
    }
}
