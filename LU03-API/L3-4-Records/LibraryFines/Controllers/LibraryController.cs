using Microsoft.AspNetCore.Mvc;
using LibraryFines.Models;

namespace LibraryFines.Controllers;

[ApiController]
[Route("api/books")]
public class LibraryController : ControllerBase
{
    private const decimal DailyFineRate = 0.50m;

    // GET: api/books
    [HttpGet]
    public IResult GetAllLoans()
    {
        return Results.Ok(LibraryData.Loans);
    }

    // POST: api/books
    [HttpPost]
    public IResult AddBook([FromBody] CreateBookLoanRequest request)
    {
        if (LibraryData.Loans.Any(l => l.Id == request.Id))
        {
            return Results.BadRequest("ID already exists.");
        }

        // map the DTO to Model
        var newLoan = new BookLoan(
            request.Id,
            request.Title,
            request.DueDate,
            request.ReturnedDate
        );

        LibraryData.Loans.Add(newLoan);

        return Results.Created($"/api/books/{newLoan.Id}", newLoan);
    }

    // GET: api/books/{id}/fine
    [HttpGet("{id}/fine")]
    public IResult GetFine(int id)
    {

        var loan = LibraryData.Loans.FirstOrDefault(l => l.Id == id);

        if (loan is null)
        {
            return Results.NotFound();
        }

        return Results.Ok(new FineResponse(
            loan.Title,
            loan.CalculateFine(0.50m),
            Math.Max(0, loan.DaysOverdue),
            loan.IsOverdue ? "Overdue" : "On Time"
        ));
    }
}