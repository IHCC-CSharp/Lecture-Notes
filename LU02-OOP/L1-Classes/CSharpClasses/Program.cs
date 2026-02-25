// Create an object from the class
CoffeeOrder morningOrder = new CoffeeOrder("Large", "Dark", 2);

// Get and print the properties
Console.WriteLine("Order Details:");
Console.WriteLine($"Size: {morningOrder.Size}");
Console.WriteLine($"Roast: {morningOrder.Roast}");
Console.WriteLine($"Sugars: {morningOrder.SugarAmount}");

// Change a property
morningOrder.SugarAmount = 3; //it's a monday
Console.WriteLine("\nUpdated Order Details:");
Console.WriteLine($"Sugar: {morningOrder.SugarAmount}");
