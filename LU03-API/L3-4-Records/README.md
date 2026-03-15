# Records and OpenAPI

<!-- TODO update project to change files to DTOs -->
<!-- TODO change BookLoan to a class -->

## Part 1: Records

Classes allow us to make custom reference types.
A struct is similar to a class, except that it is a custom **value type** instead.
With a few exceptions, records can do everything that classes can do.
They are designed to be immutable.
You can be very successful in C# without ever using records, but they are a powerful tool to have in your toolbox.

### Slideshow

- [Slides](slideshow/slides.html)

### Example

We will built a simple API much like yesterday, but this time we will use records instead of classes.

```bash
dotnet new webapi -o LibraryFines --use-controllers
cd LibraryFines
dotnet run
```

> Skip the POST method in the controller for Part 1

## Part 2: Open API

### Web UI

Add [Scalar](https://scalar.com/) package.

```bash
dotnet add package Scalar.AspNetCore
```

In `program.cs` add the following.

```csharp
using Scalar.AspNetCore; //add import at the top
app.MapScalarApiReference(); //add this to dev env for scalar UI to work
```

- Go to none UI: http://localhost:5275/openapi/v1.json
- Go to UI: http://localhost:5275/scalar

### What is OpenAPI?

> Hint you can give AI your `json` file and it can build a LOT.

### Add POST method.

We will make a new DTO record for this.
Without DTO API would need calculated feilds.
Below is example JSON blog request.

```json
{
    "id": 5,
    "title": "Book",
    "dueDate": "2025-05-12",
    "returnedDate": "2025-06-12"
}
```

### Building Svelte

We will build a VERY simple Svelte front end.

```bash
npx sv create front-end #don't use TS
cd front-end
npm install
npm run dev
```

Add dependency for [Hey-API](https://heyapi.dev/)

```bash
npm install @hey-api/openapi-ts -D
npm install @hey-api/client-fetch
npx openapi-ts -i http://localhost:5275/openapi/v1.json -o src/lib/api  #change port
```

Show off the `/lib` folder.
Build the file out in: [`/front-end`](LibraryFines/front-end/src/routes/+page.svelte)

### CORS

We need to add the following cors config to `program.cs`.

```csharp
app.UseCors(policy => policy
    .AllowAnyOrigin()
    .AllowAnyMethod()
    .AllowAnyHeader());
```
