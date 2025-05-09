using System.ComponentModel.DataAnnotations;

namespace VehiclePassportAPI.Models
{
    public class Service
    {

        [Key]
        public int ServiceID { get; set; }

        public string ServiceName { get; set; } = string.Empty;
        public string DescriptionText { get; set; } = string.Empty;
        public decimal BasePrice { get; set; }
        public int LoyaltyPoints { get; set; }

        public ICollection<ServiceCenterProvidesService> ProvidedServices { get; set; } = new List<ServiceCenterProvidesService>();
        public ICollection<ServiceInAppointment> ServiceInAppointments { get; set; } = new List<ServiceInAppointment>();
    }
}
