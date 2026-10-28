using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;
using RestoReserve.Api.Data;

namespace RestoReserve.Tests;

internal sealed class TestDatabase : IAsyncDisposable
{
    private readonly SqliteConnection connection;

    private TestDatabase(SqliteConnection connection, RestoContext context)
    {
        this.connection = connection;
        Context = context;
    }

    public RestoContext Context { get; }

    public static async Task<TestDatabase> CreateAsync()
    {
        // By the name being ":memory:", the database will be created in memory
        var connection = new SqliteConnection("Data Source=:memory:");
        await connection.OpenAsync();

        var options = new DbContextOptionsBuilder<RestoContext>()
            .UseSqlite(connection)
            .Options;
        var context = new RestoContext(options);
        await context.Database.EnsureCreatedAsync();

        return new TestDatabase(connection, context);
    }

    public async ValueTask DisposeAsync()
    {
        await Context.DisposeAsync();
        await connection.DisposeAsync();
    }
}
