using Microsoft.AspNetCore.Mvc;
using RetroGameApp.Models;
using RetroGameApp.DTOs;
using RetroGameApp.Repositories;

namespace RetroGameApp.Controllers;

[ApiController]
[Route("api/[controller]")]
public class GameController(GameRepository repo) : ControllerBase
{
    [HttpGet]
    public IResult GetAll()
    {
        var games = repo.GetAll();
        return Results.Ok(games);
    }


    // TODO change to DTO
    // http://localhost:5000/api/Game/Search?platform=NES
    // http://localhost:5000/api/Game/search?platform=NES&genre=Platformer
    [HttpGet("search")]
    public IResult Search([FromQuery] GameSearchDto search)
    {
        var games = repo.Search(search);
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