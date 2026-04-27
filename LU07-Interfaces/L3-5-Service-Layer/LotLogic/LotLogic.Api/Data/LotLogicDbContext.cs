using LotLogic.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LotLogic.Api.Data;

public class LotLogicDbContext : DbContext
{
    public LotLogicDbContext(DbContextOptions<LotLogicDbContext> options) : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // Configure TPH inheritance for Vehicle, Car, and Motorcycle
        modelBuilder.Entity<Vehicle>()
            .HasDiscriminator<string>("VehicleType")
            .HasValue<Car>("Car")
            .HasValue<Motorcycle>("Motorcycle");
    }
}
