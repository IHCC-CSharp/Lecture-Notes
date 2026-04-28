# Intro to TDD

## What is TDD?

<!-- TODO use interface -->

- [Slides](./Slides/slides.html)

## TDD Example

Follow this structure during the lecture.

1. Write a failing test first.
2. Write the smallest code to pass.
3. Refactor safely.

```bash
mkdir TDDDemo
cd TDDDemo
dotnet new console -n TDDDemo.App
dotnet new xunit -n TDDDemo.Tests
dotnet add TDDDemo.Tests/TDDDemo.Tests.csproj reference TDDDemo.App/TDDDemo.App.csproj
dotnet new sln
dotnet sln add TDDDemo.App/TDDDemo.App.csproj
dotnet sln add TDDDemo.Tests/TDDDemo.Tests.csproj
```

To run the text, make sure your in the test project directory and run (not console or solution):

```bash
dotnet test
```
