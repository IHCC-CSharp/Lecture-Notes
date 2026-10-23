# EF DB FK

> Objective: Reinforce EF by creating a one-to-many relationship between two entities using foreign keys.

Game Library:

One Console can have many Games, but each Game can only belong to one Console.
Project has no DTOs for simplicity.

## Create the Project

```bash
# Create Solution
mkdir GameLibrary
cd GameLibrary
dotnet new sln -n GameLibrary
# Create Projects
dotnet new webapi -n GameLibrary.Api --use-controllers
dotnet new classlib -n GameLibrary.Core
# Add Projects to Solution
dotnet sln add GameLibrary.Api/GameLibrary.Api.csproj
dotnet sln add GameLibrary.Core/GameLibrary.Core.csproj
# Add Reference
dotnet add GameLibrary.Api/GameLibrary.Api.csproj reference GameLibrary.Core/GameLibrary.Core.csproj
# Add Nuget Packages
cd GameLibrary.Api
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Scalar.AspNetCore
```

Run the migrations.

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

## Testing the API

Years need to be in DateTime format.

```json
{
    "name": "N64",
    "manufacturer": "Nintendo",
    "releaseDate": "1995-01-01T00:00:00"
}
```
