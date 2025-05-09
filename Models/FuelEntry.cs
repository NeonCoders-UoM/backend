using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using VPassport.Models;

namespace VPassport.Models
{
    public class FuelEntry
    {
        [Key]
        public int FuelEntryId { get; set; }

        [Required]
        public int VehicleId { get; set; }

        [ForeignKey("VehicleId")]
        public CustomerVehicle Vehicle { get; set; }

        [Required]
        public DateTime RefuelDate { get; set; }

        [Required]
        public decimal Litres { get; set; }
    }
}
