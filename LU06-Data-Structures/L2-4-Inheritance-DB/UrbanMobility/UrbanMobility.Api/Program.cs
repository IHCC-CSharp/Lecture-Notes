using UrbanMobility.Api.Repositories;
using Scalar.AspNetCore;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddControllers();
builder.Services.AddOpenApi();

const string ConnectionString = "Data Source=urbanmobility.db";
builder.Services.AddScoped(sp => new VehicleRepository(ConnectionString));

var app = builder.Build();


app.MapOpenApi();
app.MapScalarApiReference();

app.UseAuthorization();

app.MapControllers();

app.Run();
