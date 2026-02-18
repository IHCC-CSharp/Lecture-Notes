# Decision Making

Today will be our first lecture where we build a full application. It will still
be very simple.

## if/else

Notice "{" go on a new line in C#. This is a style choice that is different from Java.

- [Docs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements)

## Switches

My rule of thumb is that if you have more than 3 cases, you should probably be
using a switch statement instead of an if/else statement.
I **am NOT** a "never nester" but I do like to avoid nesting if/else statements more than 2 levels deep.

- [Docs](https://learn.microsoft.com/en-us/dotnet/csharp/language-reference/statements/selection-statements#the-switch-statement)

## Example 1

Simple example showing off if/else and switch statements.

- [Playground](Playground/Program.cs)

## Rich Console

## Use of NuGet Package

[Rich Console](https://www.nuget.org/packages/CSharpPlayersGuide.RichConsole)

``bash
dotnet add package CSharpPlayersGuide.RichConsole

```


## Example 2

Now using Rich Console lets make a simple Temperature Converter.

- [Temperature Converter](TemperatureConverter/Program.cs)
```
