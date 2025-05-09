using Microsoft.AspNetCore.Mvc;
using VehiclePassportAPI.Dtos.ServiceCenter;
using VehiclePassportAPI.Services.Interfaces;

namespace VehiclePassportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ServiceCenterController : ControllerBase
    {
        private readonly IServiceCenterService _serviceCenterService;

        public ServiceCenterController(IServiceCenterService serviceCenterService)
        {
            _serviceCenterService = serviceCenterService;
        }

        [HttpPost]
        public async Task<IActionResult> AddServiceCenter([FromBody] ServiceCenterCreateDto dto)
        {
            var result = await _serviceCenterService.AddServiceCenterAsync(dto);
            return CreatedAtAction(nameof(GetServiceCenterById), new { id = result.StationID }, result);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateServiceCenter(int id, [FromBody] ServiceCenterUpdateDto dto)
        {
            var result = await _serviceCenterService.UpdateServiceCenterAsync(id, dto);
            return Ok(result);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllServiceCenters()
        {
            var result = await _serviceCenterService.GetAllServiceCentersAsync();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetServiceCenterById(int id)
        {
            var result = await _serviceCenterService.GetServiceCenterByIdAsync(id);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteServiceCenter(int id)
        {
            var success = await _serviceCenterService.DeleteServiceCenterAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
