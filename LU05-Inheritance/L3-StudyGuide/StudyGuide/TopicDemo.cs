namespace StudyGuide;

using StudyGuide.Models;

public class TopicDemo
{
    public static void Collections()
    {
        Console.Clear();
        Console.WriteLine("A List<T> stores multiple values and can grow as items are added.");
        Console.WriteLine("A foreach loop visits each item, so the same operation works for the whole collection.");


        List<string> readingList = ["Dune", "Kindred"];
        readingList.Add("The Hobbit");

        Console.WriteLine("Books in the reading list:");
        foreach (string title in readingList)
        {
            Console.WriteLine($"- {title}");
        }

        Console.WriteLine($"Total books: {readingList.Count}");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public static void Looping()
    {
        Console.Clear();
        Console.WriteLine("Loops repeat work over a range or while a condition is true.");

        int[] lapTimes = [74, 71, 73];
        int totalSeconds = 0;

        for (int lap = 0; lap < lapTimes.Length; lap++)
        {
            totalSeconds += lapTimes[lap];
            Console.WriteLine($"Lap {lap + 1}: {lapTimes[lap]} seconds");
        }

        Console.WriteLine($"Combined time: {totalSeconds} seconds");

        Console.WriteLine("You can loop though an array and create a new array");
        double[] cartItems = [12.99, 5.99, 3.49];
        Console.WriteLine("Cart items no tax:");
        foreach (double item in cartItems)
        {
            Console.WriteLine($"Item: {item:0.00}");
        }

        // loop through the cartItems array and create a new array with tax added to each item
        double[] cartItemsWithTax = cartItems.Select(item => item * 1.07).ToArray();
        foreach (double item in cartItemsWithTax)
        {
            Console.WriteLine($"Item with tax: {item:0.00}");
        }

        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public static void ClassesAndAccess()
    {
        Console.Clear();
        Console.WriteLine("A class defines a type; an object stores its own state. Access modifiers control what callers can use.");

        var playlist = new Playlist("Road Trip");
        playlist.AddSong("Northbound");
        playlist.AddSong("Open Road");

        Console.WriteLine($"{playlist.Name}: {playlist.SongCount} songs");
        Console.WriteLine("The name and song count are public, but the list of songs is private.");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public static void ConstantsAndStatic()
    {
        Console.Clear();
        Console.WriteLine("A const value is fixed at compile time. A static member belongs to the type, not one object.");

        int seats = 3;
        decimal cost = EventPricing.CalculateCost(seats);
        Console.WriteLine($"{seats} seats at ${EventPricing.PricePerSeat:0.00} each cost ${cost:0.00}.");
        Console.WriteLine($"Maximum seats per booking: {EventPricing.MaximumSeats}.");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public static void Enums()
    {
        Console.Clear();
        Console.WriteLine("An enum represents a limited set of named choices. Branching can define behavior for each value.");

        Forecast forecast = Forecast.Rain;
        string advice = forecast switch
        {
            Forecast.Sun => "Bring sunglasses.",
            Forecast.Cloud => "A light jacket may help.",
            Forecast.Rain => "Bring an umbrella.",
            _ => "Check the forecast again."
        };

        Console.WriteLine($"Forecast: {forecast}. {advice}");

        Console.WriteLine("Convert user input to an enum value:");
        Console.Write("Enter a forecast (Sun, Cloud, Rain): ");
        string? input = Console.ReadLine();
        // You can also use Enum.TryParse
        Forecast userForecast = Enum.Parse<Forecast>(input);
        Console.WriteLine($"You entered: {userForecast}");

        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public static void Records()
    {
        Console.Clear();
        Console.WriteLine("Records are concise data types with value-based equality and init-only positional properties.");

        var original = new MapPin("Lookout Point", 44.2, -91.8);
        // Updated is a new record
        var updated = original with { Latitude = 44.3 };

        Console.WriteLine($"Original: {original}");
        Console.WriteLine($"Updated copy: {updated}");
        Console.WriteLine($"Original is unchanged: {original.Latitude != updated.Latitude}");
        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public static void Inheritance()
    {
        Console.Clear();
        Console.WriteLine("A derived class inherits shared behavior and can override virtual behavior from its base class.");

        List<Shape> shapes = [new Circle(2), new Rectangle(3, 4)];
        foreach (Shape shape in shapes)
        {
            Console.WriteLine($"{shape.Name} area: {shape.GetArea():0.00}");
        }

        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }

    public static void ModelToSqlMapping()
    {
        Console.Clear();
        Console.WriteLine("A model represents a database row with properties whose types and names correspond to its columns.");

        var item = new InventoryItem
        {
            ItemId = 42,
            Name = "Field Journal",
            Quantity = 17
        };

        //Check in project root for InventoryItems.sql to see how this model maps
        Console.WriteLine("This should map to the InventoryItems.sql table.");

        Console.Write("Press any key to continue...");
        Console.ReadKey();
        Console.Clear();
    }
}