string expression = "";
List<string> keys = new List<string>();

void DisplayCalculator(string expr)
{
    Console.Clear();
    Console.WriteLine("_________________");
    Console.WriteLine(expr.PadRight(17));
    Console.WriteLine("_________________");
    Console.WriteLine("[7] [8] [9] [/]");
    Console.WriteLine("[4] [5] [6] [*]");
    Console.WriteLine("[1] [2] [3] [-]");
    Console.WriteLine("[0] [.] [=] [+]");
}

while (true)
{
    DisplayCalculator(expression);
    Console.Write("Press a button (digit, operator, or =): ");
    //we hate null user input. So if its null we set it to "".
    string input = Console.ReadLine() ?? "";

    if (input == "=")
    {
        break;
    }

    //check if its 0-9, or an op
    if (int.TryParse(input, out _) || "+-*/.".Contains(input))
    {
        keys.Add(input);
        expression = string.Join("", keys);
    }
    else
    {
        Console.WriteLine("Invalid input!");
    }
}
//once they hit "="
if (keys.Count >= 3)
{
    double a = double.Parse(keys[0]);
    // operator is always the middle
    string op = keys[1];
    double b = double.Parse(keys[2]);

    double result = Calculate(a, op, b);
    Console.WriteLine($"Result: {result}");
}
else
{
    Console.WriteLine("Not enough inputs for calculation.");
}

double Calculate(double a, string op, double b)
{
    return op switch
    {
        "+" => a + b,
        "-" => a - b,
        "*" => a * b,
        "/" =>  a / b,
        _ => 0
    };
}
