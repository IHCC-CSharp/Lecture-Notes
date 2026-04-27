namespace TDDDemo.App;

public static class Features
{
    // "Bad" example: hard-coded values that only work for a tiny range.
    public static bool IsEvenBad(int number)
    {
        return number == 0 || number == 2 || number == 4 || number == 6 || number == 8 || number == 10;
    }

    public static bool IsEven(int number)
    {
        return number % 2 == 0;
    }

    // "Bad" example: only counts lowercase vowels.
    public static int CountVowelsBad(string text)
    {
        int count = 0;

        foreach (char c in text)
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u')
            {
                count++;
            }
        }

        return count;
    }

    public static int CountVowels(string text)
    {
        int count = 0;

        foreach (char c in text)
        {
            char lower = char.ToLowerInvariant(c);
            if (lower == 'a' || lower == 'e' || lower == 'i' || lower == 'o' || lower == 'u')
            {
                count++;
            }
        }

        return count;
    }

    // "Bad" example: no trimming and no guard rails.
    public static string BuildGreetingBad(string name)
    {
        return "Hello, " + name + "!";
    }

    public static string BuildGreeting(string name)
    {
        if (string.IsNullOrWhiteSpace(name))
        {
            return "Hello, friend!";
        }

        return $"Hello, {name.Trim()}!";
    }
}