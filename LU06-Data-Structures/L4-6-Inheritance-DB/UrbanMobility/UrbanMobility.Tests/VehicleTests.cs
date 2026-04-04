using UrbanMobility.Api.Models;
using Xunit;

namespace UrbanMobility.Tests;

public class VehicleTests
{
    [Theory]
    [InlineData(10, 1, 9)]    // $10/hr * 1hr * 0.9 discount = $9
    [InlineData(20, 5, 90)]   // $20/hr * 5hr * 0.9 discount = $90
    public void ElectricVehicle_CalculateRentalCost_AppliesGreenDiscount(decimal rate, int hours, decimal expected)
    {
        // Arrange
        var vehicle = new ElectricVehicle { HourlyRate = rate };

        // Act
        var result = vehicle.CalculateRentalCost(hours);

        // Assert
        Assert.Equal(expected, result);
    }

    [Theory]
    [InlineData(10, 1, 15)]   // $10/hr * 1hr + $5 fee = $15
    [InlineData(20, 2, 45)]   // $20/hr * 2hr + $5 fee = $45
    public void FuelVehicle_CalculateRentalCost_AddsEnvironmentalFee(decimal rate, int hours, decimal expected)
    {
        // Arrange
        var vehicle = new FuelVehicle { HourlyRate = rate };

        // Act
        var result = vehicle.CalculateRentalCost(hours);

        // Assert
        Assert.Equal(expected, result);
    }
}