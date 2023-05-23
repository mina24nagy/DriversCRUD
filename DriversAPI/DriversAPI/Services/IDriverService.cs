using DriversAPI.Models.DTOs;

namespace DriversAPI.Services
{
    public interface IDriverService
    {
        Task<IEnumerable<DriverDto>> GetAll();
        Task<DriverDto> GetById(int id);
        Task<String> GetAlphabetizedDriverName(int driverId);
        Task Create(DriverDto driverDto);
        Task Update(DriverDto driverDto);
        Task<bool> Delete(int driverId);
        Task<bool> BulkInsert(int numOfRecords);
    }
}
