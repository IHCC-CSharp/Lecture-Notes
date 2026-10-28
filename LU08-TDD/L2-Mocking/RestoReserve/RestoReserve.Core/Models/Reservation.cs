using System.Text.Json.Serialization;

namespace RestoReserve.Core.Models;

public class Reservation
{
    public int Id { get; set; }

    //Don't need to display all the restaurant details for each reservation
    [JsonIgnore]
    public Restaurant? Restaurant { get; set; }

    public int RestaurantId { get; set; }
    public required string CustomerName { get; set; }
    public RStatus Status { get; set; }
    public DateTime ReservationTime { get; set; }
}