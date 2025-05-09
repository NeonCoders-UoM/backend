using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehiclePassportAPI.Models
{
    public class Appointment
    {
        [Key]
        public int AppointmentID { get; set; }

        [Required] public int VehicleID { get; set; }
        [Required] public int StationID { get; set; }
        [Required] public int CustomerID { get; set; }

        [ForeignKey("VehicleID")] public CustomerVehicle Vehicle { get; set; }
        [ForeignKey("StationID")] public ServiceStation ServiceStation { get; set; }
        [ForeignKey("CustomerID")] public Customer Customer { get; set; }

        public DateTime AppointmentDate { get; set; }
        public string Status { get; set; } = "Pending";  // Pending, Accepted, Rejected
        public string Type { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;

        public ICollection<ServiceInAppointment> Services { get; set; } = new List<ServiceInAppointment>();
    }
}
