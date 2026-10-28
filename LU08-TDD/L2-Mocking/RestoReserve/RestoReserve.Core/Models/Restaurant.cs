using System.Text.Json.Serialization;

namespace RestoReserve.Core.Models;

public class Restaurant
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public Cuisine Cuisine { get; set; }
    // This only works if the restaurant closes before midnight
    // Also TimeOnly is not supported in SQLite
    // So it will be stored as a string
    // In the service layer we will have to convert it.
    public TimeOnly OpeningTime { get; set; }
    public TimeOnly ClosingTime { get; set; }

    //We don't want to return all the reservations when we return a restaurant
    [JsonIgnore]
    public List<Reservation> Reservations { get; set; } = [];
}