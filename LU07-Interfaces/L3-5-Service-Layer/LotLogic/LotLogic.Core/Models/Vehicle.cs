namespace LotLogic.Core.Models;

public abstract class Vehicle
{
    public int Id { get; set; }
    public string LicensePlate { get; set; } = string.Empty;
    public DateTime? CheckInUtc { get; set; }
    public DateTime? CheckOutUtc { get; set; }
    public decimal? LastFee { get; set; }
    public decimal TotalFees { get; set; } = 0m;

    public abstract decimal RateMultiplier { get; }

    public void CheckIn()
    {
        if (CheckInUtc.HasValue)
            // TODO Make this a custom exception type
            throw new InvalidOperationException("Vehicle is already checked in.");

        CheckInUtc = DateTime.UtcNow;
        CheckOutUtc = null;
    }

    public decimal CheckOut()
    {
        if (!CheckInUtc.HasValue)
            throw new InvalidOperationException("Vehicle is not checked in.");

        CheckOutUtc = DateTime.UtcNow;
        LastFee = CalculateFee();
        TotalFees += LastFee.Value;
        CheckInUtc = null;

        return LastFee.Value;
    }

    public decimal CalculateFee(decimal baseHourlyRate = 5.00m)
    {
        var end = CheckOutUtc ?? DateTime.UtcNow;
        var start = CheckInUtc ?? end;
        var minutes = Math.Max(0, (end - start).TotalMinutes);
        var billableHours = (int)Math.Ceiling(minutes / 60.0d);

        return billableHours * baseHourlyRate * RateMultiplier;
    }
}
