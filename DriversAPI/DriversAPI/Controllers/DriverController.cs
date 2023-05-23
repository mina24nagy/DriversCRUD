using DriversAPI.Models.DTOs;
using DriversAPI.Services;
using Microsoft.AspNetCore.Mvc;

namespace DriversAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class DriverController : ControllerBase
    {
        private readonly ResponseDto _response;
        private readonly IDriverService _driverService;

        public DriverController(IDriverService driverService)
        {
            this._response = new ResponseDto();
            this._driverService = driverService;
        }

        [HttpGet]
        public async Task<object> Get()
        {
            try
            {
                IEnumerable<DriverDto> driversList = await _driverService.GetAll();
                _response.Result = driversList;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
            }
            return _response;
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<object> Get(int id)
        {
            try
            {
                DriverDto driverDto = await _driverService.GetById(id);
                _response.Result = driverDto;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
            }
            return _response;
        }

        [HttpGet]
        [Route("alphabetized/{id}")]
        public async Task<object> GetAlphabetizedDriverName(int id)
        {
            try
            {
                string alphabetizedDriverName = await _driverService.GetAlphabetizedDriverName(id);
                _response.Result = alphabetizedDriverName;
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
            }

            return _response;
        }

        [HttpPost]
        public async Task<object> Create([FromBody] DriverDto driverDto)
        {
            try
            {
                await _driverService.Create(driverDto);
                _response.DisplayMessage = "Driver Added Successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
                _response.DisplayMessage = "Driver Not Added Successfully";
            }
            return _response;
        }

        [HttpPut]
        public async Task<object> Put([FromBody] DriverDto driverDto)
        {
            try
            {
                await _driverService.Update(driverDto);
                _response.DisplayMessage = "Driver Updated Successfully"; 
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
                _response.DisplayMessage = "Driver Not Updated Successfully";
            }
            return _response;
        }

        [HttpDelete("{id:int}")]
        public async Task<object> Delete(int id)
        {
            try
            {
                bool isDeleted = await _driverService.Delete(id);
                _response.Result = isDeleted;
                _response.DisplayMessage = "Driver Deleted Successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
                _response.DisplayMessage = "Driver Not Deleted Successfully";
            }
            return _response;
        }

        [HttpPost("{numOfRecords:int}")]
        public async Task<object> BulkInsert(int numOfRecords)
        {
            try
            {
                bool isInserted = await _driverService.BulkInsert(numOfRecords);
                _response.Result = isInserted;
                _response.DisplayMessage = "Bulk Insert Is Done Successfully";
            }
            catch (Exception ex)
            {
                _response.IsSuccess = false;
                _response.ErrorMessages.Add(ex.Message);
                _response.DisplayMessage = "Bulk Insert Is Not Done Successfully";
            }
            return _response;
        }
    }
}
