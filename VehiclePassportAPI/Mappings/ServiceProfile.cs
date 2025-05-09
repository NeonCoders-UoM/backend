using AutoMapper;
using VehiclePassportAPI.Dtos.Service;
using VehiclePassportAPI.Models;

namespace VehiclePassportAPI.Mappings
{
    public class ServiceProfile : Profile
    {
        public ServiceProfile()
        {
            CreateMap<Service, ServiceDto>();
        }
    }
}
