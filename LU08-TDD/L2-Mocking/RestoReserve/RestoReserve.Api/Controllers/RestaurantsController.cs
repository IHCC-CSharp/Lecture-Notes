using Microsoft.AspNetCore.Mvc;
using RestoReserve.Api.Service;
using RestoReserve.Core.DTOs;
using RestoReserve.Core.Models;

namespace RestoReserve.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class RestaurantsController(IRestaurantService restaurantService) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IReadOnlyList<Restaurant>>> GetAll()
    {
        return Ok(await restaurantService.GetAllRestaurantsAsync());
    }

    [HttpGet("names")]
    public async Task<ActionResult<IReadOnlyList<string>>> GetNames()
    {
        return Ok(await restaurantService.GetRestaurantNamesAsync());
    }

    [HttpPost]
    public async Task<ActionResult<Restaurant>> Create(CreateRestoRequest request)
    {
        var restaurant = await restaurantService.CreateRestaurantAsync(request);
        return StatusCode(StatusCodes.Status201Created, restaurant);
    }
}
