using LotLogic.Core.Models;

namespace LotLogic.Core.DTOs;

public record CheckInRequest(string LicensePlate = "", VehicleType VehicleType = default);

public record VehicleResponse(
    int Id = 0,
    string LicensePlate = "",
    VehicleType VehicleType = default,
    DateTime? CheckInUtc = null,
    DateTime? CheckOutUtc = null,
    decimal? LastFee = null,
    decimal TotalFees = 0m);
