using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehiclePassportAPI.Models
{
    public class ServiceInAppointment
    {
        [Key]
        public int Id { get; set; }
        [Required] public int AppointmentID { get; set; }
        [Required] public int ServiceID { get; set; }

        [ForeignKey("ServiceID")] public Service Service { get; set; }
        [ForeignKey("AppointmentID")] public Appointment Appointment { get; set; }
    }
}
