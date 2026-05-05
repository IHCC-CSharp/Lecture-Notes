# Mocking

## What is Mocking?

## Create the Project

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

## Controllers

Below is my idea what services/endpoints we will have in our API.
Services will not map 1:1 to endpoints.

- [POST] `api/restaurants` - Create a new restaurant

- [GET] `api/reservations` - Get all reservations
- [GET] `api/reservations/{id}` - Get a reservation by **restaurant** id.
- [POST] `api/reservations` - Create a new reservation
    - Checks restaurant is open at the time of reservation
    - Checks if reservation is in the future
    - Checks if restaurant has capacity at the time of reservation
    - Checks if no other reservation exists for the same restaurant at the same time (our restaurant only has one table)
- [PATCH] `api/reservations/{id}` - Cancel a reservation
    - Checks if reservation exists
    - Checks if reservation is in the future
    - Checks if reservation is 12hrs or more in the future (can't cancel within 12hrs of reservation)

    
OR I a simple lightswitch project with "smart" featurs where the light turns off automaticlly after midnight. 
