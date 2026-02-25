public class Package
{
    // Static fields: The building keeps track of "All Time" totals.
    private static int _totalPackagesProcessed = 0;
    private static double _totalRevenue = 0;

    // Instance fields (Properties)
    public string Description { get; set; }
    public double Weight { get; set; }
    public double Distance { get; set; }

    public Package(string desc, double weight, double dist)
    {
        Description = desc;
        Weight = weight;
        Distance = dist;

        //global static
        _totalPackagesProcessed++;

        double cost = ShippingProcessor.CalculatePostage(Weight, Distance);
        _totalRevenue += cost; //total revenue is static
    }

    // Static Method: Returns global summary.
    public static string GetGlobalReport()
    {
        return $"Total Packages: {_totalPackagesProcessed} | Total Revenue: ${_totalRevenue:F2}";
    }

    public double CalculateCost()
    {
        return ShippingProcessor.CalculatePostage(Weight, Distance);
    }

    public override string ToString()
    {
        return $"LABEL FOR: {Description}\nWEIGHT:    {Weight}kg\nCOST:      ${CalculateCost():F2}";
    }
}
