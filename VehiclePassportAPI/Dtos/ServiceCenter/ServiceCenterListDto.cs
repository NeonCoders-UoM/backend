namespace VehiclePassportAPI.Dtos.ServiceCenter
{
    public class ServiceCenterListDto
    {
        public int StationID { get; set; }
        public string StationName { get; set; } = String.Empty;
        public string Email { get; set; } = String.Empty;
        public string Address { get; set; } = String.Empty;
        public string Telephone { get; set; } = String.Empty;
    }
}
