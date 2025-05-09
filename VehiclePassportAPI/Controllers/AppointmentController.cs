using Microsoft.AspNetCore.Mvc;
using VehiclePassportAPI.Dtos.Appointment;
using VehiclePassportAPI.Services.Interfaces;

namespace VehiclePassportAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AppointmentController : ControllerBase
    {
        private readonly IAppointmentService _appointmentService;

        public AppointmentController(IAppointmentService appointmentService)
        {
            _appointmentService = appointmentService;
        }

        [HttpPost]
        public async Task<IActionResult> CreateAppointment([FromBody] AppointmentCreateDto dto)
        {
            var result = await _appointmentService.CreateAppointmentAsync(dto);
            return CreatedAtAction(nameof(GetAppointmentById), new { id = result.AppointmentID }, result);
        }

        [HttpGet("servicecenter/{stationId}")]
        public async Task<IActionResult> GetAppointmentsByServiceCenter(int stationId)
        {
            var result = await _appointmentService.GetAppointmentsByServiceCenterAsync(stationId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetAppointmentById(int id)
        {
            var result = await _appointmentService.GetAppointmentByIdAsync(id);
            return Ok(result);
        }

        [HttpPost("{id}/accept")]
        public async Task<IActionResult> AcceptAppointment(int id)
        {
            var success = await _appointmentService.AcceptAppointmentAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> RejectAppointment(int id)
        {
            var success = await _appointmentService.RejectAppointmentAsync(id);
            if (!success)
                return NotFound();
            return NoContent();
        }
    }
}
