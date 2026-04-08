# Intro to EF

Our projects are getting bigger and more complex.
So to tame the line count we will start to use Entity Framework (EF) to generate our SQL for us.
EF is an Object-Relational Mapper (ORM).
We still need to follow good database design principles, but we can write C# code and have EF generate the SQL for us.

- [EF Core](https://learn.microsoft.com/en-us/ef/core/)

## EF Example

C# Model
Below is a rough sketch of the C# model we will use later.
Just show students this we will type it out together later.

<!-- TODO make sure this is the same to the actual code -->

```csharp
public class BloggingContext : DbContext
{
    public BloggingContext(DbContextOptions<BloggingContext> options) : base(options)
    {
    }

    public DbSet<Blog> Blogs { get; set; }
    public DbSet<Post> Posts { get; set; }
}

public class Blog
{
    public int BlogId { get; set; }
    public string Url { get; set; }
    public int Rating { get; set; }
    public List<Post> Posts { get; set; }
}

public class Post
{
    public int PostId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }

    public int BlogId { get; set; }
    public Blog Blog { get; set; }
}
```

### How the C# code maps to EF

- `BloggingContext : DbContext` is the EF session and model root.
- `DbSet<Blog>` maps to a `Blogs` table.
- `DbSet<Post>` maps to a `Posts` table.
- `BlogId` and `PostId` are primary keys by convention.
- `Post.BlogId` becomes the foreign key to `Blogs.BlogId`.
- `Blog.Posts` and `Post.Blog` are navigation properties for relationships.

### Inheritance Mapping Strategies in EF Core

EF Core supports all three strategies:

- TPH (Table Per Hierarchy)
- TPT (Table Per Type)
- TPC (Table Per Concrete Class)

If you do nothing, EF Core uses **TPH by default**.

Quick guidance:

- Use TPH first for most apps (fastest and simplest).
- Use TPT when normalized tables per type are more important than query speed.
- Use TPC when you want no shared base table and can accept duplicated columns.

### Diagram of the EF Example

- [Excalidraw Diagram](./diagram.png)
    - [Source](./diagram.excalidraw)
    - [Svg](./diagram.svg)

## EF Example

Now lets build this thing.
This project won't have any controllers or endpoints.
Just want to prove that we can create the database with no raw SQL statements

```bash
# Create the project
mkdir Blogging
cd Blogging
dotnet new webapi -n Blogging.Api --use-controllers
dotnet new sln
dotnet sln add Blogging.Api/Blogging.Api.csproj
# Add packages via NuGet
cd Blogging.Api
dotnet new gitignore
# You might need to install the EF tool first
dotnet tool install --global dotnet-ef
# Project packages
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package Microsoft.EntityFrameworkCore.Sqlite
dotnet add package Microsoft.AspNetCore.OpenApi
dotnet add package Scalar.AspNetCore
# Run the project
dotnet run
```

- Make the models
- Make the DbContext
- Configure the connection string in `appsettings.json`
- Wire up the DbContext in Program.cs

Our first migration.

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

Now run the project, stop it and look at our new `.db` file.
The app does nothing more.

## Next time

Now that we know how to use EF.
Lets make a full fat API with it.
