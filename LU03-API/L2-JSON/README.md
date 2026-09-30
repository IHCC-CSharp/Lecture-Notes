# L2 - JSON

## Create the API

```bash
dotnet new webapi -o PokeAPI --use-controllers
cd PokeAPI
dotnet run
```

## Primary Constructor

Our `Pokemon.cs` uses a primary constructor.
A primary constructor is a new feature in C# 12 that allows you to define the properties of a class directly in the constructor signature.

- [Docs](https://learn.microsoft.com/en-us/dotnet/csharp/whats-new/tutorials/primary-constructors)

## `.http`

- [MS Blog Post](https://devblogs.microsoft.com/ise/api-testing-using-http-files/)
- [JetBrains](https://www.jetbrains.com/help/idea/http-client-in-product-code-editor.html)

## Front End

Next time we will build a complex Svelte front end.
We don't have time to build the front end in class, but wanted to remind students what a vanilla JS front end might look like.

[Complete Front End](./PokeAPI/fontend/index.html)

![Front End Screenshot](./PokeAPI/fontend/screenshot.png)
