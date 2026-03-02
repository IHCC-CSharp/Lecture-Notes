using Microsoft.AspNetCore.Mvc;
using PokeAPI.Models;

namespace PokeAPI.Controllers;

[ApiController]
[Route("api/pokemon")]
public class PokemonController : ControllerBase
{
    [HttpGet]
    public IResult Get()
    {
        return Results.Ok(PokemonData.Pokedex);
    }

    [HttpGet("{name}")]
    public IResult GetByName(string name)
    {
        // LINQ Fuzzy search 
        var pokemon = PokemonData.Pokedex.FirstOrDefault(p =>
            p.Name.Contains(name, StringComparison.OrdinalIgnoreCase));

        return pokemon is null
            ? Results.NotFound(new { error = $"Pokemon '{name}' not found." })
            : Results.Ok(pokemon);
    }
}