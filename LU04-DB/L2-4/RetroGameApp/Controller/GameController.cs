using Microsoft.AspNetCore.Mvc;
using RetroGameApp.Models;
using RetroGameApp.DTOs;
using RetroGameApp.Repositories;

namespace RetroGameApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GamesController(GameRepository repo) : ControllerBase
{
    [HttpGet]
    public IResult GetAll()
    {
        var games = repo.GetAll();
        return Results.Ok(games);
    }


    // TODO change to DTO
    [HttpGet("search")]
    public IResult GetByFilter([FromQuery] string? platform, [FromQuery] string? genre)
    {
        var search = new GameSearchDto(platform, genre);
        var games = repo.GetByFilter(search);
        return Results.Ok(games);
    }

    [HttpPost]
    public IResult Add(VideoGame game)
    {
        repo.Add(game);
        // Returns a 201 Created status
        return Results.Created($"/api/games/{game.Id}", game);
    }
}