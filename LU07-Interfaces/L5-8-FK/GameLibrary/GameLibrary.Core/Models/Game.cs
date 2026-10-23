namespace GameLibrary.Core.Models;

public class Game
{
    public int Id { get; set; }
    public required string Title { get; set; }
    public required string Genre { get; set; }
    public DateTime ReleaseDate { get; set; }
    public int ConsoleId { get; set; }
    public GameConsole Console { get; set; } = null!;
}