using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using VehiclePassportAPI.Data;
using VehiclePassportAPI.Dtos.Vehicle;
using VehiclePassportAPI.Mappers;

namespace VehiclePassportAPI.Controllers
{
    [Route("api/vehicles")]
    [ApiController]
    public class VehicleControllers : ControllerBase
    {
        private readonly ApplicationDBContext _context;
        public VehicleControllers(ApplicationDBContext context)
        {
            _context = context;

        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var stock = await _context.Vehicle.FindAsync(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToVehicleDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateVehicle([FromBody] CreateVehicleRequestDto vehicleDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            vehicleDto.CustomerID = 2;
            var vehicleModel = vehicleDto.ToVehicleFromCreateDto();
            await _context.Vehicle.AddAsync(vehicleModel);
            await _context.SaveChangesAsync();
            return Created($"api/vehicles/{vehicleModel.VehicleID}", vehicleModel.ToVehicleDto());
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateVehicle([FromRoute] int id, [FromBody] UpdateVehicleRequestDto updateDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            updateDto.CustomerID = 2;
            var vehicleModel = await _context.Vehicle.FirstOrDefaultAsync(x => x.VehicleID == id);

            if(vehicleModel == null)
            {
                return NotFound();
            }

            vehicleModel.RegistrationNumber = updateDto.RegistrationNumber;
            vehicleModel.ChassiNumber = updateDto.ChassiNumber;
            vehicleModel.FuelType = updateDto.FuelType;
            vehicleModel.Brand = updateDto.Brand;
            vehicleModel.Model = updateDto.Model;
            vehicleModel.Mileage = updateDto.Mileage;

            await _context.SaveChangesAsync();

            return Ok(vehicleModel.ToVehicleDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteVehicle([FromRoute] int id)
        {
            var vehicleModel = await  _context.Vehicle.FirstOrDefaultAsync(x => x.VehicleID == id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            _context.Vehicle.Remove(vehicleModel);
            await _context.SaveChangesAsync();

            return NoContent();
        }
    }
}
