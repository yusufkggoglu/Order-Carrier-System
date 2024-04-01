using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Dtos
{
    public record class BaseOrderDto
    {
        //[Required(ErrorMessage = "CarrierId is a required field.")]
        //[Range(1, int.MaxValue, ErrorMessage = "CarrierId must be greater than zero.")]
        //public int CarrierId { get; init; }

        [Required(ErrorMessage = "OrderDesi is a required field.")]
        [Range(1, int.MaxValue, ErrorMessage = "OrderDesi must be greater than zero.")]
        public int OrderDesi { get; init; }

        //[Required(ErrorMessage = "OrderDate is a required field.")]
        //public DateTime OrderDate { get; init; }

        //[Required(ErrorMessage = "OrderCarrierCost is a required field.")]
        //[Range(1, int.MaxValue, ErrorMessage = "OrderCarrierCost must be greater than zero.")]
        //public decimal OrderCarrierCost { get; init; }

    }
}
