using LotLogic.Core.Models;

namespace LotLogic.Core.DTOs;

// TODO make this a record type

public class CheckInRequest
{
    public string LicensePlate { get; set; } = string.Empty;
    public VehicleType VehicleType { get; set; }
}
