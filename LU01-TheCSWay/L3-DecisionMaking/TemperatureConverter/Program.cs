using CSharpPlayersGuide.RichConsole;

//Rich Console is a simple library for adding color and text effects to console output.
//I added this just to practice using external libraries and NuGet.

Console.WriteLine("Temperature Converter");
Console.WriteLine("1. Celsius to Fahrenheit");
Console.WriteLine("2. Fahrenheit to Celsius");
Console.Write("Choose an option (1 or 2): ");
var choice = Console.ReadLine();

switch (choice)
{
    case "1":
        Console.Write("Enter Celsius: ");
        // Get user input and convert to double
        var c = double.Parse(Console.ReadLine());
        //Do math to convert to Fahrenheit
        var f = (c * 9 / 5) + 32;
        // Output result with 2 decimal places and change text color
        RichConsole.WriteLine($"{c}°C is {f:F2}°F", new Color(0, 255, 0));
        break;
    case "2":
        // Copy and modify code above
        Console.Write("Enter Fahrenheit: ");
        var f2 = double.Parse(Console.ReadLine());
        var c2 = (f2 - 32) * 5 / 9;
        RichConsole.WriteLine($"{f2}°F is {c2:F2}°C", new Color(0, 0, 255));
        break;
    default:
        RichConsole.WriteLine("Invalid choice", TextEffects.AllCaps, new Color(255, 0, 0));
        break;
}