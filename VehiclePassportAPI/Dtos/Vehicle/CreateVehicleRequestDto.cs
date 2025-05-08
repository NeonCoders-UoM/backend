using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using VehiclePassportAPI.Models;

namespace VehiclePassportAPI.Dtos.Vehicle
{
    public class CreateVehicleRequestDto
    {          
        public string RegistrationNumber { get; set; } = string.Empty;            
        public string FuelType { get; set; } = string.Empty;     
        public string ChassiNumber { get; set; } = string.Empty;        
        public string Brand { get; set; } = string.Empty;       
        public string Model { get; set; } = string.Empty;
        public int CustomerID { get; set; } 

    }
}
