using GlobalErrorApp.Models;

namespace GlobalErrorApp.Services;

public interface IDriverService
{
    Task<IEnumerable<Driver>> GetDrivers();
    Task<Driver?> GetDriverById(int id);
    Task<Driver> AddDriver(Driver driver);
    Task<Driver> UpdateDriver(Driver driver);
    Task<bool> DeleteDriver(int id);
}