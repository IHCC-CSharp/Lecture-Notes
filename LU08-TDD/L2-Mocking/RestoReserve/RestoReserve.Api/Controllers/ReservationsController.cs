using Microsoft.AspNetCore.Mvc;
using RestoReserve.Api.Service;
using RestoReserve.Core.DTOs;
using RestoReserve.Core.Models;

namespace RestoReserve.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ReservationsController(IReservationService reservationService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Reservation>>> GetAll()
    {
        return Ok(await reservationService.GetAllReservationsAsync());
    }

    [HttpGet("by-restaurant/{restaurantName}")]
    public async Task<ActionResult<IReadOnlyList<Reservation>>> GetByRestaurant(string restaurantName)
    {
        try
        {
            return Ok(await reservationService.GetReservationsByRestaurantNameAsync(restaurantName));
        }
        catch (ArgumentException exception)
        {
            return BadRequest(exception.Message);
        }
    }

    [HttpPost]
    public async Task<IActionResult> Create(CreateReservation request)
    {
        try
        {
            await reservationService.CreateReservationAsync(request);
            return StatusCode(StatusCodes.Status201Created);
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (InvalidOperationException exception)
        {
            return Conflict(exception.Message);
        }
    }

    [HttpPost("{reservationId:int}/cancel")]
    public async Task<ActionResult<Reservation>> Cancel(int reservationId)
    {
        try
        {
            return Ok(await reservationService.CancelReservationAsync(reservationId));
        }
        catch (KeyNotFoundException exception)
        {
            return NotFound(exception.Message);
        }
        catch (InvalidOperationException exception)
        {
            return Conflict(exception.Message);
        }
    }
}
