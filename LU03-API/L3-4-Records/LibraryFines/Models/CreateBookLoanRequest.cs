public record CreateBookLoanRequest(
    // User passes in ID so we can test for duplicates
    // Better example the program would generate the ID for the user
    int Id,
    string Title
    // DateTime DueDate,
    // DateTime? ReturnedDate
);
