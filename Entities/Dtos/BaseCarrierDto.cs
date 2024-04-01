using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record class BaseCarrierDto
    {
        [Required(ErrorMessage = "CarrierName is a required field.")]
        public string CarrierName { get; init; }
        [Required(ErrorMessage = "CarrierIsActive is a required field.")]
        public bool CarrierIsActive { get; init; }
        [Required(ErrorMessage = "CarrierPlusDesiCost is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "CarrierPlusDesiCost must be greater than zero.")]
        public int CarrierPlusDesiCost { get; init; }
        [Required(ErrorMessage = "CarrierConfigurationId is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "CarrierConfigurationId must be greater than zero.")]
        public int CarrierConfigurationId { get; init; }
    }
}
