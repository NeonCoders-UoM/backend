using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VPassport.Data;
using VPassport.DTOs;
using VPassport.Models;

[Route("api/[controller]")]
[ApiController]
public class ServiceRecordsController : ControllerBase
{
    private readonly AppDbContext _context;

    public ServiceRecordsController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/ServiceRecords
    [HttpGet]
    public async Task<ActionResult<IEnumerable<ServiceRecordResponseDTO>>> GetServiceRecords()
    {
        return await _context.ServiceRecords
            .Select(sr => new ServiceRecordResponseDTO
            {
                Id = sr.Id,
                Date = sr.Date,
                Description = sr.Description,
                Cost = sr.Cost,
                VehicleId = sr.VehicleId
            })
            .ToListAsync();
    }

    // GET: api/ServiceRecords/5
    [HttpGet("{id}")]
    public async Task<ActionResult<ServiceRecordResponseDTO>> GetServiceRecord(int id)
    {
        var sr = await _context.ServiceRecords.FindAsync(id);

        if (sr == null)
            return NotFound();

        return new ServiceRecordResponseDTO
        {
            Id = sr.Id,
            Date = sr.Date,
            Description = sr.Description,
            Cost = sr.Cost,
            VehicleId = sr.VehicleId
        };
    }

    // POST: api/ServiceRecords
    [HttpPost]
    public async Task<ActionResult<ServiceRecordResponseDTO>> PostServiceRecord(ServiceRecordDTO dto)
    {
        var serviceRecord = new ServiceRecord
        {
            Date = dto.Date,
            Description = dto.Description,
            Cost = dto.Cost,
            VehicleId = dto.VehicleId
        };

        _context.ServiceRecords.Add(serviceRecord);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetServiceRecord), new { id = serviceRecord.Id }, new ServiceRecordResponseDTO
        {
            Id = serviceRecord.Id,
            Date = serviceRecord.Date,
            Description = serviceRecord.Description,
            Cost = serviceRecord.Cost,
            VehicleId = serviceRecord.VehicleId
        });
    }

    // PUT: api/ServiceRecords/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutServiceRecord(int id, ServiceRecordDTO dto)
    {
        var existingRecord = await _context.ServiceRecords.FindAsync(id);

        if (existingRecord == null)
            return NotFound();

        existingRecord.Date = dto.Date;
        existingRecord.Description = dto.Description;
        existingRecord.Cost = dto.Cost;
        existingRecord.VehicleId = dto.VehicleId;

        await _context.SaveChangesAsync();

        return NoContent();
    }

    // DELETE: api/ServiceRecords/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeleteServiceRecord(int id)
    {
        var record = await _context.ServiceRecords.FindAsync(id);
        if (record == null)
            return NotFound();

        _context.ServiceRecords.Remove(record);
        await _context.SaveChangesAsync();

        return NoContent();
    }
}

