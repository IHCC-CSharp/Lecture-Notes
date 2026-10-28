using Microsoft.EntityFrameworkCore;
using RestoReserve.Api.Data;
using RestoReserve.Core.DTOs;
using RestoReserve.Core.Models;

namespace RestoReserve.Api.Service;

public class ReservationService(RestoContext context) : IReservationService
{
    public async Task<Reservation> CancelReservationAsync(int reservationId)
    {
        var reservation = await context.Reservations
            .SingleOrDefaultAsync(reservation => reservation.Id == reservationId);

        if (reservation is null)
        {
            throw new KeyNotFoundException($"Reservation {reservationId} was not found.");
        }

        if (reservation.Status == RStatus.Cancelled)
        {
            throw new InvalidOperationException("This reservation has already been cancelled.");
        }

        var timeUntilReservation = reservation.ReservationTime - DateTime.Now;
        if (timeUntilReservation <= TimeSpan.Zero)
        {
            throw new InvalidOperationException("Only future reservations can be cancelled.");
        }

        if (timeUntilReservation < TimeSpan.FromHours(12))
        {
            throw new InvalidOperationException("Reservations can only be cancelled at least 12 hours in advance.");
        }

        reservation.Status = RStatus.Cancelled;
        await context.SaveChangesAsync();

        return reservation;
    }

    public async Task<Reservation> CreateReservationAsync(CreateReservation request)
    {
        //We only take 2.
        //If there are more then 2 we already messed up.
        var restaurantMatches = await context.Restaurants
            .Where(restaurant => restaurant.Name == request.RestaurantName)
            .Take(2)
            .ToListAsync();

        if (restaurantMatches.Count == 0)
        {
            throw new KeyNotFoundException($"Restaurant '{request.RestaurantName}' was not found.");
        }

        if (restaurantMatches.Count > 1)
        {
            throw new InvalidOperationException(
                $"More than one restaurant is named '{request.RestaurantName}'.");
        }

        var restaurant = restaurantMatches[0];
        var now = DateTime.Now;
        if (request.ReservationTime <= now)
        {
            throw new InvalidOperationException("Reservations must be in the future.");
        }

        var reservationTime = TimeOnly.FromDateTime(request.ReservationTime);
        if (reservationTime < restaurant.OpeningTime || reservationTime >= restaurant.ClosingTime)
        {
            throw new InvalidOperationException("The restaurant is not open at the requested reservation time.");
        }

        var timeSlotTaken = await context.Reservations.AnyAsync(reservation =>
            reservation.RestaurantId == restaurant.Id &&
            reservation.ReservationTime == request.ReservationTime &&
            reservation.Status != RStatus.Cancelled);

        if (timeSlotTaken)
        {
            throw new InvalidOperationException("A reservation already exists for this restaurant at that time.");
        }

        var newReservation = new Reservation
        {
            Restaurant = restaurant,
            RestaurantId = restaurant.Id,
            CustomerName = request.CustomerName,
            Status = RStatus.Pending,
            ReservationTime = request.ReservationTime
        };

        context.Reservations.Add(newReservation);
        await context.SaveChangesAsync();

        return newReservation;
    }

    public async Task<IReadOnlyList<Reservation>> GetAllReservationsAsync()
    {
        return await context.Reservations
            .Include(reservation => reservation.Restaurant)
            .OrderBy(reservation => reservation.ReservationTime)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<Reservation>> GetReservationsByRestaurantNameAsync(string restaurantName)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(restaurantName);

        return await context.Reservations
            .Include(reservation => reservation.Restaurant)
            .Where(reservation => reservation.Restaurant != null &&
                                  reservation.Restaurant.Name == restaurantName)
            .OrderBy(reservation => reservation.ReservationTime)
            .ToListAsync();
    }
}