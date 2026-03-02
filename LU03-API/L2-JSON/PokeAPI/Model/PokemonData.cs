namespace PokeAPI.Models;

public static class PokemonData
{
    public static List<Pokemon> Pokedex =
    [
        // Source: https://pokeapi.co/
        new Pokemon(1, "Bulbasaur", "Grass", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/1.png", false),
        new Pokemon(4, "Charmander", "Fire", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/4.png", false),
        new Pokemon(7, "Squirtle", "Water", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/7.png", false),
        new Pokemon(25, "Pikachu", "Electric", "https://raw.githubusercontent.com/PokeAPI/sprites/master/sprites/pokemon/25.png", false)
    ];
}