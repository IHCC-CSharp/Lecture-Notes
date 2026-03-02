namespace LibraryFines.Models;

public static class LibraryData
{
    public static readonly List<BookLoan> Loans =
    [
        new(1, "The C# Player's Guide", DateTime.Today.AddDays(-10), DateTime.Today.AddDays(-2)),
        new(2, "Clean Code", DateTime.Today.AddDays(-5), null), //  Overdue
        new(3, "The Hobbit", DateTime.Today.AddDays(5), null)    // On Time
    ];
}