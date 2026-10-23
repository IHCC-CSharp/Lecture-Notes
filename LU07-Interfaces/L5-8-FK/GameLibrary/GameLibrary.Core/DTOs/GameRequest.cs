namespace GameLibrary.Core.DTOs;

/// <summary>Request data for adding a game to an existing console.</summary>
public sealed record GameRequest(string Title, string Genre, DateTime ReleaseDate, int ConsoleId);
