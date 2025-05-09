using System;

namespace VPassport.DTOs
{
    public class FuelEntryReadDto
    {
        public int FuelEntryId { get; set; }
        public DateTime RefuelDate { get; set; }
        public decimal Litres { get; set; }
        public int VehicleId { get; set; }
    }
}
