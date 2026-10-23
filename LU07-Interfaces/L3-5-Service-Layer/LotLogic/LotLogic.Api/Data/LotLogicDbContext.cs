using LotLogic.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace LotLogic.Api.Data;

public class LotLogicDbContext : DbContext
{
    public LotLogicDbContext(DbContextOptions<LotLogicDbContext> options) : base(options)
    {
    }

    public DbSet<Vehicle> Vehicles => Set<Vehicle>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Vehicle>()
            .UseTpcMappingStrategy();

        modelBuilder.Entity<Car>().ToTable("Cars");
        modelBuilder.Entity<Motorcycle>().ToTable("Motorcycles");
    }
}
