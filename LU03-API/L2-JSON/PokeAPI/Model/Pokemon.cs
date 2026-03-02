namespace PokeAPI.Models;

public class Pokemon(int id, string name, string type, string imageUrl, bool isLegendary)
{
    public int Id { get; set; } = id;
    public string Name { get; set; } = name;
    public string Type { get; set; } = type;
    public string ImageUrl { get; set; } = imageUrl;
    public bool IsLegendary { get; set; } = isLegendary;
}