namespace VPassport.DTOs
{
    public class ServiceReminderDto
    {
        public int Id { get; set; }
        public int VehicleId { get; set; }
        public string ServiceType { get; set; } = string.Empty;
        public int TimeIntervalInMonths { get; set; }
        public int NotifyPeriodInDays { get; set; }
    }
}