namespace VehiclePassportAPI.Dtos.ServiceCenter
{
    public class ServiceCenterUpdateDto
    {
        public string StationName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Telephone { get; set; } = String.Empty;
        public string OwnerName { get; set; } = String.Empty;
        public string VATNumber { get; set; } = String.Empty;
        public string RegistrationNumber { get; set; } = String.Empty;
        public List<int> ServiceIds { get; set; }
    }
}
