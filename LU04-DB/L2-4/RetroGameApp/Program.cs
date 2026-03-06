using RetroGameApp.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddOpenApi();
builder.Services.AddControllers();

const string ConnectionString = "Data Source=retro_games.db";
builder.Services.AddScoped(sp => new GameRepository(ConnectionString));

var app = builder.Build();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapControllers();
app.Run();