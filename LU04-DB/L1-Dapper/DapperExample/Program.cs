using System.Collections.Generic;
using System.Data;
using System.Linq;
using Microsoft.Data.Sqlite;
using Dapper;
using DapperExample.Models;

// SQLite connection string  ('golf.db')
const string ConnectionString = "Data Source=golf.db";

InitializeDatabase();
SeedData();

Console.WriteLine("--- Super Battle Golf Power-Up Menu ---");
DisplayPowerUps();


static void InitializeDatabase()
{
    using var connection = new SqliteConnection(ConnectionString);

    // Create table script
    var createTableSql = @"
            CREATE TABLE IF NOT EXISTS PowerUps (
                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                Name TEXT NOT NULL,
                Description TEXT NOT NULL,
                Category TEXT NOT NULL
            );";

    connection.Execute(createTableSql);
}

static void SeedData()
{
    using var connection = new SqliteConnection(ConnectionString);

    // Check if we already have data to avoid duplicates
    var count = connection.ExecuteScalar<int>("SELECT COUNT(*) FROM PowerUps");
    if (count > 0)
    {
        return;
    }

    // Data from Super Battle Golf
    var items = new List<PowerUp>
        {
            new(0, "Rocket Launcher", "Fires a homing missile that locks onto a target and stuns them.", "Offensive"),
            new(0, "Air Horn", "Disrupts concentration, causing opponents to overshoot their swing.", "Disruption"),
            new(0, "Golf Cart", "Fast traversal that can ram and stun multiple players.", "Mobility")
        };

    // Dapper makes inserting lists easy
    var insertSql = "INSERT INTO PowerUps (Name, Description, Category) VALUES (@Name, @Description, @Category)";
    connection.Execute(insertSql, items);

    Console.WriteLine("Database seeded with items.\n");
}

static void DisplayPowerUps()
{
    using var connection = new SqliteConnection(ConnectionString);

    // Dapper maps the rows directly to our Record type
    var sql = "SELECT * FROM PowerUps";
    var powerUps = connection.Query<PowerUp>(sql).ToList();

    foreach (var item in powerUps)
    {
        Console.WriteLine($"[{item.Category.ToUpper()}]");
        Console.WriteLine($"Name: {item.Name}");
        Console.WriteLine($"Effect: {item.Description}");
        Console.WriteLine(new string('-', 30));
    }
}
