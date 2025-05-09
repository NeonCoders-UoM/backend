using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VehiclePassportAPI.Models;

namespace VehiclePassportAPI.Dtos.Vehicle
{
    public class CreateVehicleRequestDto
    {
        [Required(ErrorMessage = "Registration number is required.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Registration number must be exactly 8 characters.")]
        public string RegistrationNumber { get; set; } = string.Empty;

        [Required]
        public string FuelType { get; set; } = string.Empty;


        [Range(0, int.MaxValue, ErrorMessage = "Mileage cannot be negative.")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Chassis number is required.")]
        [StringLength(6, MinimumLength = 6, ErrorMessage = "Chassis number must be exactly 6 characters.")]
        public string ChassiNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Brand is required.")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; } = string.Empty;

        [Required]
        public int CustomerID { get; set; } 

    }
}
