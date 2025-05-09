using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VPassport.Data;
using VPassport.DTOs;
using VPassport.Models;

[Route("api/[controller]")]
[ApiController]
public class PartWarrantiesController : ControllerBase
{
    private readonly AppDbContext _context;

    public PartWarrantiesController(AppDbContext context)
    {
        _context = context;
    }

    // GET: api/PartWarranties
    [HttpGet]
    public async Task<ActionResult<IEnumerable<PartWarrantyDto>>> GetPartWarranties()
    {
        return await _context.PartWarranties
            .Select(p => new PartWarrantyDto
            {
                Id = p.Id,
                PartName = p.PartName,
                WarrantyProvider = p.WarrantyProvider,
                StartDate = p.StartDate,
                DurationInMonths = p.DurationInMonths,
                ExpiryDate = p.StartDate.AddMonths(p.DurationInMonths),
                VehicleId = p.VehicleId
            })
            .ToListAsync();
    }

    // GET: api/PartWarranties/5
    [HttpGet("{id}")]
    public async Task<ActionResult<PartWarrantyDto>> GetPartWarranty(int id)
    {
        var part = await _context.PartWarranties.FindAsync(id);

        if (part == null) return NotFound();

        return new PartWarrantyDto
        {
            Id = part.Id,
            PartName = part.PartName,
            WarrantyProvider = part.WarrantyProvider,
            StartDate = part.StartDate,
            DurationInMonths = part.DurationInMonths,
            ExpiryDate = part.StartDate.AddMonths(part.DurationInMonths),
            VehicleId = part.VehicleId
        };
    }

    // POST: api/PartWarranties
    [HttpPost]
    public async Task<ActionResult<PartWarrantyDto>> PostPartWarranty(CreatePartWarrantyDto dto)
    {
        var entity = new PartWarranty
        {
            PartName = dto.PartName,
            WarrantyProvider = dto.WarrantyProvider,
            StartDate = dto.StartDate,
            DurationInMonths = dto.DurationInMonths,
            VehicleId = dto.VehicleId
        };

        _context.PartWarranties.Add(entity);
        await _context.SaveChangesAsync();

        return CreatedAtAction(nameof(GetPartWarranty), new { id = entity.Id }, new PartWarrantyDto
        {
            Id = entity.Id,
            PartName = entity.PartName,
            WarrantyProvider = entity.WarrantyProvider,
            StartDate = entity.StartDate,
            DurationInMonths = entity.DurationInMonths,
            ExpiryDate = entity.ExpiryDate,
            VehicleId = entity.VehicleId
        });
    }

    // PUT: api/PartWarranties/5
    [HttpPut("{id}")]
    public async Task<IActionResult> PutPartWarranty(int id, CreatePartWarrantyDto dto)
    {
        var part = await _context.PartWarranties.FindAsync(id);
        if (part == null) return NotFound();

        part.PartName = dto.PartName;
        part.WarrantyProvider = dto.WarrantyProvider;
        part.StartDate = dto.StartDate;
        part.DurationInMonths = dto.DurationInMonths;
        part.VehicleId = dto.VehicleId;

        await _context.SaveChangesAsync();
        return NoContent();
    }

    // DELETE: api/PartWarranties/5
    [HttpDelete("{id}")]
    public async Task<IActionResult> DeletePartWarranty(int id)
    {
        var warranty = await _context.PartWarranties.FindAsync(id);
        if (warranty == null)
        {
            return NotFound();
        }

        _context.PartWarranties.Remove(warranty);
        await _context.SaveChangesAsync();

        return NoContent();
    }

}
