using Microsoft.EntityFrameworkCore;
using RestoReserve.Api.Data;
using RestoReserve.Core.DTOs;
using RestoReserve.Core.Models;

namespace RestoReserve.Api.Service;

public class RestaurantService(RestoContext context) : IRestaurantService
{
    public async Task<Restaurant> CreateRestaurantAsync(CreateRestoRequest request)
    {
        var restaurant = new Restaurant
        {
            Name = request.Name,
            Cuisine = request.Cuisine,
            OpeningTime = request.OpeningTime,
            ClosingTime = request.ClosingTime
        };

        context.Restaurants.Add(restaurant);
        await context.SaveChangesAsync();

        return restaurant;
    }

    public async Task<IReadOnlyList<Restaurant>> GetAllRestaurantsAsync()
    {
        return await context.Restaurants
            .OrderBy(restaurant => restaurant.Name)
            .ToListAsync();
    }

    public async Task<IReadOnlyList<string>> GetRestaurantNamesAsync()
    {
        return await context.Restaurants
            .OrderBy(restaurant => restaurant.Name)
            .Select(restaurant => restaurant.Name)
            .ToListAsync();
    }
}