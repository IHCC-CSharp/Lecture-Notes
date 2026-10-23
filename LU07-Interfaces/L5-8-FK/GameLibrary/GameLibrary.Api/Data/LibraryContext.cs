using GameLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Api.Data;

public class LibraryContext : DbContext
{
    public LibraryContext(DbContextOptions<LibraryContext> options) : base(options)
    {
    }

    public DbSet<Game> Games => Set<Game>();
    public DbSet<GameConsole> Consoles => Set<GameConsole>();


    // Explicitly configure the relationship between Game and Console entities
    // We don't need this because EF Core can infer the relationship based on 
    // the foreign key in the Game entity.
    // protected override void OnModelCreating(ModelBuilder modelBuilder)
    // {
    //     modelBuilder.Entity<GameConsole>()
    //         .HasMany(console => console.Games)
    //         .WithOne(game => game.Console)
    //         .HasForeignKey(game => game.ConsoleId)
    //         .IsRequired();
    // }
}