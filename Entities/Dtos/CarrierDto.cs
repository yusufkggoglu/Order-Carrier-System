using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record class CarrierDto
    {
        public int CarrierId { get; init; }
        public string CarrierName { get; init; }
        public bool CarrierIsActive { get; init; }
        public int CarrierPlusDesiCost { get; init; }
        public int CarrierConfigurationId { get; init; }
    }
}
