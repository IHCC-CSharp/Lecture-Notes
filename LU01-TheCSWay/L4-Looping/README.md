# Looping

## Arrays

While we call them "arrays", in this class we will mostly be using "Lists" which are a more flexible version of arrays.

| Arrays                   | Lists                  | ArrayList (old)                         |
| ------------------------ | ---------------------- | --------------------------------------- |
| Fixed size               | Dynamic size           | Dynamic size                            |
| Can be multi-dimensional | Always one-dimensional | Always one-dimensional                  |
| Can be of any type       | Can be of any type     | Can only hold objects (not value types) |
| Faster than lists        | Slower than arrays     | Slower than arrays and lists            |

**Note:** ArrayList is an older, non-generic collection and is not recommended for use in modern C#.
You should use generic `List<T>` instead for type-safe dynamic collections.

## For/While

Very must like in Java, we have the `for` and `while` loops in C#.
The syntax is very similar to Java as well.
For this reason, we will blow through these pretty quickly since you **SHOULD** already be familiar with them.

## Methods basics

Methods in C# are functions defined in classes.
We will talk about `class`es later.
For now just remember everything in C# is inside a class.
Even though we are using Top-level statements, they are still wrapped in a class behind the scenes.

```csharp
public int Add(int a, int b)
{
    return a + b;
}
```

### C# vs Java

- Naming: PascalCase (e.g., `AddNumbers`) vs. camelCase in Java
- Parameters: C# supports `ref`, `out`, `params`, optional, and named parameters
- Async: Built-in `async`/`await`
- Access: C# adds `internal` modifier

- [docs](https://learn.microsoft.com/en-us/dotnet/csharp/programming-guide/classes-and-structs/methods)

## Random Number Generation

You can generate pseudo-random numbers in C# using `Random`.
Why is it called "pseudo-random"?

- [Computers are deterministic](https://www.cloudflare.com/learning/ssl/lava-lamp-encryption/)

```csharp
Random rand = new Random();
// Generates a random integer between 1 and 99 (inclusive of 1, exclusive of 100)
int randomInt = rand.Next(1, 100);
```

## Example 1

- [Playground](Playground/Program.cs)

## LU01 Demo

I like to put these little "Demo"s in my lectures to show how to put together the concepts we've learned in a small program.

- [LU01 Demo](../Demo/Program.cs)
