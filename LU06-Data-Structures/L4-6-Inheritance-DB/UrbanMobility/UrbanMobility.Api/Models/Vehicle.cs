namespace UrbanMobility.Api.Models;

public abstract class Vehicle
{
    public int Id { get; set; }
    public string Vin { get; set; } = string.Empty;
    public string ModelName { get; set; } = string.Empty;
    public decimal HourlyRate { get; set; }
    public VehicleStatus Status { get; set; }

    public abstract decimal CalculateRentalCost(int hours);
}