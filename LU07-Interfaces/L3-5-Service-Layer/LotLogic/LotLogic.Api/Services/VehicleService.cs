using LotLogic.Api.Data;
using LotLogic.Core.DTOs;
using LotLogic.Core.Models;
using LotLogic.Core.Services;
using Microsoft.EntityFrameworkCore;

namespace LotLogic.Api.Services;

public class VehicleService : IVehicleService
{
    private readonly LotLogicDbContext _db;

    public VehicleService(LotLogicDbContext db)
    {
        _db = db;
    }

    public async Task<VehicleResponse> CheckInAsync(CheckInRequest request)
    {
        var plate = request.LicensePlate.Trim().ToUpperInvariant();

        var vehicle = await _db.Vehicles
            .FirstOrDefaultAsync(v => v.LicensePlate == plate);

        if (vehicle is null)
        {
            vehicle = request.VehicleType switch
            {
                VehicleType.Car => (Vehicle)new Car { LicensePlate = plate },
                VehicleType.Motorcycle => new Motorcycle { LicensePlate = plate },
                _ => throw new ArgumentException("Unknown vehicle type.")
            };

            _db.Vehicles.Add(vehicle);
        }

        vehicle.CheckIn();
        await _db.SaveChangesAsync();

        return ToResponse(vehicle);
    }

    public async Task<VehicleResponse> CheckOutAsync(string licensePlate)
    {
        var plate = licensePlate.Trim().ToUpperInvariant();

        var vehicle = await _db.Vehicles
            .FirstOrDefaultAsync(v => v.LicensePlate == plate)
            ?? throw new KeyNotFoundException($"Vehicle {plate} not found.");

        vehicle.CheckOut();
        await _db.SaveChangesAsync();

        return ToResponse(vehicle);
    }

    public async Task<VehicleResponse> GetVehicleAsync(string licensePlate)
    {
        var plate = licensePlate.Trim().ToUpperInvariant();

        var vehicle = await _db.Vehicles
            .FirstOrDefaultAsync(v => v.LicensePlate == plate)
            ?? throw new KeyNotFoundException($"Vehicle {plate} not found.");

        return ToResponse(vehicle);
    }

    private static VehicleResponse ToResponse(Vehicle vehicle) => new()
    {
        Id = vehicle.Id,
        LicensePlate = vehicle.LicensePlate,
        VehicleType = vehicle is Car ? VehicleType.Car : VehicleType.Motorcycle,
        CheckInUtc = vehicle.CheckInUtc,
        CheckOutUtc = vehicle.CheckOutUtc,
        LastFee = vehicle.LastFee,
        TotalFees = vehicle.TotalFees
    };
}
