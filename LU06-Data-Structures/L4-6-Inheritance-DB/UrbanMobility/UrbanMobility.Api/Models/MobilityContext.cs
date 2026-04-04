namespace UrbanMobility.Api.Models;

using Microsoft.EntityFrameworkCore;

public class MobilityContext : DbContext
{
    public MobilityContext(DbContextOptions<MobilityContext> options) : base(options)
    {
    }

    // Question: How many tables will this create in the database? Why?
    // Answer: It will create 1 table for Vehicles.
    public DbSet<Vehicle> Vehicles => Set<Vehicle>();
    public DbSet<ElectricVehicle> ElectricVehicles => Set<ElectricVehicle>();
    public DbSet<FuelVehicle> FuelVehicles => Set<FuelVehicle>();
}