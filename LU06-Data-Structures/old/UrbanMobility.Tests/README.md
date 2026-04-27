# Inheritance and Database

### TPH or TPY or TPC


### Async/Await

Our project today will use async/await to perform database operations asynchronously.

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
- Create the Repository
    - At first only implement CreateElectricAsync()
- Create the Controller
    - At first only implement CreateElectric()
- Write it up in the Program.cs
- Test it with Scalar

## Part 2 XUnit

From now on, our labs will require you to write unit tests using the XUnit framework.

```bash
# Create the test project
dotnet new xunit -o UrbanMobility.Tests
# Add reference to the API project or what ever project you are testing
dotnet add UrbanMobility.Tests/UrbanMobility.Tests.csproj reference UrbanMobility.Api/UrbanMobility.Api.csproj
# Add the test project to the solution
dotnet sln add UrbanMobility.Tests/UrbanMobility.Tests.csproj
```

```bash
#need to add Dapper to the test just for this example
dotnet add package Dapper
```


```bash
# Run the tests
cd UrbanMobility.Tests
dotnet test
```
