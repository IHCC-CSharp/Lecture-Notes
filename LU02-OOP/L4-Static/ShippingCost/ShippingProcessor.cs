// The class is static so are all it's members
public static class ShippingProcessor
{
    // const: Hard-coded base rate that never changes while the app runs.
    public const double BaseRatePerKg = 5.50;

    // readonly: A surcharge that could be set differently every time the system starts.
    public static readonly double FuelSurcharge = 12.25;

    public static double CalculatePostage(double weight, double distance)
    {
        double weightCost = weight * BaseRatePerKg;
        double distanceCost = distance * 0.15;
        return weightCost + distanceCost + FuelSurcharge;
    }

    public static string GetSafeInput(string prompt)
    {
        Console.Write($"{prompt}: ");
        string? input = Console.ReadLine();

        if (string.IsNullOrWhiteSpace(input))
        {
            return "DEFAULT_VAL";
        }
        return input;
    }
}