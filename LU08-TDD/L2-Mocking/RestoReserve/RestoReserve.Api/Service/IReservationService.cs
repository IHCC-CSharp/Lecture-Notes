using RestoReserve.Core.DTOs;
using RestoReserve.Core.Models;

namespace RestoReserve.Api.Service;

public interface IReservationService
{
    Task<IReadOnlyList<Reservation>> GetAllReservationsAsync();

    Task<IReadOnlyList<Reservation>> GetReservationsByRestaurantNameAsync(string restaurantName);

    Task<Reservation> CreateReservationAsync(CreateReservation request);

    Task<Reservation> CancelReservationAsync(int reservationId);
}