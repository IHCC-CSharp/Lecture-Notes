namespace RetroGameApp.Models;

public record VideoGame(
    long Id,
    string Title,
    string Platform,
    long ReleaseYear,
    string Genre
);