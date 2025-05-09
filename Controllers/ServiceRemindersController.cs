using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VPassport.Data;
using VPassport.DTOs;
using VPassport.Models;

namespace VPassport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServiceRemindersController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ServiceRemindersController(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        [HttpPost]
        public async Task<ActionResult<ServiceReminderReadDto>> CreateReminder(ServiceReminderCreateDto dto)
        {
            var reminder = _mapper.Map<ServiceReminder>(dto);
            _context.ServiceReminders.Add(reminder);
            await _context.SaveChangesAsync();

            var result = _mapper.Map<ServiceReminderReadDto>(reminder);
            return CreatedAtAction(nameof(GetReminder), new { id = reminder.Id }, result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceReminderReadDto>> GetReminder(int id)
        {
            var reminder = await _context.ServiceReminders.FindAsync(id);
            if (reminder == null) return NotFound();

            return _mapper.Map<ServiceReminderReadDto>(reminder);
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ServiceReminderDto>>> GetAll()
        {
            var reminders = await _context.ServiceReminders
                .Select(r => new ServiceReminderDto
                {
                    Id = r.Id,
                    VehicleId = r.VehicleId,
                    ServiceType = r.ServiceType,
                    TimeIntervalInMonths = r.TimeIntervalInMonths,
                    NotifyPeriodInDays = r.NotifyPeriodInDays
                })
                .ToListAsync();

            return Ok(reminders);
        }

        [HttpGet("vehicle/{vehicleId}")]
        public async Task<ActionResult<IEnumerable<ServiceReminderReadDto>>> GetRemindersByVehicle(int vehicleId)
        {
            var reminders = await _context.ServiceReminders
                .Where(r => r.VehicleId == vehicleId)
                .ToListAsync();

            return _mapper.Map<List<ServiceReminderReadDto>>(reminders);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateReminder(int id, ServiceReminderDto dto)
        {
            if (id != dto.Id) return BadRequest("ID mismatch");

            var reminder = await _context.ServiceReminders.FindAsync(id);
            if (reminder == null) return NotFound();

            reminder.ServiceType = dto.ServiceType;
            reminder.TimeIntervalInMonths = dto.TimeIntervalInMonths;
            reminder.NotifyPeriodInDays = dto.NotifyPeriodInDays;
            reminder.VehicleId = dto.VehicleId;

            await _context.SaveChangesAsync();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReminder(int id)
        {
            var reminder = await _context.ServiceReminders.FindAsync(id);
            if (reminder == null) return NotFound();

            _context.ServiceReminders.Remove(reminder);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}