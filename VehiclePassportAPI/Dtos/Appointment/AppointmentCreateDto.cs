namespace VehiclePassportAPI.Dtos.Appointment
{
    public class AppointmentCreateDto
    {
        public int CustomerID { get; set; }
        public int VehicleID { get; set; }
        public int StationID { get; set; }
        public DateTime AppointmentDate { get; set; }
        public List<int> ServiceIds { get; set; }
    }
}
