namespace VehiclePassportAPI.Dtos.Appointment
{
    public class AppointmentListDto
    {
        public int AppointmentID { get; set; }
        public string OwnerName { get; set; } = String.Empty;
        public DateTime AppointmentDate { get; set; }
    }
}
