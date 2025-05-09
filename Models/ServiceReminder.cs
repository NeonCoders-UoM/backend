namespace VPassport.Models
{
    public class ServiceReminder
    {
        public int Id { get; set; }

        public int VehicleId { get; set; }
        public CustomerVehicle Vehicle { get; set; }

        public string ServiceType { get; set; } = string.Empty;

        public int TimeIntervalInMonths { get; set; }

        public int NotifyPeriodInDays { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public bool IsTriggered { get; set; }
    }
}