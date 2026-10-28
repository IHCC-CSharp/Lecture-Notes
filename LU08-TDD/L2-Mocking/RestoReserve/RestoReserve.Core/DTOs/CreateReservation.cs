namespace RestoReserve.Core.DTOs;

public class CreateReservation
{
    public required string RestaurantName { get; set; }
    public required string CustomerName { get; set; }
    public DateTime ReservationTime { get; set; }
}