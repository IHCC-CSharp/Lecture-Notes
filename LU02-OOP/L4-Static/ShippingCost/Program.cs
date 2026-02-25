List<Package> dailyManifest = [];
bool isRunning = true;

Console.WriteLine("WELCOME TO THE SHIPPING TERMINAL");
Console.WriteLine($"Current Base Rate: ${ShippingProcessor.BaseRatePerKg}/kg");
Console.WriteLine($"Daily Fuel Surcharge: ${ShippingProcessor.FuelSurcharge}");

while (isRunning)
{
    Console.WriteLine("\nACTIONS: [1] Add Package [2] System Stats [3] Exit");
    string choice = ShippingProcessor.GetSafeInput("Select Action");

    switch (choice)
    {
        case "1":
            CreatePackageWorkflow(dailyManifest);
            break;
        case "2":
            Console.Clear();
            Console.WriteLine(Package.GetGlobalReport()); //Notice: not using an instance
            break;
        case "3":
            isRunning = false;
            break;
        default:
            Console.WriteLine("Invalid selection.");
            break;
    }
}


static void CreatePackageWorkflow(List<Package> manifest)
{
    Console.Clear();

    string desc = ShippingProcessor.GetSafeInput("Enter Item Description");

    // Handling numeric null safety/parsing.
    double weight = 0;
    while (weight <= 0)
    {
        string wInput = ShippingProcessor.GetSafeInput("Enter Weight (kg)");
        double.TryParse(wInput, out weight);
        if (weight <= 0) Console.WriteLine("Weight must be a positive number.");
    }

    double dist = 0;
    while (dist <= 0)
    {
        string dInput = ShippingProcessor.GetSafeInput("Enter Distance (km)");
        double.TryParse(dInput, out dist);
        if (dist <= 0) Console.WriteLine("Distance must be a positive number.");
    }

    // Creating the instance.
    Package p = new Package(desc, weight, dist);
    manifest.Add(p);

    Console.WriteLine("\nPackage successfully processed!");
    Console.WriteLine(p);
}