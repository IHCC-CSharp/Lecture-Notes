using Microsoft.EntityFrameworkCore;
using RestoReserve.Api.Service;
using RestoReserve.Core.DTOs;
using RestoReserve.Core.Models;

namespace RestoReserve.Tests;

public class ReservationServiceTests
{
    [Fact]
    public async Task CreateReservationAsync_ValidRequest_SavesPendingReservation()
    {
        await using var database = await TestDatabase.CreateAsync();
        var restaurant = await AddRestaurantAsync(database, "Bubba-Q's");
        var service = new ReservationService(database.Context);
        var request = new CreateReservation
        {
            RestaurantName = restaurant.Name,
            CustomerName = "Luke",
            ReservationTime = FutureReservationTime(18)
        };

        var result = await service.CreateReservationAsync(request);

        Assert.Equal(restaurant.Id, result.RestaurantId);
        Assert.Equal("Luke", result.CustomerName);
        Assert.Equal(RStatus.Pending, result.Status);
        Assert.Equal(request.ReservationTime, result.ReservationTime);
        Assert.Equal(1, await database.Context.Reservations.CountAsync());
    }

    [Fact]
    public async Task CreateReservationAsync_UnknownRestaurant_ThrowsKeyNotFoundException()
    {
        await using var database = await TestDatabase.CreateAsync();
        var service = new ReservationService(database.Context);
        var request = NewRequest("Missing Restaurant", FutureReservationTime(18));

        await Assert.ThrowsAsync<KeyNotFoundException>(() => service.CreateReservationAsync(request));
    }

