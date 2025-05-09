namespace VPassport.DTOs
{
    public class ServiceRecordResponseDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public string Description { get; set; }
        public decimal Cost { get; set; }
        public int VehicleId { get; set; }
    }
}
