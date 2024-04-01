using API.ActionFilters;
using Business.Contracts;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierController : ControllerBase
    {
        private readonly ICarrierService _carrierService;
        public CarrierController(ICarrierService carrierService)
        {
            _carrierService = carrierService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _carrierService.GetAllCarriersAsync(false);
            return Ok(data);
        }

        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> Get([FromRoute(Name = "id")] int id)
        //{
        //    var data = await _carrierService.GetOneCarrierByIdAsync(id, false);
        //    return Ok(data);
        //}

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarrierCreateDto carrierDto)
        {
            await _carrierService.CreateOneCarrierAsync(carrierDto);
            return StatusCode(201, "Kargo şirketi Eklendi.");
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id, [FromBody] CarrierUpdateDto carrierDto)
        {
            await _carrierService.UpdateOneCarrierAsync(id, carrierDto, false);
            return StatusCode(200, $"{id} numaralı kargo şirketi güncellendi.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            await _carrierService.DeleteOneCarrierAsync(id, false);
            return StatusCode(200, $"{id} numaralı kargo şirketi silindi.");
        }
    }
}
