namespace VPassport.DTOs
{
    public class PartWarrantyDto
    {
        public int Id { get; set; }
        public string PartName { get; set; } = null!;
        public string? WarrantyProvider { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationInMonths { get; set; }
        public DateTime ExpiryDate { get; set; }
        public int VehicleId { get; set; }
    }
}
