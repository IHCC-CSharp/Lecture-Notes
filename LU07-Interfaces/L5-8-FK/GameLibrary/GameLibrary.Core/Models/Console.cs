namespace GameLibrary.Core.Models;

public class GameConsole
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public required string Manufacturer { get; set; }
    public DateTime ReleaseDate { get; set; }
    public ICollection<Game> Games { get; set; } = new List<Game>();
}