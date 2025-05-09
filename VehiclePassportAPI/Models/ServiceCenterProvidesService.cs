using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace VehiclePassportAPI.Models
{
    public class ServiceCenterProvidesService
    {
        [Key]
        public int Id { get; set; }
        [Required] public int StationID { get; set; }
        [Required] public int ServiceID { get; set; }
        [ForeignKey("StationID")] public ServiceStation ServiceStation { get; set; }
        [ForeignKey("ServiceID")] public Service Service { get; set; }

        public decimal Price { get; set; }
        public string Status { get; set; } = string.Empty;
    }
}
