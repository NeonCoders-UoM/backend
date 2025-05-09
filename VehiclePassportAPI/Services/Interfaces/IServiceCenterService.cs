using VehiclePassportAPI.Dtos.ServiceCenter;

namespace VehiclePassportAPI.Services.Interfaces
{
    public interface IServiceCenterService
    {
        Task<ServiceCenterDetailDto> AddServiceCenterAsync(ServiceCenterCreateDto dto);
        Task<ServiceCenterDetailDto> UpdateServiceCenterAsync(int id, ServiceCenterUpdateDto dto);
        Task<IEnumerable<ServiceCenterListDto>> GetAllServiceCentersAsync();
        Task<ServiceCenterDetailDto> GetServiceCenterByIdAsync(int id);
        Task<bool> DeleteServiceCenterAsync(int id);
    }
}
