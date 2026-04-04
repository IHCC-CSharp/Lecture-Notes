using Microsoft.AspNetCore.Mvc;
using UrbanMobility.Api.Models;
using UrbanMobility.Api.Repositories;

namespace UrbanMobility.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
public class VehiclesController : ControllerBase
{
    private readonly VehicleRepository _repository;

    public VehiclesController(VehicleRepository repository)
    {
        _repository = repository;
    }

    [HttpGet]
    public async Task<IResult> GetAll()
    {
        var vehicles = await _repository.GetAllAsync();
        return Results.Ok(vehicles);
    }

    [HttpGet("{id}")]
    public async Task<IResult> GetById(int id)
    {
        var vehicle = await _repository.GetByIdAsync(id);

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

        var id = await _repository.CreateElectricAsync(vehicle);
        vehicle.Id = id;

        return Results.Created($"/api/vehicles/{id}", vehicle);
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

        var id = await _repository.CreateFuelAsync(vehicle);
        vehicle.Id = id;

        return Results.Created($"/api/vehicles/{id}", vehicle);
    }

    [HttpDelete("{id}")]
    public async Task<IResult> Delete(int id)
    {
        var deleted = await _repository.DeleteAsync(id);

        return deleted
            ? Results.NoContent()
            : Results.NotFound();
    }
}