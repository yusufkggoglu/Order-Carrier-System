using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record class OrderDto
    {
        public int OrderId { get; init; }
        public int CarrierId { get; init; }
        public int OrderDesi { get; init; }
        public DateTime OrderDate { get; init; }
        public decimal OrderCarrierCost { get; init; }
    }
}
