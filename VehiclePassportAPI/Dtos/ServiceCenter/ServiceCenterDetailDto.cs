using VehiclePassportAPI.Dtos.Service;

namespace VehiclePassportAPI.Dtos.ServiceCenter
{
    public class ServiceCenterDetailDto
    {
        public int StationID { get; set; }
        public string StationName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Telephone { get; set; } = String.Empty;
        public string OwnerName { get; set; } = String.Empty;
        public string VATNumber { get; set; } = String.Empty;
        public string RegistrationNumber { get; set; } = String.Empty;
        public decimal CommissionRate { get; set; }
        public List<ServiceDto> Services { get; set; }
    }
}
