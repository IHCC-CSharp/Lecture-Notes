using Microsoft.EntityFrameworkCore;
using RestoReserve.Core.Models;

namespace RestoReserve.Api.Data;

public class RestoContext(DbContextOptions<RestoContext> options) : DbContext(options)
{
    public DbSet<Restaurant> Restaurants { get; set; }
    public DbSet<Reservation> Reservations { get; set; }
}