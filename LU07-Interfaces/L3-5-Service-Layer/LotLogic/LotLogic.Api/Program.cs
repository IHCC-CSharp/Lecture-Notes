using LotLogic.Api.Data;
using LotLogic.Api.Services;
using LotLogic.Core.Services;
using Microsoft.EntityFrameworkCore;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<LotLogicDbContext>(options =>
    options.UseSqlite("Data Source=lotlogic.db"));

builder.Services.AddScoped<IVehicleService, VehicleService>();

builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

using (var scope = app.Services.CreateScope())
    scope.ServiceProvider.GetRequiredService<LotLogicDbContext>().Database.EnsureCreated();

app.MapOpenApi();
app.MapScalarApiReference();

app.MapControllers();

app.Run();
