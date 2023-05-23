using AutoMapper;
using DriversAPI.Helpers;
using DriversAPI.Models;
using DriversAPI.Models.DTOs;
using DriversAPI.Repositories;

namespace DriversAPI.Services
{
    public class DriverService : IDriverService
    {
        private readonly IDriverRepository _driverRepository;
        private readonly IMapper _mapper;

        public DriverService(IDriverRepository driverRepository, IMapper mapper)
        {
            _driverRepository = driverRepository;
            _mapper = mapper;
        }

        public async Task<IEnumerable<DriverDto>> GetAll()
        {
            return _mapper.Map<IEnumerable<Driver>, IEnumerable<DriverDto>>(await _driverRepository.GetDrivers());
        }

        public async Task<DriverDto> GetById(int driverId)
        {
            var driver = await _driverRepository.GetDriverById(driverId);

            return driver == null
                ? throw new KeyNotFoundException("Driver not found")
                : _mapper.Map<Driver, DriverDto>(driver);
        }

        public async Task<String> GetAlphabetizedDriverName(int driverId)
        {
            var driver = await _driverRepository.GetDriverById(driverId);

            return driver == null
                ? throw new KeyNotFoundException("Driver not found")
                : $"{StringUtility.SortString(driver.FirstName)} {StringUtility.SortString(driver.LastName)}";
        }

        public async Task Create(DriverDto driverDto)
        {
            var driver = _mapper.Map<DriverDto, Driver>(driverDto);
            await _driverRepository.CreateDriver(driver);
        }

        public async Task Update(DriverDto driverDto)
        {
            var driverExists = await _driverRepository.GetDriverById(driverDto.Id);
            if (driverExists == null)
                throw new KeyNotFoundException("Driver not found");

            var driver = _mapper.Map<DriverDto, Driver>(driverDto);
            await _driverRepository.UpdateDriver(driver);
        }

        public async Task<bool> Delete(int driverId)
        {
            var driverExists = await _driverRepository.GetDriverById(driverId);
            if (driverExists == null)
                throw new KeyNotFoundException("Driver not found");

            return await _driverRepository.DeleteDriver(driverId);
        }

        public async Task<bool> BulkInsert(int numOfRecords)
        {
            for (int i = 0; i < numOfRecords; i++)
            {
                var driver = new Driver()
                {
                    FirstName = StringUtility.GetRandomString(),
                    LastName = StringUtility.GetRandomString(),
                    PhoneNumber = StringUtility.GetRandomPhoneNumber(),
                    Email =
                        $"{StringUtility.GetRandomString().ToLower()}@{StringUtility.GetRandomString().ToLower()}.com"
                };

                await _driverRepository.CreateDriver(driver);
            }

            return true;
        }

    }
}
