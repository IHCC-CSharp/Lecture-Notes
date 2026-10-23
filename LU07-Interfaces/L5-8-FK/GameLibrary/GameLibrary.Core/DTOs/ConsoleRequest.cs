namespace GameLibrary.Core.DTOs;

/// <summary>Request data for adding a console.</summary>
public sealed record ConsoleRequest(string Name, string Manufacturer, DateTime ReleaseDate);
