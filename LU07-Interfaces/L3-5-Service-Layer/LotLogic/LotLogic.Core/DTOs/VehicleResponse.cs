using LotLogic.Core.Models;

namespace LotLogic.Core.DTOs;


// TODO make this a record type
public class VehicleResponse
{
    public VehicleType VehicleType { get; set; }
    public DateTime? CheckInUtc { get; set; }
    public DateTime? CheckOutUtc { get; set; }
    public decimal? LastFee { get; set; }
    public decimal TotalFees { get; set; }
}
