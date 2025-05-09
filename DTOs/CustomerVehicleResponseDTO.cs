namespace VPassport.DTOs
{
    public class CustomerVehicleResponseDTO
    {
        public int Vehicle_ID { get; set; }
        public string RegistrationNumber { get; set; }
        public string Fuel { get; set; }
        public string ChassiNumber { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public int Customer_ID { get; set; }
    }
}
