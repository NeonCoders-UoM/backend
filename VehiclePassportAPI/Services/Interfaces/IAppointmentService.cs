using VehiclePassportAPI.Dtos.Appointment;

namespace VehiclePassportAPI.Services.Interfaces
{
    public interface IAppointmentService
    {
        Task<AppointmentDetailDto> CreateAppointmentAsync(AppointmentCreateDto dto);
        Task<IEnumerable<AppointmentListDto>> GetAppointmentsByServiceCenterAsync(int stationId);
        Task<AppointmentDetailDto> GetAppointmentByIdAsync(int id);
        Task<bool> AcceptAppointmentAsync(int id);
        Task<bool> RejectAppointmentAsync(int id);
    }
}
