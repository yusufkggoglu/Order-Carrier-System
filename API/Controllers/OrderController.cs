using API.ActionFilters;
using Business.Contracts;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;
        public OrderController(IOrderService OrderService)
        {
            _orderService = OrderService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _orderService.GetAllOrdersAsync(false);
            return Ok(data);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> Get([FromRoute(Name = "id")] int id)
        {
            var data = await _orderService.GetOneOrderByIdAsync(id, false);
            return Ok(data);
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] OrderCreateDto OrderDto)
        {
            await _orderService.CreateOneOrderAsync(OrderDto);
            return StatusCode(201, "Sipariş Eklendi.");
        }

        //[ServiceFilter(typeof(ValidationFilterAttribute))]

        //[HttpPut("{id:int}")]
        //public async Task<IActionResult> Update([FromRoute(Name = "id")] int id, [FromBody] OrderUpdateDto OrderDto)
        //{
        //    await _orderService.UpdateOneOrderAsync(id, OrderDto, false);
        //    return StatusCode(200, $"{id} numaralı sipariş güncellendi.");
        //}

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            await _orderService.DeleteOneOrderAsync(id, false);
            return StatusCode(200, $"{id} numaralı sipariş silindi.");
        }
    }
}
