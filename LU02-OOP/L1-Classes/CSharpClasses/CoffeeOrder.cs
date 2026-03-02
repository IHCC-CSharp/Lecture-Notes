namespace CSharpClasses;

public class CoffeeOrder
{
    // Auto-implemented properties (No manual backing fields needed)
    // https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/auto-implemented-properties
    public string Size { get; set; }
    public string Roast { get; set; }
    public int SugarAmount { get; set; }


    // CSharp Documentation Comments: https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/xmldoc
    /**
     * Constructor: A special method to initialize new objects.
     * - Same name as the class.
     * - No return type (not even void).
     * - Can take parameters to set initial property values.
     */
    public CoffeeOrder(string size, string roast, int sugarAmount)
    {
        // Set the properties using the constructor parameters
        // The 'this' keyword is optional 
        // Don't need to use setters since we have auto-implemented properties
        Size = size;
        Roast = roast;
        SugarAmount = sugarAmount;
    }
}