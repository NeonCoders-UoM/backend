using System.ComponentModel.DataAnnotations;

namespace VehiclePassportAPI.Models
{
    public class ServiceStation
    {
        [Key]
        public int StationID { get; set; }

        public string VATNumber { get; set; } = string.Empty;
        public string OwnerName { get; set; } = string.Empty;
        public string RegistrationNumber { get; set; } = string.Empty;
        public string StationName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        [EmailAddress] public string Email { get; set; } = string.Empty;
        public string Telephone { get; set; } = string.Empty;
        public string StationStatus { get; set; } = string.Empty;

        public ICollection<ServiceCenterProvidesService> ServicesProvided { get; set; } = new List<ServiceCenterProvidesService>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
