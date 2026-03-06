using Microsoft.Data.Sqlite;
using Dapper;
using RetroGameApp.Models;
using RetroGameApp.DTOs;

namespace RetroGameApp.Repositories;

public class GameRepository
{
    private readonly string _connectionString;

    public GameRepository(string connectionString)
    {
        _connectionString = connectionString;
        InitializeDatabase();
    }

    private void InitializeDatabase()
    {
        using var connection = new SqliteConnection(_connectionString);
        var sql = @"
            CREATE TABLE IF NOT EXISTS Games (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Title TEXT NOT NULL,
                Platform TEXT NOT NULL,
                ReleaseYear INTEGER NOT NULL,
                Genre TEXT NOT NULL
            );";
        connection.Execute(sql);
    }

    public IEnumerable<VideoGame> GetAll()
    {
        using var connection = new SqliteConnection(_connectionString);
        return connection.Query<VideoGame>("SELECT * FROM Games");
    }

    public IEnumerable<VideoGame> GetByFilter(GameSearchDto search)
    {
        using var connection = new SqliteConnection(_connectionString);

        var sql = "SELECT * FROM Games WHERE 1=1";

        if (!string.IsNullOrEmpty(search.Platform))
        {
            sql += " AND Platform = @Platform";
        }
        if (!string.IsNullOrEmpty(search.Genre))
        {
            sql += " AND Genre = @Genre";
        }

        return connection.Query<VideoGame>(sql, search);
    }

    public void Add(VideoGame game)
    {
        using var connection = new SqliteConnection(_connectionString);
        var sql = @"INSERT INTO Games (Title, Platform, ReleaseYear, Genre) 
                    VALUES (@Title, @Platform, @ReleaseYear, @Genre)";
        connection.Execute(sql, game);
    }
}