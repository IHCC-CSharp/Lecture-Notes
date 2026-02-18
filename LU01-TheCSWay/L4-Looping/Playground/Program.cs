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