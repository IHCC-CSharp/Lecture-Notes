// Arrays (Fixed size)
int[] fixedNumbers = { 1, 2, 3, 4, 5 };
// fixedNumbers.Add(6); // Can't do this, arrays have fixed size

// Lists (Dynamic arrays)
List<int> numbers = new List<int> { 1, 2, 3, 4, 5 };
numbers.Add(6);
Console.WriteLine($"List: {string.Join(", ", numbers)}");

//For Loop
for (int i = 0; i < numbers.Count; i++)
{
    Console.WriteLine($"Index {i}: {numbers[i]}");
}

//While Loop
int counter = 0;
while (counter < 3)
{
    Console.WriteLine($"While loop iteration: {counter + 1}");
    counter++;
}

//Methods Basics
int sum = Add(10, 20);
Console.WriteLine($"Sum of 10 and 20: {sum}");

static int Add(int a, int b)
{
    return a + b;
}

// Random Number Generation
Random rand = new(); // You can also do `new Random()`

Console.WriteLine("\n=== Combined Example: Guess the Number ===");
int secretNumber = rand.Next(1, 11); // 1 to 10
int guess = 0;
int attempts = 0;

Console.WriteLine("I'm thinking of a number between 1 and 10. Guess it!");

while (guess != secretNumber)
{
    Console.Write("Enter your guess: ");
    if (int.TryParse(Console.ReadLine(), out guess))
    {
        attempts++;
        if (guess < secretNumber)
        {
            Console.WriteLine("Too low!");
        }
        else if (guess > secretNumber)
        {
            Console.WriteLine("Too high!");
        }
        else
        {
            Console.WriteLine($"Correct! It took you {attempts} attempts.");
        }
    }
    else
    {
        Console.WriteLine("Please enter a valid number.");
    }
}

// Example 2D List of Temperatures This Week (7 days, 2 readings per day: morning and evening)
List<List<double>> temperaturesThisWeek = new List<List<double>>
{
    new List<double> { 15.5, 22.0 }, // Monday
    new List<double> { 16.2, 23.5 }, // Tuesday
    new List<double> { 14.8, 21.3 }, // Wednesday
    new List<double> { 17.0, 24.1 }, // Thursday
    new List<double> { 18.5, 25.0 }, // Friday
    new List<double> { 19.2, 26.5 }, // Saturday
    new List<double> { 17.8, 24.8 }  // Sunday
};

Console.WriteLine("\n=== Temperatures This Week ===");
string[] days = { "Monday", "Tuesday", "Wednesday", "Thursday", "Friday", "Saturday", "Sunday" };
for (int i = 0; i < temperaturesThisWeek.Count; i++)
{
    Console.WriteLine($"{days[i]}: Morning {temperaturesThisWeek[i][0]}°C, Evening {temperaturesThisWeek[i][1]}°C");
}

// Example of List of Tuples
List<(string name, double salary, string position)> employees = new();
employees.Add(("John", 50000.0, "Developer"));
employees.Add(("Jane", 60000.0, "Manager"));
employees.Add(("Bob", 45000.0, "Designer"));

Console.WriteLine("\n=== Employees Example ===");
foreach (var employee in employees)
{
    Console.WriteLine($"Name: {employee.name}, Salary: {employee.salary}, Position: {employee.position}");
}


