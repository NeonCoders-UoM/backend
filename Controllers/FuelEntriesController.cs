using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VPassport.Data;
using VPassport.DTOs;
using VPassport.Models;

namespace VPassport.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FuelEntriesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FuelEntriesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public async Task<ActionResult<FuelEntryReadDto>> PostFuelEntry(FuelEntryCreateDto dto)
        {
            var entry = new FuelEntry
            {
                VehicleId = dto.VehicleId,
                RefuelDate = dto.RefuelDate,
                Litres = dto.Litres
            };

            _context.FuelEntries.Add(entry);
            await _context.SaveChangesAsync();

            var resultDto = new FuelEntryReadDto
            {
                FuelEntryId = entry.FuelEntryId,
                VehicleId = entry.VehicleId,
                RefuelDate = entry.RefuelDate,
                Litres = entry.Litres
            };

            return CreatedAtAction(nameof(GetFuelEntry), new { id = resultDto.FuelEntryId }, resultDto);
        }



        [HttpGet("{id}")]
        public async Task<ActionResult<FuelEntryReadDto>> GetFuelEntry(int id)
        {
            var entry = await _context.FuelEntries.FindAsync(id);

            if (entry == null)
                return NotFound();

            return new FuelEntryReadDto
            {
                FuelEntryId = entry.FuelEntryId,
                VehicleId = entry.VehicleId,
                RefuelDate = entry.RefuelDate,
                Litres = entry.Litres
            };
        }

        [HttpGet("MonthlyUsage/{vehicleId}")]
        public async Task<ActionResult<IEnumerable<MonthlyFuelUsageDto>>> GetMonthlyFuelUsage(int vehicleId)
        {
            var usage = await _context.FuelEntries
                .Where(e => e.VehicleId == vehicleId)
                .GroupBy(e => new { e.RefuelDate.Year, e.RefuelDate.Month })
                .Select(g => new MonthlyFuelUsageDto
                {
                    Year = g.Key.Year,
                    Month = g.Key.Month,
                    TotalLitres = g.Sum(e => e.Litres)
                })
                .OrderBy(g => g.Year).ThenBy(g => g.Month)
                .ToListAsync();

            return Ok(usage);
        }
    }
}
