namespace VPassport.Models
{
    public class PartWarranty
    {
        public int Id { get; set; }
        public string PartName { get; set; } = null!;
        public string? WarrantyProvider { get; set; }
        public DateTime StartDate { get; set; }
        public int DurationInMonths { get; set; }

        public DateTime ExpiryDate => StartDate.AddMonths(DurationInMonths);

        public int VehicleId { get; set; }
        public CustomerVehicle Vehicle { get; set; } = null!;
    }
}
