using LotLogic.Core.DTOs;

namespace LotLogic.Core.Services;

public interface IVehicleService
{
    Task<VehicleResponse> CheckInAsync(CheckInRequest request);
    Task<VehicleResponse> CheckOutAsync(string licensePlate);
    Task<VehicleResponse> GetVehicleAsync(string licensePlate);
}
