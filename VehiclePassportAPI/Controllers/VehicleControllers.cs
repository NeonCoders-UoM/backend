using Microsoft.AspNetCore.Mvc;
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
        public IActionResult GetById([FromRoute] int id)
        {
            var stock = _context.Vehicle.Find(id);

            if (stock == null)
            {
                return NotFound();
            }

            return Ok(stock.ToVehicleDto());
        }

        [HttpPost]
        public IActionResult CreateVehicle([FromBody] CreateVehicleRequestDto vehicleDto)
        {
            vehicleDto.CustomerID = 2;
            var vehicleModel = vehicleDto.ToVehicleFromCreateDto();
            _context.Vehicle.Add(vehicleModel);
            _context.SaveChanges();
            return Created($"api/vehicles/{vehicleModel.VehicleID}", vehicleModel.ToVehicleDto());
        }

        [HttpPut("{id}")]
        public IActionResult UpdateVehicle([FromRoute] int id, [FromBody] UpdateVehicleRequestDto updateDto)
        {
            updateDto.CustomerID = 2;
            var vehicleModel = _context.Vehicle.FirstOrDefault(x => x.VehicleID == id);

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

            _context.SaveChanges();

            return Ok(vehicleModel.ToVehicleDto());
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteVehicle([FromRoute] int id)
        {
            var vehicleModel = _context.Vehicle.FirstOrDefault(x => x.VehicleID == id);

            if (vehicleModel == null)
            {
                return NotFound();
            }

            _context.Vehicle.Remove(vehicleModel);
            _context.SaveChanges();

            return NoContent();
        }
    }
}
