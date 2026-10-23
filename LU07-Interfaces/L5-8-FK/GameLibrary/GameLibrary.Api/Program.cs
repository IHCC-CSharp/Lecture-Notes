using GameLibrary.Api.Data;
using GameLibrary.Api.Service;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<LibraryContext>(options =>
    options.UseSqlite("Data Source=gamelibrary.db"));
builder.Services.AddScoped<ILibraryService, LibraryService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapOpenApi();
app.MapControllers();
app.MapScalarApiReference();

app.Run();
