# Mocking

## What is Mocking?

Mocking is a technique used in software development to create fake objects that simulate the behavior of real objects. This is particularly useful in unit testing, where you want to test a component in isolation without relying on external dependencies.

We don't do that.
We are using the real DB just in memory only.

## Create the Project

Students will download a zip file containing the project.
Below are the commands to create the project from scratch.

RestoReserve

```bash
# Create Solution
mkdir RestoReserve
cd RestoReserve
dotnet new sln -n RestoReserve
# Create Projects
dotnet new webapi -n RestoReserve.Api --use-controllers
dotnet new classlib -n RestoReserve.Core
dotnet new xunit -n RestoReserve.Tests
# Add Projects to Solution
dotnet sln add RestoReserve.Api/RestoReserve.Api.csproj
dotnet sln add RestoReserve.Core/RestoReserve.Core.csproj
dotnet sln add RestoReserve.Tests/RestoReserve.Tests.csproj
# Add Reference
dotnet add RestoReserve.Api/RestoReserve.Api.csproj reference RestoReserve.Core/RestoReserve.Core.csproj
dotnet add RestoReserve.Tests/RestoReserve.Tests.csproj reference RestoReserve.Core/RestoReserve.Core.csproj
# Add Nuget Packages
cd RestoReserve.Api
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.OpenApi
dotnet add package Scalar.AspNetCore.Microsoft
```

## Db Seeding

This project has auto seeding of the database. When the application starts, it will check if the database is empty and seed it with some initial data.

Seeding data can be in any format you want. Just need to parse it and add it to the database. You can use JSON, CSV, or XML.
Or as a simple C# code to add data to the database.

## Manual Testing

```json
{
    "restaurantName": "Bubba-Q's",
    "customerName": "Luke",
    "reservationTime": "2026-10-28T18:30:00"
}
```

## XUnit Tests

```bash
# Run in RestoReserve.Tests folder
dotnet test
```

## Blazor Server Client

The separate Blazor Web App renders interactively on the server and calls the
API with `HttpClient`. It references `RestoReserve.Core` for request and
response models.

Run the API and web app in separate terminals:

```bash
dotnet run --project RestoReserve.Api
dotnet run --project RestoReserve.Web
```
