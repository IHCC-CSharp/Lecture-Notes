using GameLibrary.Core.DTOs;
using GameLibrary.Core.Models;

namespace GameLibrary.Api.Service;

public interface ILibraryService
{
    Task<IEnumerable<Game>> GetAllGamesAsync();
    Task<Game?> GetGameByIdAsync(int id);
    Task<Game?> AddGameAsync(GameRequest request);

    Task<IEnumerable<string>> GetAllConsoleNamesAsync();
    Task<GameConsole> AddConsoleAsync(ConsoleRequest request);

    Task<IEnumerable<Game>> GetGamesByConsoleIdAsync(int consoleId);
}