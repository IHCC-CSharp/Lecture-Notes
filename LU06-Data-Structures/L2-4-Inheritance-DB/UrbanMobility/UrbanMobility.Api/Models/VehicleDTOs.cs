namespace UrbanMobility.Api.Models;

public abstract record CreateVehicleRequest(
    string Vin,
    string ModelName,
    decimal HourlyRate,
    VehicleStatus Status
);

public record CreateElectricRequest(
    string Vin,
    string ModelName,
    decimal HourlyRate,
    VehicleStatus Status,
    double BatteryCapacityKwh,
    int CurrentChargeLevel
) : CreateVehicleRequest(Vin, ModelName, HourlyRate, Status);

public record CreateFuelRequest(
    string Vin,
    string ModelName,
    decimal HourlyRate,
    VehicleStatus Status,
    double FuelTankSizeLiters,
    EngineType Engine
) : CreateVehicleRequest(Vin, ModelName, HourlyRate, Status);