namespace UrbanMobility.Api.Models;

public class FuelVehicle : Vehicle
{
    public double FuelTankSizeLiters { get; set; }
    public EngineType Engine { get; set; }

    public override decimal CalculateRentalCost(int hours)
    {
        // Fuel vehicles have a flat rate plus a $5 environmental fee
        return (HourlyRate * hours) + 5.00m;
    }
    
}