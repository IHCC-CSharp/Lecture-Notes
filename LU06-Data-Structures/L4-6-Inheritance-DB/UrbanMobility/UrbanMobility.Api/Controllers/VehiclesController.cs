using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using UrbanMobility.Api.Models;

namespace UrbanMobility.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly MobilityContext _context;

    public VehiclesController(MobilityContext context)
    {
        _context = context;
    }

    [HttpGet]
    public async Task<IResult> GetAll()
    {
        var vehicles = await _context.Vehicles.ToListAsync();
        return Results.Ok(vehicles);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetById(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);

        return vehicle is not null
            ? Results.Ok(vehicle)
            : Results.NotFound();
    }

    [HttpPost("electric")]
    public async Task<IResult> CreateElectric(CreateElectricRequest request)
    {
        var vehicle = new ElectricVehicle
        {
            Vin = request.Vin,
            ModelName = request.ModelName,
            HourlyRate = request.HourlyRate,
            Status = request.Status,
            BatteryCapacityKwh = request.BatteryCapacityKwh,
            CurrentChargeLevel = request.CurrentChargeLevel
        };

        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();

        return Results.Created($"/api/vehicles/{vehicle.Id}", vehicle);
    }

    [HttpPost("fuel")]
    public async Task<IResult> CreateFuel(CreateFuelRequest request)
    {
        var vehicle = new FuelVehicle
        {
            Vin = request.Vin,
            ModelName = request.ModelName,
            HourlyRate = request.HourlyRate,
            Status = request.Status,
            FuelTankSizeLiters = request.FuelTankSizeLiters,
            Engine = request.Engine
        };

        _context.Vehicles.Add(vehicle);
        await _context.SaveChangesAsync();

        return Results.Created($"/api/vehicles/{vehicle.Id}", vehicle);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        var vehicle = await _context.Vehicles.FindAsync(id);
        if (vehicle is null)
        {
            return Results.NotFound();
        }

        _context.Vehicles.Remove(vehicle);
        await _context.SaveChangesAsync();

        return Results.NoContent();
    }
}