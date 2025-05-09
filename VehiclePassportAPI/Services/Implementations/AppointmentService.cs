using Microsoft.EntityFrameworkCore;
using AutoMapper;
using VehiclePassportAPI.Data;
using VehiclePassportAPI.Dtos.Appointment;
using VehiclePassportAPI.Models;
using VehiclePassportAPI.Services.Interfaces;

namespace VehiclePassportAPI.Services.Implementations
{
    public class AppointmentService : IAppointmentService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public AppointmentService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<AppointmentDetailDto> CreateAppointmentAsync(AppointmentCreateDto dto)
        {
            var appointment = _mapper.Map<Appointment>(dto);

            foreach (var serviceId in dto.ServiceIds)
            {
                appointment.Services.Add(new ServiceInAppointment
                {
                    ServiceID = serviceId
                });
            }

            _context.Appointments.Add(appointment);
            await _context.SaveChangesAsync();

            // Fetch with relationships for detail DTO
            var created = await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Vehicle)
                .Include(a => a.Services)
                    .ThenInclude(s => s.Service)
                .FirstOrDefaultAsync(a => a.AppointmentID == appointment.AppointmentID);

            return _mapper.Map<AppointmentDetailDto>(created);
        }

        public async Task<IEnumerable<AppointmentListDto>> GetAppointmentsByServiceCenterAsync(int stationId)
        {
            var appointments = await _context.Appointments
                .Where(a => a.StationID == stationId)
                .Include(a => a.Customer)
                .ToListAsync();

            return _mapper.Map<IEnumerable<AppointmentListDto>>(appointments);
        }

        public async Task<AppointmentDetailDto> GetAppointmentByIdAsync(int id)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Customer)
                .Include(a => a.Vehicle)
                .Include(a => a.Services)
                    .ThenInclude(sa => sa.Service)
                .FirstOrDefaultAsync(a => a.AppointmentID == id);

            if (appointment == null)
                return null;

            return _mapper.Map<AppointmentDetailDto>(appointment);
        }

        public async Task<bool> AcceptAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments.FindAsync(id);
            if (appointment == null)
                return false;

            appointment.Status = "Accepted";
            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<bool> RejectAppointmentAsync(int id)
        {
            var appointment = await _context.Appointments
                .Include(a => a.Services)
                .FirstOrDefaultAsync(a => a.AppointmentID == id);

            if (appointment == null)
                return false;

            _context.ServicesInAppointment.RemoveRange(appointment.Services);
            _context.Appointments.Remove(appointment);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
