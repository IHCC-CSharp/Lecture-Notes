//if statement
var x = 5;
if (x > 3)
{
    Console.WriteLine("x is greater than 3");
}

// You can use if on strings too (unlike Java, C# uses == for string comparison)
var name = "Alice";
if (name == "Alice")
{
    Console.WriteLine("Hello Alice");
}

// Example of if/else statement
if (x > 10)
{
    Console.WriteLine("x is greater than 10");
}
else
{
    Console.WriteLine("x is not greater than 10");
}


// Example of switch statement
//Docs: https://www.w3schools.com/cs/cs_user_input.php
Console.Write("Enter a day of the week: ");
var day = Console.ReadLine(); // Read input from user
switch (day)
{
    case "Monday":
        Console.WriteLine("Today is Monday");
        break;
    case "Tuesday":
        Console.WriteLine("Today is Tuesday");
        break;
    default:
        Console.WriteLine("Other day");
        break;
}

