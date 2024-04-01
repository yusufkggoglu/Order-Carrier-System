using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record class CarrierConfigurationDto
    {
        public int CarrierConfigurationId { get; init; }
        public int CarrierId { get; init; }
        public int CarrierMaxDesi { get; init; }
        public int CarrierMinDesi { get; init; }
        public decimal CarrierCost { get; init; }
    }
}
