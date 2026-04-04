using Microsoft.EntityFrameworkCore;
using UrbanMobility.Api.Models;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddDbContext<MobilityContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("MobilityDb")));

var app = builder.Build();

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<MobilityContext>();
    db.Database.EnsureCreated();
}

app.MapOpenApi();
app.MapScalarApiReference();

app.UseAuthorization();

app.MapControllers();

app.Run();
