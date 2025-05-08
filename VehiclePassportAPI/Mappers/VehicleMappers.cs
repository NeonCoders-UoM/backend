using VehiclePassportAPI.Dtos.Vehicle;
using VehiclePassportAPI.Models;

namespace VehiclePassportAPI.Mappers
{
    public static class VehicleMappers
    {
        public static Vehicle ToVehicleFromCreateDto(this CreateVehicleRequestDto vehicleDto)
        {
            return new Vehicle
            {
                RegistrationNumber = vehicleDto.RegistrationNumber,
                FuelType = vehicleDto.FuelType,
                ChassiNumber = vehicleDto.ChassiNumber,
                Brand = vehicleDto.Brand,
                Model =vehicleDto.Model,
                CustomerID =vehicleDto.CustomerID,
                Mileage = vehicleDto.Mileage
            };
        }

        public static VehicleDto ToVehicleDto(this Vehicle vehicleModel)
        {
            return new VehicleDto {
                VehicleId = vehicleModel.VehicleID,
                RegistrationNumber = vehicleModel.RegistrationNumber,
                FuelType = vehicleModel.FuelType,
                ChassiNumber = vehicleModel.ChassiNumber,
                Brand = vehicleModel.Brand,
                Model = vehicleModel.Model,
                Mileage = vehicleModel.Mileage
            };
        }
    }
}
