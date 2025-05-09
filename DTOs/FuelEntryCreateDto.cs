using System;
using System.ComponentModel.DataAnnotations;

namespace VPassport.DTOs
{
    public class FuelEntryCreateDto
    {
        [Required]
        public int VehicleId { get; set; }

        [Required]
        public DateTime RefuelDate { get; set; }

        [Required]
        public decimal Litres { get; set; }
    }
}
