namespace LibraryFines.Models;

public record BookLoan(int Id, string Title, DateTime DueDate, DateTime? ReturnedDate)
{
    // Calculated properties
    public int DaysOverdue =>
        ((ReturnedDate ?? DateTime.Today) - DueDate).Days;

    public bool IsOverdue => DaysOverdue > 0;

    public decimal CalculateFine(decimal dailyRate) =>
        IsOverdue ? DaysOverdue * dailyRate : 0.0m;
}
