namespace VehiclePassportAPI.Dtos.Vehicle
{
    public class VehicleDto
    {
        public int VehicleId { get; set; } 
        public string RegistrationNumber { get; set; } = string.Empty;
        public string FuelType { get; set; } = string.Empty;
        public string ChassiNumber { get; set; } = string.Empty;
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
    }
}
