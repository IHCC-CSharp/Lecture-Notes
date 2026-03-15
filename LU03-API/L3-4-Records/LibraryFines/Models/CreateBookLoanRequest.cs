public record CreateBookLoanRequest(
    int Id,
    string Title,
    DateTime DueDate,
    DateTime? ReturnedDate
);
