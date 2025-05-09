using System.ComponentModel.DataAnnotations;

namespace VPassport.Models
{
    public class Customer
    {
        [Key]
        public int Customer_ID { get; set; }

        [Required]
        public string First_name { get; set; }

        [Required]
        public string Last_name { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        public string Address { get; set; }

        [Required]
        public string PhoneNumber { get; set; }

        [Required]
        public string NIC { get; set; }

        [Required]
        public string Password { get; set; }

        public ICollection<CustomerVehicle> Vehicles { get; set; } = new List<CustomerVehicle>();
    }
}
