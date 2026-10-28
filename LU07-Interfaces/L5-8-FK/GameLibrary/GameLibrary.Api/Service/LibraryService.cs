using GameLibrary.Api.Data;
using GameLibrary.Core.DTOs;
using GameLibrary.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace GameLibrary.Api.Service;

public class LibraryService(LibraryContext context) : ILibraryService
{
    public async Task<IEnumerable<Game>> GetAllGamesAsync() =>
        await context.Games.ToListAsync();

    public async Task<Game?> GetGameByIdAsync(int id) =>
        await context.Games.FindAsync(id);

    public async Task<Game?> AddGameAsync(GameRequest request)
    {
        //TODO example this line didn't work???
        var consoleExists = await context.Consoles
            .AnyAsync(gameConsole => gameConsole.Id == request.ConsoleId);
        if (!consoleExists)
        {
            return null;
        }

        var game = new Game
        {
            Title = request.Title,
            Genre = request.Genre,
            ReleaseDate = request.ReleaseDate,
            ConsoleId = request.ConsoleId
        };
        context.Games.Add(game);
        await context.SaveChangesAsync();
        return game;
    }

    public async Task<IEnumerable<string>> GetAllConsoleNamesAsync() =>
        await context.Consoles
            .Select(gameConsole => gameConsole.Name)
            .ToListAsync();

    public async Task<GameConsole> AddConsoleAsync(ConsoleRequest request)
    {
        var console = new GameConsole
        {
            Name = request.Name,
            Manufacturer = request.Manufacturer,
            ReleaseDate = request.ReleaseDate
        };
        context.Consoles.Add(console);
        await context.SaveChangesAsync();
        return console;
    }

    public async Task<IEnumerable<Game>> GetGamesByConsoleIdAsync(int consoleId)
    {
        return await context.Games
            .Where(game => game.ConsoleId == consoleId)
            .ToListAsync();
    }
}
