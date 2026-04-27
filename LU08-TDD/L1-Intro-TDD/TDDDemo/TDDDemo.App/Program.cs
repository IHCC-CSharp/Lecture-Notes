using TDDDemo.App;

Console.WriteLine("IsEvenBad(4): " + Features.IsEvenBad(4));
Console.WriteLine("IsEvenBad(12): " + Features.IsEvenBad(12) + "  <- bad method misses this");
Console.WriteLine("IsEven(12): " + Features.IsEven(12));
Console.WriteLine();

Console.WriteLine("CountVowelsBad(\"ApplE\"): " + Features.CountVowelsBad("ApplE"));
Console.WriteLine("CountVowels(\"ApplE\"): " + Features.CountVowels("ApplE"));
Console.WriteLine();

Console.WriteLine("BuildGreetingBad(\"  Luke  \"): " + Features.BuildGreetingBad("  Luke  "));
Console.WriteLine("BuildGreeting(\"  Luke  \"): " + Features.BuildGreeting("  Luke  "));
Console.WriteLine("BuildGreeting(\"   \"): " + Features.BuildGreeting("   "));
