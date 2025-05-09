namespace VehiclePassportAPI.Dtos.Service
{
    public class ServiceDto
    {
        public int ServiceID { get; set; }
        public string ServiceName { get; set; } = String.Empty;
        public string DescriptionText { get; set; } = String.Empty;
        public decimal BasePrice { get; set; }
        public int LoyaltyPoints { get; set; }
    }
}
