using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehiclePassportAPI.Models
{
    public class CustomerVehicle
    {
        [Key]
        public int VehicleID { get; set; }

        [Required] public int CustomerID { get; set; }
        [ForeignKey("CustomerID")] public Customer Customer { get; set; }

        public string RegistrationNumber { get; set; } = string.Empty;
        public string Mileage { get; set; } = string.Empty;
        public string Fuel { get; set; } = string.Empty;
        public string ChassisNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;

        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
