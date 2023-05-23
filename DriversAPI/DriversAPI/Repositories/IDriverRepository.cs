using DriversAPI.Models;

namespace DriversAPI.Repositories
{
    public interface IDriverRepository
    {
        Task<IEnumerable<Driver>> GetDrivers();
        Task<Driver> GetDriverById(int id);
        Task<int> CreateDriver(Driver driver);
        Task<int> UpdateDriver(Driver driver);
        Task<bool> DeleteDriver(int driverId);
    }
}
