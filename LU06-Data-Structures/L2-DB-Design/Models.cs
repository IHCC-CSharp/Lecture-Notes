namespace UrbanMobility;

public enum VehicleStatus
{
    InService = 1,
    Maintenance = 2,
    Retired = 3
}

public enum FuelType
{
    Gasoline = 1,
    Diesel = 2,
    Electric = 3,
    Hybrid = 4
}

public abstract class Vehicle
{
    public int Id { get; set; }
    public required string Vin { get; set; }
    public required string Make { get; set; }
    public required string Model { get; set; }
    public int Year { get; set; }
    public VehicleStatus Status { get; set; }
}

public sealed class Car : Vehicle
{
    public int DoorCount { get; set; }
    public FuelType FuelType { get; set; }
}

public sealed class Truck : Vehicle
{
    public decimal PayloadCapacityKg { get; set; }
    public int AxleCount { get; set; }
}

public sealed class Scooter : Vehicle
{
    public int BatteryWh { get; set; }
    public int MaxRangeKm { get; set; }
}