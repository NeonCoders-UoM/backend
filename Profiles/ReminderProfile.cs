using AutoMapper;
using VPassport.DTOs;
using VPassport.Models;
using VPassport.DTOs;
using VPassport.Models;
using static System.Runtime.InteropServices.JavaScript.JSType;

public class ReminderProfile : Profile
{
    public ReminderProfile()
    {
        CreateMap<ServiceReminder, ServiceReminderReadDto>();
        CreateMap<ServiceReminderCreateDto, ServiceReminder>();
    }
}
