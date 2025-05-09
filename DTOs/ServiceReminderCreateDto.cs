namespace VPassport.DTOs
{
    public class ServiceReminderCreateDto
    {
        public int VehicleId { get; set; }
        public string ServiceType { get; set; } = string.Empty;
        public int TimeIntervalInMonths { get; set; }
        public int NotifyPeriodInDays { get; set; }
    }
}