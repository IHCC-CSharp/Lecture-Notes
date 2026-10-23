using GameLibrary.Api.Service;
using GameLibrary.Core.Models;
using GameLibrary.Core.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace GameLibrary.Api.Controllers;

[ApiController]
[Route("api/library")]
public class LibraryController(ILibraryService libraryService) : ControllerBase
{
    [HttpGet("games")]
    public async Task<ActionResult<IEnumerable<Game>>> GetAllGames()
    {
        var games = await libraryService.GetAllGamesAsync();
        // If games = []
        return games.Count() == 0 ? NotFound() : Ok(games);
    }

    [HttpGet("games/{id:int}")]
    public async Task<ActionResult<Game>> GetGameById(int id)
    {
        var game = await libraryService.GetGameByIdAsync(id);
        return game is null ? NotFound() : Ok(game);
    }

    [HttpPost("games")]
    public async Task<IActionResult> AddGame(GameRequest request)
    {
        var game = await libraryService.AddGameAsync(request);
        if (game is null)
        {
            return NotFound();
        }

        return CreatedAtAction(nameof(GetGameById), new { id = game.Id }, game);
    }

    [HttpGet("consoles")]
    public async Task<ActionResult<IEnumerable<string>>> GetAllConsoleNames()
    {
        var consoleNames = await libraryService.GetAllConsoleNamesAsync();
        return Ok(consoleNames);
    }

    [HttpPost("consoles")]
    public async Task<IActionResult> AddConsole(ConsoleRequest request)
    {
        var console = await libraryService.AddConsoleAsync(request);
        return StatusCode(StatusCodes.Status201Created, console);
    }

    [HttpGet("consoles/{consoleId:int}/games")]
    public async Task<ActionResult<IEnumerable<Game>>> GetGamesByConsoleId(int consoleId)
    {
        var games = await libraryService.GetGamesByConsoleIdAsync(consoleId);
        return Ok(games);
    }
}
