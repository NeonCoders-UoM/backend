using AutoMapper;
using VehiclePassportAPI.Dtos.Appointment;
using VehiclePassportAPI.Models;

namespace VehiclePassportAPI.Mappings
{
    public class AppointmentProfile : Profile
    {
        public AppointmentProfile()
        {
            CreateMap<Appointment, AppointmentListDto>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src =>
                    src.Customer.First_name + " " + src.Customer.Last_name));

            CreateMap<Appointment, AppointmentDetailDto>()
                .ForMember(dest => dest.OwnerName, opt => opt.MapFrom(src =>
                    src.Customer.First_name + " " + src.Customer.Last_name))
                .ForMember(dest => dest.LicensePlateNumber, opt => opt.MapFrom(src => src.Vehicle.RegistrationNumber))
                .ForMember(dest => dest.Vehicle, opt => opt.MapFrom(src =>
                    $"{src.Vehicle.Brand} {src.Vehicle.Model}"))
                .ForMember(dest => dest.Services, opt => opt.MapFrom(src =>
                    src.Services.Select(s => s.Service)));

            CreateMap<AppointmentCreateDto, Appointment>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(_ => "Pending"));
        }
    }
}
