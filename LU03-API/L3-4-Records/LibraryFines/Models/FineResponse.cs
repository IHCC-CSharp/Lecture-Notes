namespace LibraryFines.Models;

public record FineResponse(string Title, decimal Amount, int DaysLate, string Status);