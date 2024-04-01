using Entities.ValidationAttributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record class BaseCarrierConfigurationDto
    {
        [Required(ErrorMessage = "CarrierId is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "CarrierId must be greater than zero.")]
        public int CarrierId { get; init; }

        [Required(ErrorMessage = "CarrierMaxDesi is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "CarrierMaxDesi must be greater than zero.")]
        public int CarrierMaxDesi { get; init; }

        [Required(ErrorMessage = "CarrierMinDesi is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "CarrierMinDesi must be greater than zero.")]
        [DesiCostValidationAttribute(ErrorMessage = "Invalid Desi values.")]
        public int CarrierMinDesi { get; init; }
        [Required(ErrorMessage = "CarrierCost is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "CarrierCost must be greater than zero.")]
        public decimal CarrierCost { get; init; }
    }
}
