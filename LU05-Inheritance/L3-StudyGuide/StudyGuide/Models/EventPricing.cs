namespace StudyGuide.Models;

public static class EventPricing
{
    // The difference between const and readonly?
    // const is a compile-time constant
    // readonly is a runtime constant.
    public const int MaximumSeats = 8;
    public static readonly decimal PricePerSeat = 12.50m;

    public static decimal CalculateCost(int seats)
    {
        return seats is > 0 and <= MaximumSeats ? seats * PricePerSeat : 0;
    }
}
