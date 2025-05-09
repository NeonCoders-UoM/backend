using AutoMapper;
using VehiclePassportAPI.Dtos.ServiceCenter;
using VehiclePassportAPI.Models;

namespace VehiclePassportAPI.Mappings
{
    public class ServiceCenterProfile : Profile
    {
        public ServiceCenterProfile()
        {
            CreateMap<ServiceStation, ServiceCenterListDto>();
            CreateMap<ServiceStation, ServiceCenterDetailDto>()
                .ForMember(dest => dest.Services, opt => opt.MapFrom(src =>
                    src.ServicesProvided.Select(sp => sp.Service)));

            CreateMap<ServiceCenterCreateDto, ServiceStation>()
                .ForMember(dest => dest.StationName, opt => opt.MapFrom(src => src.StationName))
                .ForMember(dest => dest.Email, opt => opt.MapFrom(src => src.Email))
                .ForMember(dest => dest.Address, opt => opt.MapFrom(src => src.Address))
                .ForMember(dest => dest.Telephone, opt => opt.MapFrom(src => src.Telephone))
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src => src.OwnerName))
                .ForMember(dest => dest.VATNumber, opt => opt.MapFrom(src => src.VATNumber))
                .ForMember(dest => dest.RegistrationNumber, opt => opt.MapFrom(src => src.RegistrationNumber))
                .ForMember(dest => dest.StationStatus, opt => opt.MapFrom(_ => "Active"));

            CreateMap<ServiceCenterUpdateDto, ServiceStation>();
        }
    }
}
