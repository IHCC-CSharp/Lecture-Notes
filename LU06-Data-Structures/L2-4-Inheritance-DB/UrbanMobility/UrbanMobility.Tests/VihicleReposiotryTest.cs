using Dapper;
using Microsoft.Data.Sqlite;
using UrbanMobility.Api.Models;
using UrbanMobility.Api.Repositories;

namespace UrbanMobility.Tests;

public class VehicleRepositoryTests
{
    private const string InMemoryConnectionString = "Data Source=InMemoryRepoTest;Mode=Memory;Cache=Shared";

    [Fact]
    public async Task SanityCheck()
    {
        using var connection = new SqliteConnection(InMemoryConnectionString);
        connection.Open();

        var repo = new VehicleRepository(InMemoryConnectionString);
        var ev = new ElectricVehicle { Vin = "TEST-123" };

        // Act
        await repo.CreateElectricAsync(ev);

        // ASSERT WITH VISUAL PROOF: 
        // Query the base table directly via Dapper to see if the row exists
        var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM Vehicles");
        var vin = connection.ExecuteScalar<string>("SELECT Vin FROM Vehicles LIMIT 1");

        Console.WriteLine($"Database Row Count: {count}");
        Console.WriteLine($"Database VIN found: {vin}");

        Assert.Equal(1, count);
        Assert.Equal("TEST-123", vin);
    }

    [Fact]
    public async Task CreateElectricAsync_AddsVehicleToDatabase()
    {
        //keeps the in-memory database alive 
        using var connection = new SqliteConnection(InMemoryConnectionString);
        connection.Open();

        //Arrange
        var repo = new VehicleRepository(InMemoryConnectionString);
        var ev = new ElectricVehicle
        {
            Vin = "EV123",
            ModelName = "Chevy Bolt",
            HourlyRate = 25.0m,
            Status = VehicleStatus.Available,
            BatteryCapacityKwh = 75.0,
            CurrentChargeLevel = 100
        };

        // Act
        var id = await repo.CreateElectricAsync(ev);
        var retrieved = await repo.GetByIdAsync(id);

        //Assert
        Assert.NotNull(retrieved);
        Assert.Equal("EV123", retrieved.Vin);
    }
}