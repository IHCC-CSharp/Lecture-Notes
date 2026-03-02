---
marp: true
theme: gaia
class: invert
paginate: true
backgroundColor: #1e1e1e
---

# Classes vs Records

By: Luke Matheis

---

## From Classes to Records

Classes are built for objects that change state over time.
Records are built for objects that represent data values.
Data not a behavior.

---

## Class Boilerplate

You must define private fields, a constructor, and getter properties.
Still better then Java though.

```csharp
public class BookLoan
{
    public int Id { get; }
    public string Title { get; }
    public BookLoan(int id, string title)
    {
        Id = id;
        Title = title;
    }
}

```

---

## Record no Boilerplate

A record achieves the same result in a single line.
It automatically handles the constructor and property assignments.

```csharp
public record BookLoan(int Id, string Title, DateTime DueDate);

```

Properties are init-only by default, meaning they cannot be changed after the object is created.

---

## Reference vs Value

Classes compare the memory address. Records compare the actual data.

```csharp
var loanA = new BookLoan(1, "The Hobbit", today);
var loanB = new BookLoan(1, "The Hobbit", today);

// Result is false for classes
// Result is true for records
bool areEqual = (loanA == loanB);
```

---

## Immutability and API Safety

Immutability ensures that data cannot be corrupted during the request lifecycle.
If you try to change a record property, the compiler throws an error.

```csharp
var loan = new BookLoan(1, "C# Basics", today);

// This line will fail to compile
loan.Title = "Advanced C#";

```

> If you want to change data, create a new record and replace the old one.

---

## Record Deconstruction

Records allow you to easily extract data back into local variables.
This is called deconstruction and makes business logic cleaner.

```csharp
var currentLoan = new BookLoan(1, "C# in Depth", today);
var (id, title, date) = currentLoan;
```

---

## When to use Record Structs

If the data is very small and short-lived, use a record struct.
These are stored on the stack rather than the heap for better performance.

```csharp
public readonly record struct Fine(decimal Amount, string Currency);

```

---
