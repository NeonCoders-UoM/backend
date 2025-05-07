using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VehiclePassportAPI.Models
{
    public class Vehicle
    {
        [Key]
        public int VehicleID { get; set; }

        [Required(ErrorMessage = "Registration number is required.")]
        [StringLength(8, MinimumLength = 8, ErrorMessage = "Registration number must be exactly 8 characters.")]
        public string RegistrationNumber { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Mileage cannot be negative.")]
        public int Mileage { get; set; }

        [Required(ErrorMessage = "Fuel type is required.")]
        public string FuelType { get; set; } = string.Empty;

        [Required(ErrorMessage = "Chassis number is required.")]
        [StringLength(17, MinimumLength = 17, ErrorMessage = "Chassis number must be exactly 17 characters.")]
        public string ChassiNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "Brand is required.")]
        public string Brand { get; set; } = string.Empty;

        [Required(ErrorMessage = "Model is required.")]
        public string Model { get; set; } = string.Empty;

        [ForeignKey("Customer")]
        public int CustomerID { get; set; }

        public Customer Customer { get; set; } = null!;
    }
}
