using VehiclePassportAPI.Dtos.Service;

namespace VehiclePassportAPI.Dtos.Appointment
{
    public class AppointmentDetailDto
    {
        public int AppointmentID { get; set; }
        public string OwnerName { get; set; } = String.Empty;
        public string LicensePlateNumber { get; set; } = String.Empty;
        public DateTime AppointmentDate { get; set; }
        public string Vehicle { get; set; } = String.Empty;
        public List<ServiceDto> Services { get; set; }
        public string Status { get; set; } = String.Empty;
    }
}
