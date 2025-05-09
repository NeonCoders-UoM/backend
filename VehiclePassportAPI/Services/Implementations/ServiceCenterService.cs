using Microsoft.EntityFrameworkCore;
using AutoMapper;
using VehiclePassportAPI.Data;
using VehiclePassportAPI.Dtos.ServiceCenter;
using VehiclePassportAPI.Models;
using VehiclePassportAPI.Services.Interfaces;

namespace VehiclePassportAPI.Services.Implementations
{
    public class ServiceCenterService : IServiceCenterService
    {
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public ServiceCenterService(AppDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }

        public async Task<ServiceCenterDetailDto> AddServiceCenterAsync(ServiceCenterCreateDto dto)
        {
            var serviceCenter = _mapper.Map<ServiceStation>(dto);

            // Add service relationships
            foreach (var serviceId in dto.ServiceIds)
            {
                serviceCenter.ServicesProvided.Add(new ServiceCenterProvidesService
                {
                    ServiceID = serviceId,
                    Status = "Active",
                    Price = 0 // Default price, can be changed later
                });
            }

            _context.ServiceStations.Add(serviceCenter);
            await _context.SaveChangesAsync();

            return _mapper.Map<ServiceCenterDetailDto>(serviceCenter);
        }

        public async Task<bool> DeleteServiceCenterAsync(int id)
        {
            var center = await _context.ServiceStations
                .Include(s => s.ServicesProvided)
                .FirstOrDefaultAsync(s => s.StationID == id);

            if (center == null)
                return false;

            _context.ServiceCenterProvidesServices.RemoveRange(center.ServicesProvided);
            _context.ServiceStations.Remove(center);

            await _context.SaveChangesAsync();
            return true;
        }

        public async Task<IEnumerable<ServiceCenterListDto>> GetAllServiceCentersAsync()
        {
            var centers = await _context.ServiceStations.ToListAsync();
            return _mapper.Map<IEnumerable<ServiceCenterListDto>>(centers);
        }

        public async Task<ServiceCenterDetailDto> GetServiceCenterByIdAsync(int id)
        {
            var center = await _context.ServiceStations
                .Include(s => s.ServicesProvided)
                    .ThenInclude(sp => sp.Service)
                .FirstOrDefaultAsync(s => s.StationID == id);

            if (center == null)
                return null;

            return _mapper.Map<ServiceCenterDetailDto>(center);
        }

        public async Task<ServiceCenterDetailDto> UpdateServiceCenterAsync(int id, ServiceCenterUpdateDto dto)
        {
            var existing = await _context.ServiceStations
                .Include(s => s.ServicesProvided)
                .FirstOrDefaultAsync(s => s.StationID == id);

            if (existing == null)
                return null;

            // Update basic fields
            _mapper.Map(dto, existing);

            // Update services
            var existingServiceIds = existing.ServicesProvided.Select(sp => sp.ServiceID).ToList();
            var newServiceIds = dto.ServiceIds.Distinct().ToList();

            var toRemove = existing.ServicesProvided.Where(sp => !newServiceIds.Contains(sp.ServiceID)).ToList();
            var toAdd = newServiceIds.Except(existingServiceIds);

            _context.ServiceCenterProvidesServices.RemoveRange(toRemove);

            foreach (var newId in toAdd)
            {
                existing.ServicesProvided.Add(new ServiceCenterProvidesService
                {
                    ServiceID = newId,
                    StationID = id,
                    Price = 0,
                    Status = "Active"
                });
            }

            await _context.SaveChangesAsync();

            return _mapper.Map<ServiceCenterDetailDto>(existing);
        }
    }
}
