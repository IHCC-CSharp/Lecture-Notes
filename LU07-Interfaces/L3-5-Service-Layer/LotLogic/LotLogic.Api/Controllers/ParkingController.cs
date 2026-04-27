using LotLogic.Core.DTOs;
using LotLogic.Core.Services;
using Microsoft.AspNetCore.Mvc;

namespace LotLogic.Api.Controllers;

[ApiController]
[Route("api/parking")]
public class ParkingController : ControllerBase
{
    private readonly IVehicleService _service;

    public ParkingController(IVehicleService service)
    {
        _service = service;
    }

    // POST /api/parking/checkin
    [HttpPost("checkin")]
    public async Task<IActionResult> CheckIn(CheckInRequest request)
    {
        var result = await _service.CheckInAsync(request);
        return Ok(result);
    }

    // POST /api/parking/checkout/{licensePlate}
    [HttpPost("checkout/{licensePlate}")]
    public async Task<IActionResult> CheckOut(string licensePlate)
    {
        var result = await _service.CheckOutAsync(licensePlate);
        return Ok(result);
    }

    // GET /api/parking/{licensePlate}
    [HttpGet("{licensePlate}")]
    public async Task<IActionResult> GetVehicle(string licensePlate)
    {
        var result = await _service.GetVehicleAsync(licensePlate);
        return Ok(result);
    }
}
