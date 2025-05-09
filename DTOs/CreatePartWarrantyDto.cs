namespace VPassport.DTOs
{
    public class CreatePartWarrantyDto
    {
        public string PartName { get; set; } = null!;
        public string? WarrantyProvider { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationInMonths { get; set; }
        public int VehicleId { get; set; }
    }
}
