namespace UrbanMobility.Api.Models;

public class ElectricVehicle : Vehicle
{
    public double BatteryCapacityKwh { get; set; }
    public int CurrentChargeLevel { get; set; } // 0-100

    public override decimal CalculateRentalCost(int hours)
    {
        // Give a 10% "Green Discount" for electric vehicles
        return (HourlyRate * hours) * 0.9m;
    }
}