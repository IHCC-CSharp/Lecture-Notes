using RestoReserve.Core.DTOs;
using RestoReserve.Core.Models;

namespace RestoReserve.Api.Service;

public interface IRestaurantService
{
    Task<Restaurant> CreateRestaurantAsync(CreateRestoRequest request);

    Task<IReadOnlyList<Restaurant>> GetAllRestaurantsAsync();

    Task<IReadOnlyList<string>> GetRestaurantNamesAsync();
}