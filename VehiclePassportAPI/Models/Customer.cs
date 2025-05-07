using System.ComponentModel.DataAnnotations;

namespace VehiclePassportAPI.Models
{
    public class Customer
    {
        [Key]
        public int CustomerID { get; set; }

        [Required(ErrorMessage = "First name is required")]
        public string FirstName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Last name is required.")]
        public string LastName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Password hash is required.")]
        [StringLength(16, MinimumLength = 8, ErrorMessage = "Password must be between 8 and 16 characters.")]
        public string Password { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string Email { get; set; } = string.Empty;

        public string Address { get; set; } = string.Empty;

        [StringLength(10, MinimumLength = 10, ErrorMessage = "Phone number must be exactly 10 digits.")]
        [RegularExpression(@"^\d{10}$", ErrorMessage = "Phone number must contain exactly 10 digits.")]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required(ErrorMessage = "NIC is required.")]
        [StringLength(12, MinimumLength = 12, ErrorMessage = "NIC must have 12 characters")]
        public string NIC { get; set; } = string.Empty;

        [Range(0, int.MaxValue, ErrorMessage = "Loyalty points cannot be negative.")]
        public int LoyaltyPoints { get; set; }

        [Url(ErrorMessage = "Invalid URL format for profile picture.")]
        public string ProfilePicture { get; set; } = string.Empty;

        public List<Vehicle> Vehicles { get; set; } = null!;
    }
}