    [Fact]
    public async Task CreateReservationAsync_DuplicateRestaurantNames_ThrowsInvalidOperationException()
    {
        await using var database = await TestDatabase.CreateAsync();
        await AddRestaurantAsync(database, "Bubba-Q's");
        await AddRestaurantAsync(database, "Bubba-Q's");
        var service = new ReservationService(database.Context);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.CreateReservationAsync(NewRequest("Bubba-Q's", FutureReservationTime(18))));
    }

    [Fact]
    public async Task CreateReservationAsync_PastTime_ThrowsInvalidOperationException()
    {
        await using var database = await TestDatabase.CreateAsync();
        await AddRestaurantAsync(database, "Bubba-Q's");
        var service = new ReservationService(database.Context);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.CreateReservationAsync(NewRequest("Bubba-Q's", DateTime.Now.AddHours(-1))));
    }

    [Fact]
    public async Task CreateReservationAsync_OutsideOpeningHours_ThrowsInvalidOperationException()
    {
        await using var database = await TestDatabase.CreateAsync();
        await AddRestaurantAsync(database, "Bubba-Q's");
        var service = new ReservationService(database.Context);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.CreateReservationAsync(NewRequest("Bubba-Q's", FutureReservationTime(21))));
    }

    [Fact]
    public async Task CreateReservationAsync_AlreadyReservedTime_ThrowsInvalidOperationException()
    {
        await using var database = await TestDatabase.CreateAsync();
        var restaurant = await AddRestaurantAsync(database, "Bubba-Q's");
        var reservationTime = FutureReservationTime(18);
        database.Context.Reservations.Add(NewReservation(restaurant, reservationTime));
        await database.Context.SaveChangesAsync();
        var service = new ReservationService(database.Context);

        await Assert.ThrowsAsync<InvalidOperationException>(() =>
            service.CreateReservationAsync(NewRequest(restaurant.Name, reservationTime)));
    }

    [Fact]
    public async Task CreateReservationAsync_CancelledSlot_CreatesReservation()
    {
        await using var database = await TestDatabase.CreateAsync();
        var restaurant = await AddRestaurantAsync(database, "Bubba-Q's");
        var reservationTime = FutureReservationTime(18);
        database.Context.Reservations.Add(NewReservation(restaurant, reservationTime, RStatus.Cancelled));
        await database.Context.SaveChangesAsync();
        var service = new ReservationService(database.Context);

        var result = await service.CreateReservationAsync(NewRequest(restaurant.Name, reservationTime));

        Assert.Equal(RStatus.Pending, result.Status);
        Assert.Equal(2, await database.Context.Reservations.CountAsync());
    }

    [Fact]
    public async Task GetAllReservationsAsync_ReturnsReservationsByTimeWithRestaurantLoaded()
    {
        await using var database = await TestDatabase.CreateAsync();
        var restaurant = await AddRestaurantAsync(database, "Bubba-Q's");
        var laterTime = FutureReservationTime(18);
        var earlierTime = laterTime.AddHours(-1);
        database.Context.Reservations.AddRange(
            NewReservation(restaurant, laterTime),
            NewReservation(restaurant, earlierTime));
        await database.Context.SaveChangesAsync();
        var service = new ReservationService(database.Context);

        var results = await service.GetAllReservationsAsync();

        Assert.Equal(2, results.Count);
        Assert.Equal(earlierTime, results[0].ReservationTime);
        Assert.Equal("Bubba-Q's", results[0].Restaurant!.Name);
    }

    [Fact]
    public async Task GetReservationsByRestaurantNameAsync_BlankName_ThrowsArgumentException()
    {
        await using var database = await TestDatabase.CreateAsync();
        var service = new ReservationService(database.Context);

        await Assert.ThrowsAsync<ArgumentException>(() => service.GetReservationsByRestaurantNameAsync(" "));
    }

    [Fact]
    public async Task CancelReservationAsync_FutureReservationMoreThan12HoursAway_CancelsReservation()
    {
        await using var database = await TestDatabase.CreateAsync();
        var restaurant = await AddRestaurantAsync(database, "Bubba-Q's");
        var reservation = NewReservation(restaurant, FutureReservationTime(18));
        database.Context.Reservations.Add(reservation);
        await database.Context.SaveChangesAsync();
        var service = new ReservationService(database.Context);

        var result = await service.CancelReservationAsync(reservation.Id);

        Assert.Equal(RStatus.Cancelled, result.Status);
    }

    [Fact]
    public async Task CancelReservationAsync_UnknownReservation_ThrowsKeyNotFoundException()
    {
        await using var database = await TestDatabase.CreateAsync();
        var service = new ReservationService(database.Context);

        await Assert.ThrowsAsync<KeyNotFoundException>(() => service.CancelReservationAsync(1));
    }

    [Fact]
    public async Task CancelReservationAsync_AlreadyCancelled_ThrowsInvalidOperationException()
    {
        await using var database = await TestDatabase.CreateAsync();
        var restaurant = await AddRestaurantAsync(database, "Bubba-Q's");
        var reservation = NewReservation(restaurant, FutureReservationTime(18), RStatus.Cancelled);
        database.Context.Reservations.Add(reservation);
        await database.Context.SaveChangesAsync();
        var service = new ReservationService(database.Context);

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.CancelReservationAsync(reservation.Id));
    }

    [Fact]
    public async Task CancelReservationAsync_LessThan12HoursAway_ThrowsInvalidOperationException()
    {
        await using var database = await TestDatabase.CreateAsync();
        var restaurant = await AddRestaurantAsync(database, "Bubba-Q's");
        var reservation = NewReservation(restaurant, DateTime.Now.AddHours(2));
        database.Context.Reservations.Add(reservation);
        await database.Context.SaveChangesAsync();
        var service = new ReservationService(database.Context);

        await Assert.ThrowsAsync<InvalidOperationException>(() => service.CancelReservationAsync(reservation.Id));
    }

    private static async Task<Restaurant> AddRestaurantAsync(TestDatabase database, string name)
    {
        var restaurant = new Restaurant
        {
            Name = name,
            Cuisine = Cuisine.Italian,
            OpeningTime = new TimeOnly(11, 0),
            ClosingTime = new TimeOnly(20, 0)
        };
        database.Context.Restaurants.Add(restaurant);
        await database.Context.SaveChangesAsync();
        return restaurant;
    }

    private static CreateReservation NewRequest(string restaurantName, DateTime reservationTime) => new()
    {
        RestaurantName = restaurantName,
        CustomerName = "Luke",
        ReservationTime = reservationTime
    };

    private static Reservation NewReservation(
        Restaurant restaurant,
        DateTime reservationTime,
        RStatus status = RStatus.Pending) => new()
    {
        Restaurant = restaurant,
        RestaurantId = restaurant.Id,
        CustomerName = "Existing Customer",
        Status = status,
        ReservationTime = reservationTime
    };

    private static DateTime FutureReservationTime(int hour) =>
        DateTime.Today.AddDays(2).AddHours(hour);
}
