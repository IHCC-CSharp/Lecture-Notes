using Microsoft.EntityFrameworkCore;
using RestoReserve.Api.Service;
using RestoReserve.Core.DTOs;
using RestoReserve.Core.Models;

namespace RestoReserve.Tests;

public class RestaurantServiceTests
{
    [Fact]
    public async Task CreateRestaurantAsync_SavesRestaurant()
    {
        await using var database = await TestDatabase.CreateAsync();
        var service = new RestaurantService(database.Context);
        var request = new CreateRestoRequest(
            "Bubba-Q's",
            Cuisine.Italian,
            new TimeOnly(11, 0),
            new TimeOnly(20, 0));

        var result = await service.CreateRestaurantAsync(request);

        Assert.Equal(request.Name, result.Name);
        Assert.Equal(request.Cuisine, result.Cuisine);
        Assert.Equal(request.OpeningTime, result.OpeningTime);
        Assert.Equal(request.ClosingTime, result.ClosingTime);
        Assert.Equal(1, await database.Context.Restaurants.CountAsync());
    }

    [Fact]
    public async Task GetAllRestaurantsAsync_ReturnsRestaurantsByName()
    {
        await using var database = await TestDatabase.CreateAsync();
        database.Context.Restaurants.AddRange(
            NewRestaurant("Zeta"),
            NewRestaurant("Alpha"));
        await database.Context.SaveChangesAsync();
        var service = new RestaurantService(database.Context);

        var results = await service.GetAllRestaurantsAsync();

        Assert.Equal(["Alpha", "Zeta"], results.Select(restaurant => restaurant.Name));
    }

    [Fact]
    public async Task GetRestaurantNamesAsync_ReturnsNamesByName()
    {
        await using var database = await TestDatabase.CreateAsync();
        database.Context.Restaurants.AddRange(
            NewRestaurant("Zeta"),
            NewRestaurant("Alpha"));
        await database.Context.SaveChangesAsync();
        var service = new RestaurantService(database.Context);

        var results = await service.GetRestaurantNamesAsync();

        Assert.Equal(["Alpha", "Zeta"], results);
    }

    private static Restaurant NewRestaurant(string name) => new()
    {
        Name = name,
        Cuisine = Cuisine.Italian,
        OpeningTime = new TimeOnly(11, 0),
        ClosingTime = new TimeOnly(20, 0)
    };
}
