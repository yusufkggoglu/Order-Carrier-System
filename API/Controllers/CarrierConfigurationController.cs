using API.ActionFilters;
using Business.Contracts;
using Entities.Dtos;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CarrierConfigurationController : ControllerBase
    {
        private readonly ICarrierConfigurationService _carrierConfigurationService;
        public CarrierConfigurationController(ICarrierConfigurationService carrierConfigurationService)
        {
            _carrierConfigurationService = carrierConfigurationService;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var data = await _carrierConfigurationService.GetAllCarrierConfigurationsAsync(false);
            return Ok(data);
        }

        //[HttpGet("{id:int}")]
        //public async Task<IActionResult> Get([FromRoute(Name = "id")] int id)
        //{
        //    var data = await _carrierConfigurationService.GetOneCarrierConfigurationByIdAsync(id, false);
        //    return Ok(data);
        //}

        [ServiceFilter(typeof(ValidationFilterAttribute))]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CarrierConfigurationCreateDto carrierConfigurationDto)
        {
            await _carrierConfigurationService.CreateOneCarrierConfigurationAsync(carrierConfigurationDto);
            return StatusCode(201, $"{carrierConfigurationDto.CarrierId} numaralı kargo şirketine ait yeni yapılandırma eklendi.");
        }

        [ServiceFilter(typeof(ValidationFilterAttribute))]

        [HttpPut("{id:int}")]
        public async Task<IActionResult> Update([FromRoute(Name = "id")] int id, [FromBody] CarrierConfigurationUpdateDto carrierConfigurationDto)
        {
            await _carrierConfigurationService.UpdateOneCarrierConfigurationAsync(id, carrierConfigurationDto, false);
            return StatusCode(200, $"{carrierConfigurationDto.CarrierId} numaralı kargo şirketine ait {id} numaralı yapılandırma güncellendi.");
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> Delete([FromRoute(Name = "id")] int id)
        {
            await _carrierConfigurationService.DeleteOneCarrierConfigurationAsync(id, false);
            return StatusCode(200, $"{id} numaralı yapılandırma silindi.");
        }
    }
}
