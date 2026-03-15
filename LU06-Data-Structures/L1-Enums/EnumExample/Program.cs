//TODO Change to difrent day of week is built in
DayOfWeek day = DayOfWeek.Wednesday;
Season s = Season.Autumn;

if (s == Season.Autumn)
{
    Console.WriteLine("Time to sign up for classes");
}


Console.WriteLine((int)day); //2


Console.Write("Enter a day of the week:");
var inputDay = Console.ReadLine();


// var userDay = inputDay switch
// {
//     "Monday" => DayOfWeek.Monday,
//     "Tuesday" => DayOfWeek.Tuesday,
//     "Wednesday" => DayOfWeek.Wednesday,
//     "Thursday" => DayOfWeek.Thursday,
//     "Friday" => DayOfWeek.Friday,
//     "Saturday" => DayOfWeek.Saturday,
//     "Sunday" => DayOfWeek.Sunday,
//     _ => throw new ArgumentException("Invalid day of the week")
// };

//Do above first
//https://learn.microsoft.com/en-us/dotnet/api/system.enum.parse?view=net-8.0
DayOfWeek userDay = Enum.Parse<DayOfWeek>(inputDay); //Throws an exception
Console.WriteLine(userDay);


public enum Season
{
    Summer = 90,
    Autumn = 60,
    Winter = 20,
    Spring = 70,
}

public enum DayOfWeek
{
    Monday,
    Tuesday,
    Wednesday,
    Thursday,
    Friday,
    Saturday,
    Sunday
}