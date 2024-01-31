using GlobalErrorApp.Exceptions;
using GlobalErrorApp.Models;
using GlobalErrorApp.Services;
using Microsoft.AspNetCore.Mvc;

namespace GlobalErrorApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DriversController : ControllerBase
{
    private readonly ILogger<DriversController> _logger;
    private readonly IDriverService _driverService;

    public DriversController(
        ILogger<DriversController> logger, 
        IDriverService driverService)
    {
        _logger = logger;
        _driverService = driverService;
    }

    [HttpGet("DriverList")]
    public async Task<IActionResult> DriverList()
    {
        var drivers = await _driverService.GetDrivers();
        return Ok(drivers);
    }

    [HttpPost("AddDriver")]
    public async Task<IActionResult> AddDriver(Driver driver)
    {
        var result = await _driverService.AddDriver(driver);
        return Ok(result);
    }

    [HttpGet("GetDriverById")]
    public async Task<IActionResult> GetDriverById(int id)
    {
        throw new BadRequestException("This is not a valid id");

        var driver = await _driverService.GetDriverById(id);

        if (driver is null)
        {
            // return NotFound();
            throw new NotFoundException("The id is an invali id");
        }

        return Ok(driver);
    }

}