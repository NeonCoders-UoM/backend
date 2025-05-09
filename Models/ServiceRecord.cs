using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VPassport.Models
{
    public class ServiceRecord
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,2)")]
        public decimal Cost { get; set; }

        // Foreign key
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public CustomerVehicle Vehicle { get; set; }
    }
}
