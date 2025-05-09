using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VPassport.Models
{
    public class CustomerVehicle
    {
        [Key]
        public int Vehicle_ID { get; set; }

        [Required]
        public string RegistrationNumber { get; set; }

        public int Customer_ID { get; set; }

        [ForeignKey("Customer_ID")]
        public Customer Customer { get; set; }

        [Required]
        public string Fuel { get; set; }

        [Required]
        public string ChassiNumber { get; set; }

        [Required]
        public string Brand { get; set; }

        [Required]
        public string Model { get; set; }

        public ICollection<Document> Documents { get; set; } = new List<Document>();
    }
}
