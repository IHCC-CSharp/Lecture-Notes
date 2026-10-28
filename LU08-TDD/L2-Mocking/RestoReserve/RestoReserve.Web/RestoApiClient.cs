using System.Net.Http.Json;
using System.Text.Json;
using RestoReserve.Core.DTOs;
using RestoReserve.Core.Models;

namespace RestoReserve.Web;

public sealed class RestoApiClient(HttpClient http)
{
    public async Task<List<Restaurant>> GetRestaurantsAsync() =>
        await http.GetFromJsonAsync<List<Restaurant>>("api/Restaurants") ?? [];

    public async Task<List<Reservation>> GetReservationsAsync() =>
        await http.GetFromJsonAsync<List<Reservation>>("api/Reservations") ?? [];

    public async Task CreateReservationAsync(CreateReservation request) =>
        await EnsureSuccessAsync(await http.PostAsJsonAsync("api/Reservations", request));

    public async Task CancelReservationAsync(int id) =>
        await EnsureSuccessAsync(await http.PostAsync($"api/Reservations/{id}/cancel", null));

    private static async Task EnsureSuccessAsync(HttpResponseMessage response)
    {
        using (response)
        {
            if (response.IsSuccessStatusCode)
            {
                return;
            }

            var body = await response.Content.ReadAsStringAsync();
            try
            {
                body = JsonSerializer.Deserialize<string>(body) ?? body;
            }
            catch (JsonException)
            {
            }

            throw new HttpRequestException(
                string.IsNullOrWhiteSpace(body) ? response.ReasonPhrase : body,
                null,
                response.StatusCode);
        }
    }
}
