using System.ComponentModel.DataAnnotations;

namespace VehiclePassportAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        public string First_name { get; set; } = string.Empty;
        public string Last_name { get; set; } = string.Empty;
        [EmailAddress] public string Email { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhoneNumber { get; set; } = string.Empty;
        public string Password { get; set; } = string.Empty;
        public string NIC { get; set; } = string.Empty;
        public int LoyaltyPoints { get; set; }
        public string ProfilePicture { get; set; } = string.Empty;

        public ICollection<CustomerVehicle> Vehicles { get; set; } = new List<CustomerVehicle>();
        public ICollection<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}
