# Inheritance and Database

Todays example we will be building a larger API with a database using Entity Framework Core.

## Async/Await

Our project today will use async/await to perform database operations asynchronously.

- [Async/Await](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/concepts/async/)

## Create the Example

```bash
# Create the project
mkdir UrbanMobility
cd UrbanMobility
dotnet new webapi -n UrbanMobility.Api --use-controllers
cd UrbanMobility.Api
dotnet new gitignore

# Packages via NuGet
dotnet add package Microsoft.Data.Sqlite
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.AspNetCore.OpenApi
dotnet add package Scalar.AspNetCore

# Add project to a solution
cd ..
dotnet new sln
dotnet sln add UrbanMobility.Api

# Run the project
dotnet run
```

- Create the Models including the Enums and DTOs
- Create the DBContext
- Create the Controller
    - At first only implement CreateElectric()
- Configure the connection string in `appsettings.json`
- Write it up in the Program.cs

### Db migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

After running the program look at the DB.
Notice how we have a complex data scenario but we only have one table.
This is because EF uses Table Per Hierarchy (TPH).
Resulting one wide table.